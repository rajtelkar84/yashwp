using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
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
        [Description("Verifying Invoices Inbox Details are loading properly;")]
        [Owner("rajkumar.telkarEXTERNAL@westpharma.com")]
        [DynamicData(nameof(DataTransfer.AccountPayableNavigation), typeof(DataTransfer), DynamicDataSourceType.Method)]
        public void TC_252675_InvoicesInboxDetails(string persona, string inbox)
        {
            try
            {
                IList<IWebElement> loader = _basePageInstance.LoaderImage;
                FinancePage financePage = _basePageInstance.NavigateToFinanceAction();
                
                WaitForLoaderToDisappear(loader);
                financePage.NavigatetoInboxDetailsPage(persona,inbox);
                WaitForLoaderToDisappear(loader);
                financePage.clickonDetailsTab();
                WaitForLoaderToDisappear(loader);
                var detailspage = financePage.pagedetailscheck(inbox);

                Assert.AreEqual("Invoices Inbox",detailspage.pageTitle);
               // Assert.IsTrue(detailspage.ActionButton > 0);
                Assert.IsTrue(detailspage.viewDetailsButton > 0);
              //  Assert.IsTrue(detailspage.allListinDetails > 0);
                Assert.IsTrue(detailspage.sortButton > 0);
                Assert.IsTrue(detailspage.filterButton > 0);

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
                Console.WriteLine(ex.Message);
            }
        }
    }
}
