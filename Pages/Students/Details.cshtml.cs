using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AdminEmentor.Data;
using AdminEmentor.Models;

namespace AdminEmentor.Pages.Students
{
    public class DetailsModel : PageModel
    {
        private readonly AdminEmentor.Data.SchoolContext _context;

        public DetailsModel(AdminEmentor.Data.SchoolContext context)
        {
            _context = context;
        }

      public Student Student { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            // var student = await _context.Students.FirstOrDefaultAsync(m => m.StudentID == id);
            Student = await _context.Students.
                Include(s => s.Enrollments).
                ThenInclude(e => e.Subject).
                AsNoTracking().FirstOrDefaultAsync(m => m.StudentID == id);
            if (Student == null)
            {
                return NotFound();
            }
            //else 
            //{
            //    Student = student;
            //}
            return Page();
        }
    }
}
