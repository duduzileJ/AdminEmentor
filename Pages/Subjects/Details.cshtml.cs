using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AdminEmentor.Data;
using AdminEmentor.Models;

namespace AdminEmentor.Pages.Subjects
{
    public class DetailsModel : PageModel
    {
        private readonly AdminEmentor.Data.SchoolContext _context;

        public DetailsModel(AdminEmentor.Data.SchoolContext context)
        {
            _context = context;
        }

      public Subject Subject { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Subjects == null)
            {
                return NotFound();
            }
            Subject = await _context.Subjects.AsNoTracking()
               .Include(c => c.Department).FirstOrDefaultAsync(m => m.SubjectID == id);
            // var subject = await _context.Subjects.FirstOrDefaultAsync(m => m.SubjectID == id);
            if (Subject == null)
            {
                return NotFound();
            }
            //else 
            //{
            //    Subject = subject;
            //}
            return Page();
        }
    }
}
