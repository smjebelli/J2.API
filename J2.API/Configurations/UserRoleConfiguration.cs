using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace J2.API.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(new IdentityUserRole<string>
            {
                RoleId = "a537935f-01b5-4f9a-9c80-ccfe728402a8",
                UserId = "75b5fe28-7aac-4b20-b430-1d1a045b5afa"
            });
        }
    }
}
