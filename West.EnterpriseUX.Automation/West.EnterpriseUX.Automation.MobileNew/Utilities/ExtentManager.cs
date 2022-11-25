using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using System;
using System.IO;

namespace West.EnterpriseUX.Automation.MobileNew
{
    public class ExtentManager : AppiumSetup
    {
        private static ExtentReports extentInstance;
        private static String timestamp = DateTime.Now.ToString("ddd, dd-MM-yyyy, HH.mm.ss tt");
        private static string docummentsFolderPath = String.Empty;
        private static string documentsDirectory = String.Empty;
        private static String reportFilepath = String.Empty;
        private static String reportFileLocation = String.Empty;

        public static ExtentReports GetInstance()
        {
            if (extentInstance == null)
                CreateInstance();
            return extentInstance;
        }

        //Create an extent report instance
        public static ExtentReports CreateInstance()
        {
            String fileName = String.Empty;

            if (laptopName.ToUpper().Equals("WINDOWS"))
            {
                docummentsFolderPath = "OneDrive - West Pharmaceutical Services, Inc\\Documents";
                documentsDirectory = Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), docummentsFolderPath);
                reportFilepath = documentsDirectory + "\\ExtentReports\\" + timestamp;
                reportFileLocation = reportFilepath + "\\" + timestamp;
                fileName = GetReportPath(reportFilepath);
            }
            else
            {
                docummentsFolderPath = "/Documents";
                documentsDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + docummentsFolderPath;
                reportFilepath = documentsDirectory + "/ExtentReports/" + timestamp;
                reportFileLocation = reportFilepath + "/" + timestamp;
                fileName = GetReportPath(reportFilepath);
            }
            
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(fileName);

            htmlReporter.Config.DocumentTitle = timestamp;
            htmlReporter.Config.ReportName = timestamp;
            htmlReporter.Config.Theme = Theme.Standard;
            htmlReporter.Config.Encoding = "utf-8";

            extentInstance = new ExtentReports();
            extentInstance.AttachReporter(htmlReporter);

            //Adding environment details
            extentInstance.AddSystemInfo("Environment", EnvName);
            extentInstance.AddSystemInfo("Platform", PlatformName);
            extentInstance.AddSystemInfo("Laptop OS", laptopName);

            return extentInstance;
        }

        //Create the report path
        private static String GetReportPath(String path)
        {
            if (!Directory.Exists(path))
            {
                var testDirectory = Directory.CreateDirectory(path);

                if (testDirectory != null)
                {
                    Console.WriteLine("Directory: " + path + " is created!");
                    return reportFileLocation;
                }
                else
                {
                    Console.WriteLine("Failed to create directory: " + path);
                    return projectDirectoryfull;
                }
            }
            else
            {
                Console.WriteLine("Directory already exists: " + path);
            }
            return reportFileLocation;
        }
    }
}
