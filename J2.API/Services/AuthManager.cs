using J2.API.Dto;
using J2.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace J2.API.Services
{
    public interface IAuthManager
    {
        Task<string> CreateToken();
        Task<bool> ValidateUser(UserLoginDto user);
        Task<bool> ValidateRole(string role);
        Task<IdentityResult> RegisterUser(UserRegisterDto user);
        Task<IdentityResult> AddUserToRole(string userName, string roleName);
        Task<bool> UserExists(string userName);
    }
    public class AuthManager : IAuthManager
    {
        private IConfiguration _configuration;
        private UserManager<AppUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private AppUser _user;

        public AuthManager(IConfiguration configuration, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _configuration = configuration;
            _userManager = userManager;
            _roleManager = roleManager;
        }


        public async Task<string> CreateToken()
        {
            var key = Environment.GetEnvironmentVariable("JKey");
            if (key == null)
                return "";

            var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

            var singingCredentials = new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>() { new Claim(ClaimTypes.Name, _user.UserName) };

            var roles = await _userManager.GetRolesAsync(_user);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var jwtSettings = _configuration.GetSection("Jwt");

            var token = new JwtSecurityToken(
                issuer: jwtSettings.GetSection("Issuer").Value,
                claims: claims,
                expires: DateTime.Now.AddMinutes(double.Parse(jwtSettings.GetSection("ValidationDurtationMinutes").Value)),
                signingCredentials: singingCredentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }

        public async Task<IdentityResult> RegisterUser(UserRegisterDto user)
        {
            AppUser appUser = new AppUser()
            {
                UserName = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,

            };
            return await _userManager.CreateAsync(appUser, user.Password);

        }

        public async Task<bool> ValidateRole(string role)
        {
            return await _roleManager.RoleExistsAsync(role);
        }

        public async Task<bool> ValidateUser(UserLoginDto user)
        {
            _user = await _userManager.FindByEmailAsync(user.Email);
            return (_user != null && await _userManager.CheckPasswordAsync(_user, user.Password));
        }
        
        public async Task<bool> UserExists(string userName)
        {
            var user = await _userManager.FindByEmailAsync(userName);
            return user != null;
        }

        public async Task<IdentityResult> AddUserToRole(string userName, string roleName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (!await _roleManager.RoleExistsAsync(roleName))
                throw new Exception("نقش مورد نظر یافت نشد");

            return await _userManager.AddToRoleAsync(user, roleName);
        }
    }
}
