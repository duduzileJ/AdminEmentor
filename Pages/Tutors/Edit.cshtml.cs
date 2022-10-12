using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdminEmentor.Data;
using AdminEmentor.Models;
using Microsoft.Identity.Client;

namespace AdminEmentor.Pages.Tutors
{
    public class EditModel : TutorSubjectsPageModel
    {
        private readonly AdminEmentor.Data.SchoolContext _context;

        public EditModel(AdminEmentor.Data.SchoolContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Tutor Tutor { get; set; } 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Tutors == null)
            {
                return NotFound();
            }
            Tutor = await _context.Tutors.Include(i => i.Schedule)
                .Include(i => i.Subjects).AsNoTracking().FirstOrDefaultAsync(m => m.TutorID == id);

            //var tutor =  await _context.Tutors.FirstOrDefaultAsync(m => m.TutorID == id);
            if (Tutor == null)
            {
                return NotFound();
            }
            PopulatedAssignedSubjectData(_context, Tutor);
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedSubjects)
        {
            if (id == null)
            {
                return Page();
            }

            var tutorToUpdate = await _context.Tutors
                 .Include(i => i.Schedule)
                 .Include(i => i.Subjects)
                 .FirstOrDefaultAsync(s => s.TutorID == id);
            if(tutorToUpdate == null)
            {
                return NotFound();
            }
            if(await TryUpdateModelAsync<Tutor>(
                tutorToUpdate,"Tutor",
                i => i.FirstName, i => i.LastName, i => i.HireDate, i => i.Email, i => i.ContactNumber))
            {
                UpdateTutorSubjects(selectedSubjects, tutorToUpdate);
                PopulatedAssignedSubjectData(_context, tutorToUpdate);
            }
            return Page();
        }
        public void UpdateTutorSubjects(string[] selectedSubjects, Tutor tutorToUpdate)
        {
            if(selectedSubjects == null)
            {
                tutorToUpdate.Subjects = new List<Subject>();
                return;
            }
            var selectedSubjectsHS = new HashSet<string>(selectedSubjects);
            var tutorSubjects = new HashSet<int>(
                 tutorToUpdate.Subjects.Select(c => c.SubjectID));
            foreach(var subject in _context.Subjects)
            {
               if(selectedSubjectsHS.Contains(subject.SubjectID.ToString()))
                {
                    if(!tutorSubjects.Contains(subject.SubjectID))
                    {
                        tutorToUpdate.Subjects.Add(subject);
                    }
                }
               else
                {
                    if(tutorSubjects.Contains(subject.SubjectID))
                    {
                        var subjectToRemove = tutorToUpdate.Subjects.Single(
                            c => c.SubjectID == subject.SubjectID);
                        tutorToUpdate.Subjects.Remove(subjectToRemove);
                    }
                }
            }
        }


    }
}
