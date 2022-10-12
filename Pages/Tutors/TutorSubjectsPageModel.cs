using AdminEmentor.Data;
using AdminEmentor.Models;
using AdminEmentor.Models.SchoolViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdminEmentor.Pages.Tutors
{
    public class TutorSubjectsPageModel : PageModel
    {
        public List<AssignedSubjectData> AssignedSubjectDataList;
        public void PopulatedAssignedSubjectData(SchoolContext context, 
            Tutor tutor)
        {
            var allSubjects = context.Subjects;
            var tutorSubjects = new HashSet<int>(
                tutor.Subjects.Select(c => c.SubjectID));
            AssignedSubjectDataList = new List<AssignedSubjectData>();
            foreach (var subject in allSubjects)
            {
                AssignedSubjectDataList.Add(new AssignedSubjectData
                {
                    SubjectID = subject.SubjectID,
                    Title = subject.Title,
                    Assigned = tutorSubjects.Contains(subject.SubjectID)
                });
            }
            
        }
    }
}
