using J2.API.Common;
using J2.API.Dto;
using J2.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace J2.API.Services
{
    public interface IExpenseCategoryService
    {
        Task<List<ExpenseCategory>> GetAllCategories(bool subCategoriesIncluded);
        int AddCategory(ExpenseCategory data);
        int UpdateCategory(ExpenseCategory data);

    }
    public class ExpenseCategorySerivce : IExpenseCategoryService
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<ExpenseCategorySerivce> _logger;
        private IMemoryCache _cache;
        

        public ExpenseCategorySerivce(
            AppDbContext context, 
            ILogger<ExpenseCategorySerivce> logger,
            IMemoryCache cache)
        {
            _dbContext = context;
            _logger = logger;
            _cache = cache ?? throw new ArgumentNullException(nameof(cache));
        }

        public int AddCategory(ExpenseCategory data)
        {
            _dbContext.ExpenseCategories.Add(data);
            return _dbContext.SaveChanges();
        }

        public async Task<List<ExpenseCategory>> GetAllCategories(bool subCategoriesIncluded = false)
        {
            if (!_cache.TryGetValue(CacheKeys.ExpenseCategoriesCacheKey, out List<ExpenseCategory> categories))
            {
                categories = subCategoriesIncluded ? await _dbContext.ExpenseCategories.Include(x => x.ExpenseSubCategories).ToListAsync() :
                 await _dbContext.ExpenseCategories.ToListAsync();

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(120))
                    .SetAbsoluteExpiration(TimeSpan.FromHours(24))
                    .SetPriority(CacheItemPriority.Normal)
                    .SetSize(1024);
                _cache.Set(CacheKeys.ExpenseCategoriesCacheKey, categories, cacheEntryOptions);

            }
            else
            {
                _logger.Log(LogLevel.Information, "Expense Category list found in cache.");
            }
            return categories;

        }

        public int UpdateCategory(ExpenseCategory data)
        {
            var ec = _dbContext.ExpenseCategories.AsNoTracking().FirstOrDefault(x => x.Id == data.Id);
            if (ec == null)
                return 0;

            ec.Name= data.Name;
            ec.Description= data.Description;

            _dbContext.Update(ec);
            //_context.UpdateEntity(ec);
            //var updateRes = _context.Update(ec);
            //if (updateRes.State == EntityState.Modified) {
            //}
            return _dbContext.SaveChanges();
        }
    }
}
