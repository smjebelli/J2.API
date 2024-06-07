using NuGet.Protocol.Core.Types;
using System.ComponentModel.DataAnnotations;

namespace J2.API.Dto
{
    public class UserRegisterDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [StringLength(30,ErrorMessage ="فرمت رمز عبور صحیح نیست",MinimumLength =8)]
        public string Password { get; set; }
        //public List<string> Roles { get; set; }
    }
}
