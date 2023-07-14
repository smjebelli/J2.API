using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using J2.API.Models;

namespace J2.API.Configurations
{
    public class SampleData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<AppDbContext>();

            string[] roles = new string[] { "Admin", "Manager", "User" };

            foreach (string role in roles)
            {
                var roleStore = new RoleStore<IdentityRole>(context);

                if (!context.Roles.Any(r => r.Name == role))
                {
                    roleStore.CreateAsync(new IdentityRole(role));
                }
            }


            var user = new AppUser
            {
                Email = "s.m.jebelli@gmail.com",
                UserName = "s.m.jebelli@gmail.com",
                FirstName = "محمد",
                LastName = "جبلی",
                PhoneNumber = "09355270270",
                NormalizedEmail = "S.M.JEBELLI@GMAIL.COM",
                NormalizedUserName = "S.M.JEBELLI@GMAIL.COM",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };


            if (!context.Users.Any(u => u.UserName == user.UserName))
            {
                var password = new PasswordHasher<AppUser>();
                var hashed = password.HashPassword(user, "secret");
                user.PasswordHash = hashed;

                var userStore = new UserStore<AppUser>(context);
                var result = userStore.CreateAsync(user);

            }

            AssignRoles(serviceProvider, user.Email, roles);

            context.SaveChangesAsync();
        }

        public static async Task<IdentityResult> AssignRoles(IServiceProvider services, string email, string[] roles)
        {
            UserManager<AppUser> _userManager = services.GetService<UserManager<AppUser>>();
            AppUser user = await _userManager.FindByEmailAsync(email);
            var result = await _userManager.AddToRolesAsync(user, roles);

            return result;
        }

    }
}
