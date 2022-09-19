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

        public Task<LoginResponseModel> GetToken(LoginRequestModel model)
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
                    return Task.FromResult(result);
                }

                var claims = new List<Claim> {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserName", existedUser.Result.UserName),
                    };


                var permissions = GetUserPermissions(existedUser.Id).ToList();
                if (permissions.Any())
                {
                    foreach (var permission in permissions)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, permission.PermissionCode));
                    }
                }

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

                return Task.FromResult(result);
            }
            catch (Exception)
            {
                return Task.FromResult(new LoginResponseModel
                {
                    Success = false,
                    Message = "Login fail",
                    AccessToken = "",
                });
            }
        }

        public Task<User?> GetExistedUser(LoginRequestModel m)
        {
            return _dbContext.Users.FirstOrDefaultAsync(u => u.UserName == m.Username && u.Password == m.Password);
        }

        public IEnumerable<Permission> GetUserPermissions(long userId)
        {
            var roles = _dbContext.Roles.Where(x => x.Users.Any(y => y.Id == userId && y.Status == 1) && x.Permissions.Any());
            return roles.SelectMany(x => x.Permissions);
        }
    }
}
