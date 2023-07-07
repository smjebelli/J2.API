using Microsoft.AspNetCore.Identity;

namespace J2.API.Models
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
