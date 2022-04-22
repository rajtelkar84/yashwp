using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace West.EnterpriseUX.Automation.MobileNew
{
    [TestClass]
    public class DashboardPageTest : AppiumSetup
    {
        [TestMethod]
        [TestCategory("DashboardPageTest")]
        [Description("Get Dashboard page source test")]
        [Owner("Girishwar.PatilEXTERNAL@westpharma.com")]
        [DynamicData(nameof(DataTransfer.LoginDataObject), typeof(DataTransfer), DynamicDataSourceType.Method)]
        public void PageSourceTest(string emailId, string password, string inbox)
        {
            Console.WriteLine(emailId + " : " + password);
            Console.WriteLine(driver.PageSource);
        }

        [TestMethod]
        [TestCategory("DashboardPageTest")]
        [Description("Open Inboxes page test")]
        [Owner("Girishwar.PatilEXTERNAL@westpharma.com")]
        [DynamicData(nameof(DataTransfer.LoginDataObject), typeof(DataTransfer), DynamicDataSourceType.Method)]
        public void OpenInboxesPageTest(string emailId, string password, string inbox)
        {
            Console.WriteLine(emailId + " : " + password + " : " + inbox);
            _basePageInstance.NavigateToInboxPage();
        }
    }
}
