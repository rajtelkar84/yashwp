using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.Threading;
using OpenQA.Selenium;
using System.IO;
using System.Linq;
using System.Reflection;
using OpenQA.Selenium.Appium;
using System.Text.RegularExpressions;
using System.Net.Http;
using System.IO.Compression;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;
using OpenQA.Selenium.Appium.Windows;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.Net.Http.Headers;
using System.Management;
using West.EnterpriseUX.Automation.UWP.PageActions;
using West.EnterpriseUX.Automation.UWP.Utilities;
using Microsoft.Azure.KeyVault;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace West.EnterpriseUX.Automation.UWP
{
    [TestClass]
    [DeploymentItem(@"Driver\")]
    [DeploymentItem(@"TestData\")]
    [DeploymentItem(@"BatchFiles\")]
    public class BaseTest : Logger
    {
        #region variables declaration

        protected static WindowsDriver<WindowsElement> _session;
        protected static BaseAction _baseAction;
        protected static LoginAction _loginAction;
        protected static HomeAction _homeAction;
        protected static InboxAction _inboxAction;
        protected static InboxFilterAction _inboxFilterAction;
        protected static ChildInboxAction _childInboxAction;
        protected static HRAddressAction _hrAddressAction;
        protected static HRBankAction _hrBankAction;
        protected static CSCustomersAction _csCustomersAction;
        protected static CSMaterialsAction _csMaterialsAction;
        protected static CSCustomerMaterialInfoAction _csCustomerMaterialInfoAction;
        protected static CSSamplesAction _csSamplesAction;
        protected static CSQuotationsAction _csQuotationsAction;
        protected static CSSalesOrdersAction _csSalesOrdersAction;
        protected static CSSalesOrderItemsAction _csSalesOrderItemsAction;
        protected static CSReturnsAction _csReturnsAction;
        protected static CSReturnsItemsAction _csReturnsItemsAction;
        protected static CSCreditMemoRequestsAction _csCreditMemoRequestsAction;
        protected static CSCreditMemoRequestItemsAction _csCreditMemoRequestItemsAction;
        protected static CSDebitMemoRequestsAction _csDebitMemoRequestsAction;
        protected static InboxChartsAction _inboxChartsAction;
        protected static InboxStoryboardsAction _storyboardsAction;
        protected static InboxKpisAction _inboxKpisAction;
        protected static FeedbackAction _feedbackAction;
        protected static PivotViewAction _pivotViewAction;
        protected static QuoteAction _quoteAction;
        protected static CreateQuoteAction _createQuoteAction;
        protected static ConfigureProductsAction _configureProductsAction;
        protected static ProductReviewAction _productReviewAction;
        protected static LabelPrintingAction _labelPrintingAction;
        protected static TimeConfirmationAction _timeConfirmationAction;
        protected static InventoryDashboardAction _inventoryDashboardAction;
        protected static CreateMaintenanceAction _createMaintenanceAction;
        protected static BinsProductsAction _binsProductsAction;
        protected static FinanceAction _financeAction;
        protected static WarehouseTasksAction _warehouseTasksAction;
        protected static EWMHandlingUnitsAction _eWMHandlingUnitsAction;
        protected static PhysicalInventoryAction _physicalInventoryAction;
        protected static ReportAction _reportAction;
        protected static GoodIssueAction _goodIssueAction;
        protected static Helper _helper = new Helper();
        protected static ProspectsAction _prospectsAction;
        protected static LeadsAction _leadsAction;
        protected static MyAppsAction _myAppsAction;
        public static RequestLOAAction _requestLOAAction;
        public static ContactsAction _contactsAction;
        public static MeetingReportAction _meetingReportAction;
        public static OpportunityAction _opportunityAction;
        public static WebformKmApprovalAction _webformKmApprovalAction;
        public static WebFormAction _webFormAction;
        public static CampaignResponceAction _campaignResponceAction;
        public static WebformKMRegistrationAction _webformKMRegistrationAction;
        public static WebinarAction _webinarAction;
        public static ContactUSAction _contactUSAction;
        public static PRQAction _prqAction;
        public static CRMCommonAction _crmCommonAction;
        public static CasesAction _casesAction;
        public static CollaborationAction _collaborationAction;
        public static ActivitiesAction _activitiesAction;
        public static CreatePRPageAction _createPRPageAction;
        public static HRSelfIdentificationAction _hrSelfIdentificationAction;
        public static HRESPPAction _hrEsppAction;
        public static IWebDriver driver;
        public static string buildVersion = string.Empty;
        public static string buildVersionNumber = string.Empty;
        public static string machineName = string.Empty;
        public static string userName = string.Empty;
        public static string password = string.Empty;
        public static string logsFolderPath = string.Empty;
        public static string screenshotsFolderPath = string.Empty;
        public static string buildsPath = string.Empty;
        public static string applicationAppId = string.Empty;
        public static string applicationName = string.Empty;
        public static string applicationEnvironment = string.Empty;
        public static string clientId = string.Empty;
        public static string clientSecret = string.Empty;
        public static string memoryUtilizationLogFileName = "MemoryUsage_" + $"{DateTime.Now:dd_MM_yyyy}" + ".csv";
        public static string testResultsLogFileName = "TestResult_" + $"{DateTime.Now:dd_MM_yyyy}" + ".csv";
        public static string inboxesMemoryUtilizationLogFileName = "InboxesMemoryUsage_" + $"{DateTime.Now:dd_MM_yyyy}" + ".csv";
        public Stopwatch testTimer;
        protected static EmployeeHubAction _employeeHubAction;
        public static string testErrorMessage = string.Empty;
        protected static CustomerAction _customerAction;

        #endregion

        public TestContext TestContext { get; set; }

        #region TestInitializes + Cleansups
        [AssemblyInitialize]
        public static void LaunchUWPApp(TestContext context)
        {
            try
            {
                logsFolderPath = context.Properties["LogFolderPath"].ToString();
                screenshotsFolderPath = context.Properties["ScreenshotFolderPath"].ToString();
                buildsPath = context.Properties["BuildsPath"].ToString();
                applicationAppId = context.Properties["AppID"].ToString();
                applicationName = context.Properties["AppName"].ToString();
                applicationEnvironment = context.Properties["AppEnvironment"].ToString();
                clientId = context.Properties["ClientId"].ToString();
                clientSecret = context.Properties["ClientSecret"].ToString();

                // Create Logs, Screenshots, Builds Folder if not present
                _helper.CreateFolder(logsFolderPath);
                _helper.CreateFolder(screenshotsFolderPath);
                _helper.CreateFolder(buildsPath);
                machineName = System.Environment.MachineName;

                //Copy the TestData based on the Environment
                CopyTestDataBasedOnEnvironemnt(applicationEnvironment);

                //Reads the UserName and Password
                ReadUserEmailIDandPassword(context);

                LogInfo($"Selected Application Environment for Automation : {applicationName}");
                LogInfo("Assembly Initialize started");

                LogInfo("Starts the Windows Application Driver Service in AssemblyInitialize");
                //Starts the Windows Application Driver Service
                StartWinAppDriverServer();

                //Creating the TestResults CSV File if not present
                _helper.CheckFileExists(Path.Combine(logsFolderPath, testResultsLogFileName));
                _helper.CheckCustomizableFileExists(Path.Combine(logsFolderPath, inboxesMemoryUtilizationLogFileName));

                //Application Data Clean Up
                   ApplicationDataCleanUp();
            }
            catch (Exception ex)
            {
                LogError($"{ex.Message} : {ex.StackTrace}");
            }
            finally
            {
                LogInfo("Assembly Initialize finished");
            }
        }
        [AssemblyCleanup]
        public static void CleanupUWPApp()
        {
            try
            {
                LogInfo("Assembly Cleanup started");
            }
            catch (Exception ex)
            {
                LogError($"{ex.Message} : {ex.StackTrace}");
            }
            finally
            {
                LogInfo("Assembly Cleanup finished");
            }
        }
        [TestInitialize]
        public void TestSetUp()
        {
            buildVersionNumber = GetBuildVersion();
            testErrorMessage = string.Empty;
            screenshotFileName = string.Empty;
            testTimer = new Stopwatch();
            testTimer.Start();
            var skipInitialize = GetType().GetMethod(TestContext.TestName).GetCustomAttributes(typeof(SkipInitializeAttribute), false).ToArray();
            try
            {
                LogInfo("Starts the Windows Application Driver Service in Test TestInitialize");
                //Starts the Windows Application Driver Service
                StartWinAppDriverServer();

                LogInfo("Test TestInitialize started");

                if (skipInitialize.Length == 0)
                {
                    // Closing any West App instance if opened
                    CloseCurrentAppInstance();

                    // Launching the App Instance
                    LaunchApp();

                    // Logging into the App
                    LoginToWD(userName, password);

                    LogMemoryUsage($"{TestContext.TestName} : TestInitialize : ");
                }
            }
            catch (Exception ex)
            {
                LogError($"{ex.Message} : {ex.StackTrace}");
                CaptureLogs(ex);
            }
            finally
            {
                LogInfo("Test TestInitialize finished");
                LogInfo($"Test : {TestContext.TestName} started");
            }
        }
        [TestCleanup]
        public void TestCleanUp()
        {
            var skipInitialize = GetType().GetMethod(TestContext.TestName).GetCustomAttributes(typeof(SkipInitializeAttribute), false).ToArray();
            try
            {
                LogInfo($"Test : {TestContext.TestName} finished");

                if (skipInitialize.Length == 0)
                {
                    LogInfo("Test TestCleanUp started");

                    LogMemoryUsage($"{TestContext.TestName} : TestCleanup : ");

                    WaitForMoment(1);

                    //Skipping the close app operation for the already closed app
                    if (_session.WindowHandles.Count > 0)
                    {
                        _homeAction.ClickOnCloseApplication();
                    }
                    WaitForMoment(1);
                }

                if (!TestContext.TestName.Contains("TC_ClearAbstractionDataTest"))
                {
                    //Saving the TestResults to ResultTable
                    ResultTable resultsTable = SaveTestResults(TestContext);

                    //Logging TestResults to TestResults.CSV
                    WriteTestResultToCSV(resultsTable);

                    string appEnvironment = GetApplicationEnvironment(applicationEnvironment);

                    //Submitting the feedback 
                    if (resultsTable.TestOutcome.ToLower().ToString() == "failed" && appEnvironment.ToLower().Equals("uatt"))
                    {
                        //Logging the feeback only foe the Failed Test Cases
                        CallFeedbackAPI(resultsTable).Wait();
                    }
                }
            }
            catch (Exception ex)
            {
                CaptureScreenShot(_session, TestContext.TestName);
                LogError($"{ex.Message} : {ex.StackTrace}");
            }
            finally
            {
                LogInfo("Test TestCleanUp finished");
            }
        }
        #endregion

        #region WinAppDriverServer
        public static void StartWinAppDriverServer()
        {
            try
            {
                string winAppDriverPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), @"Windows Application Driver\WinAppDriver.exe");
                LogInfo($"Windows Application Driver Server path : {winAppDriverPath}");
                Process[] winAppDrivers = Process.GetProcessesByName("WinAppDriver");

                if (winAppDrivers.Length == 0)
                {
                    LogInfo($"Windows Application Driver Server is not running.");
                    LogInfo($"Started the Windows Application Driver Server by Method-1");
                    LogInfo($"Windows Application Driver Batch exe path : {winAppDriverPath}");
                    Process.Start(winAppDriverPath);
                    WaitForMoment(1);

                    winAppDrivers = Process.GetProcessesByName("WinAppDriver");

                    if (winAppDrivers.Length == 0)
                    {
                        LogInfo($"Starting Windows Application Driver Server by method-1 failed.");
                        LogInfo($"Started the Windows Application Driver Server by Method-2");
                        var workingDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                        winAppDriverPath = Path.Combine(workingDirectory, @"startWinAppDriver.bat");
                        Process.Start(winAppDriverPath);
                        LogInfo($"Windows Application Driver Batch File path : {winAppDriverPath}");
                        WaitForMoment(1);

                        winAppDrivers = Process.GetProcessesByName("WinAppDriver");

                        if (winAppDrivers.Length == 0)
                        {
                            LogInfo($"Strating Windows Application Driver Server by method-2 is unsuccessfull.");
                        }
                        else
                        {
                            LogInfo($"Strating Windows Application Driver Server by method-2 is successfull.");
                        }
                    }
                    else
                    {
                        LogInfo($"Strating Windows Application Driver Server by method-1 is successfull.");
                    }
                }
                else
                {
                    LogInfo($"Windows Application Driver Server is already running.");
                }
            }
            catch (Exception ex)
            {
                LogError($"{ex.Message} : {ex.StackTrace}");
            }
        }

        #endregion

        #region LaunchingAndClosingApp 
        public static void LaunchApp()
        {
            LogInfo("Launching of the UWP started");
            var appCapabilities = new AppiumOptions();
            appCapabilities.AddAdditionalCapability("app", applicationAppId);
            appCapabilities.AddAdditionalCapability("ms:waitForAppLaunch", 20);
            try
            {
                LogInfo("Creating the Session started");
                _session = new WindowsDriver<WindowsElement>(new Uri(CommonTestSettings.WindowsApplicationDriverUrl), appCapabilities, TimeSpan.FromSeconds(30));
              
                Assert.IsNotNull(_session, "Error in launching the UWP App by method-1");
                WaitForMoment(4);
                LogInfo("Creating the Session finished");
            }
            catch (Exception ex)
            {
                LogError($"Error in launching WD Application by method-1 : {ex.Message} : {ex.StackTrace}");
                AttachAppSession();
            }
            _session.Manage().Window.Maximize();
            WaitForMoment(1.5);

            var allWindowHandles = _session.WindowHandles;
            _session.SwitchTo().Window(allWindowHandles[0]);

            _baseAction = new BaseAction(_session);
            _loginAction = new LoginAction(_session);
            _homeAction = new HomeAction(_session);
            _inboxAction = new InboxAction(_session);
            _inboxFilterAction = new InboxFilterAction(_session);
            _childInboxAction = new ChildInboxAction(_session);
            _hrAddressAction = new HRAddressAction(_session);
            _inboxChartsAction = new InboxChartsAction(_session);
            _hrBankAction = new HRBankAction(_session);
            _csCustomersAction = new CSCustomersAction(_session);
            _csMaterialsAction = new CSMaterialsAction(_session);
            _csCustomerMaterialInfoAction = new CSCustomerMaterialInfoAction(_session);
            _csSamplesAction = new CSSamplesAction(_session);
            _csQuotationsAction = new CSQuotationsAction(_session);
            _csSalesOrdersAction = new CSSalesOrdersAction(_session);
            _csSalesOrderItemsAction = new CSSalesOrderItemsAction(_session);
            _csReturnsAction = new CSReturnsAction(_session);
            _csReturnsItemsAction = new CSReturnsItemsAction(_session);
            _csCreditMemoRequestsAction = new CSCreditMemoRequestsAction(_session);
            _csCreditMemoRequestItemsAction = new CSCreditMemoRequestItemsAction(_session);
            _csDebitMemoRequestsAction = new CSDebitMemoRequestsAction(_session);
            _storyboardsAction = new InboxStoryboardsAction(_session);
            _inboxKpisAction = new InboxKpisAction(_session);
            _feedbackAction = new FeedbackAction(_session);
            _pivotViewAction = new PivotViewAction(_session);
            _quoteAction = new QuoteAction(_session);
            _createQuoteAction = new CreateQuoteAction(_session);
            _configureProductsAction = new ConfigureProductsAction(_session);
            _productReviewAction = new ProductReviewAction(_session);
            _labelPrintingAction = new LabelPrintingAction(_session);
            _timeConfirmationAction = new TimeConfirmationAction(_session);
            _inventoryDashboardAction = new InventoryDashboardAction(_session);
            _createMaintenanceAction = new CreateMaintenanceAction(_session);
            _reportAction = new ReportAction(_session);
            _goodIssueAction = new GoodIssueAction(_session);
            _contactsAction = new ContactsAction(_session);
            _opportunityAction = new OpportunityAction(_session);
            _meetingReportAction = new MeetingReportAction(_session);
            _webformKmApprovalAction = new WebformKmApprovalAction(_session);
            _webFormAction = new WebFormAction(_session);
            _prospectsAction = new ProspectsAction(_session);
            _leadsAction = new LeadsAction(_session);
            _campaignResponceAction = new CampaignResponceAction(_session);
            _webformKMRegistrationAction = new WebformKMRegistrationAction(_session);
            _webinarAction = new WebinarAction(_session);
            _contactUSAction = new ContactUSAction(_session);
            _prqAction = new PRQAction(_session);
            _crmCommonAction = new CRMCommonAction(_session);
            _casesAction = new CasesAction(_session);
            _activitiesAction = new ActivitiesAction(_session);
            _collaborationAction = new CollaborationAction(_session);
            _myAppsAction = new MyAppsAction(_session);
            _requestLOAAction = new RequestLOAAction(_session);
            _employeeHubAction = new EmployeeHubAction(_session);
            _customerAction = new CustomerAction(_session);
            _binsProductsAction= new BinsProductsAction(_session);
            _warehouseTasksAction = new WarehouseTasksAction(_session);
            _eWMHandlingUnitsAction = new EWMHandlingUnitsAction(_session);
            _physicalInventoryAction = new PhysicalInventoryAction(_session);
            _createPRPageAction = new CreatePRPageAction(_session);
            _financeAction = new FinanceAction(_session);
            _hrSelfIdentificationAction = new HRSelfIdentificationAction(_session);
            _hrEsppAction = new HRESPPAction(_session);
            _baseAction.WaitForLoadingToDisappear("all");

            LogInfo("Launching of the UWP finished");
        }
        public static void CloseCurrentAppInstance()
        {
            try
            {
                LogInfo("Closing the West UWP Application instance.");

                foreach (System.Diagnostics.Process proc in System.Diagnostics.Process.GetProcessesByName("West.EnterpriseUX.UWP"))
                {
                    proc.Kill();
                }
            }
            catch (Exception ex)
            {
                LogError($"{ex.Message} : {ex.StackTrace}");
            }
        }
        public static bool IsProcessOpen(string name)
        {
            foreach (Process clsProcess in Process.GetProcesses())
            {
                if (clsProcess.ProcessName.Contains(name))
                {
                    return true;
                }
            }

            return false;
        }
        public static void AttachAppSession(string windowName = "West Digital")
        {
            try
            {
                var desktopCapabilities = new AppiumOptions();
                desktopCapabilities.AddAdditionalCapability("platformName", "Windows");
                desktopCapabilities.AddAdditionalCapability("app", "Root");
                desktopCapabilities.AddAdditionalCapability("deviceName", "WindowsPC");
                _session = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), desktopCapabilities);

                WindowsElement applicationWindow = null;
                var openWindows = _session.FindElementsByClassName("ApplicationFrameWindow");
                foreach (var window in openWindows)
                {
                    if (window.GetAttribute("Name").Contains(windowName))
                    {
                        applicationWindow = window;
                        try
                        {
                            applicationWindow.Click();
                        }
                        catch (Exception ex)
                        {
                            LogError($"Error in clicking on application by method-2:{ex.Message} : {ex.StackTrace}");
                        }
                        break;
                    }
                }
                // Attaching to existing Application Window
                var topLevelWindowHandle = applicationWindow.GetAttribute("NativeWindowHandle");
                topLevelWindowHandle = int.Parse(topLevelWindowHandle).ToString("X");

                var capabilities = new AppiumOptions();
                capabilities.AddAdditionalCapability("deviceName", "WindowsPC");
                capabilities.AddAdditionalCapability("appTopLevelWindow", topLevelWindowHandle);
                _session = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), capabilities);

                _baseAction = new BaseAction(_session);
                _loginAction = new LoginAction(_session);
                _homeAction = new HomeAction(_session);
                _inboxAction = new InboxAction(_session);
                _inboxFilterAction = new InboxFilterAction(_session);
                _childInboxAction = new ChildInboxAction(_session);
                _hrAddressAction = new HRAddressAction(_session);
                _inboxChartsAction = new InboxChartsAction(_session);
                _hrBankAction = new HRBankAction(_session);
                _csCustomersAction = new CSCustomersAction(_session);
                _storyboardsAction = new InboxStoryboardsAction(_session);
                _inboxKpisAction = new InboxKpisAction(_session);
                _feedbackAction = new FeedbackAction(_session);
                _pivotViewAction = new PivotViewAction(_session);
                _quoteAction = new QuoteAction(_session);
                _createQuoteAction = new CreateQuoteAction(_session);
                _configureProductsAction = new ConfigureProductsAction(_session);
                _productReviewAction = new ProductReviewAction(_session);

                _createPRPageAction = new CreatePRPageAction(_session);
               
                _binsProductsAction = new BinsProductsAction(_session);
                _eWMHandlingUnitsAction = new EWMHandlingUnitsAction(_session);
                _warehouseTasksAction = new WarehouseTasksAction(_session);
                _physicalInventoryAction = new PhysicalInventoryAction(_session);
;               _baseAction.WaitForLoadingToDisappear("all");
            }
            catch (Exception ex)
            {
                LogError($"Error in launching WD Application by method-2 : {ex.Message} : {ex.StackTrace}");
            }
        }
        public static void OpenApplication(string appID)
        {
            try
            {
                string appFullPath = $@"shell:appsFolder\{appID}";
                LogInfo($"Launching the App and its fullpath : {appFullPath}");
                Process p = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.UseShellExecute = true;
                startInfo.FileName = startInfo.FileName = appFullPath;
                p.StartInfo = startInfo;
                p.Start();
            }
            catch (Exception ex)
            {
                LogError($"Error in opening WD Application: {ex.Message} : {ex.StackTrace}");
            }
        }
        #endregion

        #region Waiters
        public static void WaitForMoment(int delay)
        {
            Thread.Sleep(delay * 1000);
        }
        public static void WaitForMoment(double delay)
        {
            Thread.Sleep(Convert.ToInt32(delay * 1000));
        }
        #endregion

        #region Performance Counters
        public static int MemoryUsageForProcess()
        {
            int memsize = 0;
            try
            {
                PerformanceCounter PCPerfCounter = new PerformanceCounter();
                PCPerfCounter.CategoryName = "Process";
                PCPerfCounter.CounterName = "Working Set - Private";
                PCPerfCounter.InstanceName = "West.EnterpriseUX.UWP";
                PCPerfCounter.MachineName = machineName;
                memsize = Convert.ToInt32(PCPerfCounter.NextValue()) / 1024;
                PCPerfCounter.Close();
                PCPerfCounter.Dispose();

                LogInfo("********************* Memory Usage on:" + machineName + "************************");
                LogInfo($"The Memory Use By WD App Test : " + (memsize / 1024).ToString() + " MB");
                LogInfo("**********************************************************************************************************");
            }
            catch (Exception ex)
            {
                LogError($"Exception occurred while extracting Memory usage by a process : { ex.Message} : { ex.StackTrace}");
                Console.WriteLine("Exception occurred while extracting Memory usage by a process" + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            return (memsize / 1024);
        }
        public static void LogMemoryUsage(string testName)
        {
            try
            {
                var memoryUsage = MemoryUsageForProcess();
                string formatedMemoryContent = $"{testName} {memoryUsage} MB";
                if (formatedMemoryContent.Contains("TestCleanup"))
                {
                    WriteToCSV(memoryUtilizationLogFileName, formatedMemoryContent + Environment.NewLine);
                }
                else
                {
                    WriteToCSV(memoryUtilizationLogFileName, formatedMemoryContent);
                }
            }
            catch (Exception ex)
            {
                LogError($"Exception occurred while extracting Memory usage by a process : { ex.Message} : { ex.StackTrace}");
                Console.WriteLine("Exception occurred while extracting Memory usage by a process" + ex.Message.ToString() + ex.StackTrace.ToString());
            }
        }
        #endregion

        #region CommonMethods
        /// <summary>
        /// Login to the application
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public void LoginToWD(string username, string password)
        {
            WaitForMoment(2);
            if (_loginAction.IsSignInHeaderPresent())
            {
                if (!_homeAction.IsIGlobalSearchImagePresent())
                {
                    LogInfo("It is in Sign In Page, so logging in to the application.");
                    _loginAction.EnterUserName(username);
                    WaitForMoment(1);
                    _loginAction.ClickOnNextButton();
                    WaitForMoment(1);
                    _loginAction.EnterPassword(password);
                    WaitForMoment(1);
                    _loginAction.ClickOnSignInButton();
                    WaitForMoment(5);
                    _loginAction.ClickOnYesButton();
                    _session.Manage().Window.Maximize();
                    LogInfo("Logging In to the application successfull.");
                    // Added temporarily to sync the WD Image loader 
                    WaitForMoment(5);
                    _baseAction.WaitForLoadingToDisappear();
                    Assert.IsTrue(_homeAction.IsIGlobalSearchImagePresent(), "Login is unsuccessfull and it did not navigate to home page");
                }
                else
                {
                    LogInfo("It is not in Sign In Page, so not logging in.");
                }
            }
            else
            {
                if (!_homeAction.IsIGlobalSearchImagePresent())
                {
                    WaitForMoment(5);
                    _baseAction.WaitForLoadingToDisappear("all");
                }
            }
        }
        /// <summary>
        /// Login Out of the application
        /// </summary>
        public void LogoutWD()
        {
            if (!_loginAction.IsSignInHeaderPresent())
            {
                LogInfo("Clicking on logout button.");
                WaitForMoment(2);
                _homeAction.ClickOnProfileImage();
                WaitForMoment(2);
                _homeAction.ClickOnLogoutButton();
                WaitForMoment(3);
                LogInfo("Logout operation is successful, it is in sign in page.");
            }
            else
            {
                LogInfo("It is in sign in page.");
            }
        }
        /// <summary>
        /// To Create the Chart for the given function, inbox
        /// </summary>
        /// <param name="chartName"></param>
        /// <param name="function"></param>
        /// <param name="persona"></param>
        /// <param name="inbox"></param>
        /// <param name="measure"></param>
        /// <param name="dimension"></param>
        public void CreateChart(string chartName, string function, string inbox, string measure, string dimension, string chartType = "Pie")
        {
            NavigateToInboxByGlobalSearch(function, inbox);
            _inboxAction.SelectAbstraction(WDAbstractions.Charts.ToString());
            _inboxChartsAction.SelectUserCreatedTab();
            _inboxChartsAction.ClickOnAddChart();
            _inboxChartsAction.EnterChartName(chartName);
            _inboxChartsAction.SelectChartType(chartType);
            _inboxChartsAction.SelectMeasueField(measure);
            _inboxChartsAction.SelectDimensionField(dimension);
            _inboxChartsAction.ClickOnCreateChart();
            _inboxChartsAction.VerifyChartTitle(chartName);
        }
        /// <summary>
        /// To Create the storyboard with create Charts/KPI's and import Charts/KPI's
        /// </summary>
        /// <param name="storyboardTitle"></param>
        /// <param name="function"></param>
        /// <param name="persona"></param>
        /// <param name="inbox"></param>
        /// <param name="chartName"></param>
        /// <param name="labelName"></param>
        /// <param name="measure"></param>
        /// <param name="dimension"></param>
        public void CreateStoryboard(string storyboardTitle, string function, string inbox, string chartName, string labelName, string measure, string dimension)
        {
            NavigateToInboxByGlobalSearch(function, inbox);

            //1. Creating the chart for the storyboard
            _inboxAction.SelectAbstraction(WDAbstractions.Storyboards.ToString());
            _storyboardsAction.ClickOnCreateStoryBoard();
            _storyboardsAction.EnterStoryboardTitle(storyboardTitle);
            _storyboardsAction.SelectStoryboardType("Chart");
            _inboxChartsAction.EnterChartName(chartName);
            _inboxChartsAction.SelectMeasueField(measure);
            _inboxChartsAction.SelectDimensionField(dimension);
            _inboxChartsAction.ClickOnCreateChart();
            LogInfo($"Creating the chart for the storyboard is completed");

            //2. Creating the KPI for the storyboard
            _storyboardsAction.SelectStoryboardType(WDAbstractions.KPIs.ToString());
            _inboxKpisAction.ConfigureKPI(labelName, "aggregation", measure);
            _inboxKpisAction.ClickOnSaveButton();
            LogInfo($"Creating the KPI for the storyboard is completed");

            //3. Import Chart
            _storyboardsAction.SelectStoryboardType("Import Chart");
            _storyboardsAction.ImportCharts();
            LogInfo($"Importing the Chart for the storyboard is completed");

            //4. Import KPI
            _storyboardsAction.SelectStoryboardType("Import KPI");
            _storyboardsAction.ImportKPIs();
            LogInfo($"Importing the KPI for the storyboard is completed");

            //5. Save the Storyboard
            _storyboardsAction.SaveStoryboard();
            _storyboardsAction.VerifyStoryboardCreation(storyboardTitle, true);
        }
        /// <summary>
        /// Navigates from home page to function, persona, inbox
        /// </summary>
        /// <param name="function"></param>
        /// <param name="persona"></param>
        /// <param name="inbox"></param>
        public void NavigateToInboxByGlobalSearch(string function, string inbox, bool checkErrorEmptyTemplate = true)
        {
            try
            {
                _homeAction.ClickOnFunction(function);
                _homeAction.ClickOnInboxesItem(inbox, checkErrorEmptyTemplate);
            }
            catch (Exception)
            {

                NavigateToInboxByInboxSearchOption(function, inbox);
            }

        }
        /// <summary>
        /// Navigates from home page to function, inbox
        /// </summary>
        /// <param name="function"></param>
        /// <param name="inbox"></param>
        public void NavigateToInboxByInboxSearchOption(string function, string inbox)
        {
            _homeAction.ClickOnFunction(function);
            _inboxAction.SearchInbox(inbox);
            _inboxAction.ClickInbox(inbox);
            _baseAction.WaitForLoadingToDisappear();
        }
        /// <summary>
        /// Navigates from home page to function, persona, inbox
        /// </summary>
        /// <param name="function"></param>
        /// <param name="persona"></param>
        /// <param name="inboxNames"></param>
        /// <param name="Action"></param>

        public void NavigateToSpecificAction(string function, string persona, string inboxNames, string Action)
        {
            _homeAction.ClickOnFunction(function);

            //Go to Persona
            //_homeAction.ClickOnPersona(persona);

            //NOTE: This is a Temprary fixed for the persona selection 
            //As there is a bug in the Framework need to remove this code once it is fixed
            if (!persona.Equals("Process Order Management"))
            {
                _homeAction.ClickOnPersona(persona);
                WaitForMoment(2);
            }

            //Go to Orders Inbox
            _inboxAction.ClickInbox(inboxNames);

            //Click on Master Action button, on right top corner.
            _inboxAction.ClickOnCreateMasterAction();

            //Click on Label Printing option
            _inboxAction.ClickOnActionOptions(Action);
            WaitForMoment(2);

            //Verifying Application should be navigate to its respected action page
            _labelPrintingAction.VerifyPageTitle(Action);
        }

        /// <summary>
        /// To Create the dashboard label in Inbox page
        /// </summary>
        /// <param name="labelName"></param>
        /// <param name="filterField"></param>
        /// <param name="filterOperator"></param>
        /// <param name="filterValue"></param>
        public void CreateDashboardLabel(string labelName, string filterField = "Currency", string filterOperator = "Equal", string filterValue = "All")
        {
            //Step-2a: Applying 1st Filter condition in the Details tab
            _inboxAction.SelectLabel("All");
            _inboxAction.ClickOnFilterActionsButton();
            //_inboxFilterAction.ApplyFilter(filterField, filterOperator, filterValue, 1);
            _inboxFilterAction.ApplyFilterUpdated(filterField, filterOperator, filterValue, 1);
            LogInfo($"Step-2a: Filtering the data for 1st Filter condition is successfull");

            //Step-3: Saving the dashboard label
            _inboxAction.ClickOnSaveLabel();
            _inboxAction.EnterLabelName(labelName);
            _inboxAction.ClickOnSaveLabelButton();
            LogInfo($"Step-3: Saving the dashboard label: {labelName} is successfull");
        }
        /// <summary>
        /// To Configure KPI with property Value
        /// </summary>
        /// <param name="labelName"></param>
        /// <param name="kpiTemplateName"></param>
        /// <param name="propertyValue"></param>
        public void ConfigureKPIWithValue(string labelName, string kpiTemplateName = "TestValue", string propertyValue = "Global Net Value", bool openKPI = false)
        {
            //Step-4: Configuring the KPI
            //Step-4a: Configuring the KPI with value
            _inboxKpisAction.SelectUserCreatedTab();
            if (openKPI)
            {
                _inboxAction.ScrollToElement(labelName);
                _inboxKpisAction.ClickOnEditImageByKPIName(labelName);
            }
            _inboxKpisAction.EnterKPIValueTitle(kpiTemplateName);
            _inboxKpisAction.SelectPropertyValue(propertyValue);
            _inboxKpisAction.SelectAggregationType("Field");
        }
        /// <summary>
        /// To Configure KPI with Measure and Dimension values
        /// </summary>
        /// <param name="labelName"></param>
        /// <param name="kpiTemplateName"></param>
        /// <param name="measureValue"></param>
        /// <param name="dimensionValue"></param>
        public void ConfigureKPIWithChart(string labelName, string kpiTemplateName = "TestValue", string chartType = "Column", string measureValue = "Net Value (netwr)", string dimensionValue = "Overall Processing Status (gbstk_desc)", bool openKPI = false)
        {
            _inboxKpisAction.SelectUserCreatedTab();
            if (openKPI)
            {
                _inboxAction.ScrollToElement(labelName);
                _inboxKpisAction.ClickOnEditImageByKPIName(labelName);
            }
            _inboxKpisAction.ClickOnAddKPITemplate();
            _inboxKpisAction.SelectAggregationType("Chart");
            _inboxChartsAction.EnterChartName(kpiTemplateName);
            _inboxChartsAction.SelectChartType(chartType);
            _inboxChartsAction.SelectMeasueField(measureValue);
            _inboxChartsAction.SelectDimensionField(dimensionValue);
        }
        /// <summary>
        /// To Configure KPI with Value(Property) and Chart(Measure & Dimension) values
        /// </summary>
        /// <param name="labelName"></param>
        /// <param name="kpiValueTemplateName"></param>
        /// <param name="propertyValue"></param>
        /// <param name="kpiChartTemplateName"></param>
        /// <param name="chartType"></param>
        /// <param name="measureValue"></param>
        /// <param name="dimensionValue"></param>
        public void ConfigureKPIWithValueAndChart(string labelName, string kpiValueTemplateName = "TestValue", string propertyValue = "Global Net Value", string kpiChartTemplateName = "TestChart", string chartType = "Column", string measureValue = "Net Value MTD", string dimensionValue = "Overall Processing Status")
        {
            //Step-4: Configuring the KPI
            //Step-4a: Configuring the KPI with value
            ConfigureKPIWithValue(labelName, kpiValueTemplateName, propertyValue, true);

            //Step-4b: Configuring the KPI with chart
            ConfigureKPIWithChart(labelName, kpiChartTemplateName, chartType, measureValue, dimensionValue, false);
        }
        public void NavigateToMyAppsInboxes(string myAppsInbox)
        {
            _homeAction.ClickOnFunction("Home");
            _homeAction.SelectMyAppsOption(myAppsInbox);
        }
        /// <summary>
        /// Clearing the Data based on the Abstraction parameter
        /// </summary>
        public void ClearAbstractionData(string abstractionName)
        {
            switch (abstractionName.ToLower())
            {
                case "kpis":
                    //Deleting the KPI Abstraction data
                    _inboxAction.SelectAbstraction(WDAbstractions.Details.ToString());
                    WaitForMoment(1);
                    _inboxAction.DeleteAllUserKPIs();
                    break;
                case "charts":
                    //Deleting the Charts Abstraction data
                    _inboxAction.SelectAbstraction(WDAbstractions.Charts.ToString());
                    WaitForMoment(1);
                    _inboxChartsAction.SelectUserCreatedTab();
                    WaitForMoment(1);
                    _inboxChartsAction.DeleteAllUserCharts();
                    break;
                case "storyboards":
                    //Deleting the Storyboards Abstraction data
                    _inboxAction.SelectAbstraction(WDAbstractions.Storyboards.ToString());
                    WaitForMoment(1);
                    _storyboardsAction.DeleteAllStoryboards();
                    break;
                case "favorites":
                    //Unfavoriting the Charts and KPI's
                    NavigateToMyAppsInboxes(MyAppsOptions.Favorites.ToString());
                    WaitForMoment(1);
                    _homeAction.UnFavoriteInFavoritesTab();
                    WaitForMoment(1);
                    _homeAction.ClickOnKPIsAndCharts();
                    WaitForMoment(1);
                    _homeAction.UnFavoriteInInsightsTab();
                    break;
                default:
                    LogInfo($"Abstraction Name : {abstractionName} is incorrect.");
                    break;
            }
        }
        public void ClearAllAbstractionData(string function = "Sales", string inbox = "Sales Orders")
        {
            ClearAbstractionData(MyAppsOptions.Favorites.ToString());

            string appEnvironment = GetApplicationEnvironment(applicationEnvironment);
            if (!appEnvironment.ToLower().Equals("prod") && !applicationName.ToLower().Contains("shopfloor"))
            {
                NavigateToInboxByGlobalSearch(function, inbox);
                ClearAbstractionData(WDAbstractions.KPIs.ToString());
                ClearAbstractionData(WDAbstractions.Charts.ToString());
                ClearAbstractionData(WDAbstractions.Storyboards.ToString());
            }

            _homeAction.ClickReloadModules();
            _homeAction.ClearCache();
        }
        public static void ApplicationDataCleanUp()
        {
            try
            {
                LogInfo("Application Data CleanUp started");

                LaunchApp();
                BaseTest baseTest = new BaseTest();
                baseTest.LoginToWD(userName, password);
                baseTest.ClearAllAbstractionData();
                _session.Close();

                LogInfo("Application Data CleanUp finished");
            }
            catch (Exception ex)
            {
                LogError($"{ex.Message} : {ex.StackTrace}");
            }

        }
        public static void NavigateToAbstractionsPage(string abstraction)
        {
            switch (abstraction.ToLower())
            {
                case "details":
                    //Verifying navigation to Details Page and Refresh icon.
                    _inboxAction.VerifyNavigationToDetailsPage();
                    break;

                case "kpis":
                    //Verifying navigation to KPIs Page and KPI visibility.
                    _inboxAction.VerifyKPIsVisibilityOnPage();
                    break;

                case "chart":
                    //Verifying navigation to Chart Page and Charts icons.
                    Assert.IsTrue(_inboxChartsAction.IsMyChartTabPresent(), "Global Charts tab is not available on page");
                    break;

                case "storyboards":
                    //Verifying navigation to Storyboard Page and create storyboard button.
                    Assert.IsTrue(_storyboardsAction.IsCreateStoryboardButtonPresent(), "Storyboard button is not available on page");
                    break;

                default:
                    LogInfo($"Abstraction Name : {abstraction} is incorrect.");
                    break;
            }
        }
        #endregion

        #region Parsing Test Results

        public void CaptureLogs(Exception ex)
        {
            testErrorMessage = OptimiseErrorDescription(ex.Message);
            LogError($"{ex.Message} : {ex.StackTrace}");
            CaptureScreenShot(_session, TestContext.TestName);
            this.TestContext.AddResultFile(screenshotFileName);
        }
        public ResultTable SaveTestResults(TestContext testContext)
        {
            // Getting the TC Description
            object testDescriptionObj = GetType().GetMethod(TestContext.TestName).GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault();
            string testDescription = testDescriptionObj?.GetType().GetProperty("Description").GetValue(testDescriptionObj, null).ToString();

            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}",
                       testTimer.Elapsed.Hours, testTimer.Elapsed.Minutes, testTimer.Elapsed.Seconds);

            // Writing Test Result Data To CSV File
            string currentDataRow = TestContext.DataRow?.Table.Rows.IndexOf(TestContext.DataRow).ToString();

            return new ResultTable(
                        testDescription + testContext.TestName + " (DataRow " + currentDataRow + ")",
                        testContext.CurrentTestOutcome.ToString(),
                        elapsedTime,
                        Regex.Replace(testErrorMessage, @"\r\n?|\n|,", String.Empty),
                        screenshotFileName
                        );
        }
        public string OptimiseErrorDescription(string actualMessage)
        {
            string errorMessage = string.Empty;

            if (actualMessage.ToLower().Contains("application window got closed"))
            {
                errorMessage = "Description: Application has got closed for one of the user action.";
            }
            else if (actualMessage.ToLower().Contains("elements not found with the xpath"))
            {
                errorMessage = "Description: FindByXPath method can’t find the element in the current Page using the following XPath. " + actualMessage;
            }
            else if (actualMessage.ToLower().Contains("elements not found with the accessibilityid"))
            {
                errorMessage = "Description: FindByAutomationId method can’t find the element in the current Page using the following Id. " + actualMessage;
            }
            else if (actualMessage.ToLower().Contains("assert.fail failed"))
            {
                errorMessage = "Description: TestCase got failed because with one of the test assertion step. " + actualMessage;
            }
            else if (actualMessage.ToLower().Contains("assert.istrue failed"))
            {
                errorMessage = "Description: TestCase got failed because with one of the test assertion step. " + actualMessage;
            }
            else
            {
                errorMessage = "Failure might be of sporadic one. " + actualMessage;
            }
            return errorMessage;
        }
        #endregion

        #region Submit Feedback on Failure
        public async Task CallFeedbackAPI(ResultTable resultsTable)
        {
            try
            {
                HttpClient client = new HttpClient();
                // Getting the Token
                var token = await GetAccessToken();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                string testCaseName = FormatTestCaseName(resultsTable.TestName);

                if (String.IsNullOrEmpty(buildVersionNumber))
                {
                    buildVersionNumber = GetBuildVersion();
                }

                Feedback feedback = new Feedback();
                feedback.Email = userName;
                feedback.Name = "Automation User";
                feedback.Phone = null;
                feedback.Title = testCaseName;
                feedback.Details = "Automation Feedback : " + resultsTable.ErrorMessage;
                feedback.Rating = 3;
                feedback.Persona = null;
                feedback.OptionalReceipients = "";
                feedback.QueueName = null;
                feedback.ImageUrl = ConvertToBase64(resultsTable.Screenshot);
                feedback.ApplicationName = applicationName;
                feedback.AppEnvironment = applicationEnvironment;
                feedback.ApplicationVersion = buildVersionNumber;
                feedback.ApplicationPlatform = "UWP";
                feedback.DeviceOSVersion = GetOSVersion();

                var serializedRoles = JsonConvert.SerializeObject(feedback);
                StringContent content = new StringContent(serializedRoles, Encoding.UTF8, "application/json");

                var requestMessage = new HttpRequestMessage(HttpMethod.Post, CommonTestSettings.feedbackAPI)
                {
                    Content = content
                };
                var responseMessage = await client.SendAsync(requestMessage);
                if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var responseText = await responseMessage.Content.ReadAsStringAsync();
                    LogInfo($"The Response Message : {responseText}");
                }
            }
            catch (Exception ex)
            {
                LogError($"{ex.Message} : {ex.StackTrace}");
            }
        }
        public static string ConvertToBase64(string screenshotPath)
        {
            byte[] imageArray = CompressBytes(File.ReadAllBytes(screenshotPath));
            string base64ImageRepresentation = Convert.ToBase64String(imageArray);
            return base64ImageRepresentation;
        }
        public static byte[] CompressBytes(byte[] imageBytes)
        {
            MemoryStream output = new MemoryStream();
            using (DeflateStream dstream = new DeflateStream(output, CompressionLevel.Optimal))
            {
                dstream.Write(imageBytes, 0, imageBytes.Length);
            }
            return output.ToArray();
        }
        public string GetBuildVersion()
        {
            string buildName = string.Empty;
            string currentDateTime = string.Empty;
            string fileDownloadedDateTime = string.Empty;
            string appxBuildPath = string.Empty;
            string appBuildVersion = string.Empty;
            bool fileDownloadedToday = false;

            try
            {
                LogInfo("Getting Build Version of the appxbundle started");

                currentDateTime = DateTime.Now.ToString("M/d/yyyy");

                string pattern = "*.msix";
                string appEnvironment = GetApplicationEnvironment(applicationEnvironment);
                appxBuildPath = Path.Combine(buildsPath, appEnvironment);
                var dirInfo = new DirectoryInfo(appxBuildPath);
                var file = (from f in dirInfo.GetFiles(pattern) orderby f.LastWriteTime descending select f).FirstOrDefault();

                if (file != null)
                {
                    fileDownloadedDateTime = file.LastAccessTime.Date.ToString("M/d/yyyy");

                    fileDownloadedToday = String.Equals(currentDateTime, fileDownloadedDateTime, StringComparison.InvariantCulture);

                    if (fileDownloadedToday)
                    {
                        buildName = file.Name;

                        string[] tokens = buildName.Split('_');
                        appBuildVersion = tokens[1];

                        LogInfo($"Build Version : {appBuildVersion}");
                        LogInfo("Getting Build Version of the appxbundle finished");
                    }
                    else
                    {
                        LogInfo($"No appxbundle downloaded today, found in Path : {appxBuildPath} on {currentDateTime}. So please check whether build downloaded successfully.");
                    }
                }
                else
                {
                    LogInfo($"No appxbundle downloaded today, found in Path : {appxBuildPath} on {currentDateTime}. So please check whether build downloaded successfully.");
                }
            }
            catch (Exception ex)
            {
                LogError($"{ex.Message} : {ex.StackTrace}");
                appBuildVersion = "";
            }
            return appBuildVersion;
        }
        public static string GetApplicationEnvironment(string environment)
        {
            string appEnvironment = string.Empty;

            switch (environment.ToLower())
            {
                case "dev":
                    appEnvironment = "Dev";
                    break;
                case "dvv":
                    appEnvironment = "Dvv";
                    break;
                case "uat":
                    appEnvironment = "UAT";
                    break;
                case "production":
                    appEnvironment = "PROD";
                    break;
                default:
                    LogInfo($"Application environment Name : {environment} is not matching.");
                    break;
            }
            return appEnvironment;
        }
        public static string FormatTestCaseName(string testCaseName)
        {
            string formatedTestCaseName = string.Empty;
            try
            {
                int startIndex = testCaseName.IndexOf("TC_");
                formatedTestCaseName = testCaseName.Substring(startIndex);
                string[] tcWithWhiteSpaces = formatedTestCaseName.Split(' ');
                formatedTestCaseName = tcWithWhiteSpaces[0];
            }
            catch (Exception ex)
            {
                LogError($"Error in fromating TC Name: {ex.Message} : {ex.StackTrace}");
                formatedTestCaseName = testCaseName.Substring(testCaseName.IndexOf("TC_"));
            }
            return formatedTestCaseName;
        }
        public async Task<string> GetAccessToken(string resourceUrl = "")
        {
            resourceUrl = CommonTestSettings.APIResouceURL;
            string clientId = CommonTestSettings.ClientId;
            string clientSecret = CommonTestSettings.ClientSecret;
            string authorityURL = CommonTestSettings.LoginBaseURL;

            try
            {
                var clientCredentials = new ClientCredential(clientId, clientSecret);
                var authContext = new AuthenticationContext(authorityURL);
                var authResult = await authContext.AcquireTokenAsync(resourceUrl, clientCredentials);
                return authResult.AccessToken;
            }
            catch (Exception ex)
            {
                LogError($"{ex.Message} : {ex.StackTrace}");
                return "";
            }
        }
        public string GetOSVersion()
        {
            try
            {
                ManagementObject mo = GetMngObj("Win32_OperatingSystem");

                if (null == mo)
                    return string.Empty;

                return mo["Version"] as string;
            }
            catch (Exception ex)
            {
                LogError($"{ex.Message} : {ex.StackTrace}");
                return string.Empty;
            }
        }
        private static ManagementObject GetMngObj(string className)
        {
            var wmi = new ManagementClass(className);

            foreach (var o in wmi.GetInstances())
            {
                var mo = (ManagementObject)o;
                if (mo != null) return mo;
            }
            return null;
        }
        #endregion

        #region Reading UserName and Password from Runsetting/Pipeline Variables
        public static void ReadUserEmailIDandPassword(TestContext context)
        {
            LogInfo("Reading of the UserEmailID and Password fields Started");

            LoadPipelineVariables();

            if (string.IsNullOrEmpty(userName) | string.IsNullOrEmpty(password))
            {
                userName = context.Properties["TestUser1EmailId"].ToString();
                string encryptedPassword = context.Properties["TestUser1Password"].ToString();
                password = CommonTestSettings.Decrypt(encryptedPassword);
            }

            LogInfo("Reading of the UserEmailID and Password fields finished");
        }
        async public static Task LoadPipelineVariables()
        {
            try
            {
                LogInfo("Reading of the Pipleline Variables Started");

                string appEnvironment = GetApplicationEnvironment(applicationEnvironment);
                if (appEnvironment.ToLower().Equals("prod"))
                {
                    await GetAzureKeyVaultData();

                    WaitForMoment(5);
                    LogInfo("Production UserName : " + userName);
                }
                else
                {
                    userName = Environment.GetEnvironmentVariable("UserName");
                    password = Environment.GetEnvironmentVariable("Password");
                }

                LogInfo("Reading of the Pipleline Variables finished");
            }
            catch (Exception ex)
            {
                LogError("Issue in reading the Azure Pipeline Variables: " + ex.Message);
            }
        }
        async public static Task GetAzureKeyVaultData()
        {
            string ClientId = CommonTestSettings.AzureKeyVaultClientId;
            string BaseURI = CommonTestSettings.AzureKeyVaultBaseURI;
            string ClientSecret = CommonTestSettings.AzureKeyVaultClientSecret;

            try
            {
                var client = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(
                async (string auth, string res, string scopr) =>
                {
                    var authContext = new Microsoft.IdentityModel.Clients.ActiveDirectory.AuthenticationContext(auth);
                    var credential = new ClientCredential(ClientId, ClientSecret);
                    AuthenticationResult result = await authContext.AcquireTokenAsync(res, credential);

                    if (result == null)
                    {
                        throw new InvalidOperationException("Failed to retrieve token");
                    }
                    return result.AccessToken;
                }
                ));

                var secretUserName = await client.GetSecretAsync(BaseURI, "automationuserid");
                var secretPassword = await client.GetSecretAsync(BaseURI, "automationusersecret");

                userName = secretUserName.Value;
                password = secretPassword.Value;
            }
            catch (Exception ex)
            {
                LogError($"{ex.Message} : {ex.StackTrace}");
            }
        }
        #endregion

        #region Handling TestData based on Environment

        public static void CopyTestDataBasedOnEnvironemnt(string appEnvironment)
        {
            try
            {
                string testDataSourceDirPath = appEnvironment;
                DirectoryInfo sourceDir = new DirectoryInfo(testDataSourceDirPath);

                Console.WriteLine(sourceDir.FullName.ToString());

                string testDataDestDirPath = ".\\";
                DirectoryInfo destDir = new DirectoryInfo(testDataDestDirPath);

                Console.WriteLine(destDir.FullName.ToString());

                foreach (FileInfo file in sourceDir.GetFiles("*.*", SearchOption.TopDirectoryOnly))
                    file.CopyTo(Path.Combine(destDir.FullName, file.Name), true);
            }
            catch (Exception ex)
            {
                LogError("Issue in reading the Azure Pipeline Variables: " + ex.Message);
            }
        }

        #endregion
    }

    public class SkipInitializeAttribute : Attribute
    {
    }
}
