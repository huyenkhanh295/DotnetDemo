using Demo.APICore.ViewModel;
using Demo.Database;
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

            var c = new Class1().Test();
            return Ok(res);
        }
    }
}