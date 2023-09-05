using J2.API.Dto;
using J2.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace J2.API.Services
{
    public interface IFamilyService
    {
        Task<bool> CreateFamily(string userName, string familyName);
        Task AddUserToFamily(string userName);
        Task RemoveUserFromFamily(Guid familyId, string userName);
        Task<List<FamilyMemberDto>> GetFamilyMembers(Guid famiyId);
    }


    public class FamilyService : IFamilyService
    {
        private readonly AppDbContext _dbContext;
        private readonly UserManager<AppUser> _userManager;
        private IHttpContextAccessor _httpContextAccessor;

        public FamilyService(AppDbContext context,
            UserManager<AppUser> userManager,
            IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _dbContext = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task AddUserToFamily(string userName)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CreateFamily(string userName, string familyName)
        {
            //string userId = _httpContextAccessor?.HttpContext?.User?
            //    .FindFirst(ClaimTypes.NameIdentifier)?.Value;

            //var user = await _userManager.FindByIdAsync(userId);
            var user = await _userManager.FindByNameAsync(userName);

            if (user == null) { return false; }

            _dbContext.Families.Add(new Family()
            {
                FamilyName = familyName,
                Members = new List<AppUser>() { user }
            });

            int res = _dbContext.SaveChanges();
            return res > 0;
        }

        public Task<List<FamilyMemberDto>> GetFamilyMembers(Guid famiyId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveUserFromFamily(Guid familyId, string userName)
        {
            throw new NotImplementedException();
        }
    }
}
