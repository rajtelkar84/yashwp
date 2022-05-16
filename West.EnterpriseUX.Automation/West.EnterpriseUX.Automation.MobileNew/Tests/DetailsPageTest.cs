using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace West.EnterpriseUX.Automation.MobileNew
{
    [TestClass]
    public class DetailsPageTest : AppiumSetup
    {
        [TestMethod]
        [TestCategory("DetailsPageTest")]
        [Description("Verifying the Page Scrolling functionality;")]
        [Owner("Girishwar.PatilEXTERNAL@westpharma.com")]
        [DynamicData(nameof(DataTransfer.InboxDataObject), typeof(DataTransfer), DynamicDataSourceType.Method)]
        public void TC_252677_PageScrollingFunctionalityTest(string persona, string inbox, string searchRecord)
        {
            try
            {
                InboxPage inboxPage = _basePageInstance.NavigateToInboxPage();
                DetailsPage detailsPage = inboxPage.PerformGlobalSearch(persona, inbox, searchRecord);

                WaitForLoaderToDisappear(_basePageInstance.LoaderImage);

                bool isPageScrolledTillTheEndOfDetailsPage = detailsPage.VerifyScrollingFunctionalityOnDetailsPage();
                Assert.IsTrue(isPageScrolledTillTheEndOfDetailsPage);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
                Console.WriteLine(ex.Message);
            }
        }
    }
}
