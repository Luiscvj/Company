using API.Dtos;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace API.Controllers;


public class UserController :BaseApiController
{
    public UserController(IUserService userService) : base(userService)
    {

    }


    [HttpPost("Register")]
   

    public async Task<IActionResult> UserAdd(RegisterDto registerDto)
    {
        try
        {
            var result = _userService.RegisterAsync(registerDto);
            return Ok(result);

        }catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("GetToken")]
    [OutputCache(NoStore =true, Duration =60)]

    public async Task<IActionResult> GetTokenAsync(LoginDto model)
    {
        var result = _userService.GetTokenAsync(model);
        return Ok(result);
    }

    [HttpPost("AddRol")]

    public async Task<ActionResult> AddRoleAsync(AddRoleDto model)
    {
        var result = _userService.AddRoleAsync(model);
        return  Ok(result);
    }

   [HttpPost("ValidateUser")]
   [ProducesResponseType(StatusCodes.Status200OK)]
   [ProducesResponseType(StatusCodes.Status400BadRequest)]
   [ProducesResponseType(StatusCodes.Status404NotFound)]

   public async Task<ActionResult> ValidateUser(string Token)
   {
     var result = await  _userService.ValidarUsuario(Token);
     if(result == null) 
    {
        return NotFound("Usuario no encontrado");
    }else if (result == "1")
    {
        return BadRequest("Por favor verifique los datos suministrados");
    }

     return Ok(result);
   }
    
}