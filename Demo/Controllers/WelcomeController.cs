using Demo.APICore.ViewModel;
using Infrastructure.Constant;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    [ApiController]
    [Route("api/welcome")]
    public class WelcomeController : ControllerBase
    {
        [Authorize(Roles = Permission.User.View)]
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