namespace JobPortal.API.Models.Authentication
{
    public class RefreshTokenResponse
    {
        public string RefreshToken { get; set; }
        public string AcessToken { get; set; }
        public string UserId { get; set; }
    }

}
