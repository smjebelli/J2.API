namespace J2.API.Models
{
    public class User:BaseEntity
    {
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string? Address { get; set; }
        public string MembershipNumber { get; set; }
    }
}
