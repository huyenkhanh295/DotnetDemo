using Newtonsoft.Json;

namespace Demo.Client.ViewModel
{
    public class WelcomeResponseModel : BaseModel
    {
        public bool Success { get; set; }
        public string Message
        {
            get
            {
                if (string.IsNullOrWhiteSpace(base.Content))
                    return string.Empty;

                return JsonConvert.DeserializeObject<string>(base.Content);
            }
        }
    }
}
