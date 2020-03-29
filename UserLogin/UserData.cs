using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    static public class UserData
    {
        static private List<User> _testUsers;
        static public List<User> TestUsers
        {
            get {
                ResetTestUserData();
                return _testUsers;
            }
            set { }
        }

        static private void ResetTestUserData()
        {
            _testUsers = new List<User>();
            _testUsers.Add(new User("Goshko123", "45678", String.Empty, (Int32)UserRoles.ADMIN, DateTime.Now, DateTime.MaxValue, DateTime.Now));
            _testUsers.Add(new User("Student1", "Some pass", "1234567890", (Int32)UserRoles.STUDENT, DateTime.Now, DateTime.MaxValue, DateTime.Now));
            _testUsers.Add(new User("Student2", "stupidPassword", "1234567891", (Int32)UserRoles.STUDENT, DateTime.Now, DateTime.MaxValue, new DateTime(2020, 2, 1, 0, 0, 0)));
        }

        static public User IsUserPassCorrect(String username, String password)
        {
            User foundUser = FindUserByUsername(username);
            if (foundUser != null && foundUser.Password.Equals(password))
            {
                return foundUser;
            }
            return null;
        }

        static public void SetUserActiveTo(string username, DateTime newValidUntilDate)
        {
            User foundUser = FindUserByUsername(username);
            if(foundUser != null)
            {
                foundUser.ValidUntil = newValidUntilDate;
                Logger.LogActivity("Changing activity of user " + username);
            }
        }

        static public void AssignUserRole(string username, UserRoles newRole)
        {
            User foundUser = FindUserByUsername(username);
            if(foundUser != null)
            {
                foundUser.Role = Convert.ToInt32(newRole);
                Logger.LogActivity("Chaging role of user " + username);
            }
        }

        static private User FindUserByUsername(string username)
        {
            foreach(User user in _testUsers)
            {
                if(user.Username.Equals(username))
                {
                    return user;
                }
            }
            return null;
        }
    }
}
