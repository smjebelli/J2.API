using J2.API.Common;
using J2.API.Dto;
using J2.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Security.Claims;

namespace J2.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class FamilyController : ApiControllerBase
    {
        private readonly ILogger<FamilyController> _logger;
        private readonly IFamilyService _familyService;
        //private readonly IConfiguration _configuration;
        //private readonly IHttpContextAccessor _accessor;
        public FamilyController(ILogger<FamilyController> logger,
            IFamilyService familyService, IConfiguration configuration,
            IHttpContextAccessor accessor) : base(configuration, accessor)
        {
            _logger = logger;
            _familyService = familyService;
        }

        /// <summary>
        /// ایجاد یک خانواده جدید توسط کاربر
        /// </summary>
        /// <param name="createFamilyRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateFamily([FromBody]  CreateFamilyRequest request)
        {
            _logger.LogInformation($"Creating Family {request.FamilyName} ...");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var claim = User.Claims.Where(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name").FirstOrDefault();
            var claim = User.Claims.Where(c => c.Type == ClaimTypes.Name).FirstOrDefault();
            
            var data = new CreateFamilyDto(
             claim?.Value,
             request.FamilyName
            ); 
            
            var res = await _familyService.CreateFamily(data);

            return GeneralResponse(res);

        }

        [HttpGet]
        public async Task<IActionResult> GetFamilies()
        {
            if (!ModelState.IsValid)            
                return BadRequest(ModelState);
            

            //var claim = User.Claims.Where(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name").FirstOrDefault();
            var claim = User.Claims.Where(c => c.Type == ClaimTypes.Name).FirstOrDefault();


            var res = await _familyService.GetFamilies(new GetFamiliesDto(claim?.Value));

            return GeneralResponse(res);

        }
    }
}
