using Demo.Client.Constant;
using Demo.Client.Extension;
using Demo.Client.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Client.Controllers
{
    [ApiController]
    [Route("api/client")]
    public class WeatherForecastController : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestModel model)
        {
            var httpClient = HttpClientExtension.Instance("https://localhost:7230/");
            var result = await httpClient.PostAsync<LoginRequestModel, LoginResultResponseModel>("api/login", model);
            StaticConstant.Token = result.AccessToken;
            return Ok(result);
        }

        [Authorize]
        [HttpGet("welcome")]
        public async Task<IActionResult> Get()
        {
            var httpClient = HttpClientExtension.Instance("https://localhost:7244/");
            var result = await httpClient.SetToken(StaticConstant.Token).GetAsync<WelcomeResponseModel>("api/welcome");

            return Ok(result);
        }
    }
}