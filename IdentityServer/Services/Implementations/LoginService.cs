using Demo.Database.Models;
using Demo.Identity.Services.Interfaces;
using Demo.Identity.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Demo.Identity.Services.Implementations
{
    public class LoginService : ILoginService
    {
        private readonly DemoIdentityContext _dbContext;
        public IConfiguration _configuration;

        public LoginService(IConfiguration config, DemoIdentityContext dbContext)
        {
            _configuration = config;
            _dbContext = dbContext;
        }

        public async Task<LoginResponseModel> GetToken(LoginRequestModel model)
        {
            try
            {
                var result = new LoginResponseModel
                {
                    Success = false,
                    Message = "",
                    AccessToken = "",
                };

                var existedUser = await GetExistedUser(model);
                if (existedUser == null)
                {
                    result.Message = "No user found!";
                    return result;
                }

                var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("Username", model.Username),
                    };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Audience"],
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(10),
                    signingCredentials: signIn);

                result.Success = true;
                result.Message = "Successfully";
                result.AccessToken = new JwtSecurityTokenHandler().WriteToken(token);

                return result;
            }
            catch (Exception)
            {
                return new LoginResponseModel
                {
                    Success = false,
                    Message = "Login fail",
                    AccessToken = "",
                };
            }
        }

        public async Task<User?> GetExistedUser(LoginRequestModel m)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.UserName == m.Username && u.Password == m.Password);
        }
    }
}
