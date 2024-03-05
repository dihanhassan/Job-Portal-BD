using System.ComponentModel.DataAnnotations;

namespace JobPortal.API.Models
{
    public class JobPostModel
    {
        [Required]
        public string UserID { get; set; } = string.Empty;
        public int postID { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;

        public int Vacancy {  get; set; } 

        public string Education { get; set; } = string.Empty;

        [Required]
        public string Organization {  get; set; } = string.Empty;
        [Required]
        public string Location { get; set; } = string.Empty;
        public string Requirements { get; set; } 
        [Required]
        public string Responsibilities { get; set; } 
        [Required]
        public string Compensation { get; set; }
        [Required]
        public string EmployeeStatus { get; set; } = string.Empty;
        public string Experience { get; set; } = string.Empty;
        public DateTime Created { get; set; } = DateTime.Now;

        public DateTime DeadLine { get; set; } = DateTime.Now;

        [Required]
        public string  Field { get; set; } = string.Empty;


    }
}
