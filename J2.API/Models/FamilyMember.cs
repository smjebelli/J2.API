using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace J2.API.Models
{
    public class FamilyMember : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        [ForeignKey("Family")]
        public Guid FamilyId { get; set; }
        public virtual Family Family{ get; set; }
    }
}
