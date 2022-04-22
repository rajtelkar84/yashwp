using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;

namespace West.EnterpriseUX.Automation.UWP.Tests
{
    /// <summary>
    /// Non-Functional Requirements Testing
    /// </summary>
    [TestCategory("NFR")]
    [TestClass]
    public class NfrTest : BaseTest
    {
        public Stopwatch stopwatch;

        [ClassCleanup]
        public static void ClassCleanup()
        {
            Console.WriteLine("ClassCleanup started");
            try
            {
                if (_session != null)
                {
                    //Closes the Current Instance of the App
                    CloseCurrentAppInstance();
                }

                WaitForMoment(300);
            }
            catch (Exception ex)
            {
                LogError($"{ex.Message} : {ex.StackTrace}");
            }
            finally
            {
                LogInfo("Class ClassCleanup finished");
            }
        }

        #region TestMethods

        [TestMethod]
        [TestCategory("NFRTest")]
        [Description("Logs the memory usage of application for navigation from home to inbox page and vice versa for > 60 mins;;")]
        [Owner("vishnuprakash.muniswamy@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"NFR_61039.csv", "NFR_61039#csv", DataAccessMethod.Sequential)]
        public void TC_61039_MeasureMemoryUsageOfInboxNavigationTest()
        {
            stopwatch = new Stopwatch();

            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();

                // Begin timer
                stopwatch.Start();

                for (int i = 0; i < 75; i++)
                {
                    NavigateToInboxPage(function, inbox);
                    WaitForMoment(3);
                }
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

        [TestMethod]
        [TestCategory("NFRTest")]
        [Description("Logs the memory usage of application for switching between the inbox abstractions for > 180 mins;;")]
        [Owner("vishnuprakash.muniswamy@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"NFR_61039.csv", "NFR_61039#csv", DataAccessMethod.Sequential)]
        public void TC_64527_MeasureMemoryUsageOfInboxAbstractionsNavigationTest()
        {
            stopwatch = new Stopwatch();

            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();

                // Begin timer
                stopwatch.Start();

                for (int i = 0; i < 100; i++)
                {
                    NavigateToEachTab(function, inbox);
                    WaitForMoment(5);
                }

                // Stop timer
                stopwatch.Stop();

                LogInfo($"Time elapsed for {TestContext.TestName}: {stopwatch.Elapsed}");
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

        /// <summary>
        /// Generic Method to Navigate to Inbox Page
        /// </summary>
        /// <param name="function"></param>
        /// <param name="inbox"></param>
        public static void NavigateToInboxPage(string function, string inbox)
        {
            try
            {
                _homeAction.ClickOnFunction(function);
                WaitForMoment(10);
                _homeAction.ClickOnInboxesItem(inbox);
                WaitForMoment(10);

                int memorySize = MemoryUsageForProcess();
                LogInfo($"{DateTime.Now} : {memorySize}");
                LogMemoryUsage($"InboxPage Memory Usage : {DateTime.Now} : ");

                WaitForMoment(5);
                _inboxAction.ClickOnHomeActionsButton();
                WaitForMoment(2);
            }
            catch (Exception ex)
            {
                LogError($"{ex.Message} : {ex.StackTrace}");
                Assert.Fail(ex.Message);
            }
        }

        public static void NavigateToEachTab(string function, string inbox)
        {
            try
            {
                _homeAction.ClickOnFunction(function);
                WaitForMoment(10);
                _homeAction.ClickOnInboxesItem(inbox);
                WaitForMoment(10);
                _inboxAction.NavigateToTabs(true);
                WaitForMoment(5);

                int memorySize = MemoryUsageForProcess();
                LogInfo($"{DateTime.Now} : {memorySize}");
                LogMemoryUsage($"Tab Navigation Memory Usage : {DateTime.Now} : ");

                WaitForMoment(5);
                _inboxAction.ClickOnHomeActionsButton();
                WaitForMoment(5);
            }
            catch (Exception ex)
            {
                LogError($"{ex.Message} : {ex.StackTrace}");
                Assert.Fail(ex.Message);
            }
        }

        #endregion
    }
}
