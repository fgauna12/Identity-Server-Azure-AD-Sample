using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tourney.Application.Services.Facility;
using Tourney.Infrastructure.Dtos;

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
        [Authorize]
        public async Task<IActionResult> GetTournaments(PagedRequest pagedRequest)
        {
            var response = await _facilityService.GetFacilitiesAsync();
            return Ok(response);
        }
    }
}