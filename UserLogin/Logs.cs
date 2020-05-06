using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserLogin
{
    public class Logs
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 LogsId
        { get; set; }

        public String Activity
        { get; set; }

        public DateTime Date
        { get; set; }

        public String Username
        { get; set; }

        public UserRoles UserRole
        { get; set; }

        public Logs()
        {
            // nothing
        }

        public Logs(String activity, DateTime date, String username, UserRoles userRole)
        {
            this.Activity = activity;
            this.Date = date;
            this.Username = username;
            this.UserRole = userRole;
        }

        public override string ToString()
        {
            return "Logs [ id: " + this.LogsId + " activity: " + this.Activity + " date: " + this.Date + " username: " + this.Username + 
                " user role: " + this.UserRole + " ]";
        }
    }
}
