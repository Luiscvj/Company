using System.Text;
using API.Helpers;
using API.Services;
using Application.UnitOfWork;
using AspNetCoreRateLimit;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.IdentityModel.Tokens;

namespace API.ApplicationServices;


public static class ApplicationServicesExtension
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork,UnitOfWork>();
        services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
        services.AddScoped<IUserService, UserService>();

       
    }

    public static void ConfigureCors(this IServiceCollection services)=>
    services.AddCors(options =>
    {
        options.AddPolicy
        (
            "CorsPolicy", builder =>
            
                builder.AllowAnyMethod()
                       .AllowAnyOrigin()
                       .AllowAnyHeader()
            
        );
    });


     public static void ConfigureRateLimiting(this IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
            services.AddInMemoryRateLimiting();
            services.Configure<IpRateLimitOptions>(opt => 
            {
                opt.EnableEndpointRateLimiting = true;
                opt.StackBlockedRequests = false;
                opt.HttpStatusCode = 429;
                opt.RealIpHeader = "X-Real-IP";
                opt.GeneralRules = new List<RateLimitRule>
                {
                    new() 
                    {
                        Endpoint = "*",
                        Period = "20s",
                        Limit = 1000
                    }
                };
            });
        }

         public static void ConfigureApiVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(opt =>
            {
                opt.DefaultApiVersion = new ApiVersion(1,0);
                opt.AssumeDefaultVersionWhenUnspecified = true;
                opt.ApiVersionReader = ApiVersionReader.Combine
                (
                    new QueryStringApiVersionReader("version"),
                    new HeaderApiVersionReader("X-Version")
                );
            });
        }


        public static void AddJwt(this IServiceCollection services, IConfiguration configuration)
        {

             services.Configure<JWT>(configuration.GetSection("JWT"));

            //Adding Athentication - JWT
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(o =>
                {
                    o.RequireHttpsMetadata = false;
                    o.SaveToken = false;
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero,
                        ValidIssuer = configuration["JWT:Issuer"],
                        ValidAudience = configuration["JWT:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]))
                    };
                });
    }
    
    }

