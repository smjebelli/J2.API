using J2.API.Dto;
using J2.API.Models;
using J2.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace J2.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ExpenseCategoryController : ControllerBase
    {
        private readonly IExpenseCategoryService _expenseCategoryService;
        private readonly ILogger<ExpenseCategoryController> _logger;
       

        public ExpenseCategoryController(
            IExpenseCategoryService expenseCategoryService,
            ILogger<ExpenseCategoryController> logger
            )
        {
            _expenseCategoryService = expenseCategoryService;
            _logger = logger;
            
        }
        /// <summary>
        /// دریافت کلیه طبقه بندی های هزینه ها
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll(bool subCategoriesIncluded = false)
        {

            _logger.LogInformation($"Getting all categories");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var res = await _expenseCategoryService.GetAllCategories(subCategoriesIncluded);

                return Ok(res);


            }
            catch (Exception ex)
            {
                return StatusCode(500, "خطایی رخ داده است");
            }

        }
        /// <summary>
        /// افزودن طبقه بندی جدید هزینه
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(AddExpenseCategoryDto obj)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var data = new ExpenseCategory() { Name = obj.Name, Description = obj.Description };
                var res = _expenseCategoryService.AddCategory(data);
                if (res > 0)
                    return Ok(res);
                else
                    return StatusCode(500, "خطایی رخ داده است");

            }
            catch (Exception ex)
            {
                return StatusCode(500, "خطایی رخ داده است");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateExpenseCategoryDto obj)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var data = new ExpenseCategory()
                {
                    Name = obj.Name,
                    Description = obj.Description,
                    Id = obj.Id
                };
                var res = _expenseCategoryService.UpdateCategory(data);
                if (res > 0)
                    return Ok(res);
                else
                    return StatusCode(500, "خطایی رخ داده است");

            }
            catch (Exception ex)
            {
                return StatusCode(500, "خطایی رخ داده است");
            }
        }
    }
}
