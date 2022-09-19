using Demo.Client.Constant;
using Demo.Client.Extension;
using Demo.Client.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Client.Controllers
{
    [ApiController]
    [Route("api/client")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestModel model)
        {
            var httpClient = HttpClientExtension.Instance("https://localhost:7230/");
            var result = await httpClient.PostAsync<LoginRequestModel, LoginResultResponseModel>("api/login", model);
            StaticConstant.Token = result.AccessToken;
            return Ok(result);
        }

        [HttpGet("welcome")]
        public IActionResult Get()
        {
            var httpClient = HttpClientExtension.Instance("https://localhost:7244/");
            var result = httpClient.SetToken("Bearer " + StaticConstant.Token).Get<WelcomeResponseModel>("api/welcome");

            return Ok(result.Result);
        }
    }
}