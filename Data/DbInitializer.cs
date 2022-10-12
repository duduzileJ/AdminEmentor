using AdminEmentor.Models;
using Microsoft.EntityFrameworkCore;
namespace AdminEmentor.Data
{
    public class DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {
           if (context.Students.Any())
            {
                return;
            }
            var duduzile = new Student
            {
                FirstName = "Duduzile",
                LastName = "January",
                Email = "duduzile.january@gmail.com",
                ContactNumber = "0737618186",
                EnrollmentDate = DateTime.Now,
            };
            var mbali = new Student
            {
                FirstName = "Mbali-Entle",
                LastName = "January",
                Email = "mbalijan@younglings.africa",
                ContactNumber = "0836916526",
                EnrollmentDate = DateTime.Parse("2020-01-03")
            };
            var ndalo = new Student
            {
                FirstName = "Ndalo-Entle",
                LastName = "Voyi",
                Email = "ndalovoyi@yahoo.com",
                ContactNumber = "0780703525",
                EnrollmentDate = DateTime.Parse("2018-03-27")
            };
            var sinothando = new Student
            {
                FirstName = "Sinothando",
                LastName = "Langa",
                Email = "sinothando.langa@gmail.com",
                ContactNumber = "0638268005",
                EnrollmentDate = DateTime.Parse("2022-01-29")
            };
            var sthando = new Student
            {
                FirstName = "Sithando",
                LastName = "Langa",
                Email = "sthandolanga07@gmail.com",
                ContactNumber = "0838691501",
                EnrollmentDate = DateTime.Parse("2019-06-29")
            };
            var ayakha = new Tutor
            {
                FirstName = "Ayakha",
                LastName = "Mzimkhulu",
                Email = "ayakha.mzimkulu@younglings.africa",
                ContactNumber = "0737312654",
                HireDate = DateTime.Parse("2018-03-21")
            };
            var cam = new Tutor
            {
                FirstName = "Cameron",
                LastName = "Davids",
                Email = "cam.davids@gmail.com",
                ContactNumber = "0818369874",
                HireDate = DateTime.Now
            };
            var josh = new Tutor
            {
                FirstName = "Joshua",
                LastName = "Schmit",
                Email = "joshschmit@gmail.com",
                ContactNumber = "0818378174",
                HireDate = DateTime.Now
            };

            var mathsClass = new Schedule
            {
              Tutor = ayakha,
              Link = "www.google.com",
              classDate = DateTime.Parse("2022-03-22")
            };
            var xhosaClass = new Schedule
            {
                Tutor = cam,
                Link = "www.w3schools.co.za",
                classDate = DateTime.Now
            };

            var langauges = new Department
            {
                Name = "languages",
                StartDate = DateTime.Parse("2019-03-01"),
                Administrator = ayakha
            };
            var mathmatics = new Department
            {
                Name = "Mathmatics",
                StartDate = DateTime.Parse("2021-02-27"),
                Administrator = cam
            };
            var science = new Department
            {
                Name = "Science",
                StartDate = DateTime.Parse("2009-06-03"),
                Administrator = josh
            };
            var naturalsciences = new Subject
            {
                SubjectID = 101,
                Title = "Natural Sciences",
                Credits = 5,
                Department = science,
                Tutors = new List<Tutor> { ayakha, cam }
            };
            var isiXhosa = new Subject
            {
                SubjectID = 102,
                Title = "IsiXhosa",
                Credits=4,
                Department = langauges,
                Tutors= new List<Tutor> { cam,josh}
            };
            var enrollments = new Enrollment[]
            {
                new Enrollment
                {
                    Student = duduzile,
                    Subject = naturalsciences,
                    Grade = Grade.A
                },
                new Enrollment
                {
                    Student = mbali,
                    Subject =isiXhosa,
                    Grade = Grade.A
                },
                new Enrollment
                {
                    Student = sinothando,
                    Subject = naturalsciences,
                    Grade = Grade.B
                }
            };
            context.AddRange(enrollments);
            context.SaveChanges();
        }
    }
}
