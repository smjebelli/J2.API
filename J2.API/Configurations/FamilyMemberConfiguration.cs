using J2.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace J2.API.Configurations
{
    public class FamilyMemberConfiguration : IEntityTypeConfiguration<FamilyMember>
    {
        public void Configure(EntityTypeBuilder<FamilyMember> builder)
        {
            
        }
    }
}
