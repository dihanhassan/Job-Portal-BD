using JobPortal.API.Models.Authentication;

namespace JobPortal.API.Models.Response
{
    public class ResponseModel
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; } = string.Empty;
        
        public UserLoginModel UserLogin { get; set; }
        
        public string accessToken { get; set; }
        public string refreshToken { get; set; }

    }
}
