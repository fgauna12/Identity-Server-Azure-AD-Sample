using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tourney.Application.Services.Facility;
using Tourney.Domain;
using Tourney.Infrastructure.Dtos;
using Tourney.Web.Authentication;

namespace Tourney.Web.Controllers
{
    [Route("api/facilities")]
    public class FacilityController : Controller
    {
        private readonly IFacilityService _facilityService;

        public FacilityController(IFacilityService facilityService)
        {
            _facilityService = facilityService;
        }

        [Route("")]
        [HttpGet]
        [Authorize(Policy = CustomPolicies.CanViewFacilities)]
        public async Task<IActionResult> GetFacilities(PagedRequest pagedRequest)
        {
            var response = await _facilityService.GetFacilitiesAsync();
            return Ok(response);
        }
    }
}