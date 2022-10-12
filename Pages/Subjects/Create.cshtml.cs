using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AdminEmentor.Data;
using AdminEmentor.Models;

namespace AdminEmentor.Pages.Subjects
{
    public class CreateModel : DepartmentNamePageModel
    {
        private readonly AdminEmentor.Data.SchoolContext _context;

        public CreateModel(AdminEmentor.Data.SchoolContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            PopulateDepartmentsDropDownList(_context);
            return Page();
        }

        [BindProperty]
        public Subject Subject { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var emptySubject = new Subject();
            if(await TryUpdateModelAsync<Subject>(
                emptySubject, "subject", s=> s.SubjectID, s=>s.DepartmentID,s=>s.Title,s => s.Credits))
            {
                _context.Subjects.Add(emptySubject);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateDepartmentsDropDownList(_context, emptySubject.DepartmentID);
            return Page();
        }
    }
}
