using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    class Program
    {
        static private void ActionOnError(string errorMsg)
        {
            Console.WriteLine("!!!" + errorMsg + "!!!");
        }

        static void Main(string[] args)
        {
            string logInMessage = "Hello, you are logged as ";
            Console.WriteLine("Enter username:");
            string username = Console.ReadLine();
            Console.WriteLine("Enter password:");
            string password = Console.ReadLine();
            User user = new User();
            LoginValidation loginValidation = new LoginValidation(username, password, ActionOnError);
            if (loginValidation.ValidateUserInput(ref user))
            {
                Console.WriteLine(user.ToString());
                switch (LoginValidation.currentUserRole)
                {
                    case UserRoles.ADMIN:
                        Console.WriteLine(logInMessage + "Admin.");
                        AdminMenu(user);
                        break;
                    case UserRoles.INSPECTOR:
                        Console.WriteLine(logInMessage + "Inspector.");
                        break;
                    case UserRoles.PROFESSOR:
                        Console.WriteLine(logInMessage + "Professor.");
                        break;
                    case UserRoles.STUDENT:
                        Console.WriteLine(logInMessage + "Student.");
                        break;
                    case UserRoles.ANONYMOUS:
                        Console.WriteLine("You aren't logged in.");
                        break;
                    default:
                        Console.WriteLine("Something went wrong");
                        break;
                }
            }
            Console.ReadLine();
        }

        static private bool AdminMenu(User user)
        {
            Console.WriteLine();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("0: Exit");
            Console.WriteLine("1: Change User role");
            Console.WriteLine("2: Change User activity");
            Console.WriteLine("3: List all Users");
            Console.WriteLine("4: Show log file");
            Console.WriteLine("5: Show current log activity");
            Console.Write("\r\nSelect an option: ");
            int option = int.Parse(Console.ReadLine());
            switch (option)
            {
                case 0: return false;
                case 1:
                    PrintAllUserRoles();
                    Console.WriteLine("Enter the new role of the User: ");
                    int roleOption = int.Parse(Console.ReadLine());
                    if (Enum.IsDefined(typeof(UserRoles), roleOption))
                    {
                        UserData.AssignUserRole(user.Username, (UserRoles)roleOption);
                    }
                    Console.WriteLine(user.Username + " " + user.Role);
                    return true;
                case 2:
                    Console.WriteLine("Enter new valid to Date: ");
                    string newDate = Console.ReadLine();
                    DateTime dt = DateTime.Parse(newDate);
                    UserData.SetUserActiveTo(user.Username, dt);
                    Console.WriteLine(user.ToString());
                    return true;
                case 3:
                    // TODO
                    return true;
                case 4:
                    string fileContent = Logger.ReadLoggFileContent();
                    Console.WriteLine(fileContent);
                    return true;
                case 5:
                    string currentLogActivity = Logger.GetCurrentSessionActivities();
                    Console.WriteLine(currentLogActivity);
                    return true;
                default:
                    return true;
            }
        }
        static private void PrintAllUserRoles()
        {
            foreach (UserRoles role in Enum.GetValues(typeof(UserRoles)))
            {
                Console.WriteLine((int)role+" "+role);
            }
        }
    }

    
}
