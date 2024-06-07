using J2.API.Dto;
using J2.API.Models;
using J2.API.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace J2.API.Services
{
    public interface IAuthService
    {
        Task<string> CreateToken();
        Task<bool> ValidateUser(UserLoginDto user);
        Task<bool> ValidateRole(string role);
        Task<IdentityResult> RegisterUser(UserRegisterDto user);
        Task<IdentityResult> AddUserToRoles(string userName, List<string> roles);
        Task<bool> UserExists(string userName);
        Task<TokenRequest> VerifyRefreshToken(TokenRequest request);
        Task<string> CreateRefreshToken();
    }
    public class AuthService : IAuthService
    {
        private IConfiguration _configuration;
        private UserManager<AppUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private AppUser _user;
        private Jwt _jwt;

        public AuthService(IConfiguration configuration, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager,IOptions<Appsettings> appSettings)
        {
            _configuration = configuration;
            _userManager = userManager;
            _roleManager = roleManager;
            _jwt= appSettings.Value.Jwt;
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

            

            var token = new JwtSecurityToken(
                issuer:_jwt.Issuer ,
                claims: claims,
                expires: DateTime.Now.AddMinutes(_jwt.ValidationDurtationMinutes),
                signingCredentials: singingCredentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }

        public async Task<IdentityResult> RegisterUser(UserRegisterDto user)
        {
            AppUser appUser = new AppUser()
            {
                UserName = user.PhoneNumber,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,

            };
            var createResult = await _userManager.CreateAsync(appUser, user.Password);
            if (!createResult.Succeeded)
            {
                throw new Exception($"Problem in creating user {appUser.UserName}");
            }
            return await _userManager.AddToRolesAsync(appUser, new List<string> { "user"});

        }

        public async Task<bool> ValidateRole(string role)
        {
            return await _roleManager.RoleExistsAsync(role);
        }

        public async Task<bool> ValidateUser(UserLoginDto user)
        {
            _user = await _userManager.FindByNameAsync(user.PhoneNumber);
            return (_user != null && await _userManager.CheckPasswordAsync(_user, user.Password));
        }

        public async Task<bool> UserExists(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            return user != null;
        }

        public async Task<IdentityResult> AddUserToRoles(string userName, List<string> roles)
        {
            var user = await _userManager.FindByNameAsync(userName);

            return await _userManager.AddToRolesAsync(user, roles);

        }

        public async Task<string> CreateRefreshToken()
        {
            
            await _userManager.RemoveAuthenticationTokenAsync(_user, _jwt.ClientId, "RefreshToken");
            var newRefreshToken = await _userManager.GenerateUserTokenAsync(_user, _jwt.ClientId, "RefreshToken");
            var result = await _userManager.SetAuthenticationTokenAsync(_user, _jwt.ClientId, "RefreshToken", newRefreshToken);
            return newRefreshToken;
        }

        public async Task<TokenRequest> VerifyRefreshToken(TokenRequest request)
        {
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var tokenContent = jwtSecurityTokenHandler.ReadJwtToken(request.Token);
            var username = tokenContent.Claims.ToList().FirstOrDefault(q => q.Type == ClaimTypes.Name)?.Value;
            _user = await _userManager.FindByNameAsync(username);
            try
            {
                var isValid = await _userManager.VerifyUserTokenAsync(_user, _jwt.ClientId, "RefreshToken", request.RefreshToken);
                if (isValid)
                {
                    return new TokenRequest { Token = await CreateToken(), RefreshToken = await CreateRefreshToken() };
                }
                await _userManager.UpdateSecurityStampAsync(_user);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return null;
        }
    }
}
