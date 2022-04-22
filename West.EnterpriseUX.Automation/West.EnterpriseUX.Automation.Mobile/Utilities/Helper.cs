using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace West.EnterpriseUX.Automation.Mobile.Utilities
{
    public class Helper
    {
        public string GenerateUniqueRandomNumber()
        {
            Random random = new Random();
            return DateTime.Now.ToString("ddMMyy") + random.Next(1, 100).ToString();
        }
        public void CreateFolder(string folderPath)
        {
            try
            {
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
        public void CheckFileExists(string completeFilePath)
        {
            Logger.LogInfo($"The expected file presence in this path {completeFilePath} : {File.Exists(completeFilePath)} ");
            if (!File.Exists(completeFilePath))
            {
                Logger.WriteToCSV(BaseTest.testResultsLogFileName, TestResultColumns.TestName + "," + TestResultColumns.TestOutcome + "," + TestResultColumns.Duration + "," + TestResultColumns.ErrorMessage + "," + TestResultColumns.Screenshot);
            }
        }
    }
}
