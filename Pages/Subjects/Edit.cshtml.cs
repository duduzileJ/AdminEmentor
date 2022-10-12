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

namespace AdminEmentor.Pages.Subjects
{
    public class EditModel : DepartmentNamePageModel
    {
        private readonly AdminEmentor.Data.SchoolContext _context;

        public EditModel(AdminEmentor.Data.SchoolContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Subject Subject { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Subjects == null)
            {
                return NotFound();
            }

            var subject =  await _context.Subjects.Include(c=> c.Department).FirstOrDefaultAsync(m => m.SubjectID == id);
            if (subject == null)
            {
                return NotFound();
            }
            PopulateDepartmentsDropDownList(_context, Subject.DepartmentID);
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var subjectToUpdate = await _context.Subjects.FindAsync(id);
            if(subjectToUpdate == null)
            {
                return NotFound();
            }
            if(await TryUpdateModelAsync<Subject>(
                subjectToUpdate,"subject", c=> c.Credits, c => c.DepartmentID, c => c.Title))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateDepartmentsDropDownList(_context, subjectToUpdate.DepartmentID);
            return Page();
        }

      

    }
}
