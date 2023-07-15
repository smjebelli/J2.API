using J2.API.Dto;
using J2.API.Models;
using J2.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace J2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IAuthManager _authManager;

        public readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger, IAuthManager authManager)
        {
            _logger = logger;
            _authManager = authManager;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto user)
        {
            _logger.LogInformation($"در حال ساخت کاربر جدید: {user.Email}");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var res = await _authManager.RegisterUser(user);
                if (res.Succeeded)
                    return Ok(res);

                else
                    return BadRequest(res.Errors.Select(x => x.Description).ToList());

            }
            catch (Exception ex)
            {
                return StatusCode(500, "خطایی رخ داده است");
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto login)
        {
            _logger.LogInformation($"در حال لاگین کاربر: {login.Email}");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!await _authManager.ValidateUser(login))
                return Unauthorized();
            else
            {
                return Accepted(new { token = await _authManager.CreateToken() });
            }


        }

        //[Authorize]
        [HttpPost]
        [Route("AddUserToRole")]
        public async Task<IActionResult> AddUserToRole(AddUserToRoleDto data)
        {
            _logger.LogInformation($"افزودن کاربر {data.UserName} به نقش {data.RoleName}");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!await _authManager.UserExists(data.UserName)) 
                return BadRequest(new { message = "کابر مورد نظر یافت نشد" });

            if (!await _authManager.ValidateRole(data.RoleName))
                return BadRequest(new { message = "نقش مورد نظر یافت نشد" });



            var res = await _authManager.AddUserToRole(data.UserName, data.RoleName);
            if (res.Succeeded)
            {
                return Ok();
            }
            else
            {
                return Problem("خطایی رخ داده است", statusCode: 500);
            }
        }

    }
}
