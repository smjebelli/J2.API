namespace J2.API.Models
{
    public class FamilyMember : BaseEntity
    {
        public List<Expense> Expenses { get; set; }
        public Guid FamilyId { get; set; }

    }
}
