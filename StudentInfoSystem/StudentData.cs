using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    static class StudentData
    {
        static private List<Student> _testStudents;
        static public List<Student> TestStudents
        {
            get 
            {
                return _testStudents = new List<Student>
                {
                    new Student(1, "Ivan", "Ivanov", "Georgiev", "FCST", "CSE", Qualification.BACHELOR, Status.FULL_TIME, "1234567890", "2", "10", "30"),
                    new Student(2, "Violeta", "Petrova", "Ivanova", "FIT", "CSS", Qualification.BACHELOR, Status.FULL_TIME, "1234567891", "4", "11", "17")
                };
            }
            private set => _testStudents = value;
        }

        static public Student IsThereStudent(string facultyNumber)
        {
            StudentInfoContext studentInfoContext = new StudentInfoContext();

            Student result = (from student in studentInfoContext.Students where student.FacultyNumber.Equals(facultyNumber) select student).First();
            return result;
        }

        static public void DeleteStudentByFacultyNumber(string facultyNumber)
        {
            StudentInfoContext studentInfoContext = new StudentInfoContext();

            Student delObj = (from student in studentInfoContext.Students where student.FacultyNumber == facultyNumber select student).First();

            studentInfoContext.Students.Remove(delObj);
            studentInfoContext.SaveChanges();
        }
    }
}
