using System.Numerics;

namespace J2.API.Models
{
    public class FamilyMember : BaseEntity
    {
        public string Name { get; set; }
        public Guid FamilyId { get; set; }
    }
}
