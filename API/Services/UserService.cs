using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using API.Dtos;
using API.Helpers;
using Application.UnitOfWork;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Persistence.Data;

namespace API.Services;

public class UserService : IUserService
{
    private readonly JWT _jwt;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordHasher<User> _passwordHasher;

   

    public UserService(IUnitOfWork unitOfWork,IOptions<JWT> jwt,IPasswordHasher<User> passwordHasher)
    {
       _jwt = jwt.Value;
       _unitOfWork = unitOfWork;
       _passwordHasher = passwordHasher;
    }
    public async  Task<string> RegisterAsync(RegisterDto model)
    {

        try
        {

        

            var usuarioExiste =     _unitOfWork.Users
                                                .Find(u => u.Username.ToLower() == model.Username.ToLower())
                                                .FirstOrDefault();

            if(usuarioExiste == null)
            {

                User user = new User
                {
                    Username = model.Username,
                    Email = model.Email
                };

                user.Password = _passwordHasher.HashPassword(user, model.Password);


                 var rolPredeterminado =  _unitOfWork.Roles
                                                     .Find(u => u.RoleName == Autorization.rol_predeterminado.ToString())
                                                     .FirstOrDefault();
                try
                {
                    user.Roles.Add(rolPredeterminado);
                    _unitOfWork.Users.Add(user);
                    await _unitOfWork.SaveAsync();

                    return $"El Usuario {model.Username} ha sido registrado exitosamente";
                }

                catch (Exception ex)
                {
                    var message = ex.Message;
                    return $"Error: {message}";
                }



            }else
            {
                 return $"El usuario con {model.Username} ya se encuentra resgistrado.";
            }

        }catch(Exception ex)
        {
            return ex.Message;
        }



    }
    public async Task<string> AddRoleAsync(AddRoleDto model)
    {
        var usuario = await _unitOfWork.Users
                                .GetByUserName(model.Username);
             if (usuario == null) return $"No existe algun usuario registrado con la cuenta olvido algun caracter?{model.Username}.";

        var resultado = _passwordHasher.VerifyHashedPassword(usuario, usuario.Password, model.Password);

        if (resultado == PasswordVerificationResult.Success)
            {
                var rolExiste = _unitOfWork.Roles
                                                .Find(u => u.RoleName.ToLower() == model.Role.ToLower())
                                                .FirstOrDefault();
                if(rolExiste != null)
                {
                    var usuarioTieneRol = usuario.Roles
                                                    .Any(u => u.RoleId == rolExiste.RoleId);

                    if (usuarioTieneRol == false)
                    {
                        usuario.Roles.Add(rolExiste);
                        _unitOfWork.Users.Update(usuario);
                        await _unitOfWork.SaveAsync();
                    }       
                    return $"Rol {model.Role} agregado a la cuenta {model.Username} de forma exitosa.";                      
                }
                 return $"Rol {model.Role} no encontrado.";

            }
            return $"Credenciales incorrectas para el ususario {usuario.Username}.";                 
    }




    public async Task<DataUserDto> GetTokenAsync(LoginDto model)
    {
          DataUserDto datosUsuarioDto = new DataUserDto();

          var usuario = await _unitOfWork.Users
                            .GetByUserName(model.Username);

          if (usuario == null)
            {
                datosUsuarioDto.EstaAutenticado = false;
                datosUsuarioDto.Mensaje = $"No existe ningun usuario con el username {model.Username}.";
                return datosUsuarioDto;
            }
         
         var result = _passwordHasher.VerifyHashedPassword(usuario, usuario.Password, model.Password);


          if (result == PasswordVerificationResult.Success)
            {
                
               
                    datosUsuarioDto.EstaAutenticado = true;
                    JwtSecurityToken jwtSecurityToken = CreateJwtToken(usuario);
                    datosUsuarioDto.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
                    datosUsuarioDto.Email = usuario.Email;
                    datosUsuarioDto.UserName = usuario.Username;
                    datosUsuarioDto.Roles =  usuario.Roles
                                                    .Select(x => x.RoleName).ToList();
                                                    

            }

            return datosUsuarioDto;
            
    }


      private JwtSecurityToken CreateJwtToken(User usuario)
    {
        var roles = usuario.Roles;
        var roleClaims = new List<Claim>();
        foreach (var role in roles)
        {
            roleClaims.Add(new Claim("roles", role.RoleName));
        }
        var claims = new[]
        {
                                new Claim(JwtRegisteredClaimNames.Sub, usuario.Username),
                                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                                new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
                                new Claim("uid", usuario.UserId.ToString())
                        }
        .Union(roleClaims);
        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
        var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
        var jwtSecurityToken = new JwtSecurityToken(
            issuer: _jwt.Issuer,
            audience: _jwt.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_jwt.DurationInMinutes),
            signingCredentials: signingCredentials);
        return jwtSecurityToken;
    }



    public async Task<string> ValidarUsuario(string Token)
    {
        try
        {
            var token = new JwtSecurityTokenHandler().ReadJwtToken(Token);

            string idUser = token.Claims.FirstOrDefault(claim => claim.Type == "Id")?.Value;
            string username = token.Claims.FirstOrDefault(claim => claim.Type == "Username")?.Value;
            string password = token.Claims.FirstOrDefault(claim => claim.Type == "password")?.Value;

           User usuario= await   _unitOfWork.Users.GetByUserName(username);

           if( usuario != null)
           {
                var result = _passwordHasher.VerifyHashedPassword(usuario, usuario.Password, password);

                if(result == PasswordVerificationResult.Success)
                {
                    return $"El usuario {username} se encuentra registrado";
                }
                return "1";

           }
           return null;

        }catch(Exception ex)
        {
            return  ex.Message;
        }
          


    }
}