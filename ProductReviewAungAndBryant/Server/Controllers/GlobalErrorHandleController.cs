using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ProductReviewAungAndBryant.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GlobalErrorHandleController : ControllerBase
    {
        // GET: api/Categories
        [HttpGet]
        public async Task<IActionResult> Get404NotFound()
        {
            return NotFound();
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<IActionResult> Get500()
        {
            return StatusCode(500);
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<IActionResult> GetUnauthorized()
        {
            return StatusCode(401);
        }
    }
}
