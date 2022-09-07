using Demo.Database;
using Demo.Identity.Services.Interfaces;
using Demo.Identity.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace IdentityServer.Controllers
{
    [ApiController]
    [Route("api/login")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="model">LoginRequestModel</param>
        /// <returns>Return a result</returns>
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestModel model)
        {
            var c = new Class1().Test();
            var result = await _loginService.GetToken(model);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return StatusCode((int)HttpStatusCode.Unauthorized, result); ;
            }
        }
    }
}