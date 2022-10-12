using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AdminEmentor.Data;
using AdminEmentor.Models;

namespace AdminEmentor.Pages.Departments
{
    public class IndexModel : PageModel
    {
        private readonly AdminEmentor.Data.SchoolContext _context;

        public IndexModel(AdminEmentor.Data.SchoolContext context)
        {
            _context = context;
        }

        public IList<Subject> Subjects { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Subjects != null)
            {
                Subjects = await _context.Subjects
                .Include(s => s.Department).AsNoTracking().ToListAsync();
            }
        }
    }
}
