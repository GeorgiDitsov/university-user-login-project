using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace UserLogin
{
    static class Logger
    {
        private const string logFileName = "test.txt";
        static private List<string> currentSessionActivities = new List<string>();

        static public void LogActivity(string activity)
        {
            string activityLine = DateTime.Now + ";"
                + LoginValidation.currentUserUsername + ";"
                + LoginValidation.currentUserRole + ";"
                + activity;
            currentSessionActivities.Add(activityLine);
            if (File.Exists(logFileName))
            {
                File.AppendAllText(logFileName, activityLine);
            }
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

        static public string GetCurrentSessionActivities()
        {
            string currentActivity = currentSessionActivities[currentSessionActivities.Count - 1];
            return currentActivity;
        }
    }
}
