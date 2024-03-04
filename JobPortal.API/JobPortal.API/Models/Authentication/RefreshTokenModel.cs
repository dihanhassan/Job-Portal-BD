namespace JobPortal.API.Models.Authentication
{
    public class RefreshTokenModel
    {
        public string Token {  get; set; }=string.Empty;

        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Expires { get; set; }

    }
}
