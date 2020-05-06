using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string LastName { get; set; }
        public string Faculty { get; set; }
        public string Programme { get; set; }
        public Qualification Qualification { get; set; }
        public Status Status { get; set; }
        public string FacultyNumber { get; set; }
        public string Course { get; set; }
        public string Stream { get; set; }
        public string Group { get; set; }

        public Student()
        {
            // nothing
        }

        public Student(int studentId, string firstName, string surname, string lastName, string faculty, string programme, Qualification qualification, 
            Status status, string facultyNumber, string course, string stream, string group)
        {
            this.StudentId = studentId;
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
