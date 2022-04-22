using System;
using System.IO;

namespace West.EnterpriseUX.Automation.Mobile.Utilities
{
    public class Logger : Screenshot
    {
        public static void LogInfo(string infoMessage)
        {
            WriteToFile(string.Format("[Info]  {0} : {1}", DateTime.Now, infoMessage));
        }
        public static void LogError(string errorMessage)
        {
            WriteToFile(string.Format("[Error] {0} : {1}", DateTime.Now, errorMessage));
        }
        public static void WriteToFile(string message)
        {
            Console.WriteLine(message);
            string filePath = BaseTest.logsFolderPath + "\\" + $"UWPAppLogs{DateTime.Now.ToString("dd_MM_yyyy")}.txt";
            FileStream fs = new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.None);
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine(message);
                sw.WriteLine();
            }
        }

        public static void WriteToCSV(string logFileName, string content)
        {
            string filePath = BaseTest.logsFolderPath + logFileName;
            using (StreamWriter swOutputFile = new StreamWriter(new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.Read)))
            {
                swOutputFile.WriteLine("{0}", content);
                Console.WriteLine(content);
            }
        }
        public static void WriteTestResultToCSV(ResultTable resultTable)
        {
            string filePath = BaseTest.logsFolderPath + BaseTest.testResultsLogFileName;
            using (StreamWriter swOutputFile = new StreamWriter(new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.Read)))
            {
                swOutputFile.WriteLine($"{resultTable.TestName},{resultTable.TestOutcome},{resultTable.Duration},{resultTable.ErrorMessage},{resultTable.Screenshot}");
                Console.WriteLine($"{resultTable.TestName},{resultTable.TestOutcome},{resultTable.Duration},{resultTable.ErrorMessage},{resultTable.Screenshot}");
            }
        }

    }
}
