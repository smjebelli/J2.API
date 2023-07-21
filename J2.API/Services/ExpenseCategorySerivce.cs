using J2.API.Dto;
using J2.API.Models;
using Microsoft.EntityFrameworkCore;

namespace J2.API.Services
{
    public interface IExpenseCategoryService
    {
        Task<List<ExpenseCategory>> GetAllCategories(bool subCategoriesIncluded);
        int AddCategory(ExpenseCategory data);

    }
    public class ExpenseCategorySerivce : IExpenseCategoryService
    {
        private readonly AppDbContext _context;
        private readonly ILogger<ExpenseCategorySerivce> _logger;


        public ExpenseCategorySerivce(AppDbContext context, ILogger<ExpenseCategorySerivce> logger)
        {
            _context = context;
            _logger = logger;
        }

        public int AddCategory(ExpenseCategory data)
        {
            _context.ExpenseCategories.Add(data);
            return _context.SaveChanges();
        }

        public async Task<List<ExpenseCategory>> GetAllCategories(bool subCategoriesIncluded=false)
        {

            var categories =subCategoriesIncluded? await _context.ExpenseCategories.Include(x => x.ExpenseSubCategories).ToListAsync():
                 await _context.ExpenseCategories.ToListAsync();
            return categories;
        }
    }
}
