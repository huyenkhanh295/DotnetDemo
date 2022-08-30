using Demo.APICore.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/welcome")]
    public class WelcomeController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetWelcomeText()
        {
            var res = new WelcomeResponseModel
            {
                Success = true,
                Message = "Welcome to Demo project"
            };
            return Ok(res);
        }
    }
}