using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace J2.API.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            var a = builder.HasData(
            new IdentityRole()
            {
                Id = "a537935f-01b5-4f9a-9c80-ccfe728402a8",
                Name = "admin",
                NormalizedName = "ADMIN"
            },

            new IdentityRole()
            {
                Id = "4635a3c1-79e6-471a-8f5e-cb75865eece8",
                Name = "user",
                NormalizedName = "USER"
            });

        }
    }
}
