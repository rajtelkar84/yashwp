using System.Collections.Generic;

namespace West.EnterpriseUX.Automation.MobileNew
{
    public class DataTransfer : AppiumSetup
    {
        public static IEnumerable<object[]> LoginDataObject()
        {
            return ExcelUtils.GetSheetData(@"C:\TestData\" + applicationEnvironment + "\\LoginData.xlsx", "LoginCredentials");
        }

        public static IEnumerable<object[]> InboxDataObject()
        {
            return ExcelUtils.GetSheetData(@"C:\TestData\" + applicationEnvironment + "\\InboxData.xlsx", "FunctionAndInbox");
        }

        public static IEnumerable<object[]> FilterDataObject()
        {
            return ExcelUtils.GetSheetData(@"C:\TestData\" + applicationEnvironment + "\\FilterData.xlsx", "FilterData");
        }

        public static IEnumerable<object[]> GridSearchDataObject()
        {
            return ExcelUtils.GetSheetData(projectDirectoryfull + "/TestData/" + applicationEnvironment + "/GridSearchData.xlsx", "GridSearchData");
        }

        public static IEnumerable<object[]> Details_252684()
        {
            return ExcelUtils.GetSheetData(projectDirectoryfull + "/TestData/" + applicationEnvironment + "/Details_252684.xlsx", "Details_252684");
        }

        public static IEnumerable<object[]> KPIs_252691()
        {
            return ExcelUtils.GetSheetData(projectDirectoryfull + "/TestData/" + applicationEnvironment + "/KPIs_252691.xlsx", "KPIs_252691");
        }

        public static IEnumerable<object[]> KPIs_252734()
        {
            return ExcelUtils.GetSheetData(projectDirectoryfull + "/TestData/" + applicationEnvironment + "/KPIs_252734.xlsx", "KPIs_252734");
        }

        public static IEnumerable<object[]> Charts_252697()
        {
            return ExcelUtils.GetSheetData(projectDirectoryfull + "/TestData/" + applicationEnvironment + "/Charts_252697.xlsx", "Charts_252697");
        }

        public static IEnumerable<object[]> Charts_252696()
        {
            return ExcelUtils.GetSheetData(projectDirectoryfull + "/TestData/" + applicationEnvironment + "/Charts_252696.xlsx", "Charts_252696");
        }
    }
}