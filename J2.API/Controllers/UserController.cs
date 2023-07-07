using J2.API.Dto;
using J2.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace J2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public readonly ILogger<UserController> _logger;

        public UserController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ILogger<UserController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] UserDto user)
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
                {
                    return Ok(res);
                }
                else
                {
                    return BadRequest(res.Errors.Select(x => x.Description).ToList());
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "خطایی رخ داده است");
            }
           
        }

    }
}
