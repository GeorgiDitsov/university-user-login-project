using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    public class Student
    {
        public string FirstName;
        public string Surname;
        public string LastName;
        public string Faculty;
        public string Programme;
        public Qualification Qualification;
        public Status Status;
        public string FacultyNumber;
        public string Course;
        public string Stream;
        public string Group;

        public Student()
        {
            // nothing
        }

        public Student(string firstName, string surname, string lastName, string faculty, string programme, Qualification qualification, 
            Status status, string facultyNumber, string course, string stream, string group)
        {
            this.FirstName = firstName;
            this.Surname = surname;
            this.LastName = lastName;
            this.Faculty = faculty;
            this.Programme = programme;
            this.Qualification = qualification;
            this.Status = status;
            this.FacultyNumber = facultyNumber;
            this.Course = course;
            this.Stream = stream;
            this.Group = group;
        }

        public override string ToString()
        {
            return "Student [name = "+this.FirstName+" "+this.Surname+" "+this.LastName+", faculty number = "+this.FacultyNumber+"]";
        }
    }
}
