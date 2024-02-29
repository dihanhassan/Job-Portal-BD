using System.ComponentModel.DataAnnotations;

namespace JobPortal.API.Models.Authentication
{
    public class UserLoginModel
    {
       
        public string UserName { get; set; }
       
        public string UserPassword { get; set; }
        public int UserType { get; set; }

       



    }
}
