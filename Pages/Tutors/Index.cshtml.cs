using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AdminEmentor.Data;
using AdminEmentor.Models;
using AdminEmentor.Models.SchoolViewModels;

namespace AdminEmentor.Pages.Tutors
{
    public class IndexModel : PageModel
    {
        private readonly AdminEmentor.Data.SchoolContext _context;

        public IndexModel(AdminEmentor.Data.SchoolContext context)
        {
            _context = context;
        }
        public TutorIndexData TutorData { get; set; }
        public int TutorID { get; set; }
        public int SubjectID { get; set; }

        public IList<Tutor> Tutor { get;set; }

        public async Task OnGetAsync(int? id, int? subjectID)
        {
           TutorData = new TutorIndexData();
            TutorData.Tutors = await _context.Tutors.Include(i => i.Schedule).Include(i => i.Subjects)
                .ThenInclude(c => c.Department).OrderBy(i => i.LastName).ToListAsync();
            if(id != null)
            {
                TutorID = id.Value;
                Tutor tutor = TutorData.Tutors.Where(i => i.TutorID == id.Value).Single();
                TutorData.Subjects = tutor.Subjects;
            }
            if(subjectID != null)
            {
                SubjectID = subjectID.Value;
                IEnumerable<Enrollment> Enrollments = await _context.Enrollments
                    .Where(x => x.SubjectID == SubjectID).Include(i => i.Student)
                    .ToListAsync();
                TutorData.Enrollments = Enrollments;
            }
            
        }
    }
}
