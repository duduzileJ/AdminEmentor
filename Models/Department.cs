using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdminEmentor.Models
{
    public class Department
    {
        public int DepartmentID { get; set; }

        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public int ? TutorID { get; set; }

        public Tutor Administrator { get; set; }
        public ICollection<Subject> Subjects { get; set; }
    }
}
