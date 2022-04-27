using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace West.EnterpriseUX.Automation.MobileNew.Utilities
{
    public class ExtentManager : AppiumSetup
    {
        private static ExtentReports extentInstance;
        private static String timestamp = DateTime.Now.ToString("ddd, dd-MM-yyyy, HH-mm-ss, tt");
        private static String reportFilepath = projectDirectoryfull + "/ExtentReports/" + timestamp;
        private static String reportFileLocation = reportFilepath + "/" + timestamp;

        public static ExtentReports GetInstance()
        {
            if (extentInstance == null)
                CreateInstance();
            return extentInstance;
        }

        //Create an extent report instance
        public static ExtentReports CreateInstance()
        {
            String fileName = GetReportPath(reportFilepath);

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
