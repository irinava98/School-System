using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem;

public class Writer
{
    public void Create()
    {
        using (var db = new SchoolSystemDbContext())
        {
            /*
            DateTime d = new DateTime(2019, 11, 25, 10, 20, 35);
            DateTime res = DateTime.SpecifyKind(d, DateTimeKind.Utc);
            */




            DateTime birthdate1 = new DateTime(1994, 3, 3);
            DateTime birthdate2 = new DateTime(1998, 5, 13);

            var student1 = new Student { Id = 1, FristName = "Irina", MiddleName = "Vladimirova", LastName = "Atanasova", Birthdate = DateTime.SpecifyKind(birthdate1, DateTimeKind.Utc) };
            var student2 = new Student { Id = 3, FristName = "Petq", MiddleName = "Ivanova", LastName = "Petrova", Birthdate = DateTime.SpecifyKind(birthdate2, DateTimeKind.Utc) };


            db.Students.Add(student1);
            db.Students.Add(student2);

            
            var teacher1 = new Teacher { Id = 1, FirstName = "Galin", MiddleName = "Atanasov", LastName = "Atanasov", Age = 55, IsActive = true };
            var teacher2 = new Teacher { Id = 2, FirstName = "Kalinka", MiddleName = "Ivanova", LastName = "Malinova", Age = 60, IsActive = true };


            db.Teachers.Add(teacher1);
            db.Teachers.Add(teacher2);


            DateTime creationDate1 = new DateTime(2022, 3, 1);
            DateTime creationDate2 = new DateTime(2022, 3, 15);
            var studentinformation1 = new Studentinformation { Id = 1, CreationDate = DateTime.SpecifyKind(creationDate1, DateTimeKind.Utc) };
            var studentinformation2 = new Studentinformation { Id = 2, CreationDate = DateTime.SpecifyKind(creationDate2, DateTimeKind.Utc) };
            db.Studentinformations.Add(studentinformation1);
            db.Studentinformations.Add(studentinformation2);




            var course1 = new Course { Id = 1, Name = "Algebra", Description = "Math Course", Credits = 10 };
            var course2 = new Course { Id = 2, Name = "C#", Description = "Programming Coure", Credits = 5 };
            var course3 = new Course { Id = 3, Name = "Geometry", Description = "Basic Course", Credits = 3 };

            db.Courses.Add(course1);
            db.Courses.Add(course2);
            db.Courses.Add(course3);


            var startdate1 = new DateTime(2022, 3, 1);
            var finishdate1 = new DateTime(2022, 5, 1);

            var studentcourse1 = new StudentCourse { CourseId = 2, StudentId = 2, StartDate = DateTime.SpecifyKind(startdate1, DateTimeKind.Utc), FinishDate = DateTime.SpecifyKind(finishdate1, DateTimeKind.Utc), Status = Status.Current };

            var startdate2 = new DateTime(2022, 2, 2);
            var finishdate2 = new DateTime(2022, 3, 2);

            var studentcourse2 = new StudentCourse { CourseId = 3, StudentId = 3, StartDate = DateTime.SpecifyKind(startdate2, DateTimeKind.Utc), FinishDate = DateTime.SpecifyKind(finishdate2, DateTimeKind.Utc), Status = Status.Finished, Assessment = 5.50 };

            db.StudentCourses.Add(studentcourse1);
            db.StudentCourses.Add(studentcourse2);


            var teachercourse1 = new TeacherCourse { CourseId = 2, TeacherId = 2 };
            var teachercourse2 = new TeacherCourse { CourseId = 3, TeacherId = 3 };
            db.TeacherCourses.Add(teachercourse1);
            db.TeacherCourses.Add(teachercourse2);



            db.SaveChanges();
        }
    }

    public void Read()
    {
        using (var db = new SchoolSystemDbContext())
        {
            var oldteachers = db.Teachers.Where(x => x.Age > 55).ToList();
            foreach(var teacher in oldteachers)
            {
                Console.WriteLine($"{teacher.FirstName} {teacher.MiddleName} {teacher.LastName} is {teacher.Age} years old.");
            }

            var studentnamess = db.Students.Select(x => x.FristName).ToList();
            foreach (var studentname in studentnamess)
            {
                Console.WriteLine(studentname);
            }

            var maxCredits = db.Courses.Select(x => x.Credits).Max().ToString();
            Console.WriteLine("Max credits for a course are : "+maxCredits);

        }

    }

    public void Update()
    {
        using (var db = new SchoolSystemDbContext())
        {
            
            var changedStudent = db.Students.FirstOrDefault(x => x.FristName == "Petq");
            changedStudent.FristName = "Galina";


            var changedTeacher = db.Teachers.FirstOrDefault(x => x.Id == 1);
            changedTeacher.MiddleName = "Anastasov";


            var changedTeacherToGetOlder = db.Teachers.FirstOrDefault(x => x.Age > 55);
            changedTeacherToGetOlder.Age = 80;

            db.SaveChanges();
        }
    }

    public void Delete()
    {
        using (var db=new SchoolSystemDbContext())
        {
            var deletedStudent = db.Students.FirstOrDefault(x => x.FristName == "Galina");
            if(deletedStudent!=null)
            {
                db.Students.Remove(deletedStudent);

                db.SaveChanges();
            }
            
        }
    }

    
}

           
    
    



