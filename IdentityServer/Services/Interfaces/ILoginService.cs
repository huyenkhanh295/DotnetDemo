using IdentityServer.ViewModel;

namespace IdentityServer.Services.Interfaces
{
    public interface ILoginService
    {
        Task<LoginResponseModel> GetToken(LoginRequestModel model);
    }
}
