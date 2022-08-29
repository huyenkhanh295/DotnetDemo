namespace IdentityServer.ViewModel
{
    public class LoginResponseModel
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string AccessToken { get; set; }
    }
}
