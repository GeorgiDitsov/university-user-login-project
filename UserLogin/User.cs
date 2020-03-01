using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    class User
    {
        public String Username
        { get; set; }
        public String Password
        { get; set; }
        public String FacNumber
        { get; set; }
        public Int32 Role
        { get; set; }
        public DateTime Created;
        public DateTime ValidUntil;

        public User() { 
            // nothing
        }

        public User(String username, String password, String facNumber, Int32 role, DateTime created, DateTime validUntil)
        {
            this.Username = username;
            this.Password = password;
            this.FacNumber = facNumber;
            this.Role = role;
            this.Created = created;
            this.ValidUntil = validUntil;
        }

        public override string ToString()
        {
            return "User [ username: " + this.Username + " password: "+ this.Password + " faculty Number: "+ this.FacNumber + " role: " + Role + 
                " created: "+ Created + " valid until:" + ValidUntil +" ]";
        }
    }
}
