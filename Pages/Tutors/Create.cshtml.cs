using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AdminEmentor.Data;
using AdminEmentor.Models;
using Microsoft.EntityFrameworkCore;

namespace AdminEmentor.Pages.Tutors
{
    public class CreateModel : TutorSubjectsPageModel
    {
        private readonly AdminEmentor.Data.SchoolContext _context;
        private readonly ILogger<TutorSubjectsPageModel> _logger;

        public CreateModel(AdminEmentor.Data.SchoolContext context, ILogger<TutorSubjectsPageModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult OnGet()
        {
            var tutor = new Tutor();
            tutor.Subjects = new List<Subject>();
            PopulatedAssignedSubjectData(_context, tutor);
            return Page();
        }

        [BindProperty]
        public Tutor Tutor { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string[] selectedSubjects)
        {
            var newTutor = new Tutor();
            if(selectedSubjects.Length > 0)
            {
                newTutor.Subjects = new List<Subject>();
                _context.Subjects.Load();
            }
            foreach(var subject in selectedSubjects)
            {
                var foundSubject = await _context.Subjects.FindAsync(int.Parse(subject));
                if(foundSubject != null)
                {
                    newTutor.Subjects.Add(foundSubject);
                }
                else
                {
                    _logger.LogWarning("Subject {subject} not found.", subject);
                }
            }
            try
            {
                if(await TryUpdateModelAsync<Tutor>(
                    newTutor,"Tutor",
                    i => i.FirstName, i => i.LastName, i => i.Email, i => i.ContactNumber, i =>i.HireDate))
                {
                    _context.Tutors.Add(newTutor);
                    await _context.SaveChangesAsync();
                    return RedirectToPage("./Index");
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            PopulatedAssignedSubjectData(_context, newTutor);
            return Page();
        }
    }
}
