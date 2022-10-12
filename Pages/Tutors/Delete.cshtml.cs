using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AdminEmentor.Data;
using AdminEmentor.Models;

namespace AdminEmentor.Pages.Tutors
{
    public class DeleteModel : PageModel
    {
        private readonly AdminEmentor.Data.SchoolContext _context;

        public DeleteModel(AdminEmentor.Data.SchoolContext context)
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

            var tutor = await _context.Tutors.FirstOrDefaultAsync(m => m.TutorID == id);

            if (tutor == null)
            {
                return NotFound();
            }
            else 
            {
                Tutor = tutor;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Tutors == null)
            {
                return NotFound();
            }
            var tutor = await _context.Tutors.FindAsync(id);

            if (tutor != null)
            {
                Tutor = tutor;
                _context.Tutors.Remove(Tutor);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
