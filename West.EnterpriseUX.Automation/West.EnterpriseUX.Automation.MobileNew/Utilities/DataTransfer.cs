﻿using System.Collections.Generic;

namespace West.EnterpriseUX.Automation.MobileNew
{
    public class DataTransfer : AppiumSetup
    {
        public static IEnumerable<object[]> LoginDataObject()
        {
           // return ExcelUtils.GetSheetData(@"C:\Users\patilg\source\repos\EnterpriseUX.Automation\West.EnterpriseUX.Automation\MobileAutomationCrossPlatform\TestData\UAT\LoginData.xlsx", "LoginCredentials");
            return ExcelUtils.GetSheetData(projectDirectoryfull + "/TestData/UAT/LoginData.xlsx", "LoginCredentials");
        }

        public static IEnumerable<object[]> InboxDataObject()
        {
            return ExcelUtils.GetSheetData(projectDirectoryfull + "/TestData/UAT/InboxData.xlsx", "FunctionAndInbox");
        }

        public static IEnumerable<object[]> FilterDataObject()
        {
            return ExcelUtils.GetSheetData(projectDirectoryfull + "/TestData/UAT/FilterData.xlsx", "FilterData");
        }
    }
}