using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Tourney.Web.Controllers
{
    [Route("api/identity")]
    public class IdentityController : Controller
    {
        /// <summary>
        /// Get the current user logged in
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public IActionResult GetSelf()
        {
            return Ok(HttpContext.User.Claims);
        }
    }
}