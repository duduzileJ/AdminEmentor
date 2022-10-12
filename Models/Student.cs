using System.ComponentModel.DataAnnotations;
namespace AdminEmentor.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [DataType(DataType.EmailAddress)]
        [Display(Name ="Email Address")]
        public string? Email { get; set; }
        [Required,StringLength(10)]
        [Display(Name = "Contact Number")]
        public string? ContactNumber { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{0:yyyy-MM-dd}", ApplyFormatInEditMode =true)]
        [Display(Name = "Enrollment Date")]
        public DateTime EnrollmentDate { get; set; }
        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
