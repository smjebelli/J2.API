﻿namespace J2.API.Models
{
    public class Expense:BaseEntity
    {
        public long Amount { get; set; }
        public DateTime ExpenseDate { get; set; }
        public Guid UserId { get; set; }
        public int ExpenseCategoryId { get; set; }
        public int ExpenseSubcategoryId { get; set; }


    }
}
