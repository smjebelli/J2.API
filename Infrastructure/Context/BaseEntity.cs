using Infrastructure.Context;
using System.ComponentModel.DataAnnotations;

namespace J2.API.Models
{
    [Auditable]
    public class BaseAutditable
    {
    }
    public class BaseEntity : BaseAutditable, IBaseEntity
    {
        public Guid Id { get; set; }
    }

}
