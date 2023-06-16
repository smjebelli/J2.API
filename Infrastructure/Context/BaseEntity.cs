using Infrastructure.Context;
using System.ComponentModel.DataAnnotations;

namespace J2.API.Models
{
    [Auditable]
    public class BaseAutditable
    {
    }
    public class BaseEntity : BaseAutditable 
    { 
        public Guid Id { get; set; } 
    }

}
