using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using West.EnterpriseUX.Automation.UWP.Utilities;

namespace West.EnterpriseUX.Automation.UWP.PageObjects
{
    public class BasePage : Logger
    {
        protected WindowsDriver<WindowsElement> Session { get; set; }
        protected WebDriverWait wait;

        public BasePage(WindowsDriver<WindowsElement> session)
        {
            Session = session;
            wait = new WebDriverWait(Session, TimeSpan.FromSeconds(5));
            Session.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        #region Generic Methods
        public static void WaitForMoment(int delay)
        {
            Thread.Sleep(delay * 1000);
        }
        public static void WaitForMoment(double delay)
        {
            Thread.Sleep(Convert.ToInt32(delay * 1000));
        }
        public IList<WindowsElement> FindElements(string locator)
        {
            IList<WindowsElement> windowsElements = null;
            string locatorType = string.Empty;
            string locatorValue = string.Empty;

            try
            {
                string[] xpathExpression = locator.Split(new char[] { ':' }, 2);
                locatorType = xpathExpression[0];
                locatorValue = xpathExpression[1];

                if (Session.WindowHandles.Count > 0)
                {
                    switch (locatorType)
                    {
                        case "Name":
                            windowsElements = Session.FindElementsByName(locatorValue);
                            break;
                        case "ClassName":
                            windowsElements = Session.FindElementsByClassName(locatorValue);
                            break;
                        case "AccessibilityId":
                            windowsElements = Session.FindElementsByAccessibilityId(locatorValue).ToList();
                            break;
                        case "XPath":
                            windowsElements = Session.FindElementsByXPath(locatorValue);
                            break;
                        default:
                            Console.WriteLine("Search field is not found");
                            return null;
                    }
                }
                else
                {
                    LogInfo($"WindowHandles count = {Session.WindowHandles.Count}");
                }
            }
            catch (InvalidOperationException ex)
            {
                LogError($"Elements not found with the {locatorType}:{locatorValue} Exception: {ex.Message} : {ex.StackTrace}");
                throw new InvalidOperationException($"Elements not found with the {locatorType}:{locatorValue} \n Exception: {ex.Message}");
            }
            catch (Exception ex)
            {
                LogError($"Elements not found with the {locatorType}:{locatorValue} Exception: {ex.Message} : {ex.StackTrace}");
                throw new Exception($"Elements not found with the {locatorType}:{locatorValue} \n Exception: {ex.Message}");
            }
            return windowsElements;
        }
        public WindowsElement FindElement(string locator)
        {
            WaitForMoment(1);
            WindowsElement windowsElement = null;
            string locatorType = string.Empty;
            string locatorValue = string.Empty;
            int attempt = 0;

            string[] xpathExpression = locator.Split(new char[] { ':' }, 2);
            locatorType = xpathExpression[0];
            locatorValue = xpathExpression[1];

            try
            {
                do
                {
                    if (Session.WindowHandles.Count > 0)
                    {
                        try
                        {
                            switch (locatorType)
                            {
                                case "Name":
                                    windowsElement = Session.FindElementByName(locatorValue);
                                    break;
                                case "ClassName":
                                    windowsElement = Session.FindElementByClassName(locatorValue);
                                    break;
                                case "AccessibilityId":
                                    windowsElement = Session.FindElementByAccessibilityId(locatorValue);
                                    break;
                                case "XPath":
                                    windowsElement = Session.FindElementByXPath(locatorValue);
                                    break;
                                default:
                                    Console.WriteLine("Search field is not found");
                                    return null;
                            }
                            attempt = 0;
                        }
                        catch (Exception ex)
                        {
                            LogError(ex.Message);
                            attempt++;
                            if (attempt == 3)
                            {
                                LogError($"Elements not found with the {locatorType}:{locatorValue} Exception: {ex.Message} : {ex.StackTrace}");
                                throw new Exception(ex.Message + "[" + locator + "]");
                            }
                            LogInfo($"Finding element by {locatorType}:{locatorValue} attempt no: {attempt}");
                            WaitForMoment(1);
                        }
                    }
                    else
                    {
                        LogInfo($"WindowHandles count = {Session.WindowHandles.Count}");
                        attempt++;
                    }
                } while (attempt != 0 && attempt < 3);

                if (attempt == 3)
                {
                    LogInfo($"WindowHandles count = {Session.WindowHandles.Count}");
                    LogError($"Elements not found with the {locatorType}:{locatorValue}");
                    Assert.Fail($"Element not found with the {locatorType}:{locatorValue}");
                }
            }
            catch (Exception ex)
            {
                LogError($"Exception: {ex.Message} : {ex.StackTrace}");
                Assert.Fail($"Exception: { ex.Message} : { ex.StackTrace}");
            }
            return windowsElement;
        }
        public bool WaitForElementUntilInvisible(string attribute, int timeout = 5)
        {
            bool isPresent;
            int attempt = 0;
            try
            {
                do
                {
                    try
                    {
                        IList<WindowsElement> element = FindElements(attribute);
                        isPresent = element.Count > 0;
                        WaitForMoment(1);
                        timeout--;
                        attempt++;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Windows Element is not present");
                        isPresent = false;
                    }

                } while (isPresent && timeout != 0);
                if (timeout == 0)
                {
                    Console.WriteLine($"Search Windows Element is still visbile with timeout of {attempt} seconds");
                }
                else
                {
                    Console.WriteLine($"Search Windows Element is invisbile in attempt : {attempt + 1}");
                }
                return isPresent;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool WaitForElementUntilVisible(string attribute, int timeout = 5)
        {
            bool isPresent = false;
            int attempt = 0;
            try
            {
                do
                {
                    try
                    {
                        WaitForMoment(1);
                        WindowsElement element = FindElement(attribute);
                        isPresent = element.Displayed;
                    }
                    catch (Exception)
                    {
                        attempt++;
                    }

                } while (!isPresent && timeout != attempt);

                if (timeout == attempt)
                {
                    Console.WriteLine($"Search Element not found with timeout of {attempt} seconds");
                }
                return isPresent;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public void WaitForElementIsVisible(string locator, long timeout = 30)
        {
            string locatorValue = string.Empty;
            string locatorType = string.Empty;

            try
            {
                string[] xpathExpression = locator.Split(new char[] { ':' }, 2);
                locatorType = xpathExpression[0];
                locatorValue = xpathExpression[1];

                /* An implicit wait is to tell WindowsDriver 
                 * to poll the DOM for a certain amount of time 
                 * when trying to find an element or elements 
                 * if they are not immediately available
                 */
                var wait = new DefaultWait<WindowsDriver<WindowsElement>>(Session)
                {
                    Timeout = TimeSpan.FromSeconds(timeout),
                    PollingInterval = TimeSpan.FromSeconds(1)
                };
                wait.IgnoreExceptionTypes(typeof(InvalidOperationException));

                WindowsElement mainWindow = null;
                if (Session.WindowHandles.Count > 0)
                {
                    wait.Until(driver =>
                    {
                        driver.SwitchTo().Window(driver.WindowHandles[0]);
                        switch (locatorType)
                        {
                            case "Name":
                                mainWindow = driver.FindElementByName(locatorValue);
                                break;
                            case "ClassName":
                                mainWindow = driver.FindElementByClassName(locatorValue);
                                break;
                            case "AccessibilityId":
                                mainWindow = driver.FindElementByAccessibilityId(locatorValue);
                                break;
                            case "XPath":
                                mainWindow = driver.FindElementByXPath(locatorValue);
                                break;
                            default:
                                Console.WriteLine("Search field is not found");
                                mainWindow = null;
                                break;
                        }
                        return mainWindow != null;
                    });
                }
                else
                {
                    LogInfo($"Application Window got closed. WindowHandles count = {Session.WindowHandles.Count}");
                }
            }
            catch (WebDriverTimeoutException ex)
            {
                throw new TimeoutException($"Elements not found with the {locatorType}:{locatorValue} \n Exception: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Elements not found with the {locatorType}:{locatorValue} \n Exception: {ex.Message}");
            }
        }
        public void WaitForLoaderToDisappear(string locatorName="all")
        {
            int timeout = 60;
            Stopwatch stopwatch = new Stopwatch();
            IList<WindowsElement> loadingElement = null;
            TimeSpan timeTaken=new TimeSpan();

            WaitForMoment(1);
            stopwatch.Start();
            try
            {
                bool isPresent;
                do
                {
                    if(locatorName.Equals("all"))
                    {
                        loadingElement = AllLoadingTexts;
                        IList<WindowsElement> userInfromationPopUp = HomeConfirmationButton;
                        if (userInfromationPopUp?.Count > 0)
                        {
                            userInfromationPopUp[0].Click();
                        }
                    }
                    else
                    {
                        loadingElement = Session.FindElementsByXPath($"//Text[contains(@Name,'{locatorName}')]");
                    }
                    if (loadingElement?.Count > 0)
                    {
                        isPresent = loadingElement.Count > 0;
                    }
                    else
                    {
                        break;
                    }
                    WaitForMoment(1);
                    timeTaken = stopwatch.Elapsed;
                } while (isPresent && timeTaken.TotalSeconds < timeout);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message} {ex.StackTrace}");
            }
            finally
            {
                LogInfo($"Loading Pop-Up : [{locatorName}] presence on screen = {stopwatch.Elapsed.Seconds} seconds.");
            }
            if (timeTaken.TotalSeconds >= timeout)
            {
                LogError($"Loading Pop-Up : [{locatorName} : {loadingElement[0]?.Text}] is not getting dissappearing even after {timeout} seconds also.");
                Assert.Fail($"Loading Pop-Up : [{locatorName} : {loadingElement[0]?.Text}] is not getting dissappearing even after {timeout} seconds also");
            }
            stopwatch.Stop();
        }
        public void WaitForElementToAppear(string locatorName)
        {
            int timeout = 60;
            Stopwatch stopwatch = new Stopwatch();
            IList<WindowsElement> requiredElement = FindElements($"XPath://*[contains(@Name,'{locatorName}')]");
            TimeSpan timeTaken = new TimeSpan();

            WaitForMoment(1);
            stopwatch.Start();
            try
            {
                do
                {
                    if (requiredElement.Count > 0)
                    {
                        break;
                    }
                    WaitForMoment(1);
                    timeTaken = stopwatch.Elapsed;
                    requiredElement = FindElements($"XPath://*[contains(@Name,'{locatorName}')]");
                } while (timeTaken.TotalSeconds < timeout);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message} {ex.StackTrace}");
            }
            finally
            {
                LogInfo($"Searching Element : [{locatorName}] present on screen after {stopwatch.Elapsed.Seconds} seconds.");
            }
            if (timeTaken.TotalSeconds >= timeout)
            {
                LogError($"Searching Element : [{locatorName} is not getting displayed even after {timeout} seconds also.");
                Assert.Fail($"Loading Pop-Up : [{locatorName} is not getting displayed even after {timeout} seconds also");
            }
            stopwatch.Stop();
        }
        #endregion

        #region Common Elements
        public IList<WindowsElement> AllLoadingTexts => FindElements("XPath://Text[contains(@Name,'Loading') or contains(@Name,'Fetching') or contains(@Name,'Fetching Modules') or contains(@Name,'Preparing') or contains(@Name,'Retry') or contains(@Name,'Authenticating user') or contains(@Name,'Adding') or contains(@Name,'Saving') or contains(@Name,'Deleting') or contains(@Name,'Removing') or contains(@Name,'Refreshing') or contains(@Name,'Please wait') or contains(@Name,'Sharing Insights') or contains(@Name,'Fetching')]");
        public IList<WindowsElement> LoadingText => FindElements("AccessibilityId:LoaderLabel");

        public IList<WindowsElement> HomeImage => FindElements("XPath://*[@AutomationId='wdLogo' or @AutomationId='Home']");
        public WindowsElement RefreshImage => FindElement("AccessibilityId:RefreshData");     
        public WindowsElement RefreshButton => FindElement("XPath://*[contains(@Name,'Refresh')]");
        public WindowsElement NavigationBar => FindElement("AccessibilityId:NavigationBar");
        public IList<WindowsElement> NavigationBarIcons => FindElements("XPath://*[@AutomationId='NavigationBar']/Image");
        public IList<WindowsElement> NotificationImage => FindElements("AccessibilityId:Notification");
        public WindowsElement FeedbackImage => FindElement("AccessibilityId:Feedback");
        public WindowsElement FilterImage => FindElement("Name:Filter");
        public WindowsElement SearchEditInGrid => FindElement("XPath://*[@AutomationId='searchEntry' and @Name='Search']");
        public IList<WindowsElement> MasterActionImage => FindElements("XPath://*[contains(@AutomationId,'masterAction_Container')]//*[contains(@Name,'Action') or @ClassName='Image']");
        public WindowsElement SearchButtonInGrid => FindElement("XPath://*[@AutomationId='searchEntry' and @Name='Search']/following-sibling::*[@AutomationId='SearchImage']");
        public WindowsElement VerticalScrollBar => FindElement("AccessibilityId:VerticalScrollBar");
        public WindowsElement ConfirmationYesButton => FindElement("XPath://Custom[@AutomationId='confirmationOptions']/Button[@AutomationId='okButton']");
        public WindowsElement ConfirmationOkButtonQ => FindElement("XPath://Button[@AutomationId='okButton_Container']");
        public WindowsElement ConfirmationPopupText => FindElement("XPath://*[@AutomationId='dialogMessage']");
        public WindowsElement ConfirmationOkButton => FindElement("XPath://Custom[@AutomationId='confirmationOptions']/Button[@AutomationId='okButton']");
        public WindowsElement InboxesButton => FindElement("AccessibilityId:inboxPicker");
        public IList<WindowsElement> MoreImage => FindElements("AccessibilityId:More");
        public IList<WindowsElement> DeleteImage => FindElements("AccessibilityId:Delete");
        public IList<WindowsElement> MainWindow => FindElements("ClassName:Windows.UI.Core.CoreWindow");
        public WindowsElement ApplyButton => FindElement("Name:Apply");
        public WindowsElement FilterApplyButton => FindElement("AccessibilityId:ApplyFilter");
        public IList<WindowsElement> ErrorImage => FindElements("AccessibilityId:ErrorImage");
        public IList<WindowsElement> ErrorLabel => FindElements("AccessibilityId:ErrorLabel");
        public IList<WindowsElement> EmptyImage => FindElements("AccessibilityId:EmptyImage");
        public IList<WindowsElement> EmptyLabel => FindElements("AccessibilityId:EmptyLabel");
        public IList<WindowsElement> DialogPopUp => FindElements("AccessibilityId:dialogMessage");
        public IList<WindowsElement> EmptyErrorTemplates => FindElements("XPath://*[contains(@AutomationId,'dialogMessage') or contains(@AutomationId,'ErrorImage') or contains(@AutomationId,'ErrorLabel') or contains(@AutomationId,'EmptyImage') or contains(@AutomationId,'EmptyLabel')]");
        public IList<WindowsElement> GlobalSearchInboxInputField => FindElements("Name:InboxPicker Input Field");
        public WindowsElement SelectInbox => FindElement("Name:Select Inbox");
        public IList<WindowsElement> GlobalSearchValueInputField => FindElements("Name:Search for records");
        public IList<WindowsElement> GlobalSearchImage => FindElements("AccessibilityId:SearchImage");
        public WindowsElement InboxesToggleButton => FindElement("AccessibilityId:PaneTogglePane");
        public IList<WindowsElement> InboxesSearchButton => FindElements("XPath://*[@AutomationId='SearchEntry' and @Name='Search for Inbox']/preceding-sibling::*[@AutomationId='SearchIcon']");
        public IList<WindowsElement> InboxesSearchTextField => FindElements("XPath://*[@AutomationId='SearchEntry' and @Name='Search for Inbox']");
        public IList<WindowsElement> ClosePopup => FindElements("AccessibilityId:ClosePopupImage");
        public IList<WindowsElement> LoadMoreButton => FindElements("XPath://*[contains(@Name,'Load More')]");
        public WindowsElement Help => FindElement("XPath://*[contains(@Name,'Help')]"); 
        public WindowsElement SuggestAFeature => FindElement("XPath://*[contains(@Name,'Suggest a Feature')]");
        public WindowsElement SuggestAfeatureTitleTextBox => FindElement("XPath://Text[contains(@Name,'Title')]/parent::Custom/parent::Custom/parent::Custom//following-sibling::Custom//Edit");
        public WindowsElement SuggestAfeatureDescriptionTextBox => FindElement("XPath://Text[contains(@Name,'Description')]/parent::Custom/parent::Custom/parent::Custom//following-sibling::Custom//Edit");
        public WindowsElement SuggestAFeatureDescription => FindElement("");
        public WindowsElement SubmitButton => FindElement("XPath://*[contains(@Name,'Submit')]");
        public IList<WindowsElement> GetAllChartsKPIsByFavoriteIcon => FindElements("AccessibilityId:Favourite");
        public IList<WindowsElement> GetAllChartsKPIsTitles => FindElements("XPath://*[@AutomationId='Favourite']/parent::Custom/parent::Custom//Text[@AutomationId='Title']");
        public IList<WindowsElement> InboxListFromDropdown(string inboxName)
        {
            return FindElements($"XPath://ListItem[@ClassName='ListBoxItem']//Text[contains(@Name,'{inboxName}')]");
        }
        public IList<WindowsElement> IndexSearchSideFrame(string inboxName)
        {
            return FindElements($"XPath://Text[@Name='{inboxName}']");
        }
        public IList<WindowsElement> GetElementByText(string windowsElementName)
        {
            return FindElements($"XPath://Text[contains(@Name,'{windowsElementName}')]");
        }
        public WindowsElement GetInboxName(string inboxName)
        {
            return FindElement($"XPath://*[@AutomationId='InboxName' and contains(@Name,'{inboxName}')]");
        }
        public IList<WindowsElement> ActionTagNames => FindElements($"XPath://*[@ClassName='AutoSuggestBox']/parent::Custom/following-sibling::Custom/Pane/Custom/Button");
        public WindowsElement CategoryListDropdown => FindElement($"XPath://*[@ClassName='ComboBox']");
        public WindowsElement ClearCache => FindElement("XPath://*[contains(@Name,'Clear Cache')]");
        public WindowsElement ClearAllCacheButton => FindElement("XPath://*[contains(@Name,'Clear All')]");
        public IList<WindowsElement> CacheClearedSuccessMsg => FindElements($"XPath://*[@Name='Cache cleared']");
        public WindowsElement ReloadModules => FindElement("XPath://*[contains(@Name,'Reload Modules')]");
        public IList<WindowsElement> RefreshingLoader => FindElements($"XPath://Text[contains(@Name,'Refreshing')]");
        public IList<WindowsElement> HomeConfirmationButton => FindElements("XPath://Custom[@AutomationId='confirmationOptions']/Button[@AutomationId='okButton']");
        public IList<WindowsElement> ZoomImage => FindElements("AccessibilityId:Zoom");
        public WindowsElement ConfiguredTab => FindElement("AccessibilityId:Global");
        public IList<WindowsElement> UserCreatedTab => FindElements("XPath://*[contains(@Name,'Created ')]");
        public WindowsElement SharedTab => FindElement("AccessibilityId:Shared");
        public IList<WindowsElement> ToggleControlText => FindElements("XPath://*[@AutomationId='PaneTogglePane']/following-sibling::Text[contains(@Name,'Menu') or contains(@Name,'Inboxes')]");
        public IList<WindowsElement> ExitWindowOkButton => FindElements("AccessibilityId:okButton");
        public IList<WindowsElement> FilterCountValue => FindElements("XPath://Custom[@AutomationId='FilterButtons_Container']/following-sibling::Custom/Text");
        public IList<WindowsElement> ActionLabels => FindElements("XPath://*[@ClassName='AutoSuggestBox']/parent::Custom/following-sibling::Custom/following-sibling::Pane/Custom/Custom");
        public IList<WindowsElement> RecordsDataRows => FindElements("XPath:.//Group[contains(@AutomationId,' Row') and contains(@Name,' Row') and @ClassName='NamedContainerAutomationPeer']");
        public IList<WindowsElement> ValuebyRowAndColumnInGrid()
        {
            return FindElements($"XPath://*[@AutomationId=' Row1' or @Name=' Row1']/descendant::*[contains(@ClassName,'TextBlock')]");
        }
        public IList<WindowsElement> ValuebyRowAndColumnInGrid(string rowNumber)
        {
            return FindElements($"XPath://*[@AutomationId=' Row{rowNumber}' or @Name=' Row{rowNumber}']/descendant::*[contains(@ClassName,'TextBlock')]");
        }
        public IList<WindowsElement> SlideDirection(string direction)
        {
            return FindElements($"XPath://*[@AutomationId='{direction}']");
        }
        public IList<WindowsElement> ClickAll()
        {
            return FindElements($"XPath://*[contains(@Name,'All')]");
        }
        public WindowsElement SyncModule => FindElement("XPath://*[contains(@Name,'Sync')]");
        public IList<WindowsElement> SuggestionLoader => FindElements($"XPath://Text[contains(@Name,'Suggestion')]");
        public WindowsElement InboxHeaderText => FindElement("XPath://*[@LocalizedControlType='tab' and @ClassName='Pivot']//*[@AutomationId='InboxName' and @ClassName='TextBlock']");
        public IList<WindowsElement> AllFilterValueCheckboxes => FindElements("XPath://Window[@ClassName='Popup']//CheckBox[@ClassName='CheckBox']");
        public WindowsElement InboxTitle => FindElement("XPath://*[@AutomationId='InboxName']");
        public IList<WindowsElement> AbstractionTabs => FindElements($"XPath://Custom[@AutomationId='InboxNameGrid']/parent::Custom/following-sibling::TabItem");
        public WindowsElement SearchBox => FindElement("XPath://*[@AutomationId='searchEntry']");
        public WindowsElement SearchImage => FindElement("XPath://*[@AutomationId='SearchImage']");
        public WindowsElement FilterButton => FindElement("XPath://*[@AutomationId='ActiveFiltersPageButton']");
        public WindowsElement FilterDropdownButton => FindElement("XPath://*[@AutomationId='OpenFilter_Container']");
        public WindowsElement SortImage => FindElement("XPath://*[@AutomationId='Sort']");
        public WindowsElement SortButton => FindElement("XPath://*[contains(@Name,'Sort')]");
        public WindowsElement MoreButton => FindElement("XPath://*[contains(@Name,'More')]");
        public WindowsElement ReloadButton => FindElement("XPath://*[@AutomationId='RefreshData']");
        public WindowsElement AddNewFilterButton => FindElement("XPath://Button[@AutomationId='AddNewFilter']");
        public WindowsElement FilterFieldText => FindElement("XPath://*[@Name='Filter Field']");
        public WindowsElement FilterOperatorText => FindElement("XPath://*[@Name='Operator']");
        public WindowsElement FilterValueText => FindElement("XPath://*[@Name='Filter Value']");
        public WindowsElement FilterFieldTextBox => FindElement("XPath://*[@AutomationId='FilterFieldTitle']/child::Custom/following-sibling::Custom/child::*[@AutomationId=' Input Field']");
        public WindowsElement FilterOperatorTextBox => FindElement("XPath://*[@AutomationId='FilterOperatorTitle']/child::Custom/following-sibling::Custom/child::*[@AutomationId='FilterOperatorPicker Input Field']");
        public WindowsElement FilterValueTextBox => FindElement("XPath://*[@AutomationId='FilterValueTitle']/child::Custom/following-sibling::Custom/child::Custom/child::Custom/child::Custom/child::Custom/child::*[@ClassName='TextBox']");
        public WindowsElement FilterCheckBox => FindElement("XPath://CheckBox[@ClassName='CheckBox']");
        public IList<WindowsElement> FilterFieldOptions => FindElements("XPath://*[@AutomationId='FilterFieldTitle']/child::Custom/following-sibling::Custom/child::*[@AutomationId=' Input Field']/child::*[@Name=' Input Field']/following-sibling::*[@AutomationId='PART_Popup'/child::*[@AutomationId=' HeaderView']/child::*[@AutomationId=' Dropdown']/child::ListItem");
        public WindowsElement SelectFilterField(string filterField)
        {
            return FindElement($"XPath://ListItem[contains(@Name,'{filterField}')]/Text");
        }
        public WindowsElement SelectOperator(string filterOperator)
        {
            return FindElement($"XPath://ListItem[contains(@Name,'{filterOperator}')]/Text");
        }
        public WindowsElement ApplyFilterButton => FindElement("XPath://*[@AutomationId='ApplyFilter']");
        public WindowsElement NoOfSearches => FindElement("XPath://*[@Name='Displayed']/following-sibling::Text");
        public WindowsElement SelectRandomMoreOption(int rowNumber)
        {
            return FindElement($"XPath://*[@AutomationId=' Row{rowNumber}']/child::[@Name='DetailAction']/child::Custom/child::Custom/child::*[@AutomationID='ViewSemantic']/following-sibling::*[@AutomationId='More']");
        }
        public WindowsElement ExpandOption => FindElement("XPath://*[@Name='Expand']");
        public WindowsElement ActualRandomFilteredValue(string filterField)
        {
            return FindElement($"XPath://ListItem[@ClassName='ListViewItem']/child::Custom/child::Custom/following-sibling::*[@Name='{filterField}']/following-sibling::Text");
        }
        public WindowsElement Digit_1_LabelText => FindElement("XPath://*[@Name='1']");
        public WindowsElement EditableFilterLabel => FindElement("XPath://*[@AutomationId='EditableFilterLabel']");
        public WindowsElement EditableFilterOperator => FindElement("XPath://*[@AutomationId='EditableFilterOperator']");
        public WindowsElement EditableFilterValue => FindElement("XPath://*[@AutomationId='EditableFilterValue']");
        public WindowsElement EditableFilterImageEdit => FindElement("XPath://*[@AutomationId='EditableFilterImageEdit']");
        public WindowsElement EditableFilterRemove => FindElement("XPath://*[@AutomationId='EditableFilterRemove']");
        public WindowsElement NoActiveFiltersMsg => FindElement("XPath://*[@Name='No Active Filters to show']");
        #endregion
    }
}
