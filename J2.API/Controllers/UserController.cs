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
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IAuthService _authSerivce;

        public readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger, IAuthService authService)
        {
            _logger = logger;
            _authSerivce = authService;
        }
        /// <summary>
        /// ثبت نام کاربر جدید
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]        
        public async Task<IActionResult> Register([FromBody] UserRegisterDto user)
        {
            _logger.LogInformation($"در حال ساخت کاربر جدید: {user.Email}");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var res = await _authSerivce.RegisterUser(user);
                if (res.Succeeded)
                {
                    return Ok(res);
                }
                else
                    return BadRequest(res.Errors.Select(x => x.Description).ToList());

            }
            catch (Exception ex)
            {
                return StatusCode(500, "خطایی رخ داده است");
            }
        }
        /// <summary>
        /// لاگین و دریافت توکن
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserLoginDto login)
        {
            _logger.LogInformation($"در حال لاگین کاربر: {login.PhoneNumber}");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!await _authSerivce.ValidateUser(login))
                return Unauthorized();
            else
            {
                return Accepted(new { token = await _authSerivce.CreateToken(), RefreshToken = await _authSerivce.CreateRefreshToken() });
            }


        }
        /// <summary>
        /// درخواست رفرش توکن
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> RefreshToken([FromBody] TokenRequest request)
        {
            var tokenRequest = await _authSerivce.VerifyRefreshToken(request);
            if (tokenRequest is null)
            {
                return Unauthorized();
            }

            return Ok(tokenRequest);
        }
        /// <summary>
        /// افزودن یک کاربر به یک نقش
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Authorize(Roles ="admin")]
        [HttpPost]
        public async Task<IActionResult> AddUserToRole([FromBody] AddUserToRoleDto data)
        {
            _logger.LogInformation($"افزودن کاربر {data.UserName} به نقشهای {data.RoleNames}");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!await _authSerivce.UserExists(data.UserName)) 
                return BadRequest(new { message = "کاربر مورد نظر یافت نشد" });

           
            var res = await _authSerivce.AddUserToRoles(data.UserName, data.RoleNames);
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
