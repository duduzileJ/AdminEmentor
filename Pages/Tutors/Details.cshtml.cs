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
    public class DetailsModel : PageModel
    {
        private readonly AdminEmentor.Data.SchoolContext _context;

        public DetailsModel(AdminEmentor.Data.SchoolContext context)
        {
            _context = context;
        }

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
    }
}
