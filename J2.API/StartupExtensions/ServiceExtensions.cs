using J2.API.Models;
using J2.API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using NuGet.Protocol;
using System.Net;
using System.Text;

namespace J2.API.StartupExtensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentity<AppUser, IdentityRole>(o =>
            o.Password = new PasswordOptions() { RequiredLength = 8 })
                .AddEntityFrameworkStores<AppDbContext>()
                //.AddRoles<IdentityRole>()
                //.AddRoleManager<IdentityRole>()
                .AddTokenProvider("JeyApi9876", typeof(EmailTokenProvider<AppUser>));


            //var builder = services.AddIdentityCore<AppUser>(x => x.Password.RequiredLength = 8);
            //builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole), services);
            //builder
            //    .AddEntityFrameworkStores<AppDbContext>()
            //    .AddRoles<IdentityRole>()
            //    .AddDefaultTokenProviders();

            //services.AddIdentity<AppUser, IdentityRole>();

        }

        public static void ConfigureJwt(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection("Jwt");
            //command on windows to create key:  setx JKey 3a367dd9-0f04-4365-bd46-13a29b278220 

            var key = Environment.GetEnvironmentVariable("Jkey");

            if (key is null)
            {
                throw new Exception("Secret Key not found");
            }

            services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(o =>
                {
                    o.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtSettings.GetSection("Issuer").Value,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
                    };
                });
            

        }


        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        Serilog.Log.Error($"Something went wrong: {contextFeature.Error}");
                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = "خطایی رخ داده است"
                        }.ToString());
                    }
                });
            });
        }

        public static void ConfigureMainServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IExpenseCategoryService, ExpenseCategorySerivce>();
            services.AddScoped<IFamilyService,FamilyService>();

        }
    }
}
