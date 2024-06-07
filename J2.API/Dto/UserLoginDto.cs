using System.ComponentModel.DataAnnotations;

namespace J2.API.Dto
{
    public class UserLoginDto
    {
        [Required]
        [StringLength(12, ErrorMessage = "PhoneNumber is not correct")]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "Password is limited to {2} to {1} characters", MinimumLength = 6)]
        public string Password { get; set; }
    }
}
