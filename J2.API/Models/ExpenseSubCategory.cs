namespace J2.API.Models
{
    
    public class ExpenseSubCategory:BaseAutditable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ExpenseCategoryId { get; set; }
    }
}
