using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using West.EnterpriseUX.Automation.MobileNew.Pages;

namespace West.EnterpriseUX.Automation.MobileNew
{
    [TestClass]
    [TestCategory("FinaceMobileTest")]
    public class FinanceTests : AppiumSetup
    {
        [TestMethod]
        [TestCategory("InboxPageTest")]
        [Description("Verifying Inbox page navigation from Home Page;")]
        [Owner("rajkumar.telkarEXTERNAL@westpharma.com")]
        [DynamicData(nameof(DataTransfer.InboxDataObject), typeof(DataTransfer), DynamicDataSourceType.Method)]
        public void TC_252675_GoToSpecificInboxTest(string persona, string inbox, string searchRecord)
        {
            try
            {
                FinancePage financePage = _basePageInstance.NavigateToFinanceAction();
                financePage.NavigatetoInboxDetailsPage("Accounts Payable", "Invoices Inbox");


            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
                Console.WriteLine(ex.Message);
            }
        }
    }
}
