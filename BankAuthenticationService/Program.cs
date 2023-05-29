using System.Reflection;
using System.Text;
using BankAuthenticationService.Bll;
using BankAuthenticationService.Bll.Repository;
using BankAuthenticationService.Dal;
using BankAuthenticationService.Dal.Repository;
using BankAuthenticationService.Model;
using Identity.WebApi.Services;
using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BankAuthenticationService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var builder = WebApplication.CreateBuilder(args);
                builder.Services.AddControllers();
                builder.Services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                }).AddJwtBearer(cfg =>
                {
                    cfg.RequireHttpsMetadata = false;
                    cfg.SaveToken = true;
                    cfg.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                    {
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetValue<string>("JWT:Secret"))),
                        ValidateAudience = true,
                        ValidateIssuer = true,
                        ValidAudience = builder.Configuration.GetValue<string>("JWT:ValidAudience"),
                        ValidIssuer = builder.Configuration.GetValue<string>("JWT:ValidIssuer"),
                        RequireExpirationTime = true,
                        ValidateIssuerSigningKey = true,
                    };
                });
                builder.Services.AddTransient<IUserService, UserService>();
                builder.Services.AddTransient<IUserDetailsBll, UserDetailsBll>();
                builder.Services.AddTransient<IUserDetailsDal, UserDetailsDal>();
                var appSettingSection = builder.Configuration.GetSection("JWT");
                builder.Services.Configure<AppSettings>(appSettingSection);
                builder.Services.AddSwaggerGen(options =>
                {
                    var securityScheme = new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                    {
                        Description = "Authorization Header",
                        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                        Name = "Authorization",
                        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
                        Scheme = "bearer",
                        BearerFormat = "JWT",
                        Reference = new Microsoft.OpenApi.Models.OpenApiReference() { Id = JwtBearerDefaults.AuthenticationScheme, Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme }

                    };
                    options.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
                    options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
                    {
                        {securityScheme, new string[] {} }
                    });
                });

                var app = builder.Build();
                app.UseAuthentication();
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseRouting();
                app.UseAuthorization();
                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
                app.Run();
            }
            catch (Exception ex)
            {
                //Log.Fatal(ex, $"Error in {typeof(Program).Namespace}");
            }
            finally
            {
                //Log.CloseAndFlush();
            }
        }
    }
}