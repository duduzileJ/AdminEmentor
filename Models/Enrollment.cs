using System.ComponentModel.DataAnnotations;

namespace AdminEmentor.Models
{
    public enum Grade
    {
        A, B,C,D,F
    }
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int SubjectID { get; set; }
        public int StudentID { get; set; }
        [DisplayFormat(NullDisplayText ="No grade")]
        public Grade? Grade { get; set; }
        public Subject Subject { get; set; }
        public Student Student { get; set; }
    }
}
