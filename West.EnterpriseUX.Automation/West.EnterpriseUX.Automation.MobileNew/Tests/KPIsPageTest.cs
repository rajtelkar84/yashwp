using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;

namespace West.EnterpriseUX.Automation.MobileNew
{
    [TestClass]
    public class KPIsPageTest : AppiumSetup
    {
        [TestMethod]
        [TestCategory("KPIsPageTest")]
        [Description("Verifying Zoom In functionality for KPI;")]
        [Owner("Girishwar.PatilEXTERNAL@westpharma.com")]
        [DynamicData(nameof(DataTransfer.KPIs_252691), typeof(DataTransfer), DynamicDataSourceType.Method)]
        public void TC_252691_VerifyZoomInFunctionalityForKPITest(string persona, string inbox, string kpiName, string filterField1, string operator1, string filterValue1, string filterField2, string operator2, string filterValue2)
        {
            try
            {
                InboxPage inboxesTab = _basePageInstance.NavigateToInboxesTab();
                DetailsPage detailsPage = (DetailsPage)inboxesTab.SearchInboxAndSelectAbstraction(inbox, "Details");
                WaitForMoment(20);
                KpisPage kpisPage = inboxesTab.OpenKpisAbstraction();

                WaitForLoaderToDisappear(_basePageInstance.LoaderImage);

                kpisPage.SelectKPIToZoom(kpiName);
                kpisPage.VerifyKpiPageTitle(kpiName);
                _basePageInstance.BackButton[0].Click();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
                Console.WriteLine(ex.Message);
            }
        }


    }
}
