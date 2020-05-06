using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public class User
    {
        public Int32 UserId
        { get; set; }
        public String Username
        { get; set; }
        public String Password
        { get; set; }
        public String FacultyNumber
        { get; set; }
        public Int32 Role
        { get; set; }
        public DateTime Created
        { get; set; }
        public DateTime? ActiveTo
        { get; set; }
        public DateTime? LastTimeLogged
        { get; set; }

        public User() { 
            // nothing
        }

        public User(Int32 userId, String username, String password, String facultyNumber, Int32 role, DateTime created, DateTime activeTo, DateTime lastTimeLogged)
        {
            this.UserId = userId;
            this.Username = username;
            this.Password = password;
            this.FacultyNumber = facultyNumber;
            this.Role = role;
            this.Created = created;
            this.ActiveTo = activeTo;
            this.LastTimeLogged = lastTimeLogged;
        }

        public override string ToString()
        {
            return "User [ id: " + this.UserId + " username: " + this.Username + " password: "+ this.Password + " faculty Number: " + 
                this.FacultyNumber + " role: " + this.Role + " created: " + this.Created + " active to:" + this.ActiveTo + " last time logged " + 
                this.LastTimeLogged + " ]";
        }
    }
}
