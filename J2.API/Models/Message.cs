using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace J2.API.Models
{
    public class Message:BaseEntity
    {
        public Guid FamilyMemberId { get; set; }
        public string Content { get; set; }
    }
}
