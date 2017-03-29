using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tourney.Application.Services.Company;
using Tourney.Infrastructure.Dtos;

namespace Tourney.Web.Controllers
{
    [Route("api/companies")]
    public class CompanyController : Controller
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [Route("")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetTournaments(PagedRequest pagedRequest)
        {
            var response = await _companyService.GetCompaniesAsync(pagedRequest);
            return Ok(response);
        }
    }
}