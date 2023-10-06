namespace J2.API.Models
{
    public class Family : BaseEntity
    {
        public string CreatedBy { get; set; }
        public string FamilyName { get; set; }
        public List<FamilyMember> Members { get; set; }
    }
}
