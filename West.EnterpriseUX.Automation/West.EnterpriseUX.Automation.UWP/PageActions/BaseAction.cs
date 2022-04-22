using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using West.EnterpriseUX.Automation.UWP.PageObjects;
using West.EnterpriseUX.Automation.UWP.Utilities;

namespace West.EnterpriseUX.Automation.UWP.PageActions
{
    public class BaseAction : Logger
    {
        protected WindowsDriver<WindowsElement> Session { get; set; }
        public static RemoteTouchScreen _touchScreen;
        public Actions _mouseActions;
        private readonly BasePage _pageInstance;

        public BaseAction(WindowsDriver<WindowsElement> _session)
        {
            Session = _session;
            _mouseActions = new Actions(_session);
            _touchScreen = new RemoteTouchScreen(Session);
            Session.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            _pageInstance = new BasePage(_session);
        }

        public static string logFileName = "Logger_" + $"{DateTime.Now:dd_MM_yyyy_hh_mm_ss}" + ".csv";
        protected WindowsElement WaitForElementToExist(Func<string, WindowsElement> findElement, string elementName, int waitTime = 10)
        {
            WindowsElement result = null;
            var timer = new Stopwatch();
            timer.Start();
            do
            {
                try
                {
                    WindowsElement elem = findElement(elementName);
                    if (elem != null)
                    {
                        result = elem;
                        break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                }

                Thread.Sleep(100);
            } while (timer.Elapsed < TimeSpan.FromSeconds(waitTime));

            return result;
        }
        protected static bool CurrentWindowIsAlive(WindowsDriver<WindowsElement> remoteSession)
        {
            bool windowIsAlive = false;

            if (remoteSession != null)
            {
                try
                {
                    windowIsAlive = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return windowIsAlive;
        }
        public static void WriteToCSV(string content)
        {
            WriteToCSV(BaseTest.inboxesMemoryUtilizationLogFileName, content);
        }
        public static void WaitForMoment(int delay)
        {
            Thread.Sleep(delay * 1000);
            LogInfo("Waited for '"+ delay.ToString() + "' seconds");
        }
        public static void WaitForMoment(double delay)
        {
            Thread.Sleep(Convert.ToInt32(delay * 1000));
        }
        public void MouseClickOnCenterOfWindowsElement(WindowsElement element)
        {
            int height = element.Size.Height;
            int width = element.Size.Width;
            WaitForMoment(1);
            _mouseActions.MoveToElement(element, width / 2, height / 2);
            WaitForMoment(1);
            _mouseActions.Click().Build().Perform();
        }
        public void MouseClickOnBottomCenterOfWindowsElement(WindowsElement element)
        {
            int height = element.Size.Height;
            int width = element.Size.Width;
            WaitForMoment(1);
            _mouseActions.MoveToElement(element, width / 2, height);
            WaitForMoment(1);
            _mouseActions.Click().Build().Perform();
        }
        public void ScrollToElement(string windowsElement)
        {
            IList<WindowsElement> windowsElements = _pageInstance.GetElementByText(windowsElement);

            if (windowsElements.Count > 0)
            {
                if (!windowsElements[0].Displayed)
                {
                    WaitForLoadingToDisappear();
                    ScrollByCount(3, windowsElement);
                }
                else
                {
                    LogInfo($"Element by Name: {windowsElement} found without scrolling in 1st attempt");
                }
            }
            else
            {
                WaitForLoadingToDisappear();
                ScrollByCount(3, windowsElement);
            }
        }
        public void ScrollVertically(int offsetX = 0, int offsetY = -100, int index = 0)
        {
            try
            {
                IList<WindowsElement> verticalScrollBar = Session.FindElementsByAccessibilityId("VerticalScrollBar").ToList();
                _touchScreen.Scroll(verticalScrollBar[index].Coordinates, offsetX, offsetY);
            }
            catch (Exception ex)
            {
                LogError($"Error in scoliing the element: {ex.Message}");
            }
        }
        public void ScrollTillEnd()
        {
            int errorCount = 0;
            do
            {
                try
                {
                    WaitForMoment(1);
                    IList<WindowsElement> allKPIFavorites = Session.FindElementsByAccessibilityId("Favourite").Where(u => u.Displayed.Equals(true)).ToList();
                    if (allKPIFavorites[0].Displayed)
                    {
                        MouseHoverOnWindowsElement(allKPIFavorites[0]);

                        for (int i = 0; i < 4; i++)
                        {
                            ScrollVertically(index: 1);

                            allKPIFavorites = Session.FindElementsByAccessibilityId("Favourite").Where(u => u.Displayed.Equals(true)).ToList();
                            MouseHoverOnWindowsElement(allKPIFavorites[0]);
                        }
                    }
                    errorCount = 0;
                }
                catch (Exception ex)
                {
                    LogError(ex.Message);
                    errorCount++;
                    if (errorCount == 4)
                    {
                        throw new Exception(ex.Message);
                    }
                    LogInfo($"Scrolling down, attempt: {errorCount}");
                }
            } while (errorCount != 0 && errorCount < 5);
        }
        public void ScrollByOffSet(int xAxisOffset=0, int yAxisOffset=-100)
        {
            try
            {
                _touchScreen.Scroll(xAxisOffset, yAxisOffset);
            }
            catch (Exception ex)
            {
                LogError(ex.Message);
                LogInfo($"Issue in Scrolling by OffSet values");
            }
        }
        public void TakeScreenshot(string screenshotName)
        {
            CaptureScreenShot(Session, screenshotName);
        }
        public void DeleteDataFromAbstractions()
        {
            int totalDeleteCount = 0;
            WaitForMoment(1);
            IList<WindowsElement> abstractionsTotalData = _pageInstance.MoreImage;
            IList<WindowsElement> abstractionsDisplayedData = _pageInstance.MoreImage.Where(d => d.Displayed.Equals(true)).ToList();
            try
            {
                do
                {
                    if (abstractionsDisplayedData.Count == 0 && abstractionsTotalData.Count > abstractionsDisplayedData.Count)
                    {
                        ScrollTillEnd();
                        abstractionsDisplayedData = _pageInstance.MoreImage.Where(d => d.Displayed.Equals(true)).ToList();
                    }

                    if (abstractionsDisplayedData.Count > 0 && abstractionsDisplayedData[0].Displayed)
                    {
                        _touchScreen.SingleTap(abstractionsDisplayedData[0].Coordinates);
                        WaitForMoment(1);
                        IList<WindowsElement> deleteOption = _pageInstance.GetElementByText("Delete");
                        WaitForMoment(1);
                        if (deleteOption.Count > 0)
                        {
                            _touchScreen.SingleTap(deleteOption[0].Coordinates);
                            WaitForMoment(1);
                            WindowsElement confirmationYesButton = _pageInstance.ConfirmationYesButton;
                            MouseClickOnWindowsElement(confirmationYesButton);
                            WaitForMoment(1);
                            WaitForLoadingToDisappear(LoadingText.Removing.ToString());
                            totalDeleteCount++;
                        }
                    }
                    abstractionsDisplayedData = _pageInstance.MoreImage.Where(d => d.Displayed.Equals(true)).ToList();

                } while (abstractionsDisplayedData.Count != 0 && totalDeleteCount <= 10);

                LogInfo($"Total Deleted KPI/Charts : {totalDeleteCount}");
            }
            catch (Exception ex)
            {
                LogError($"{ex.Message} : {ex.StackTrace}");
            }
        }
        public void MouseClickOnWindowsElement(WindowsElement element)
        {
            if (element != null)
                _touchScreen.SingleTap(element.Coordinates);
            else
                LogInfo($"WindowsElement by Name/Test : {element.Text} value is null, so not able to perform click operation");
        }
        public void MouseHoverOnWindowsElement(WindowsElement element)
        {
            if (element != null)
            {
                _mouseActions.MoveToElement(element);
                _mouseActions.Build().Perform();
            }
            else
                LogInfo($"WindowsElement by Name/Test : {element.Text} value is null, so not able to perform click operation");
        }
        public void WaitForLoadingToDisappear(string loadingText = null)
        {
            if (String.IsNullOrEmpty(loadingText))
            {
                _pageInstance.WaitForLoaderToDisappear();
            }
            else
            {
                _pageInstance.WaitForLoaderToDisappear(loadingText);
            }
            LogInfo("Waited for the Loader to disappear");
        }
        public void WaitForElementToAppear(string elementName)
        {
            if (!String.IsNullOrEmpty(elementName))
            {
                _pageInstance.WaitForElementToAppear(elementName);
            }
        }
        public void ScrollByCount(int count, string windowsElement="Test")
        {
            int errorCount = 0;
            do
            {
                try
                {
                    WaitForMoment(1);
                    IList<WindowsElement> allKPIFavorites = Session.FindElementsByAccessibilityId("Favourite").Where(u => u.Displayed.Equals(true)).ToList();
                    if (allKPIFavorites[0].Displayed)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            IList<WindowsElement> loadMoreOption = _pageInstance.LoadMoreButton;

                            if (loadMoreOption.Count > 0)
                            {
                                loadMoreOption[0].Click();
                            }
                            else
                            {
                                if (allKPIFavorites.Count > 0)
                                {
                                    MouseHoverOnWindowsElement(allKPIFavorites[0]);
                                    ScrollVertically(index: 1);
                                }

                                allKPIFavorites = Session.FindElementsByAccessibilityId("Favourite").Where(u => u.Displayed.Equals(true)).ToList();
                                if (allKPIFavorites.Count > 0)
                                {
                                    MouseHoverOnWindowsElement(allKPIFavorites[0]);
                                }
                            }
                        }
                    }
                    errorCount = 0;
                }
                catch (Exception ex)
                {
                    LogError(ex.Message);
                    errorCount++;
                    if (errorCount == 5)
                    {
                        LogInfo($"Element by Name: {windowsElement} Not found after scrolling {errorCount} times");
                    }
                    LogInfo($"Scrolling down, attempt: {errorCount}");
                }
            } while (errorCount != 0 && errorCount < 5);
        }
        public void VerifyInvisibilityOfErrorMessages()
        {
            IList<WindowsElement> emptyErrorTemplate = _pageInstance.EmptyErrorTemplates;

            if (emptyErrorTemplate.Count > 0)
            {
                IList<WindowsElement> emptyImages = _pageInstance.EmptyImage;
                IList<WindowsElement> emptylabels = _pageInstance.EmptyLabel;
                IList<WindowsElement> errorImages = _pageInstance.ErrorImage;
                IList<WindowsElement> errorlabels = _pageInstance.ErrorLabel;
                IList<WindowsElement> dailogPopUp = _pageInstance.DialogPopUp;

                if (dailogPopUp.Count > 0)
                {
                    Assert.Fail($"Dailog Pop-up is displaying when tried to navigate to current page with message : {dailogPopUp[0].Text}.");
                }
                else if (emptyImages.Count > 0)
                {
                    if (emptylabels.Count > 0)
                    {
                        LogInfo($"Empty Image is detected. Data is not getting displayed in the current page. Empty Label message : {emptylabels[0].Text}.");
                    }
                    else
                    {
                        LogInfo($"Empty Image is detected. Data is not getting displayed in the current page.");
                    }
                }
                else if (errorImages.Count > 0)
                {
                    if (errorlabels.Count > 0)
                    {
                        Assert.Fail($"Error Image is detected. Data is not getting displayed in the current page. Error Label message : {errorlabels[0].Text}.");
                    }
                    else
                    {
                        Assert.Fail($"Error Image is detected. Data is not getting displayed in the current page.");
                    }
                }
            }
            else
            {
                LogInfo($"Empty Image, Empty Label, Error Image, Error Label and Error Dialog is not getting displayed in the current page.");
            }
        }
        public void LogAppMemoryUsage(string content)
        {
            try
            {
                if (content.Contains("TestCleanup"))
                {
                    WriteToCSV(BaseTest.inboxesMemoryUtilizationLogFileName, content + Environment.NewLine);
                }
                else
                {
                    WriteToCSV(BaseTest.inboxesMemoryUtilizationLogFileName, content);
                }
            }
            catch (Exception ex)
            {
                LogError($"Exception occurred while extracting Memory usage by a process : { ex.Message} : { ex.StackTrace}");
                Console.WriteLine("Exception occurred while extracting Memory usage by a process" + ex.Message.ToString() + ex.StackTrace.ToString());
            }
        }

        #region CommonActions
        public static Boolean Exists(WindowsElement windowElement)
        {
            bool temp = false;
            try
            {
                if (windowElement.Displayed)
                {
                    temp = true;
                }
                else
                {
                    temp = false;
                }
            }
            catch (Exception)
            {
                temp = false;
            }
            return temp;
        }

        public static void ClickElement(WindowsElement windowElement)
        {
            try
            {
                windowElement.Click();
            }
            catch (Exception element)
            {
                Assert.Fail("Problem in clicking the element " + element);
            }
        }

        public static void ClickClearEnterText(WindowsElement windowElement,String value)
        {
            ClickElement(windowElement);
            ClearElement(windowElement);
            EnterText(windowElement, value);
        }

        public static string SelectFirstValueInDropDown(WindowsElement windowElement,string attribute)
        {
            string selectedValue = string.Empty;
            ClearElement(windowElement);
            ClickElement(windowElement);
            WaitForMoment(.25);
            EnterText(windowElement, Keys.Down);
            WaitForMoment(.25);
            EnterText(windowElement, Keys.Down);
            WaitForMoment(.25);
            EnterText(windowElement, Keys.Return);
            WaitForMoment(.25);
            selectedValue = GetAttribute(windowElement, attribute);
            return selectedValue;
        }

        


        public static void ClearElement(WindowsElement windowElement)
        {
            try
            {
                windowElement.Clear();
            }
            catch (Exception element)
            {
                Assert.Fail("Problem in clicking the element " + element);
            }
        }

        public static void ClearBySelectingValue(WindowsElement windowElement)
        {
            windowElement.SendKeys(Keys.Control + "a");
            windowElement.SendKeys(Keys.Control + "a");
            windowElement.SendKeys(Keys.Delete);
            windowElement.SendKeys(Keys.Delete);

        }

        public static void ClickBackspace(WindowsElement windowElement)
        {
            windowElement.SendKeys(Keys.Backspace);
            

        }

        public static void EnterText(WindowsElement windowElement, String inputValue)
        {
            try
            {
                windowElement.SendKeys(inputValue);
            }
            catch (Exception element)
            {
                Assert.Fail("Problem in entering the element " + element);
            }
        }

        public static void waitTillElementDissappear(WindowsElement element)
        {
            try
            {
                int temp = 0;
                while (Exists(element))
                {
                    WaitForMoment(1);
                    temp = temp + 1;
                    if (temp == 10)
                    {
                        Assert.Fail("Waited till 120 seconds still the elememt is present" + element.Text);
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                Assert.Fail("problem in waiting till element exist" + e);
            }
        }

        public static string GetDateTimeRelpaceSlashWithUnderscore()
        {
            try
            {
                return Convert.ToString(DateTime.Now).Replace("/", "_").Replace(":", "_").Replace(" ", "_");

            }
            catch (Exception e)
            {
                Assert.Fail("Problem in getting Date time " + e);
                return "";
            }
        }

        public static string GetDateInFormat(DateTime date, String format)
        {
            try
            {
                return date.ToString(format);

            }
            catch (Exception e)
            {
                Assert.Fail("Problem in getting Date time " + e);
                return "";
            }
        }

        public static string GetDateFastOrFutureInFormat(DateTime date, String format,int addDays)
        {
            try
            {
                return date.AddDays(addDays).ToString(format);

            }
            catch (Exception e)
            {
                Assert.Fail("Problem in getting Date time " + e);
                return "";
            }
        }

        public static string DirectoryPat()
        {
            try
            {
                string currentDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location).ToString();
                return currentDirectory;
            }
            catch (Exception e)
            {
                Assert.Fail("Problem in getting Directory path" + e);
                return "";
            }
        }

        public static void SplitAndEnterText(WindowsElement windowElement, String inputValue)
        {
            try
            {
                string[] test = Regex.Split(inputValue, string.Empty);

                foreach (string s in test)
                {
                    WaitForMoment(0.1);
                    windowElement.SendKeys(s);
                }
            }
            catch (Exception element)
            {
                Assert.Fail("Problem in clicking the element " + element);
            }
        }

        public int CountNumFilesInTheFolder(String searchDir, String fileExtention)
        {
            try
            {
                return Directory.GetFiles(searchDir, "*" + fileExtention, SearchOption.AllDirectories).Length;
            }
            catch (Exception)
            {
                Assert.Fail();
                return -1;
            }
        }

        public static string GetAttribute(WindowsElement windowElement,String attribute)
        {
            try
            {
                return windowElement.GetAttribute(attribute);
            }
            catch (Exception )
            {
                //Assert.Fail("Problem in getting attribute the element " +attribute+ element);
                return "";
            }
        }

        public static string WordInBetween(string sentence, string wordOne, string wordTwo)
        {
            int start = sentence.IndexOf(wordOne) + wordOne.Length + 1;
            int end = sentence.IndexOf(wordTwo) - start - 1;
            return sentence.Substring(start, end);
        }
        public List<String> GetFirstRowValues()
        {
            List<String> values = new List<String>();
            IList<WindowsElement> rowValues = _pageInstance.ValuebyRowAndColumnInGrid();
            if (rowValues.Equals(null))
            {
                rowValues = _pageInstance.ValuebyRowAndColumnInGrid();
            }
            for (int i = 0; i < rowValues.Count; i++)
            {
                values.Add(rowValues[i].Text);
            }

            return values;
        }
        public List<String> GetRowValues(int rowNumber)
        {
            List<String> values = new List<String>();
            IList<WindowsElement> rowValues = _pageInstance.ValuebyRowAndColumnInGrid(Convert.ToString(rowNumber));
            if (rowValues.Equals(null))
            {
                rowValues = _pageInstance.ValuebyRowAndColumnInGrid(Convert.ToString(rowNumber));
            }
            for (int i = 0; i < rowValues.Count; i++)
            {
                values.Add(rowValues[i].Text);
            }

            return values;
        }
    }
    #endregion

    public static class StringExtensions
    {
        public static bool IsNumeric(this string input)
        {
            return Regex.IsMatch(input, @"^\d+$");
        }
    }

}
