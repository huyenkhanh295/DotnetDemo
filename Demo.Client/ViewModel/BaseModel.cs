using System.Net;

namespace Demo.Client.ViewModel
{
    public class BaseModel
    {
        public HttpStatusCode StatusCode { get; set; }
        public string? Content { get; set; }
    }
}
