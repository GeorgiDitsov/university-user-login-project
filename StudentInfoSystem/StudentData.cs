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
                    new Student() 
                    {
                        StudentId = 1,
                        FirstName = "Ivan",
                        Surname = "Ivanov",
                        LastName = "Georgiev",
                        Faculty = "FCST",
                        Programme = "CSE",
                        Qualification = (int) Qualification.BACHELOR,
                        Status = (int) Status.FULL_TIME,
                        FacultyNumber = "1234567890",
                        Course = "2",
                        Stream="10",
                        Group="30"
                    },
                    new Student()
                    {
                        StudentId = 2,
                        FirstName = "Violeta",
                        Surname = "Petrova",
                        LastName = "Ivanova",
                        Faculty = "FIT",
                        Programme = "CSS",
                        Qualification = (int) Qualification.BACHELOR,
                        Status = (int) Status.FULL_TIME,
                        FacultyNumber = "1234567891",
                        Course = "4",
                        Stream="11",
                        Group="17"
                    }
                };
            }
            private set => _testStudents = value;
        }

        static public Student IsThereStudent(string facultyNumber)
        {
            StudentContext studentContext = new StudentContext();

            Student result = (from student in studentContext.Students where student.FacultyNumber.Equals(facultyNumber) select student).First();
            return result;
        }

        static public void DeleteStudentByFacultyNumber(string facultyNumber)
        {
            StudentContext studentContext = new StudentContext();

            Student delObj = (from student in studentContext.Students where student.FacultyNumber == facultyNumber select student).First();

            studentContext.Students.Remove(delObj);
            studentContext.SaveChanges();
        }
    }
}
