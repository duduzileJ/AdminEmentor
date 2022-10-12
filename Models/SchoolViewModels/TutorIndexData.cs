namespace AdminEmentor.Models.SchoolViewModels
{
    public class TutorIndexData
    {
        public IEnumerable<Tutor> Tutors { get; set; }
        public IEnumerable <Subject> Subjects { get; set; }
        public IEnumerable <Enrollment> Enrollments { get; set; }
    }
}
