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
                ResetTestStudentData(); 
                return _testStudents;
            }
            private set => _testStudents = value; 
        }

        static private void ResetTestStudentData()
        {
            _testStudents = new List<Student>();
            _testStudents.Add(new Student("Ivan", "Ivanov", "Georgiev", "FCST", "CSE", Qualification.BACHELOR, Status.ASSURED, "1234567890", "2", "10", "30"));
        }
    }
}
