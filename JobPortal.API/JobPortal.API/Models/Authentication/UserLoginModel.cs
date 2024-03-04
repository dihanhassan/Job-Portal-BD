using System.ComponentModel.DataAnnotations;

namespace JobPortal.API.Models.Authentication
{
    public class UserLoginModel
    {
        public string UserID { get; set; } 
        public string UserName { get; set; }
       
        public string UserPassword { get; set; }
        public int UserType { get; set; }

       public string RefreshToken { get; set; } = string.Empty;
        public string AccessToken { get; set; } = string.Empty;



    }
}
