using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace J2.API.Models
{
    public class FamilyMember : BaseEntity
    {
        public Guid AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public string NickName { get; set; }
        public bool IsFamilyAdmin { get; set; }
        public Guid FamilyId { get; set; }
        public Family Family{ get; set; }
    }
}
