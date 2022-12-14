using AdminEmentor.Data;
using AdminEmentor.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace AdminEmentor.Pages.Subjects
{
    public class DepartmentNamePageModel : PageModel
    {
        public SelectList DepartmentNameSL { get; set; }
        public void PopulateDepartmentsDropDownList(SchoolContext _context, object selectedDepartment = null)
        {
            var departmentsQuery = from d in _context.Departments
                                   orderby d.Name
                                   select d;
            DepartmentNameSL = new SelectList(departmentsQuery.AsNoTracking(), "DepartmentID","Name", selectedDepartment);
        }
    }
}
