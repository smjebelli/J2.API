using J2.API.Dto;
using J2.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Security.Claims;

namespace J2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamilyController : ControllerBase
    {
        private readonly ILogger<FamilyController> _logger;
        private readonly IFamilyService _familyService
            ;
        public FamilyController(ILogger<FamilyController> logger, IFamilyService familyService)
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
        public async Task<IActionResult> CreateFamily([FromBody] CreateFamilyDto createFamilyRequest)
        {
            _logger.LogInformation($"Creating Family {createFamilyRequest.FamilyName} ...");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var claim = User.Claims.Where(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name").FirstOrDefault();

            var res = await _familyService.CreateFamily(claim?.Value, createFamilyRequest.FamilyName);
            if (res)
                return Ok();
            else
                return StatusCode(406);



        }
    }
}
