namespace J2.API.Models
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string MobileNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<Expense> Expenses { get; set; }
        public Guid FamilyId { get; set; }

    }
}
