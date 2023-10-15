using J2.API.Common;
using J2.API.Constants;
using J2.API.Dto;
using J2.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace J2.API.Services
{
    public interface IFamilyService
    {
        Task<GeneralBaseResponse> CreateFamily(CreateFamilyDto createFamilyRequest);
        Task AddUserToFamily(string userName);
        Task RemoveUserFromFamily(Guid familyId, string userName);
        Task<List<FamilyMemberDto>> GetFamilyMembers(Guid famiyId);
        Task<GeneralBaseResponse<List<FamilyDto>>> GetFamilies(GetFamiliesDto getFamilieRequest);
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

        public async Task<GeneralBaseResponse> CreateFamily(CreateFamilyDto createFamilyRequest)
        {
            var response = new GeneralBaseResponse();

            var user = await _userManager.FindByNameAsync(createFamilyRequest.UserName);


            if (user == null)
            {
                response.Result = NodeResult.UserNotFound;
                return response;
            }
            var families = _dbContext.Families.FromSqlRaw<Family>(
                $"select * from families where CreatedBy='{user.Id}' and FamilyName='{createFamilyRequest.FamilyName}'").ToList();

            if (families.Any())
            {
                response.Result = NodeResult.FamilyAlreadyExists;
                return response;
            }

            var member = new FamilyMember()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                NickName = $"{user.FirstName} {user.LastName}"
            };


            var family = _dbContext.Families.Add(new Family()
            {
                FamilyName = createFamilyRequest.FamilyName,
                Members = new List<FamilyMember>() { member }
            });



            int res = _dbContext.SaveChanges(user.Id);
            if (res > 0)
            {
                response.Result = NodeResult.Ok;
                return response;

            }
            else
            {
                response.Result = NodeResult.Error;
            }

            return response;
        }

        public async Task<GeneralBaseResponse<List<FamilyDto>>> GetFamilies(GetFamiliesDto getFamilieRequest)
        {
            var response = new GeneralBaseResponse<List<FamilyDto>>();
            List<Family> families;
            var user = await _userManager.FindByNameAsync(getFamilieRequest.userName);

            if (user == null)
            {
                response.Result = NodeResult.UserNotFound;
                return response;
            }

            var roles = await _userManager.GetRolesAsync(user);

            var adminRole = roles.Where(x => x.ToLower().Contains("admin")).FirstOrDefault();
            if (!string.IsNullOrEmpty(adminRole))
                families = _dbContext.Families.FromSqlRaw<Family>($"select * from families where CreatedBy is not null").ToList();

            else
                families = _dbContext.Families.FromSqlRaw<Family>($"select * from families where CreatedBy='{user.Id}'").ToList();

            if (families.Any())
            {
                response.Data = families.Select(x => new FamilyDto(x.Id.ToString(), x.FamilyName, user.UserName)).ToList();
            }
            else
            {
                response.Result = NodeResult.NotContent;
                return response;
            }

            response.Result = NodeResult.Ok;
            return response;
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
