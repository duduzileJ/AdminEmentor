using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdminEmentor.Models
{
    public class Schedule
    {
        [Key]
        public int TutorID { get; set; }
        [Display(Name = "Link for class")]
        public string Link { get; set; }
        public DateTime classDate { get; set; }

        public Tutor Tutor { get; set; }
    }
}
