namespace JobPortal.API.Models
{
    public class ApplicantInfoModel
    {
        public string FirstName { get; set; } 
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string MobileNumber { get; set; }
        public string Experience { get; set; }
        public string Skill { get; set;}

        public string Institution { get; set; }
        public DateTime AppliedDate { get; set;}

        public string ResumeUrl {  get; set; }

    }
}
