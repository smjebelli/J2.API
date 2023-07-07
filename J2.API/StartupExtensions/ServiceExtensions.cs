using J2.API.Models;
using Microsoft.AspNetCore.Identity;
using NuGet.Protocol;

namespace J2.API.StartupExtensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentityCore<AppUser>(x => x.Password.RequiredLength = 8);
            builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole), services);
            builder.AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

            services.AddIdentity<AppUser, IdentityRole>();
           
        }


    }
}
