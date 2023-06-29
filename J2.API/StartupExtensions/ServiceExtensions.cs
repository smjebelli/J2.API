using Infrastructure.Context;
using J2.API.Models;
using Microsoft.AspNetCore.Identity;

namespace J2.API.StartupExtensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentityCore<BaseUser>(x=>x.Password.RequiredLength=8);
            builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole), services);
            builder.AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

        }
    }
}
