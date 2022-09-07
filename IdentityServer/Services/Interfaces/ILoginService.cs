using Demo.Identity.ViewModel;

namespace Demo.Identity.Services.Interfaces
{
    public interface ILoginService
    {
        Task<LoginResponseModel> GetToken(LoginRequestModel model);
    }
}
