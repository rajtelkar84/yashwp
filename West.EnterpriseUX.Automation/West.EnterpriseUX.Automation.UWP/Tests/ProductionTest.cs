using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;

namespace West.EnterpriseUX.Automation.UWP.Tests
{
    /// <summary>
    /// Non-Functional Requirements Testing
    /// </summary>
    [TestCategory("Production")]
    [TestClass]
    public class ProductionTest : BaseTest
    {
        public Stopwatch stopwatch;

        #region TestMethods

        [TestMethod]
        [TestCategory("ProductionTest")]
        [Description("Verifies navigation to each inbox page and logs inbox status;;")]
        [Owner("vishnuprakash.muniswamy@westpharma.com")]
        public void TC_58788_CheckingBasicFunctionalityOfInboxesNavigationTes()
        {
            stopwatch = new Stopwatch();

            try
            {
                _homeAction.ClickReloadModules();
                _homeAction.NavigateToEachInboxFromEachFunction();
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
            finally
            {
                // Stop timer
                stopwatch.Stop();

                LogInfo($"Time elapsed for {TestContext.TestName}: {stopwatch.Elapsed}");
            }
        }



        #endregion

        #region OtherMethods

        

        #endregion

    }
    
}
