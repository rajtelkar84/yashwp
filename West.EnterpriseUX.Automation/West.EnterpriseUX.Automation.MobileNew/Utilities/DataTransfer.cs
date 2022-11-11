﻿using System.Collections.Generic;

namespace West.EnterpriseUX.Automation.MobileNew
{
    public class DataTransfer : AppiumSetup
    {
        public static IEnumerable<object[]> LoginDataObject()
        {
            return ExcelUtils.GetSheetData(projectDirectoryfull + "/TestData/" + Constant.ENV_NAME + "/LoginData.xlsx", "LoginCredentials");
        }

        public static IEnumerable<object[]> InboxDataObject()
        {
            return ExcelUtils.GetSheetData(projectDirectoryfull + "/TestData/" + Constant.ENV_NAME + "/InboxData.xlsx", "FunctionAndInbox");
        }

        public static IEnumerable<object[]> FilterDataObject()
        {
            return ExcelUtils.GetSheetData(projectDirectoryfull + "/TestData/" + Constant.ENV_NAME + "/FilterData.xlsx", "FilterData");
        }

        public static IEnumerable<object[]> GridSearchDataObject()
        {
            return ExcelUtils.GetSheetData(projectDirectoryfull + "/TestData/" + Constant.ENV_NAME + "/GridSearchData.xlsx", "GridSearchData");
        }
    }
}