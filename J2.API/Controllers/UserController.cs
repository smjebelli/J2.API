using J2.API.Dto;
using J2.API.Models;
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
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public readonly ILogger<UserController> _logger;

        public UserController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ILogger<UserController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
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
                AppUser u = new AppUser()
                {
                    UserName = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,        
                    
                };
                var res= await _userManager.CreateAsync(u,user.Password);
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

          // var res = await _signInManager.PasswordSignInAsync(new AppUser() { Email = login.Email }, login.Password, true, false);

            var _user = await _userManager.FindByNameAsync(login.Email);
            var validPassword = await _userManager.CheckPasswordAsync(_user, login.Password);
            if (_user != null && validPassword)
                return Accepted();

            else
                return Unauthorized();

        }

        //[HttpPost]
        //[Route("AddUserToRole")]
        //public async Task<IActionResult> AddUserToRole(AddUserToRoleDto data)
        //{
        //    _logger.LogInformation($"افزودن کاربر {data.UserName} به نقش {data.RoleName}");
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var user = await _userManager.FindByNameAsync(data.UserName);
        //    if (user == null)
        //    {
        //        return BadRequest();
        //    }
        //    var role = await _roleManager.FindByNameAsync(data.RoleName);
        //    if (role == null)
        //    {
        //        return BadRequest();
        //    }

        //    var res= await _userManager.AddToRoleAsync(user, data.RoleName);
        //    if (res.Succeeded)
        //    {
        //        return Ok();
        //    }
        //    else
        //    {
        //        return Problem("خطایی رخ داده است", statusCode: 500);
        //    }
        //}

    }
}
