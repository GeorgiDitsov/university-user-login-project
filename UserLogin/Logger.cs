using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace UserLogin
{
    static public class Logger
    {
        private const string logFileName = "test.txt";
        static private List<Logs> currentSessionActivities = new List<Logs>();

        static public void LogActivity(string activity)
        {
            Logs logs = new Logs(activity, DateTime.Now, LoginValidation.currentUserUsername, LoginValidation.currentUserRole);
            currentSessionActivities.Add(logs);
            SaveLogsToDb(logs);
            if (File.Exists(logFileName))
            {
                File.AppendAllText(logFileName, logs.ToString());
            }
        }

        private static void SaveLogsToDb(Logs logs)
        {
            LogsContext dbContext = new LogsContext();
            dbContext.Logs.Add(logs);
            dbContext.SaveChanges();
        }

        static public string ReadLoggFileContent()
        {
            StringBuilder sb = new StringBuilder();
            string[] lines = File.ReadAllLines(logFileName);
            foreach (string line in lines)
            {
                sb.Append(line + " \n");
            }
            return sb.ToString();
            // return File.ReadAllText(logFileName);
        }

        static public Logs GetCurrentSessionActivities()
        {
            Logs currentActivity = currentSessionActivities[currentSessionActivities.Count - 1];
            return currentActivity;
        }
    }
}
