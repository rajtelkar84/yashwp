using System.Collections.Generic;

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

        public static IEnumerable<object[]> KPIs_252691()
        {
            return ExcelUtils.GetSheetData(projectDirectoryfull + "/TestData/" + Constant.ENV_NAME + "/KPIs_252691.xlsx", "KPIs_252691");
        }

        public static IEnumerable<object[]> Charts_252697()
        {
            return ExcelUtils.GetSheetData(projectDirectoryfull + "/TestData/" + Constant.ENV_NAME + "/Charts_252697.xlsx", "Charts_252697");
        }
    }
}