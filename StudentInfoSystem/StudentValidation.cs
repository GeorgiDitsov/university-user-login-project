using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLogin;

namespace StudentInfoSystem
{
    static class StudentValidation
    {
        static public Student GetStudentDataByUser(User user) 
        {
            if (user.FacultyNumber.Equals(String.Empty)) 
            {
                throw new Exception("Faculty number field is empty");
            }
            foreach (Student student in StudentData.TestStudents)
            {
                if (student.FacultyNumber.Equals(user.FacultyNumber))
                {
                    return student;
                }
            }
            throw new Exception("There is no student assigned to this user");
        }
    }
}
