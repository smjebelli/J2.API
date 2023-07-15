using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace J2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        //[Authorize]
        [HttpGet]
        [Route("Test1")]
        public async Task<IActionResult> Test()
        {
            return Ok(new { id = 1 });
        }

        [Authorize(Roles ="admin")]
        [HttpGet]
        [Route("Test2")]
        public async Task<IActionResult> Test2()
        {
            return Ok(new { id = 2 });
        }
    }
}
