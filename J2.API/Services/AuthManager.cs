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
    }
    public class AuthManager : IAuthManager
    {
        private IConfiguration _configuration;
        private UserManager<AppUser> _userManager;
        private AppUser _user;

        public AuthManager(IConfiguration configuration, UserManager<AppUser> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
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

        public async Task<bool> ValidateUser(UserLoginDto user)
        {
            _user = await _userManager.FindByEmailAsync(user.Email);
            return (_user != null && await _userManager.CheckPasswordAsync(_user, user.Password));
        }
    }
}
