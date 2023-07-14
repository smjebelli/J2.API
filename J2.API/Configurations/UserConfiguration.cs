using J2.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace J2.API.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            AppUser appUser = new AppUser
            {
                Id = "75b5fe28-7aac-4b20-b430-1d1a045b5afa",
                Email = "s.m.jebelli@gmail.com",
                UserName = "s.m.jebelli@gmail.com",
                FirstName = "محمد",
                LastName = "جبلی",
                PhoneNumber = "09355270270",
                NormalizedEmail = "S.M.JEBELLI@GMAIL.COM",
                NormalizedUserName = "S.M.JEBELLI@GMAIL.COM",
                //CreatedBy = "system",
                //CreatedOn = DateTime.Now,
            };
            

            //set user password
            PasswordHasher<AppUser> ph = new PasswordHasher<AppUser>();
            appUser.PasswordHash = ph.HashPassword(appUser, "P@ssw0rd");
            
            //seed user
            builder.HasData(appUser);
            
            //set user role to admin
            //builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            //{
            //    RoleId = ROLE_ID,
            //    UserId = ADMIN_ID
            //});
        }
    }
}
