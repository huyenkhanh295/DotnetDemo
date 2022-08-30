using IdentityServer.Models;
using IdentityServer.Services.Interfaces;
using IdentityServer.ViewModel;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IdentityServer.Services.Implementations
{
    public class LoginService : ILoginService
    {
        public IConfiguration _configuration;
        public LoginService(IConfiguration config)
        {
            _configuration = config;
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

                var existedUser = GetExistedUser(model);
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

        public User? GetExistedUser(LoginRequestModel m)
        {
            return UserList.Users.FirstOrDefault(u => u.Username == m.Username && u.Password == m.Password);
        }
    }
}
