using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using West.EnterpriseUX.Automation.UWP.Utilities;

namespace West.EnterpriseUX.Automation.UWP.Tests
{
    [TestClass]
    public class HRTests : BaseTest
    {

        #region HR Tests
        [TestMethod]
        [TestCategory("HRTest")]
        [Description("Verify Reset functionality while adding new bank from Bank Inbox;;")]
        [Owner("vineeth.pamuexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"HR_277583.csv", "HR_277583#csv", DataAccessMethod.Sequential)]
        public void TC_277583_ResetFunctionalityOfNewBankDetailsTest()
        {
            try
            {
                LogInfo("=============================== Test Method execution has started ======================");
                string testUser = this.TestContext.Properties["HRInitiator"].ToString();
                string country = this.TestContext.DataRow["country"].ToString();
                string iBAN = this.TestContext.DataRow["iBAN"].ToString();
                string bankControlKey = this.TestContext.DataRow["bankControlKey"].ToString();
                string testUserPassword = TestContext.Properties["HRPassword"].ToString();
                LogInfo($"testUser: {testUser}, testUserPassword: {testUserPassword}");
                string payeeName = string.Empty;
                string accountNumber = string.Empty;
                string amount = _helper.GenerateRandomDigits(2);
                string uniqueNumber = _helper.GenerateUniqueRandomNumber();
                string banktype = this.TestContext.DataRow["bankType"].ToString();

                payeeName = $"Payeeof{country}" + uniqueNumber.ToString();
                accountNumber = _helper.GenerateRandomDigits(7);

                LogInfo($"Country: {country},TestUserEmailID: {testUser},PayeeName: {payeeName},IBAN: {iBAN},AccountNumber: {accountNumber}, BankControlKey: {bankControlKey}, bankType: {banktype}");

                //LogoutWD application
                LogoutWD();
                // Launching the App Instance
                LaunchApp();

                // Login with the test user account
                LoginToWD(testUser, testUserPassword);

                NavigateToInboxByGlobalSearch("Human Resources", "Personal Profile");
                WaitForMoment(2);
                _inboxAction.SelectFirstInboxRecord();
                WaitForMoment(2);
                _childInboxAction.ClickOnChildInboxeItem("Personal Profile", "Banking");
                WaitForMoment(2);
                _childInboxAction.ClickOnFirstChildInboxeItem("Personal Profile", "Banking");
                WaitForMoment(5);
                _childInboxAction.ClickOnCreateButton();
                WaitForMoment(2);
                _hrBankAction.VerifyBankDetailsResetFunctionality(payeeName, iBAN, accountNumber, amount, country, bankControlKey, banktype);
                WaitForMoment(2);
                screenshotFileName = string.Empty;
                LogInfo("=================Test Method Execution Completed =================");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("HRTest")]
        [Description("Verify Mandatory fields required Message displayed while adding new Main bank;;")]
        [Owner("vineeth.pamuexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"HR_277754.csv", "HR_277754#csv", DataAccessMethod.Sequential)]
        public void TC_277754_ErrorMessageInNewMainBankDetails()
        {
            try
            {
                LogInfo("=============================== Test Method execution has started ======================");
                string bankType = this.TestContext.DataRow["bankType"].ToString();
                string popUpMessage = this.TestContext.DataRow["message"].ToString();
                string testUser = this.TestContext.Properties["HRInitiator"].ToString();
                string testUserPassword = TestContext.Properties["HRPassword"].ToString();
                LogInfo($"testUser: {testUser}, testUserPassword: {testUserPassword}");

                //LogoutWD application
                LogoutWD();
                // Launching the App Instance
                LaunchApp();
                // Login with the test user account
                LogInfo("=========Logged in with User : " + testUser);
                LoginToWD(testUser, testUserPassword);

                NavigateToInboxByGlobalSearch("Human Resources", "Personal Profile");
                WaitForMoment(2);
                _inboxAction.SelectFirstInboxRecord();
                WaitForMoment(2);
                _childInboxAction.ClickOnChildInboxeItem("Personal Profile", "Banking");
                WaitForMoment(2);
                _childInboxAction.ClickOnFirstChildInboxeItem("Personal Profile", "Banking");
                WaitForMoment(3);
                _childInboxAction.ClickOnCreateButton();
                WaitForMoment(2);
                _hrBankAction.SelectBankType(bankType);
                _hrBankAction.ClickOnSave();
                WaitForMoment(2);
                _hrBankAction.ValidatePopUpMessage(popUpMessage);
                WaitForMoment(2);
                _hrBankAction.ClickOkButton();
                screenshotFileName = string.Empty;
                LogInfo("=================Test Method Execution Completed =================");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("HRTest")]
        [Description("Test End Main Bank Functionality Error Message;;")]
        [Owner("vineeth.pamuexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"HR_277755.csv", "HR_277755#csv", DataAccessMethod.Sequential)]
        public void TC_277755_EndMainBankFunctionalityError()
        {
            try
            {
                LogInfo("=============================== Test Method execution has started ======================");
                string bankType = this.TestContext.DataRow["bankType"].ToString();
                string popUpMessage = this.TestContext.DataRow["message"].ToString();
                string testUser = this.TestContext.Properties["HRInitiator"].ToString();
                string testUserPassword = TestContext.Properties["HRPassword"].ToString();
                LogInfo($"testUser: {testUser}, testUserPassword: {testUserPassword}");

                //LogoutWD application
                LogoutWD();
                // Launching the App Instance
                LaunchApp();
                // Login with the test user account of that specific country
                LogInfo("=========Logged in with User : " + testUser);
                LoginToWD(testUser, testUserPassword);

                NavigateToInboxByGlobalSearch("Human Resources", "Personal Profile");
                WaitForMoment(2);
                _inboxAction.SelectFirstInboxRecord();
                WaitForMoment(2);
                _childInboxAction.ClickOnChildInboxeItem("Personal Profile", "Banking");
                WaitForMoment(2);
                _childInboxAction.ClickOnFirstChildInboxeItem("Personal Profile", "Banking");
                WaitForMoment(3);
                    _hrBankAction.SelectBankAction(bankType);
                    WaitForMoment(2);
                    _hrBankAction.SelectEndNow();
                    WaitForMoment(2);
                    _hrBankAction.ValidatePopUpMessage(popUpMessage);
                    WaitForMoment(2);
                    _hrBankAction.ClickOkButton();
                    screenshotFileName = string.Empty;
                    LogInfo("=================Test Method Execution Completed =================");
               
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("HRTest")]
        [Description("Verify Mandatory fields required Message displayed while adding new Other bank;;")]
        [Owner("vineeth.pamuexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"HR_280542.csv", "HR_280542#csv", DataAccessMethod.Sequential)]
        public void TC_280542_ErrorMessageInNewOtherBankDetails()
        {
            try
            {
                LogInfo("=============================== Test Method execution has started ======================");
                string bankType = this.TestContext.DataRow["bankType"].ToString();
                string popUpMessage = this.TestContext.DataRow["message"].ToString();
                string testUser = this.TestContext.Properties["HRInitiator"].ToString();
                string testUserPassword = TestContext.Properties["HRPassword"].ToString();
                LogInfo($"testUser: {testUser}, testUserPassword: {testUserPassword}");

                //LogoutWD application
                LogoutWD();
                // Launching the App Instance
                LaunchApp();

                // Login with the test user account of that specific country
                LogInfo("=========Logged in with User : " + testUser);
                LoginToWD(testUser, testUserPassword);

                NavigateToInboxByGlobalSearch("Human Resources", "Personal Profile");
                WaitForMoment(2);
                _inboxAction.SelectFirstInboxRecord();
                WaitForMoment(2);
                _childInboxAction.ClickOnChildInboxeItem("Personal Profile", "Banking");
                WaitForMoment(2);
                _childInboxAction.ClickOnFirstChildInboxeItem("Personal Profile", "Banking");
                WaitForMoment(3);
                _childInboxAction.ClickOnCreateButton();
                WaitForMoment(2);
                _hrBankAction.SelectBankType(bankType);
                _hrBankAction.ClickOnSave();
                WaitForMoment(2);
                _hrBankAction.ValidatePopUpMessage(popUpMessage);
                WaitForMoment(2);
                _hrBankAction.ClickOkButton();
                screenshotFileName = string.Empty;
                LogInfo("=================Test Method Execution Completed =================");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("HRTest")]
        [Description("Verify Bank Reset Functionality from Profile Page;;")]
        [Owner("vineeth.pamuexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"HR_277583.csv", "HR_277583#csv", DataAccessMethod.Sequential)]
        public void TC_331881_BankResetFunctionalityFromProfilePage()
        {
            try
            {
                LogInfo("=============================== Test Method execution has started ======================");
                string bankType = this.TestContext.DataRow["bankType"].ToString();
                //string popUpMessage = this.TestContext.DataRow["message"].ToString();
                string testUser = this.TestContext.Properties["HRInitiator"].ToString();
                string testUserPassword = TestContext.Properties["HRPassword"].ToString();
                LogInfo($"testUser: {testUser}, testUserPassword: {testUserPassword}");

                string country = this.TestContext.DataRow["country"].ToString();
                string iBAN = this.TestContext.DataRow["iBAN"].ToString();
                string bankControlKey = this.TestContext.DataRow["bankControlKey"].ToString();
                LogInfo($"testUser: {testUser}, testUserPassword: {testUserPassword}");
                string payeeName = string.Empty;
                string accountNumber = string.Empty;
                string amount = _helper.GenerateRandomDigits(2);
                string uniqueNumber = _helper.GenerateUniqueRandomNumber();

                payeeName = $"Payeeof{country}" + uniqueNumber.ToString();
                accountNumber = _helper.GenerateRandomDigits(7);

                LogInfo($"Country: {country},TestUserEmailID: {testUser},PayeeName: {payeeName},IBAN: {iBAN},AccountNumber: {accountNumber}, BankControlKey: {bankControlKey}, BankType: {bankType}");

                //LogoutWD application
                LogoutWD();
                // Launching the App Instance
                LaunchApp();

                // Login with the test user account of that specific country
                LogInfo("=========Logged in with User : " + testUser);
                LoginToWD(testUser, testUserPassword);

                WaitForMoment(2);
                _homeAction.ClickOnProfileImage();
                _homeAction.ViewLoggedInUserProfile();
                WaitForMoment(2);
                _hrBankAction.SelectBankAccountMenuOption();
                WaitForMoment(2);
                _childInboxAction.ClickOnCreateButton();
                WaitForMoment(2);
                _hrBankAction.VerifyBankDetailsResetFunctionality(payeeName, iBAN, accountNumber, amount, country, bankControlKey, bankType);
                WaitForMoment(2);
                screenshotFileName = string.Empty;
                LogInfo("=================Test Method Execution Completed =================");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("HRTest")]
        [Description("Create US Main Bank from Bank Inbox;;")]
        [Owner("vineeth.pamuexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"HR_CreateBank_480838.csv", "HR_CreateBank_480838#csv", DataAccessMethod.Sequential)]
        public void TC_480838_CreateUSMainBankFromBankInbox()
        {
            try
            {
                LogInfo("=============================== Test Method execution has started ======================");
                string bankType = this.TestContext.DataRow["bankType"].ToString();
                string popUpMessage = this.TestContext.DataRow["message"].ToString();
                string bankControlKey = this.TestContext.DataRow["bankControlKey"].ToString();
                string testUser = this.TestContext.Properties["HR_USOrigin"].ToString();
                string testUserPassword = TestContext.Properties["HRPassword"].ToString();
                LogInfo($"testUser: {testUser}, testUserPassword: {testUserPassword}");

                string country = this.TestContext.DataRow["country"].ToString();
                string payeeName = string.Empty;
                string accountNumber = string.Empty;
                string uniqueNumber = _helper.GenerateUniqueRandomNumber();
                string iBAN = this.TestContext.DataRow["iBAN"].ToString();
                payeeName = $"Payeeof{country}" + uniqueNumber.ToString();
                accountNumber = _helper.GenerateRandomDigits(10);
                string confirmBankAccountNumber = accountNumber;
                string shareAmount = _helper.GenerateRandomDigits(3);
                string sharePercentage = _helper.GenerateRandomDigits(2);
                LogInfo($"Country: {country},TestUserEmailID: {testUser}, iBAN: {iBAN}, PayeeName: {payeeName},AccountNumber: {accountNumber}, ConfirmBankAccountNumber: {confirmBankAccountNumber}, BankControlKey: {bankControlKey}, BankType: {bankType}, shareAmount: {shareAmount}, sharePercentage: {sharePercentage}");


                //LogoutWD application
                LogoutWD();
                // Launching the App Instance
                LaunchApp();

                // Login with the test user account of that specific country
                LogInfo("=========Logged in with User : " + testUser);
                LoginToWD(testUser, testUserPassword);

                NavigateToInboxByGlobalSearch("Human Resources", "Personal Profile");
                WaitForMoment(2);
                _inboxAction.SelectFirstInboxRecord();
                WaitForMoment(2);
                _childInboxAction.ClickOnChildInboxeItem("Personal Profile", "Banking");
                WaitForMoment(2);
                _childInboxAction.ClickOnFirstChildInboxeItem("Personal Profile", "Banking");
                WaitForMoment(3);
                _childInboxAction.ClickOnCreateButton();
                WaitForMoment(2);
                _hrBankAction.CreateBank(bankType, country, payeeName, accountNumber, confirmBankAccountNumber, bankControlKey, popUpMessage, iBAN, shareAmount, sharePercentage);
                screenshotFileName = string.Empty;
                LogInfo("=================Test Method Execution Completed =================");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("HRTest")]
        [Description("Create US Main Bank from Profile Page;;")]
        [Owner("vineeth.pamuexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"HR_CreateBank_480838.csv", "HR_CreateBank_480838#csv", DataAccessMethod.Sequential)]
        public void TC_480841_CreateUSMainBankFromProfiePage()
        {
            try
            {
                LogInfo("=============================== Test Method execution has started ======================");
                string bankType = this.TestContext.DataRow["bankType"].ToString();
                string popUpMessage = this.TestContext.DataRow["message"].ToString();
                string bankControlKey = this.TestContext.DataRow["bankControlKey"].ToString();
                string testUser = this.TestContext.Properties["HR_USOrigin"].ToString();
                string testUserPassword = TestContext.Properties["HRPassword"].ToString();
                LogInfo($"testUser: {testUser}, testUserPassword: {testUserPassword}");

                string country = this.TestContext.DataRow["country"].ToString();
                string payeeName = string.Empty;
                string accountNumber = string.Empty;
                string uniqueNumber = _helper.GenerateUniqueRandomNumber();
                string iBAN = this.TestContext.DataRow["iBAN"].ToString();
                payeeName = $"Payeeof{country}" + uniqueNumber.ToString();
                accountNumber = _helper.GenerateRandomDigits(10);
                string confirmBankAccountNumber = accountNumber;
                string shareAmount = _helper.GenerateRandomDigits(3);
                string sharePercentage = _helper.GenerateRandomDigits(2);
                LogInfo($"Country: {country},TestUserEmailID: {testUser}, iBAN: {iBAN}, PayeeName: {payeeName},AccountNumber: {accountNumber}, ConfirmBankAccountNumber: {confirmBankAccountNumber}, BankControlKey: {bankControlKey}, BankType: {bankType}, shareAmount: {shareAmount}, sharePercentage: {sharePercentage}");

                //LogoutWD application
                LogoutWD();
                // Launching the App Instance
                LaunchApp();

                // Login with the test user account of that specific country
                LogInfo("=========Logged in with User : " + testUser);
                LoginToWD(testUser, testUserPassword);

                WaitForMoment(2);
                _homeAction.ClickOnProfileImage();
                _homeAction.ViewLoggedInUserProfile();
                WaitForMoment(2);
                _hrBankAction.SelectBankAccountMenuOption();
                WaitForMoment(2);
                _childInboxAction.ClickOnCreateButton();
                WaitForMoment(2);
                _hrBankAction.CreateBank(bankType, country, payeeName, accountNumber, confirmBankAccountNumber, bankControlKey, popUpMessage, iBAN, shareAmount, sharePercentage);
                screenshotFileName = string.Empty;
                LogInfo("=================Test Method Execution Completed =================");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("HRTest")]
        [Description("Error Alert when Reentered Account is not same from Profile Page;;")]
        [Owner("vineeth.pamuexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"HR_CreateBankAccountError_480843.csv", "HR_CreateBankAccountError_480843#csv", DataAccessMethod.Sequential)]
        public void TC_480843_VerifyErrorAlertInAccountNumberReEnterFromProfiePage()
        {
            try
            {
                LogInfo("=============================== Test Method execution has started ======================");
                string bankType = this.TestContext.DataRow["bankType"].ToString();
                string popUpMessage = this.TestContext.DataRow["message"].ToString();
                string bankControlKey = this.TestContext.DataRow["bankControlKey"].ToString();
                string testUser = this.TestContext.Properties["HR_USOrigin"].ToString();
                string testUserPassword = TestContext.Properties["HRPassword"].ToString();
                LogInfo($"testUser: {testUser}, testUserPassword: {testUserPassword}");

                string country = this.TestContext.DataRow["country"].ToString();
                string payeeName = string.Empty;
                string accountNumber = string.Empty;
                string uniqueNumber = _helper.GenerateUniqueRandomNumber();
                string iBAN = this.TestContext.DataRow["iBAN"].ToString();
                payeeName = $"Payeeof{country}" + uniqueNumber.ToString();
                accountNumber = _helper.GenerateRandomDigits(10);
                string confirmBankAccountNumber = string.Empty;
                do
                {
                    confirmBankAccountNumber = _helper.GenerateRandomDigits(10);
                    bool flag = confirmBankAccountNumber.Contains(accountNumber);
                } while (confirmBankAccountNumber.Equals(accountNumber));
                string shareAmount = _helper.GenerateRandomDigits(3);
                string sharePercentage = _helper.GenerateRandomDigits(2);
                LogInfo($"Country: {country},TestUserEmailID: {testUser}, iBAN: {iBAN}, PayeeName: {payeeName},AccountNumber: {accountNumber}, ConfirmBankAccountNumber: {confirmBankAccountNumber}, BankControlKey: {bankControlKey}, BankType: {bankType}, shareAmount: {shareAmount}, sharePercentage: {sharePercentage}");

                //LogoutWD application
                LogoutWD();
                // Launching the App Instance
                LaunchApp();

                // Login with the test user account of that specific country
                LogInfo("=========Logged in with User : " + testUser);
                LoginToWD(testUser, testUserPassword);

                WaitForMoment(2);
                _homeAction.ClickOnProfileImage();
                _homeAction.ViewLoggedInUserProfile();
                WaitForMoment(2);
                _hrBankAction.SelectBankAccountMenuOption();
                WaitForMoment(2);
                _childInboxAction.ClickOnCreateButton();
                WaitForMoment(2);
                _hrBankAction.CreateBank(bankType, country, payeeName, accountNumber, confirmBankAccountNumber, bankControlKey, popUpMessage, iBAN, shareAmount, sharePercentage);
                screenshotFileName = string.Empty;
                LogInfo("=================Test Method Execution Completed =================");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("HRTest")]
        [Description("Error Alert when Reentered Account is not same from Bank Inbox;;")]
        [Owner("vineeth.pamuexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"HR_CreateBankAccountError_480843.csv", "HR_CreateBankAccountError_480843#csv", DataAccessMethod.Sequential)]
        public void TC_480846_VerifyErrorAlertInAccountNumberReEnterFromBankInbox()
        {
            try
            {
                LogInfo("=============================== Test Method execution has started ======================");
                string bankType = this.TestContext.DataRow["bankType"].ToString();
                string popUpMessage = this.TestContext.DataRow["message"].ToString();
                string bankControlKey = this.TestContext.DataRow["bankControlKey"].ToString();
                string testUser = this.TestContext.Properties["HR_USOrigin"].ToString();
                string testUserPassword = TestContext.Properties["HRPassword"].ToString();
                LogInfo($"testUser: {testUser}, testUserPassword: {testUserPassword}");

                string country = this.TestContext.DataRow["country"].ToString();
                string payeeName = string.Empty;
                string accountNumber = string.Empty;
                string uniqueNumber = _helper.GenerateUniqueRandomNumber();
                string iBAN = this.TestContext.DataRow["iBAN"].ToString();
                payeeName = $"Payeeof{country}" + uniqueNumber.ToString();
                accountNumber = _helper.GenerateRandomDigits(10);
                string confirmBankAccountNumber = string.Empty;
                do
                {
                    confirmBankAccountNumber = _helper.GenerateRandomDigits(10);
                    bool flag = confirmBankAccountNumber.Contains(accountNumber);
                } while (confirmBankAccountNumber.Equals(accountNumber));
                string shareAmount = _helper.GenerateRandomDigits(3);
                string sharePercentage = _helper.GenerateRandomDigits(2);
                LogInfo($"Country: {country},TestUserEmailID: {testUser}, iBAN: {iBAN}, PayeeName: {payeeName},AccountNumber: {accountNumber}, ConfirmBankAccountNumber: {confirmBankAccountNumber}, BankControlKey: {bankControlKey}, BankType: {bankType}, shareAmount: {shareAmount}, sharePercentage: {sharePercentage}");

                //LogoutWD application
                LogoutWD();
                // Launching the App Instance
                LaunchApp();

                // Login with the test user account of that specific country
                LogInfo("=========Logged in with User : " + testUser);
                LoginToWD(testUser, testUserPassword);

                WaitForMoment(2);
                NavigateToInboxByGlobalSearch("Human Resources", "Personal Profile");
                WaitForMoment(2);
                _inboxAction.SelectFirstInboxRecord();
                WaitForMoment(2);
                _childInboxAction.ClickOnChildInboxeItem("Personal Profile", "Banking");
                WaitForMoment(2);
                _childInboxAction.ClickOnFirstChildInboxeItem("Personal Profile", "Banking");
                WaitForMoment(3);
                _childInboxAction.ClickOnCreateButton();
                WaitForMoment(2);
                _hrBankAction.CreateBank(bankType, country, payeeName, accountNumber, confirmBankAccountNumber, bankControlKey, popUpMessage, iBAN, shareAmount, sharePercentage);
                screenshotFileName = string.Empty;
                LogInfo("=================Test Method Execution Completed =================");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("HRTest")]
        [Description("Error Alert when Confirm Bank Account is null from Profile Page;;")]
        [Owner("vineeth.pamuexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"HR_CreateBankAccountError_480843.csv", "HR_CreateBankAccountError_480843#csv", DataAccessMethod.Sequential)]
        public void TC_480847_VerifyErrorAlert_ConfirmAccountNullInProfiePage()
        {
            try
            {
                LogInfo("=============================== Test Method execution has started ======================");
                string bankType = this.TestContext.DataRow["bankType"].ToString();
                string popUpMessage = this.TestContext.DataRow["message"].ToString();
                string bankControlKey = this.TestContext.DataRow["bankControlKey"].ToString();
                string testUser = this.TestContext.Properties["HR_USOrigin"].ToString();
                string testUserPassword = TestContext.Properties["HRPassword"].ToString();
                LogInfo($"testUser: {testUser}, testUserPassword: {testUserPassword}");

                string country = this.TestContext.DataRow["country"].ToString();
                string payeeName = string.Empty;
                string accountNumber = string.Empty;
                string uniqueNumber = _helper.GenerateUniqueRandomNumber();
                string iBAN = this.TestContext.DataRow["iBAN"].ToString();
                payeeName = $"Payeeof{country}" + uniqueNumber.ToString();
                accountNumber = _helper.GenerateRandomDigits(10);
                string confirmBankAccountNumber = null;
                string shareAmount = _helper.GenerateRandomDigits(3);
                string sharePercentage = _helper.GenerateRandomDigits(2);
                LogInfo($"Country: {country},TestUserEmailID: {testUser}, iBAN: {iBAN}, PayeeName: {payeeName},AccountNumber: {accountNumber}, ConfirmBankAccountNumber: {confirmBankAccountNumber}, BankControlKey: {bankControlKey}, BankType: {bankType}, shareAmount: {shareAmount}, sharePercentage: {sharePercentage}");

                //LogoutWD application
                LogoutWD();
                // Launching the App Instance
                LaunchApp();

                // Login with the test user account of that specific country
                LogInfo("=========Logged in with User : " + testUser);
                LoginToWD(testUser, testUserPassword);

                WaitForMoment(2);
                _homeAction.ClickOnProfileImage();
                _homeAction.ViewLoggedInUserProfile();
                WaitForMoment(2);
                _hrBankAction.SelectBankAccountMenuOption();
                WaitForMoment(2);
                _childInboxAction.ClickOnCreateButton();
                WaitForMoment(2);
                _hrBankAction.CreateBank(bankType, country, payeeName, accountNumber, "", bankControlKey, popUpMessage, iBAN, shareAmount, sharePercentage);
                screenshotFileName = string.Empty;
                LogInfo("=================Test Method Execution Completed =================");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("HRTest")]
        [Description("Error Alert when Confirm Bank Account is null from Bank Inbox;;")]
        [Owner("vineeth.pamuexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"HR_CreateBankAccountError_480843.csv", "HR_CreateBankAccountError_480843#csv", DataAccessMethod.Sequential)]
        public void TC_480849_VerifyErrorAlert_ConfirmAccountNullInBankInbox()
        {
            try
            {
                LogInfo("=============================== Test Method execution has started ======================");
                string bankType = this.TestContext.DataRow["bankType"].ToString();
                string popUpMessage = this.TestContext.DataRow["message"].ToString();
                string bankControlKey = this.TestContext.DataRow["bankControlKey"].ToString();
                string testUser = this.TestContext.Properties["HR_USOrigin"].ToString();
                string testUserPassword = TestContext.Properties["HRPassword"].ToString();
                LogInfo($"testUser: {testUser}, testUserPassword: {testUserPassword}");

                string country = this.TestContext.DataRow["country"].ToString();
                string payeeName = string.Empty;
                string accountNumber = string.Empty;
                string uniqueNumber = _helper.GenerateUniqueRandomNumber();
                string iBAN = this.TestContext.DataRow["iBAN"].ToString();
                payeeName = $"Payeeof{country}" + uniqueNumber.ToString();
                accountNumber = _helper.GenerateRandomDigits(10);
                string confirmBankAccountNumber = null;
                string shareAmount = _helper.GenerateRandomDigits(3);
                string sharePercentage = _helper.GenerateRandomDigits(2);
                LogInfo($"Country: {country},TestUserEmailID: {testUser}, iBAN: {iBAN}, PayeeName: {payeeName},AccountNumber: {accountNumber}, ConfirmBankAccountNumber: {confirmBankAccountNumber}, BankControlKey: {bankControlKey}, BankType: {bankType}, shareAmount: {shareAmount}, sharePercentage: {sharePercentage}");

                //LogoutWD application
                LogoutWD();
                // Launching the App Instance
                LaunchApp();

                // Login with the test user account of that specific country
                LogInfo("=========Logged in with User : " + testUser);
                LoginToWD(testUser, testUserPassword);

                WaitForMoment(2);
                NavigateToInboxByGlobalSearch("Human Resources", "Personal Profile");
                WaitForMoment(2);
                _inboxAction.SelectFirstInboxRecord();
                WaitForMoment(2);
                _childInboxAction.ClickOnChildInboxeItem("Personal Profile", "Banking");
                WaitForMoment(2);
                _childInboxAction.ClickOnFirstChildInboxeItem("Personal Profile", "Banking");
                WaitForMoment(3);
                _childInboxAction.ClickOnCreateButton();
                WaitForMoment(2);
                _hrBankAction.CreateBank(bankType, country, payeeName, accountNumber, "", bankControlKey, popUpMessage, iBAN, shareAmount, sharePercentage);
                screenshotFileName = string.Empty;
                LogInfo("=================Test Method Execution Completed =================");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        
        [TestMethod]
        [TestCategory("HRTest")]
        [Description("Create US Other Bank from Bank Inbox;;")]
        [Owner("vineeth.pamuexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"HR_CreateOtherBank_480856.csv", "HR_CreateOtherBank_480856#csv", DataAccessMethod.Sequential)]
        public void TC_480856_CreateUSOtherBankFromBankInbox()
        {
            try
            {
                LogInfo("=============================== Test Method execution has started ======================");
                string bankType = this.TestContext.DataRow["bankType"].ToString();
                string popUpMessage = this.TestContext.DataRow["message"].ToString();
                string bankControlKey = this.TestContext.DataRow["bankControlKey"].ToString();
                string testUser = this.TestContext.Properties["HR_USOrigin"].ToString();
                string testUserPassword = TestContext.Properties["HRPassword"].ToString();
                LogInfo($"testUser: {testUser}, testUserPassword: {testUserPassword}");

                string country = this.TestContext.DataRow["country"].ToString();
                string payeeName = string.Empty;
                string accountNumber = string.Empty;
                string uniqueNumber = _helper.GenerateUniqueRandomNumber();
                string iBAN = this.TestContext.DataRow["iBAN"].ToString();
                payeeName = $"Payeeof{country}" + uniqueNumber.ToString();
                accountNumber = _helper.GenerateRandomDigits(10);
                string confirmBankAccountNumber = accountNumber;
                string shareAmount = _helper.GenerateRandomDigits(3);
                string sharePercentage = _helper.GenerateRandomDigits(2);
                LogInfo($"Country: {country},TestUserEmailID: {testUser}, iBAN: {iBAN}, PayeeName: {payeeName},AccountNumber: {accountNumber}, ConfirmBankAccountNumber: {confirmBankAccountNumber}, BankControlKey: {bankControlKey}, BankType: {bankType}, shareAmount: {shareAmount}, sharePercentage: {sharePercentage}");

                //LogoutWD application
                LogoutWD();
                // Launching the App Instance
                LaunchApp();

                // Login with the test user account of that specific country
                LogInfo("=========Logged in with User : " + testUser);
                LoginToWD(testUser, testUserPassword);

                WaitForMoment(2);
                NavigateToInboxByGlobalSearch("Human Resources", "Personal Profile");
                WaitForMoment(2);
                _inboxAction.SelectFirstInboxRecord();
                WaitForMoment(2);
                _childInboxAction.ClickOnChildInboxeItem("Personal Profile", "Banking");
                WaitForMoment(2);
                _childInboxAction.ClickOnFirstChildInboxeItem("Personal Profile", "Banking");
                WaitForMoment(3);
                _childInboxAction.ClickOnCreateButton();
                WaitForMoment(2);
                _hrBankAction.CreateBank(bankType, country, payeeName, accountNumber, confirmBankAccountNumber, bankControlKey, popUpMessage, iBAN, shareAmount, sharePercentage);

                //Verify Other Bank Created is available in Profile Page
                WaitForMoment(2);
                _homeAction.ClickOnProfileImage();
                WaitForMoment(2);
                _homeAction.ViewLoggedInUserProfile();
                WaitForMoment(2);
                _hrBankAction.SelectBankAccountMenuOption();
                WaitForMoment(2);
                _hrBankAction.VerifyBankField(accountNumber);
                screenshotFileName = string.Empty;
                LogInfo("=================Test Method Execution Completed =================");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("HRTest")]
        [Description("Create US Other Bank from Profile Page;;")]
        [Owner("vineeth.pamuexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"HR_CreateOtherBank_480856.csv", "HR_CreateOtherBank_480856#csv", DataAccessMethod.Sequential)]
        public void TC_480857_CreateUSOtherBankFromProfilePage()
        {
            try
            {
                LogInfo("=============================== Test Method execution has started ======================");
                string bankType = this.TestContext.DataRow["bankType"].ToString();
                string popUpMessage = this.TestContext.DataRow["message"].ToString();
                string bankControlKey = this.TestContext.DataRow["bankControlKey"].ToString();
                string testUser = this.TestContext.Properties["HR_USOrigin"].ToString();
                string testUserPassword = TestContext.Properties["HRPassword"].ToString();
                LogInfo($"testUser: {testUser}, testUserPassword: {testUserPassword}");

                string country = this.TestContext.DataRow["country"].ToString();
                string payeeName = string.Empty;
                string accountNumber = string.Empty;
                string uniqueNumber = _helper.GenerateUniqueRandomNumber();
                string iBAN = this.TestContext.DataRow["iBAN"].ToString();
                payeeName = $"Payeeof{country}" + uniqueNumber.ToString();
                accountNumber = _helper.GenerateRandomDigits(10);
                string confirmBankAccountNumber = accountNumber;
                string shareAmount = _helper.GenerateRandomDigits(3);
                string sharePercentage = _helper.GenerateRandomDigits(2);
                LogInfo($"Country: {country},TestUserEmailID: {testUser}, iBAN: {iBAN}, PayeeName: {payeeName},AccountNumber: {accountNumber}, ConfirmBankAccountNumber: {confirmBankAccountNumber}, BankControlKey: {bankControlKey}, BankType: {bankType}, shareAmount: {shareAmount}, sharePercentage: {sharePercentage}");

                //LogoutWD application
                LogoutWD();
                // Launching the App Instance
                LaunchApp();

                // Login with the test user account of that specific country
                LogInfo("=========Logged in with User : " + testUser);
                LoginToWD(testUser, testUserPassword);

                WaitForMoment(2);
                _homeAction.ClickOnProfileImage();
                WaitForMoment(2);
                _homeAction.ViewLoggedInUserProfile();
                WaitForMoment(2);
                _hrBankAction.SelectBankAccountMenuOption();
                WaitForMoment(2);
                _childInboxAction.ClickOnCreateButton();
                WaitForMoment(2);
                _hrBankAction.CreateBank(bankType, country, payeeName, accountNumber, confirmBankAccountNumber, bankControlKey, popUpMessage, iBAN, shareAmount, sharePercentage);

                //Verify Other Bank Created is available in Bank Inbox
                WaitForMoment(2);
                _homeAction.ClickOnHomeActionsButton();
                WaitForMoment(2);
                NavigateToInboxByGlobalSearch("Human Resources", "Personal Profile");
                WaitForMoment(2);
                _inboxAction.SelectFirstInboxRecord();
                WaitForMoment(2);
                _childInboxAction.ClickOnChildInboxeItem("Personal Profile", "Banking");
                WaitForMoment(2);
                _childInboxAction.ClickOnFirstChildInboxeItem("Personal Profile", "Banking");
                WaitForMoment(3);
                _hrBankAction.FilterDataBySearch(accountNumber);
                WaitForMoment(2);
                _hrBankAction.VerifyBankField(accountNumber);
                screenshotFileName = string.Empty;
                LogInfo("=================Test Method Execution Completed =================");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("HRTest")]
        [Description("Other Bank Error Alert when Reentered Account is not same from Profile Page;;")]
        [Owner("vineeth.pamuexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"HR_CreateOtherBankAccountError_480860.csv", "HR_CreateOtherBankAccountError_480860#csv", DataAccessMethod.Sequential)]
        public void TC_480860_OtherBankVerifyErrorAlertInAccountNumberReEnterFromProfiePage()
        {
            try
            {
                LogInfo("=============================== Test Method execution has started ======================");
                string bankType = this.TestContext.DataRow["bankType"].ToString();
                string popUpMessage = this.TestContext.DataRow["message"].ToString();
                string bankControlKey = this.TestContext.DataRow["bankControlKey"].ToString();
                string testUser = this.TestContext.Properties["HR_USOrigin"].ToString();
                string testUserPassword = TestContext.Properties["HRPassword"].ToString();
                LogInfo($"testUser: {testUser}, testUserPassword: {testUserPassword}");

                string country = this.TestContext.DataRow["country"].ToString();
                string payeeName = string.Empty;
                string accountNumber = string.Empty;
                string uniqueNumber = _helper.GenerateUniqueRandomNumber();
                string iBAN = this.TestContext.DataRow["iBAN"].ToString();
                payeeName = $"Payeeof{country}" + uniqueNumber.ToString();
                accountNumber = _helper.GenerateRandomDigits(10);
                string confirmBankAccountNumber = string.Empty;
                do
                {
                    confirmBankAccountNumber = _helper.GenerateRandomDigits(10);
                    bool flag = confirmBankAccountNumber.Contains(accountNumber);
                } while (confirmBankAccountNumber.Equals(accountNumber));
                string shareAmount = _helper.GenerateRandomDigits(3);
                string sharePercentage = _helper.GenerateRandomDigits(2);
                LogInfo($"Country: {country},TestUserEmailID: {testUser}, iBAN: {iBAN}, PayeeName: {payeeName},AccountNumber: {accountNumber}, ConfirmBankAccountNumber: {confirmBankAccountNumber}, BankControlKey: {bankControlKey}, BankType: {bankType}, shareAmount: {shareAmount}, sharePercentage: {sharePercentage}");

                //LogoutWD application
                LogoutWD();
                // Launching the App Instance
                LaunchApp();

                // Login with the test user account of that specific country
                LogInfo("=========Logged in with User : " + testUser);
                LoginToWD(testUser, testUserPassword);

                WaitForMoment(2);
                _homeAction.ClickOnProfileImage();
                _homeAction.ViewLoggedInUserProfile();
                WaitForMoment(2);
                _hrBankAction.SelectBankAccountMenuOption();
                WaitForMoment(2);
                _childInboxAction.ClickOnCreateButton();
                WaitForMoment(2);
                _hrBankAction.CreateBank(bankType, country, payeeName, accountNumber, confirmBankAccountNumber, bankControlKey, popUpMessage, iBAN, shareAmount, sharePercentage);
                screenshotFileName = string.Empty;
                LogInfo("=================Test Method Execution Completed =================");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("HRTest")]
        [Description("Other Bank Error Alert when Reentered Account is not same from Bank Inbox;;")]
        [Owner("vineeth.pamuexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"HR_CreateOtherBankAccountError_480860.csv", "HR_CreateOtherBankAccountError_480860#csv", DataAccessMethod.Sequential)]
        public void TC_480862_OtherBankVerifyErrorAlertInAccountNumberReEnterFromBankInbox()
        {
            try
            {
                LogInfo("=============================== Test Method execution has started ======================");
                string bankType = this.TestContext.DataRow["bankType"].ToString();
                string popUpMessage = this.TestContext.DataRow["message"].ToString();
                string bankControlKey = this.TestContext.DataRow["bankControlKey"].ToString();
                string testUser = this.TestContext.Properties["HR_USOrigin"].ToString();
                string testUserPassword = TestContext.Properties["HRPassword"].ToString();
                LogInfo($"testUser: {testUser}, testUserPassword: {testUserPassword}");

                string country = this.TestContext.DataRow["country"].ToString();
                string payeeName = string.Empty;
                string accountNumber = string.Empty;
                string uniqueNumber = _helper.GenerateUniqueRandomNumber();
                string iBAN = this.TestContext.DataRow["iBAN"].ToString();
                payeeName = $"Payeeof{country}" + uniqueNumber.ToString();
                accountNumber = _helper.GenerateRandomDigits(10);
                string confirmBankAccountNumber = string.Empty;
                do
                {
                    confirmBankAccountNumber = _helper.GenerateRandomDigits(10);
                    bool flag = confirmBankAccountNumber.Contains(accountNumber);
                } while (confirmBankAccountNumber.Equals(accountNumber));
                string shareAmount = _helper.GenerateRandomDigits(3);
                string sharePercentage = _helper.GenerateRandomDigits(2);
                LogInfo($"Country: {country},TestUserEmailID: {testUser}, iBAN: {iBAN}, PayeeName: {payeeName},AccountNumber: {accountNumber}, ConfirmBankAccountNumber: {confirmBankAccountNumber}, BankControlKey: {bankControlKey}, BankType: {bankType}, shareAmount: {shareAmount}, sharePercentage: {sharePercentage}");

                //LogoutWD application
                LogoutWD();
                // Launching the App Instance
                LaunchApp();

                // Login with the test user account of that specific country
                LogInfo("=========Logged in with User : " + testUser);
                LoginToWD(testUser, testUserPassword);

                WaitForMoment(2);
                _homeAction.ClickOnHomeActionsButton();
                WaitForMoment(2);
                NavigateToInboxByGlobalSearch("Human Resources", "Personal Profile");
                WaitForMoment(2);
                _inboxAction.SelectFirstInboxRecord();
                WaitForMoment(2);
                _childInboxAction.ClickOnChildInboxeItem("Personal Profile", "Banking");
                WaitForMoment(2);
                _childInboxAction.ClickOnFirstChildInboxeItem("Personal Profile", "Banking");
                WaitForMoment(3);
                _childInboxAction.ClickOnCreateButton();
                WaitForMoment(2);
                _hrBankAction.CreateBank(bankType, country, payeeName, accountNumber, confirmBankAccountNumber, bankControlKey, popUpMessage, iBAN, shareAmount, sharePercentage);
                screenshotFileName = string.Empty;
                LogInfo("=================Test Method Execution Completed =================");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("HRTest")]
        [Description("Other Bank Error Alert when Confirm Bank Account is null from Bank Inbox;;")]
        [Owner("vineeth.pamuexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"HR_CreateOtherBankAccountError_480860.csv", "HR_CreateOtherBankAccountError_480860#csv", DataAccessMethod.Sequential)]
        public void TC_480867_OtherBankVerifyErrorAlert_ConfirmAccountNullInBankInbox()
        {
            try
            {
                LogInfo("=============================== Test Method execution has started ======================");
                string bankType = this.TestContext.DataRow["bankType"].ToString();
                string popUpMessage = this.TestContext.DataRow["message"].ToString();
                string bankControlKey = this.TestContext.DataRow["bankControlKey"].ToString();
                string testUser = this.TestContext.Properties["HR_USOrigin"].ToString();
                string testUserPassword = TestContext.Properties["HRPassword"].ToString();
                LogInfo($"testUser: {testUser}, testUserPassword: {testUserPassword}");

                string country = this.TestContext.DataRow["country"].ToString();
                string payeeName = string.Empty;
                string accountNumber = string.Empty;
                string uniqueNumber = _helper.GenerateUniqueRandomNumber();
                string iBAN = this.TestContext.DataRow["iBAN"].ToString();
                payeeName = $"Payeeof{country}" + uniqueNumber.ToString();
                accountNumber = _helper.GenerateRandomDigits(10);
                string confirmBankAccountNumber = null;
                string shareAmount = _helper.GenerateRandomDigits(3);
                string sharePercentage = _helper.GenerateRandomDigits(2);
                LogInfo($"Country: {country},TestUserEmailID: {testUser}, iBAN: {iBAN}, PayeeName: {payeeName},AccountNumber: {accountNumber}, ConfirmBankAccountNumber: {confirmBankAccountNumber}, BankControlKey: {bankControlKey}, BankType: {bankType}, shareAmount: {shareAmount}, sharePercentage: {sharePercentage}");

                //LogoutWD application
                LogoutWD();
                // Launching the App Instance
                LaunchApp();

                // Login with the test user account of that specific country
                LogInfo("=========Logged in with User : " + testUser);
                LoginToWD(testUser, testUserPassword);

                WaitForMoment(2);
                NavigateToInboxByGlobalSearch("Human Resources", "Personal Profile");
                WaitForMoment(2);
                _inboxAction.SelectFirstInboxRecord();
                WaitForMoment(2);
                _childInboxAction.ClickOnChildInboxeItem("Personal Profile", "Banking");
                WaitForMoment(2);
                _childInboxAction.ClickOnFirstChildInboxeItem("Personal Profile", "Banking");
                WaitForMoment(3);
                _childInboxAction.ClickOnCreateButton();
                WaitForMoment(2);
                _hrBankAction.CreateBank(bankType, country, payeeName, accountNumber, "", bankControlKey, popUpMessage, iBAN, shareAmount, sharePercentage);
                screenshotFileName = string.Empty;
                LogInfo("=================Test Method Execution Completed =================");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("HRTest")]
        [Description("Other Bank Error Alert when Confirm Bank Account is null from Profile Page;;")]
        [Owner("vineeth.pamuexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"HR_CreateOtherBankAccountError_480860.csv", "HR_CreateOtherBankAccountError_480860#csv", DataAccessMethod.Sequential)]
        public void TC_480869_OtherBankVerifyErrorAlert_ConfirmAccountNullInProfiePage()
        {
            try
            {
                LogInfo("=============================== Test Method execution has started ======================");
                string bankType = this.TestContext.DataRow["bankType"].ToString();
                string popUpMessage = this.TestContext.DataRow["message"].ToString();
                string bankControlKey = this.TestContext.DataRow["bankControlKey"].ToString();
                string testUser = this.TestContext.Properties["HR_USOrigin"].ToString();
                string testUserPassword = TestContext.Properties["HRPassword"].ToString();
                LogInfo($"testUser: {testUser}, testUserPassword: {testUserPassword}");

                string country = this.TestContext.DataRow["country"].ToString();
                string payeeName = string.Empty;
                string accountNumber = string.Empty;
                string uniqueNumber = _helper.GenerateUniqueRandomNumber();
                string iBAN = this.TestContext.DataRow["iBAN"].ToString();
                payeeName = $"Payeeof{country}" + uniqueNumber.ToString();
                accountNumber = _helper.GenerateRandomDigits(10);
                string confirmBankAccountNumber = null;
                string shareAmount = _helper.GenerateRandomDigits(3);
                string sharePercentage = _helper.GenerateRandomDigits(2);
                LogInfo($"Country: {country},TestUserEmailID: {testUser}, iBAN: {iBAN}, PayeeName: {payeeName},AccountNumber: {accountNumber}, ConfirmBankAccountNumber: {confirmBankAccountNumber}, BankControlKey: {bankControlKey}, BankType: {bankType}, shareAmount: {shareAmount}, sharePercentage: {sharePercentage}");

                //LogoutWD application
                LogoutWD();
                // Launching the App Instance
                LaunchApp();

                // Login with the test user account of that specific country
                LogInfo("=========Logged in with User : " + testUser);
                LoginToWD(testUser, testUserPassword);

                WaitForMoment(2);
                _homeAction.ClickOnProfileImage();
                _homeAction.ViewLoggedInUserProfile();
                WaitForMoment(2);
                _hrBankAction.SelectBankAccountMenuOption();
                WaitForMoment(2);
                _childInboxAction.ClickOnCreateButton();
                WaitForMoment(2);
                _hrBankAction.CreateBank(bankType, country, payeeName, accountNumber, "", bankControlKey, popUpMessage, iBAN, shareAmount, sharePercentage);
                screenshotFileName = string.Empty;
                LogInfo("=================Test Method Execution Completed =================");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("HRTest")]
        [Description("Create India Main Bank from Profile Page;;")]
        [Owner("vineeth.pamuexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"HR_CreateIndiaBank_281784.csv", "HR_CreateIndiaBank_281784#csv", DataAccessMethod.Sequential)]
        public void TC_281784_CreateIndiaMainBankFromProfiePage()
        {
            try
            {
                LogInfo("=============================== Test Method execution has started ======================");
                string bankType = this.TestContext.DataRow["bankType"].ToString();
                string popUpMessage = this.TestContext.DataRow["message"].ToString();
                string bankControlKey = this.TestContext.DataRow["bankControlKey"].ToString();
                string testUser = this.TestContext.Properties["HR_IndiaOrigin"].ToString();
                string testUserPassword = TestContext.Properties["HRPassword"].ToString();
                LogInfo($"testUser: {testUser}, testUserPassword: {testUserPassword}");

                string country = this.TestContext.DataRow["country"].ToString();
                string payeeName = string.Empty;
                string accountNumber = string.Empty;
                string uniqueNumber = _helper.GenerateUniqueRandomNumber();
                string iBAN = this.TestContext.DataRow["iBAN"].ToString();
                payeeName = $"Payeeof{country}" + uniqueNumber.ToString();
                accountNumber = _helper.GenerateRandomDigits(10);
                string confirmBankAccountNumber = accountNumber;
                string shareAmount = _helper.GenerateRandomDigits(3);
                string sharePercentage = _helper.GenerateRandomDigits(2);
                LogInfo($"Country: {country},TestUserEmailID: {testUser}, iBAN: {iBAN}, PayeeName: {payeeName},AccountNumber: {accountNumber}, ConfirmBankAccountNumber: {confirmBankAccountNumber}, BankControlKey: {bankControlKey}, BankType: {bankType}, shareAmount: {shareAmount}, sharePercentage: {sharePercentage}");

                //LogoutWD application
                LogoutWD();
                // Launching the App Instance
                LaunchApp();

                // Login with the test user account of that specific country
                LogInfo("=========Logged in with User : " + testUser);
                LoginToWD(testUser, testUserPassword);

                 WaitForMoment(2);
                _homeAction.ClickOnProfileImage();
                _homeAction.ViewLoggedInUserProfile();
                WaitForMoment(2);
                _hrBankAction.SelectBankAccountMenuOption();
                WaitForMoment(2);
                _childInboxAction.ClickOnCreateButton();
                WaitForMoment(2);
                //Create Main Bank for India Origin
                _hrBankAction.CreateBank(bankType, country, payeeName, accountNumber, confirmBankAccountNumber, bankControlKey, popUpMessage, iBAN, shareAmount, sharePercentage);

                //Verify Other Bank Created is available in Profile Page
                WaitForMoment(2);
                _hrBankAction.SelectBankAccountMenuOption();
                WaitForMoment(2);
                _hrBankAction.VerifyBankField(accountNumber);

                //Verify Main Bank Created is available in Bank Inbox
                WaitForMoment(2);
                _homeAction.ClickOnHomeActionsButton();
                WaitForMoment(2);
                NavigateToInboxByGlobalSearch("Human Resources", "Personal Profile");
                WaitForMoment(2);
                _inboxAction.SelectFirstInboxRecord();
                WaitForMoment(2);
                _childInboxAction.ClickOnChildInboxeItem("Personal Profile", "Banking");
                WaitForMoment(2);
                _childInboxAction.ClickOnFirstChildInboxeItem("Personal Profile", "Banking");
                WaitForMoment(3);
                _hrBankAction.FilterDataBySearch(accountNumber);
                WaitForMoment(2);
                _hrBankAction.VerifyBankField(accountNumber);

                screenshotFileName = string.Empty;
                LogInfo("=================Test Method Execution Completed =================");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("HRTest")]
        [Description("Profile Page Verify Mandatory fields required Message displayed while adding new Main bank;;")]
        [Owner("vineeth.pamuexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"HR_277754.csv", "HR_277754#csv", DataAccessMethod.Sequential)]
        public void TC_331882_ProfilePageErrorMessageInNewMainBankDetails()
        {
            try
            {
                LogInfo("=============================== Test Method execution has started ======================");
                string bankType = this.TestContext.DataRow["bankType"].ToString();
                string popUpMessage = this.TestContext.DataRow["message"].ToString();
                string testUser = this.TestContext.Properties["HRInitiator"].ToString();
                string testUserPassword = TestContext.Properties["HRPassword"].ToString();
                LogInfo($"testUser: {testUser}, testUserPassword: {testUserPassword}");

                //LogoutWD application
                LogoutWD();
                // Launching the App Instance
                LaunchApp();
                // Login with the test user account
                LogInfo("=========Logged in with User : " + testUser);
                LoginToWD(testUser, testUserPassword);

                WaitForMoment(2);
                _homeAction.ClickOnProfileImage();
                _homeAction.ViewLoggedInUserProfile();
                WaitForMoment(2);
                _hrBankAction.SelectBankAccountMenuOption();
                WaitForMoment(2);
                _childInboxAction.ClickOnCreateButton();
                WaitForMoment(2);
                _hrBankAction.ClickOnSave();
                WaitForMoment(2);
                //Validate error message 'Please enter all fields' is displayed
                _hrBankAction.ValidatePopUpMessage(popUpMessage);
                WaitForMoment(2);
                _hrBankAction.ClickOkButton();
                screenshotFileName = string.Empty;
                LogInfo("=================Test Method Execution Completed =================");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("HRTest")]
        [Description("Profile Page Verify Mandatory fields required Message displayed while adding new Other bank;;")]
        [Owner("vineeth.pamuexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"HR_280542.csv", "HR_280542#csv", DataAccessMethod.Sequential)]
        public void TC_331885_ProfilePageErrorMessageInNewOtherBankDetails()
        {
            try
            {
                LogInfo("=============================== Test Method execution has started ======================");
                string bankType = this.TestContext.DataRow["bankType"].ToString();
                string popUpMessage = this.TestContext.DataRow["message"].ToString();
                string testUser = this.TestContext.Properties["HR_USOrigin"].ToString();
                string testUserPassword = TestContext.Properties["HRPassword"].ToString();
                LogInfo($"testUser: {testUser}, testUserPassword: {testUserPassword}");

                //LogoutWD application
                LogoutWD();
                // Launching the App Instance
                LaunchApp();
                // Login with the test user account
                LogInfo("=========Logged in with User : " + testUser);
                LoginToWD(testUser, testUserPassword);

                WaitForMoment(2);
                _homeAction.ClickOnProfileImage();
                _homeAction.ViewLoggedInUserProfile();
                WaitForMoment(2);
                _hrBankAction.SelectBankAccountMenuOption();
                WaitForMoment(2);
                _childInboxAction.ClickOnCreateButton();
                WaitForMoment(2);
                _hrBankAction.SelectBankType(bankType);
                _hrBankAction.ClickOnSave();
                WaitForMoment(2);
                //Validate error message 'Please enter all fields' is displayed
                _hrBankAction.ValidatePopUpMessage(popUpMessage);
                WaitForMoment(2);
                _hrBankAction.ClickOkButton();
                screenshotFileName = string.Empty;
                LogInfo("=================Test Method Execution Completed =================");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("HRTest")]
        [Description("Create India Main Bank from Bank Inbox;;")]
        [Owner("vineeth.pamuexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"HR_CreateIndiaBank_281784.csv", "HR_CreateIndiaBank_281784#csv", DataAccessMethod.Sequential)]
        public void TC_331887_CreateIndiaMainBankFromBankInbox()
        {
            try
            {
                LogInfo("=============================== Test Method execution has started ======================");
                string bankType = this.TestContext.DataRow["bankType"].ToString();
                string popUpMessage = this.TestContext.DataRow["message"].ToString();
                string bankControlKey = this.TestContext.DataRow["bankControlKey"].ToString();
                string testUser = this.TestContext.Properties["HR_IndiaOrigin"].ToString();
                string testUserPassword = TestContext.Properties["HRPassword"].ToString();
                LogInfo($"testUser: {testUser}, testUserPassword: {testUserPassword}");
                string country = this.TestContext.DataRow["country"].ToString();
                string iBAN = this.TestContext.DataRow["iBAN"].ToString();
                
                string payeeName = string.Empty;
                string accountNumber = string.Empty;
                string uniqueNumber = _helper.GenerateUniqueRandomNumber();
                payeeName = $"Payeeof{country}" + uniqueNumber.ToString();

                accountNumber = _helper.GenerateRandomDigits(10);
                string confirmBankAccountNumber = accountNumber;
                string shareAmount = _helper.GenerateRandomDigits(3);
                string sharePercentage = _helper.GenerateRandomDigits(2);
                LogInfo($"Country: {country},TestUserEmailID: {testUser}, iBAN: {iBAN}, PayeeName: {payeeName},AccountNumber: {accountNumber}, ConfirmBankAccountNumber: {confirmBankAccountNumber}, BankControlKey: {bankControlKey}, BankType: {bankType}, shareAmount: {shareAmount}, sharePercentage: {sharePercentage}");

                //LogoutWD application
                LogoutWD();
                // Launching the App Instance
                LaunchApp();

                // Login with the test user account of that specific country
                LogInfo("=========Logged in with User : " + testUser);
                LoginToWD(testUser, testUserPassword);

                WaitForMoment(2);
                NavigateToInboxByGlobalSearch("Human Resources", "Personal Profile");
                WaitForMoment(2);
                _inboxAction.SelectFirstInboxRecord();
                WaitForMoment(2);
                _childInboxAction.ClickOnChildInboxeItem("Personal Profile", "Banking");
                WaitForMoment(2);
                _childInboxAction.ClickOnFirstChildInboxeItem("Personal Profile", "Banking");
                WaitForMoment(3);
                _childInboxAction.ClickOnCreateButton();
                WaitForMoment(2);
                
                //Create Main Bank for India Origin from Bank Inbox
                _hrBankAction.CreateBank(bankType, country, payeeName, accountNumber, confirmBankAccountNumber, bankControlKey, popUpMessage, iBAN, shareAmount, sharePercentage);
                
                //Verify Other Bank Created is available in Profile Page
                WaitForMoment(2);
                _homeAction.ClickOnProfileImage();
                WaitForMoment(2);
                _homeAction.ViewLoggedInUserProfile();
                WaitForMoment(2);
                _hrBankAction.SelectBankAccountMenuOption();
                WaitForMoment(2);
                _hrBankAction.VerifyBankField(accountNumber);
                screenshotFileName = string.Empty;
                LogInfo("=================Test Method Execution Completed =================");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("HRTest")]
        [Description("End Other Bank for US Users;;")]
        [Owner("vineeth.pamuexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"HR_CreateOtherBank_480856.csv", "HR_CreateOtherBank_480856#csv", DataAccessMethod.Sequential)]
        public void TC_474054_EndUSOtherBank()
        {
            try
            {
                LogInfo("=============================== Test Method execution has started ======================");
                string bankType = this.TestContext.DataRow["bankType"].ToString();
                string popUpMessage = this.TestContext.DataRow["message"].ToString();
                string bankControlKey = this.TestContext.DataRow["bankControlKey"].ToString();
                string testUser = this.TestContext.Properties["HR_USOrigin"].ToString();
                string testUserPassword = TestContext.Properties["HRPassword"].ToString();
                LogInfo($"testUser: {testUser}, testUserPassword: {testUserPassword}");

                string country = this.TestContext.DataRow["country"].ToString();
                string payeeName = string.Empty;
                string accountNumber = string.Empty;
                string uniqueNumber = _helper.GenerateUniqueRandomNumber();
                string iBAN = this.TestContext.DataRow["iBAN"].ToString();
                payeeName = $"Payeeof{country}" + uniqueNumber.ToString();
                accountNumber = _helper.GenerateRandomDigits(10);
                string confirmBankAccountNumber = accountNumber;
                string shareAmount = _helper.GenerateRandomDigits(3);
                string sharePercentage = _helper.GenerateRandomDigits(2);
                LogInfo($"Country: {country},TestUserEmailID: {testUser}, iBAN: {iBAN}, PayeeName: {payeeName},AccountNumber: {accountNumber}, ConfirmBankAccountNumber: {confirmBankAccountNumber}, BankControlKey: {bankControlKey}, BankType: {bankType}, shareAmount: {shareAmount}, sharePercentage: {sharePercentage}");

                //LogoutWD application
                LogoutWD();
                // Launching the App Instance
                LaunchApp();

                // Login with the test user account of that specific country
                LogInfo("=========Logged in with User : " + testUser);
                LoginToWD(testUser, testUserPassword);

                WaitForMoment(2);
                NavigateToInboxByGlobalSearch("Human Resources", "Personal Profile");
                WaitForMoment(2);
                _inboxAction.SelectFirstInboxRecord();
                WaitForMoment(2);
                _childInboxAction.ClickOnChildInboxeItem("Personal Profile", "Banking");
                WaitForMoment(2);
                _childInboxAction.ClickOnFirstChildInboxeItem("Personal Profile", "Banking");
                WaitForMoment(3);
                _childInboxAction.ClickOnCreateButton();
                WaitForMoment(2);
                _hrBankAction.CreateBank(bankType, country, payeeName, accountNumber, confirmBankAccountNumber, bankControlKey, popUpMessage, iBAN, shareAmount, sharePercentage);

                _hrBankAction.FilterDataBySearch(accountNumber);
                WaitForMoment(2);
                _hrBankAction.VerifyBankField(accountNumber);
                _hrBankAction.SelectBankAction(bankType);
                WaitForMoment(2);
                _hrBankAction.SelectEndNow();
                WaitForMoment(2);
                _hrBankAction.ValidatePopUpMessage("Are you sure you want to end this bank details?");
                WaitForMoment(2);
                _hrBankAction.ClickOkButton();
                screenshotFileName = string.Empty;
                LogInfo("=================Test Method Execution Completed =================");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("HRTest")]
        [Description("Update US Other Bank from Bank Inbox;;")]
        [Owner("vineeth.pamuexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"HR_UpdateUSOtherBank_285065.csv", "HR_UpdateUSOtherBank_285065#csv", DataAccessMethod.Sequential)]
        public void TC_285065_UpdateUSOtherBankFromBankInbox()
        {
            try
            {
                LogInfo("=============================== Test Method execution has started ======================");
                string bankType = this.TestContext.DataRow["bankType"].ToString();
                string popUpMessage = this.TestContext.DataRow["message"].ToString();
                string bankUpdateMessage = this.TestContext.DataRow["updateMessage"].ToString();
                string bankControlKey = this.TestContext.DataRow["bankControlKey"].ToString();
                string testUser = this.TestContext.Properties["HR_USOrigin"].ToString();
                string testUserPassword = TestContext.Properties["HRPassword"].ToString();
                LogInfo($"testUser: {testUser}, testUserPassword: {testUserPassword}");

                string country = this.TestContext.DataRow["country"].ToString();
                string payeeName = string.Empty;
                string accountNumber = string.Empty;
                string uniqueNumber = _helper.GenerateUniqueRandomNumber();
                string iBAN = this.TestContext.DataRow["iBAN"].ToString();
                payeeName = $"Payeeof{country}" + uniqueNumber.ToString();
                accountNumber = _helper.GenerateRandomDigits(10);
                string confirmBankAccountNumber = accountNumber;
                string shareAmount = _helper.GenerateRandomDigits(3);
                string sharePercentage = _helper.GenerateRandomDigits(2);
                LogInfo($"Country: {country},TestUserEmailID: {testUser}, iBAN: {iBAN}, PayeeName: {payeeName},AccountNumber: {accountNumber}, ConfirmBankAccountNumber: {confirmBankAccountNumber}, BankControlKey: {bankControlKey}, BankType: {bankType}, shareAmount: {shareAmount}, sharePercentage: {sharePercentage}, updateBankMessage: {bankUpdateMessage}");

                //LogoutWD application
                LogoutWD();
                // Launching the App Instance
                LaunchApp();

                // Login with the test user account of that specific country
                LogInfo("=========Logged in with User : " + testUser);
                LoginToWD(testUser, testUserPassword);

                WaitForMoment(2);
                NavigateToInboxByGlobalSearch("Human Resources", "Personal Profile");
                WaitForMoment(2);
                _inboxAction.SelectFirstInboxRecord();
                WaitForMoment(2);
                _childInboxAction.ClickOnChildInboxeItem("Personal Profile", "Banking");
                WaitForMoment(2);
                _childInboxAction.ClickOnFirstChildInboxeItem("Personal Profile", "Banking");
                WaitForMoment(3);
                _childInboxAction.ClickOnCreateButton();
                WaitForMoment(2);
                _hrBankAction.CreateBank(bankType, country, payeeName, accountNumber, confirmBankAccountNumber, bankControlKey, popUpMessage, iBAN, shareAmount, sharePercentage);

                //Select the created Other Bank 
                _hrBankAction.FilterDataBySearch(accountNumber);
                WaitForMoment(2);
                _hrBankAction.VerifyBankField(accountNumber);
                _hrBankAction.SelectBankAction(bankType);
                WaitForMoment(2);
                _hrBankAction.SelectEditAction();

                //Update Bank Details
                shareAmount = _helper.GenerateRandomDigits(3);
                _hrBankAction.UpdateBankDetailsCountryBased(bankType, country, payeeName, accountNumber, confirmBankAccountNumber, bankControlKey, bankUpdateMessage, iBAN, shareAmount, sharePercentage);

                LogInfo("=================Test Method Execution Completed =================");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("HRTest")]
        [Description("Verify Delete Action not present Main Bank;;")]
        [Owner("vineeth.pamuexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"HR_CreateBank_480838.csv", "HR_CreateBank_480838#csv", DataAccessMethod.Sequential)]
        public void TC_331883_DeleteActionNotPresentMainBank()
        {
            try
            {
                LogInfo("=============================== Test Method execution has started ======================");
                string bankType = this.TestContext.DataRow["bankType"].ToString();
                string popUpMessage = this.TestContext.DataRow["message"].ToString();
                string bankControlKey = this.TestContext.DataRow["bankControlKey"].ToString();
                string testUser = this.TestContext.Properties["HR_USOrigin"].ToString();
                string testUserPassword = TestContext.Properties["HRPassword"].ToString();
                LogInfo($"testUser: {testUser}, testUserPassword: {testUserPassword}");

                string country = this.TestContext.DataRow["country"].ToString();
                string payeeName = string.Empty;
                string accountNumber = string.Empty;
                string uniqueNumber = _helper.GenerateUniqueRandomNumber();
                string iBAN = this.TestContext.DataRow["iBAN"].ToString();
                payeeName = $"Payeeof{country}" + uniqueNumber.ToString();
                accountNumber = _helper.GenerateRandomDigits(10);
                string confirmBankAccountNumber = accountNumber;
                string shareAmount = _helper.GenerateRandomDigits(3);
                string sharePercentage = _helper.GenerateRandomDigits(2);
                LogInfo($"Country: {country},TestUserEmailID: {testUser}, iBAN: {iBAN}, PayeeName: {payeeName},AccountNumber: {accountNumber}, ConfirmBankAccountNumber: {confirmBankAccountNumber}, BankControlKey: {bankControlKey}, BankType: {bankType}, shareAmount: {shareAmount}, sharePercentage: {sharePercentage}");


                //LogoutWD application
                LogoutWD();
                // Launching the App Instance
                LaunchApp();

                // Login with the test user account of that specific country
                LogInfo("=========Logged in with User : " + testUser);
                LoginToWD(testUser, testUserPassword);

                _homeAction.ClickOnProfileImage();
                _homeAction.ViewLoggedInUserProfile();
                WaitForMoment(2);
                _hrBankAction.SelectBankAccountMenuOption();
                WaitForMoment(2);
                _childInboxAction.ClickOnCreateButton();
                WaitForMoment(2);
                _hrBankAction.CreateBank(bankType, country, payeeName, accountNumber, confirmBankAccountNumber, bankControlKey, popUpMessage, iBAN, shareAmount, sharePercentage);
                screenshotFileName = string.Empty;

                //Navigate to Bank Inbox and verify Delete Option not available in Main Bank Semantic box
                WaitForMoment(2);
                _homeAction.ClickOnHomeActionsButton();
                WaitForMoment(2);
                NavigateToInboxByGlobalSearch("Human Resources", "Personal Profile");
                WaitForMoment(2);
                _inboxAction.SelectFirstInboxRecord();
                WaitForMoment(2);
                _childInboxAction.ClickOnChildInboxeItem("Personal Profile", "Banking");
                WaitForMoment(2);
                _childInboxAction.ClickOnFirstChildInboxeItem("Personal Profile", "Banking");
                WaitForMoment(3);
                _hrBankAction.FilterDataBySearch(accountNumber);
                WaitForMoment(2);
                _hrBankAction.SelectBankAction(bankType);
                _hrBankAction.VerifyDeleteActionPresent(bankType);
                LogInfo("=================Test Method Execution Completed =================");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        #endregion


        #region HR Address Test
        [TestMethod]
        [TestCategory("HRTest")]
        [TestCategory("HRAddressTest")]
        [Description("Create US Address Address Inbox;;")]
        [Owner("vineeth.pamuexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"HR_CreateUSAddress_286910.csv", "HR_CreateUSAddress_286910#csv", DataAccessMethod.Sequential)]
        public void TC_286910_CreateUSAddressFromAddressInbox()
        {
            try
            {
                string country = this.TestContext.DataRow["country"].ToString();
                string region = this.TestContext.DataRow["region"].ToString();
                string pincode = this.TestContext.DataRow["pincode"].ToString();
                string city = this.TestContext.DataRow["city"].ToString();
                string telephone = this.TestContext.DataRow["telephone"].ToString();
                string addressType = this.TestContext.DataRow["addressType"].ToString();
                string message = this.TestContext.DataRow["message"].ToString();
                string testUser = this.TestContext.Properties["HR_USOrigin"].ToString();
                string testUserPassword = TestContext.Properties["HRPassword"].ToString();
                LogInfo($"testUser: {testUser}, testUserPassword: {testUserPassword}");
                string careOf = string.Empty;
                string addressFirstLine = string.Empty;
                string addressSecondLine = string.Empty;
                string TelephoneNo = string.Empty;
                string uniqueNumber = _helper.GenerateUniqueRandomNumber();
                string countrySmallCase = country.ToLower();
                careOf = $"Careof{countrySmallCase}" + uniqueNumber;
                addressFirstLine = "AddressFirstline";
                addressSecondLine = "AddressSecondline";
                TelephoneNo = $"{telephone}"+ _helper.GenerateRandomDigits(6);

                LogInfo("====================Test Method Execution has started=================");
                LogInfo($"AddressType: {addressType}, Country: {country},CareOf: {careOf},AddressFirstLine: {addressFirstLine},AddressSecondLine: {addressSecondLine}, Region: {region}, Pincode: {pincode}, City: {city}, TelephoneNo.: {TelephoneNo}");

                //LogoutWD application
                LogoutWD();
                // Launching the App Instance
                LaunchApp();

                // Login with the test user account of that specific country
                LoginToWD(testUser, testUserPassword);
                               
                NavigateToInboxByGlobalSearch("Human Resources", "Personal Profile");
                WaitForMoment(2);
                _inboxAction.SelectFirstInboxRecord();
                WaitForMoment(2);
                _childInboxAction.ClickOnChildInboxeItem("Personal Profile", "Address");
                WaitForMoment(2);
                _childInboxAction.ClickOnFirstChildInboxeItem("Personal Profile", "Address");
                WaitForMoment(3);
                _childInboxAction.ClickOnCreateButton();
                WaitForMoment(3);
                _hrAddressAction.CreateAddressDetails(addressType, careOf, addressFirstLine, addressSecondLine, region, city, pincode, TelephoneNo, country, message);
                WaitForMoment(1);
               
                NavigateToInboxByGlobalSearch("Human Resources", "Personal Profile");
                WaitForMoment(2);
                _inboxAction.SelectFirstInboxRecord();
                WaitForMoment(2);
                _hrAddressAction.VerifyPersonalAddressField(careOf);
                screenshotFileName = string.Empty;
                LogInfo("====================Test Method Execution has Completed=================");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
           
        }

        [TestMethod]
        [TestCategory("HRTest")]
        [TestCategory("HRAddressTest")]
        [Description("Verify Mandatory Field Error message Address Inbox;;")]
        [Owner("vineeth.pamuexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"HR_MandatoryFieldErrorAlert_278065.csv", "HR_MandatoryFieldErrorAlert_278065#csv", DataAccessMethod.Sequential)]
        public void TC_278065_MandatoryFieldRequiredErrorMessage_AddressInbox()
        {
            try
            {
                string country = this.TestContext.DataRow["country"].ToString();
                string region = this.TestContext.DataRow["region"].ToString();
                string pincode = this.TestContext.DataRow["pincode"].ToString();
                string city = this.TestContext.DataRow["city"].ToString();
                string telephone = this.TestContext.DataRow["telephone"].ToString();
                string addressType = this.TestContext.DataRow["addressType"].ToString();
                string message = this.TestContext.DataRow["message"].ToString();
                string testUser = this.TestContext.Properties["HR_USOrigin"].ToString();
                string testUserPassword = TestContext.Properties["HRPassword"].ToString();
                LogInfo($"testUser: {testUser}, testUserPassword: {testUserPassword}");
                string careOf = string.Empty;
                string addressFirstLine = string.Empty;
                string addressSecondLine = string.Empty;
                string TelephoneNo = string.Empty;
                string uniqueNumber = _helper.GenerateUniqueRandomNumber();
                string countrySmallCase = country.ToLower();
                careOf = $"Careof{countrySmallCase}" + uniqueNumber;
                addressFirstLine = "AddressFirstline";
                addressSecondLine = "AddressSecondline";
                TelephoneNo = $"{telephone}" + _helper.GenerateRandomDigits(6);

                LogInfo("====================Test Method Execution has started=================");
                LogInfo($"AddressType: {addressType}, Country: {country},CareOf: {careOf},AddressFirstLine: {addressFirstLine},AddressSecondLine: {addressSecondLine}, Region: {region}, Pincode: {pincode}, City: {city}, TelephoneNo.: {TelephoneNo}");

                //LogoutWD application
                LogoutWD();
                // Launching the App Instance
                LaunchApp();

                // Login with the test user account of that specific country
                LoginToWD(testUser, testUserPassword);

                NavigateToInboxByGlobalSearch("Human Resources", "Personal Profile");
                WaitForMoment(2);
                _inboxAction.SelectFirstInboxRecord();
                WaitForMoment(2);
                _childInboxAction.ClickOnChildInboxeItem("Personal Profile", "Address");
                WaitForMoment(2);
                _childInboxAction.ClickOnFirstChildInboxeItem("Personal Profile", "Address");
                WaitForMoment(3);
                _childInboxAction.ClickOnCreateButton();
                WaitForMoment(3);

                //Enter Address, Name, AddressFirstLine and Click on Save
                _hrAddressAction.SelectAddressType(addressType);
                _hrAddressAction.EnterCareOf(careOf);
                _hrAddressAction.EnterAddressFirstLine(addressFirstLine);
                _hrAddressAction.ClickOnSave();
                WaitForMoment(4);

                //Validate the error alert message
                _hrAddressAction.ValidatePopUpMessage(message);
                _hrAddressAction.TakeScreenshot("CreateAddress_" + country);
                _hrAddressAction.ClickOnOk();

                screenshotFileName = string.Empty;
                LogInfo("====================Test Method Execution has Completed=================");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("HRTest")]
        [TestCategory("HRAddressTest")]
        [Description("Create Address Reset Functionality Address Inbox;;")]
        [Owner("vineeth.pamuexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"HR_AddressReset_278027.csv", "HR_AddressReset_278027#csv", DataAccessMethod.Sequential)]
        public void TC_278027_CreateAddressResetFunctionality_AddressInbox()
        {
            try
            {
                string country = this.TestContext.DataRow["country"].ToString();
                string region = this.TestContext.DataRow["region"].ToString();
                string pincode = this.TestContext.DataRow["pincode"].ToString();
                string city = this.TestContext.DataRow["city"].ToString();
                string telephone = this.TestContext.DataRow["telephone"].ToString();
                string addressType = this.TestContext.DataRow["addressType"].ToString();
                string message = this.TestContext.DataRow["message"].ToString();
                string testUser = this.TestContext.Properties["HR_USOrigin"].ToString();
                string testUserPassword = TestContext.Properties["HRPassword"].ToString();
                LogInfo($"testUser: {testUser}, testUserPassword: {testUserPassword}");
                string careOf = string.Empty;
                string addressFirstLine = string.Empty;
                string addressSecondLine = string.Empty;
                string TelephoneNo = string.Empty;
                string uniqueNumber = _helper.GenerateUniqueRandomNumber();
                string countrySmallCase = country.ToLower();
                careOf = $"Careof{countrySmallCase}" + uniqueNumber;
                addressFirstLine = "AddressFirstline";
                addressSecondLine = "AddressSecondline";
                TelephoneNo = $"{telephone}" + _helper.GenerateRandomDigits(6);

                LogInfo("====================Test Method Execution has started=================");
                LogInfo($"AddressType: {addressType}, Country: {country},CareOf: {careOf},AddressFirstLine: {addressFirstLine},AddressSecondLine: {addressSecondLine}, Region: {region}, Pincode: {pincode}, City: {city}, TelephoneNo.: {TelephoneNo}");

                //LogoutWD application
                LogoutWD();
                // Launching the App Instance
                LaunchApp();

                // Login with the test user account of that specific country
                LoginToWD(testUser, testUserPassword);

                NavigateToInboxByGlobalSearch("Human Resources", "Personal Profile");
                WaitForMoment(2);
                _inboxAction.SelectFirstInboxRecord();
                WaitForMoment(2);
                _childInboxAction.ClickOnChildInboxeItem("Personal Profile", "Address");
                WaitForMoment(2);
                _childInboxAction.ClickOnFirstChildInboxeItem("Personal Profile", "Address");
                WaitForMoment(3);
                _childInboxAction.ClickOnCreateButton();
                WaitForMoment(3);

                //Validate the Reset Button Functioanlity in Create Address Page
                _hrAddressAction.VerifyAddressResetFunctionality(addressType, careOf, addressFirstLine, addressSecondLine, region, city, pincode, TelephoneNo, country, message);

                screenshotFileName = string.Empty;
                LogInfo("====================Test Method Execution has Completed=================");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("HRTest")]
        [TestCategory("HRAddressTest")]
        [Description("Create Europe Address from Address Inbox;;")]
        [Owner("vineeth.pamuexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"HR_CreateEuropeAddress_286657.csv", "HR_CreateEuropeAddress_286657#csv", DataAccessMethod.Sequential)]
        public void TC_286657_CreateEuropeAddressFromAddressInbox()
        {
            try
            {
                string country = this.TestContext.DataRow["country"].ToString();
                string region = this.TestContext.DataRow["region"].ToString();
                string pincode = this.TestContext.DataRow["pincode"].ToString();
                string city = this.TestContext.DataRow["city"].ToString();
                string telephone = this.TestContext.DataRow["telephone"].ToString();
                string addressType = this.TestContext.DataRow["addressType"].ToString();
                string message = this.TestContext.DataRow["message"].ToString();
                string testUser = this.TestContext.Properties["HR_GermanyOrigin"].ToString();
                string testUserPassword = TestContext.Properties["HRPassword"].ToString();
                LogInfo($"testUser: {testUser}, testUserPassword: {testUserPassword}");
                string careOf = string.Empty;
                string addressFirstLine = string.Empty;
                string addressSecondLine = string.Empty;
                string TelephoneNo = string.Empty;
                string uniqueNumber = _helper.GenerateUniqueRandomNumber();
                string countrySmallCase = country.ToLower();
                careOf = $"Careof{countrySmallCase}" + uniqueNumber;
                addressFirstLine = "AddressFirstline";
                addressSecondLine = "AddressSecondline";
                TelephoneNo = $"{telephone}" + _helper.GenerateRandomDigits(6);

                LogInfo("====================Test Method Execution has started=================");
                LogInfo($"AddressType: {addressType}, Country: {country},CareOf: {careOf},AddressFirstLine: {addressFirstLine},AddressSecondLine: {addressSecondLine}, Region: {region}, Pincode: {pincode}, City: {city}, TelephoneNo.: {TelephoneNo}");

                //LogoutWD application
                LogoutWD();
                // Launching the App Instance
                LaunchApp();

                // Login with the test user account of that specific country
                LoginToWD(testUser, testUserPassword);

                NavigateToInboxByGlobalSearch("Human Resources", "Personal Profile");
                WaitForMoment(2);
                _inboxAction.SelectFirstInboxRecord();
                WaitForMoment(2);
                _childInboxAction.ClickOnChildInboxeItem("Personal Profile", "Address");
                WaitForMoment(2);
                _childInboxAction.ClickOnFirstChildInboxeItem("Personal Profile", "Address");
                WaitForMoment(3);
                _childInboxAction.ClickOnCreateButton();
                WaitForMoment(3);
                _hrAddressAction.CreateAddressDetails(addressType, careOf, addressFirstLine, addressSecondLine, region, city, pincode, TelephoneNo, country, message);
                WaitForMoment(1);

                NavigateToInboxByGlobalSearch("Human Resources", "Personal Profile");
                WaitForMoment(2);
                _inboxAction.SelectFirstInboxRecord();
                WaitForMoment(2);
                _hrAddressAction.VerifyPersonalAddressField(careOf);
                screenshotFileName = string.Empty;
                LogInfo("====================Test Method Execution has Completed=================");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        [TestCategory("HRTest")]
        [TestCategory("HRAddressTest")]
        [Description("End Now Permanent Address Error from Address Inbox;;")]
        [Owner("vineeth.pamuexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"HR_CreateUSAddress_286910.csv", "HR_CreateUSAddress_286910#csv", DataAccessMethod.Sequential)]
        public void TC_287289_EndNowPermanentAddressErrorAlert()
        {
            try
            {
                string country = this.TestContext.DataRow["country"].ToString();
                string region = this.TestContext.DataRow["region"].ToString();
                string pincode = this.TestContext.DataRow["pincode"].ToString();
                string city = this.TestContext.DataRow["city"].ToString();
                string telephone = this.TestContext.DataRow["telephone"].ToString();
                string addressType = this.TestContext.DataRow["addressType"].ToString();
                string message = this.TestContext.DataRow["message"].ToString();
                string testUser = this.TestContext.Properties["HR_USOrigin"].ToString();
                string testUserPassword = TestContext.Properties["HRPassword"].ToString();
                LogInfo($"testUser: {testUser}, testUserPassword: {testUserPassword}");
                string careOf = string.Empty;
                string addressFirstLine = string.Empty;
                string addressSecondLine = string.Empty;
                string TelephoneNo = string.Empty;
                string uniqueNumber = _helper.GenerateUniqueRandomNumber();
                string countrySmallCase = country.ToLower();
                careOf = $"Careof{countrySmallCase}" + uniqueNumber;
                addressFirstLine = "AddressFirstline";
                addressSecondLine = "AddressSecondline";
                TelephoneNo = $"{telephone}" + _helper.GenerateRandomDigits(6);

                LogInfo("====================Test Method Execution has started=================");
                LogInfo($"AddressType: {addressType}, Country: {country},CareOf: {careOf},AddressFirstLine: {addressFirstLine},AddressSecondLine: {addressSecondLine}, Region: {region}, Pincode: {pincode}, City: {city}, TelephoneNo.: {TelephoneNo}");

                //LogoutWD application
                LogoutWD();
                // Launching the App Instance
                LaunchApp();

                // Login with the test user account of that specific country
                LoginToWD(testUser, testUserPassword);

                NavigateToInboxByGlobalSearch("Human Resources", "Personal Profile");
                WaitForMoment(2);
                _inboxAction.SelectFirstInboxRecord();
                WaitForMoment(2);
                _childInboxAction.ClickOnChildInboxeItem("Personal Profile", "Address");
                WaitForMoment(2);
                _childInboxAction.ClickOnFirstChildInboxeItem("Personal Profile", "Address");
                WaitForMoment(3);
                _childInboxAction.ClickOnCreateButton();
                WaitForMoment(3);
                _hrAddressAction.CreateAddressDetails(addressType, careOf, addressFirstLine, addressSecondLine, region, city, pincode, TelephoneNo, country, message);
                WaitForMoment(1);

                //Verify End Now Action Error Alert for Permanent Address
                _hrBankAction.FilterDataBySearch(careOf);
                WaitForMoment(2);
                _hrAddressAction.SelectAddressAction();
                WaitForMoment(2);
                _hrBankAction.SelectEndNow();
                WaitForMoment(1);
                _hrAddressAction.ValidatePopUpMessage("Permanent Address cannot be deleted");
                _hrAddressAction.ClickOnOk();
                screenshotFileName = string.Empty;
                LogInfo("====================Test Method Execution has Completed=================");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        [TestCategory("HRTest")]
        [TestCategory("HRAddressTest")]
        [Description("Verify County field in Address for Region pennsylvania;;")]
        [Owner("vineeth.pamuexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"HR_CreateAddressWithCounty_453479.csv", "HR_CreateAddressWithCounty_453479#csv", DataAccessMethod.Sequential)]
        public void TC_453479_VerifyCountyandCreateAddress()
        {
            try
            {
                string country = this.TestContext.DataRow["country"].ToString();
                string region = this.TestContext.DataRow["region"].ToString();
                string pincode = this.TestContext.DataRow["pincode"].ToString();
                string city = this.TestContext.DataRow["city"].ToString();
                string telephone = this.TestContext.DataRow["telephone"].ToString();
                string addressType = this.TestContext.DataRow["addressType"].ToString();
                string message = this.TestContext.DataRow["message"].ToString();
                string testUser = this.TestContext.Properties["HR_USOrigin"].ToString();
                string testUserPassword = TestContext.Properties["HRPassword"].ToString();
                LogInfo($"testUser: {testUser}, testUserPassword: {testUserPassword}");
                string careOf = string.Empty;
                string addressFirstLine = string.Empty;
                string addressSecondLine = string.Empty;
                string TelephoneNo = string.Empty;
                string uniqueNumber = _helper.GenerateUniqueRandomNumber();
                string countrySmallCase = country.ToLower();
                careOf = $"Careof{countrySmallCase}" + uniqueNumber;
                addressFirstLine = "AddressFirstline";
                addressSecondLine = "AddressSecondline";
                TelephoneNo = $"{telephone}" + _helper.GenerateRandomDigits(6);

                LogInfo("====================Test Method Execution has started=================");
                LogInfo($"AddressType: {addressType}, Country: {country},CareOf: {careOf},AddressFirstLine: {addressFirstLine},AddressSecondLine: {addressSecondLine}, Region: {region}, Pincode: {pincode}, City: {city}, TelephoneNo.: {TelephoneNo}");

                //LogoutWD application
                LogoutWD();
                // Launching the App Instance
                LaunchApp();

                // Login with the test user account of that specific country
                LoginToWD(testUser, testUserPassword);

                NavigateToInboxByGlobalSearch("Human Resources", "Personal Profile");
                WaitForMoment(2);
                _inboxAction.SelectFirstInboxRecord();
                WaitForMoment(2);
                _childInboxAction.ClickOnChildInboxeItem("Personal Profile", "Address");
                WaitForMoment(2);
                _childInboxAction.ClickOnFirstChildInboxeItem("Personal Profile", "Address");
                WaitForMoment(3);
                _childInboxAction.ClickOnCreateButton();
                WaitForMoment(3);
                _hrAddressAction.CreateAddressDetails(addressType, careOf, addressFirstLine, addressSecondLine, region, city, pincode, TelephoneNo, country, message);
                WaitForMoment(1);

                NavigateToInboxByGlobalSearch("Human Resources", "Personal Profile");
                WaitForMoment(2);
                _inboxAction.SelectFirstInboxRecord();
                WaitForMoment(2);
                _hrAddressAction.VerifyPersonalAddressField(careOf);
                screenshotFileName = string.Empty;
                LogInfo("====================Test Method Execution has Completed=================");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        [TestCategory("HRTest")]
        [TestCategory("HRAddressTest")]
        [Description("End Now Temporary Address from Address Inbox;;")]
        [Owner("vineeth.pamuexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"HR_USATempAddress_286656.csv", "HR_USATempAddress_286656#csv", DataAccessMethod.Sequential)]
        public void TC_286656_EndNowTemporaryAddress_AddressInbox()
        {
            try
            {
                string country = this.TestContext.DataRow["country"].ToString();
                string region = this.TestContext.DataRow["region"].ToString();
                string pincode = this.TestContext.DataRow["pincode"].ToString();
                string city = this.TestContext.DataRow["city"].ToString();
                string telephone = this.TestContext.DataRow["telephone"].ToString();
                string addressType = this.TestContext.DataRow["addressType"].ToString();
                string message = this.TestContext.DataRow["message"].ToString();
                string testUser = this.TestContext.Properties["HR_USOrigin"].ToString();
                string testUserPassword = TestContext.Properties["HRPassword"].ToString();
                string endNowMessage = TestContext.DataRow["endNowMessage"].ToString();
                
                LogInfo($"testUser: {testUser}, testUserPassword: {testUserPassword}");
                string careOf = string.Empty;
                string addressFirstLine = string.Empty;
                string addressSecondLine = string.Empty;
                string TelephoneNo = string.Empty;
                string uniqueNumber = _helper.GenerateUniqueRandomNumber();
                string countrySmallCase = country.ToLower();
                careOf = $"Careof{countrySmallCase}" + uniqueNumber;
                addressFirstLine = "AddressFirstline";
                addressSecondLine = "AddressSecondline";
                TelephoneNo = $"{telephone}" + _helper.GenerateRandomDigits(6);

                LogInfo("====================Test Method Execution has started=================");
                LogInfo($"AddressType: {addressType}, Country: {country},CareOf: {careOf},AddressFirstLine: {addressFirstLine},AddressSecondLine: {addressSecondLine}, Region: {region}, Pincode: {pincode}, City: {city}, TelephoneNo.: {TelephoneNo}, EndNowSuccessMessage: {endNowMessage}");

                //LogoutWD application
                LogoutWD();
                // Launching the App Instance
                LaunchApp();

                // Login with the test user account of that specific country
                LoginToWD(testUser, testUserPassword);

                NavigateToInboxByGlobalSearch("Human Resources", "Personal Profile");
                WaitForMoment(2);
                _inboxAction.SelectFirstInboxRecord();
                WaitForMoment(2);
                _childInboxAction.ClickOnChildInboxeItem("Personal Profile", "Address");
                WaitForMoment(2);
                _childInboxAction.ClickOnFirstChildInboxeItem("Personal Profile", "Address");
                WaitForMoment(3);
                _childInboxAction.ClickOnCreateButton();
                WaitForMoment(3);
                _hrAddressAction.CreateAddressDetails(addressType, careOf, addressFirstLine, addressSecondLine, region, city, pincode, TelephoneNo, country, message);
                WaitForMoment(1);

                //Verify End Now Action for Temporary Address
                _hrBankAction.FilterDataBySearch(careOf);
                WaitForMoment(1);
                _hrAddressAction.SelectAddressAction();
                WaitForMoment(1);
                _hrBankAction.SelectEndNow();
                WaitForMoment(1);
                _hrAddressAction.ClickOnOk();
                _hrAddressAction.ValidatePopUpMessage(endNowMessage);
                _contactsAction.ClickOnRefreshData();
                _hrBankAction.FilterDataBySearch(careOf);
                bool flag = _hrAddressAction.VerifyRecordPresent(careOf);
                LogInfo("Temporary Address present in Address Inbox after deleted flag: " + flag);
                Assert.IsFalse(flag,"Temporary Address Record still displayed in Address Inbox after deleted");
                WaitForMoment(2);

                screenshotFileName = string.Empty;
                LogInfo("====================Test Method Execution has Completed=================");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        [TestCategory("HRTest")]
        [TestCategory("HRAddressTest")]
        [Description("End Now Emergency Contact from Address Inbox;;")]
        [Owner("vineeth.pamuexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"HR_CreateEmergencyContact_286914.csv", "HR_CreateEmergencyContact_286914#csv", DataAccessMethod.Sequential)]
        public void TC_286914_EndNowEmergencyContact_AddressInbox()
        {
            try
            {
                string country = this.TestContext.DataRow["country"].ToString();
                string region = this.TestContext.DataRow["region"].ToString();
                string pincode = this.TestContext.DataRow["pincode"].ToString();
                string city = this.TestContext.DataRow["city"].ToString();
                string telephone = this.TestContext.DataRow["telephone"].ToString();
                string addressType = this.TestContext.DataRow["addressType"].ToString();
                string message = this.TestContext.DataRow["message"].ToString();
                string testUser = this.TestContext.Properties["HR_USOrigin"].ToString();
                string testUserPassword = TestContext.Properties["HRPassword"].ToString();
                string endNowMessage = TestContext.DataRow["endNowMessage"].ToString();

                LogInfo($"testUser: {testUser}, testUserPassword: {testUserPassword}");
                string careOf = string.Empty;
                string addressFirstLine = string.Empty;
                string addressSecondLine = string.Empty;
                string TelephoneNo = string.Empty;
                string uniqueNumber = _helper.GenerateUniqueRandomNumber();
                string countrySmallCase = country.ToLower();
                careOf = $"Careof{countrySmallCase}" + uniqueNumber;
                addressFirstLine = "AddressFirstline";
                addressSecondLine = "AddressSecondline";
                TelephoneNo = $"{telephone}" + _helper.GenerateRandomDigits(6);

                LogInfo("====================Test Method Execution has started=================");
                LogInfo($"AddressType: {addressType}, Country: {country},CareOf: {careOf},AddressFirstLine: {addressFirstLine},AddressSecondLine: {addressSecondLine}, Region: {region}, Pincode: {pincode}, City: {city}, TelephoneNo.: {TelephoneNo}, EndNowSuccessMessage: {endNowMessage}");

                //LogoutWD application
                LogoutWD();
                // Launching the App Instance
                LaunchApp();

                // Login with the test user account of that specific country
                LoginToWD(testUser, testUserPassword);

                NavigateToInboxByGlobalSearch("Human Resources", "Personal Profile");
                WaitForMoment(2);
                _inboxAction.SelectFirstInboxRecord();
                WaitForMoment(2);
                _childInboxAction.ClickOnChildInboxeItem("Personal Profile", "Address");
                WaitForMoment(2);
                _childInboxAction.ClickOnFirstChildInboxeItem("Personal Profile", "Address");
                WaitForMoment(3);
                _childInboxAction.ClickOnCreateButton();
                WaitForMoment(3);
                _hrAddressAction.CreateAddressDetails(addressType, careOf, addressFirstLine, addressSecondLine, region, city, pincode, TelephoneNo, country, message);
                WaitForMoment(1);

                //Verify End Now Action for Temporary Address
                _hrBankAction.FilterDataBySearch(careOf);
                WaitForMoment(1);
                _hrAddressAction.SelectAddressAction();
                WaitForMoment(1);
                _hrBankAction.SelectEndNow();
                WaitForMoment(1);
                _hrAddressAction.ClickOnOk();
                _hrAddressAction.ValidatePopUpMessage(endNowMessage);
                _contactsAction.ClickOnRefreshData();
                _hrBankAction.FilterDataBySearch(careOf);
                bool flag = _hrAddressAction.VerifyRecordPresent(careOf);
                LogInfo("Emergency Contact present in Address Inbox after deleted flag: " + flag);
                Assert.IsFalse(flag, "Emergency Contact Record still displayed in Address Inbox after deleted");
                WaitForMoment(2);

                screenshotFileName = string.Empty;
                LogInfo("====================Test Method Execution has Completed=================");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        [TestCategory("HRTest")]
        [TestCategory("HRAddressTest")]
        [Description("Verify user is able to add multiple address;;")]
        [Owner("vineeth.pamuexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"HR_USAMultipleAddress_278064.csv", "HR_USAMultipleAddress_278064#csv", DataAccessMethod.Sequential)]
        public void TC_278064_CreateMultipleAddress_AddressInbox()
        {
            try
            {
                string country = this.TestContext.DataRow["country"].ToString();
                string region = this.TestContext.DataRow["region"].ToString();
                string pincode = this.TestContext.DataRow["pincode"].ToString();
                string city = this.TestContext.DataRow["city"].ToString();
                string telephone = this.TestContext.DataRow["telephone"].ToString();
                string addressType = this.TestContext.DataRow["addressType"].ToString();
                string message = this.TestContext.DataRow["message"].ToString();
                string testUser = this.TestContext.Properties["HR_USOrigin"].ToString();
                string testUserPassword = TestContext.Properties["HRPassword"].ToString();
                string TempSuccessMsg = message.Replace("*", "Temporary Address");
                string PermSuccessMsg = message.Replace("*", "Permanent Address");
                string EmergencySuccessMsg = message.Replace("*", "Emergency Address");
                LogInfo($"testUser: {testUser}, testUserPassword: {testUserPassword}");
                
                string addressFirstLine = string.Empty;
                string addressSecondLine = string.Empty;
                string TelephoneNo = string.Empty;
                string uniqueNumber = _helper.GenerateUniqueRandomNumber();
                string countrySmallCase = country.ToLower();
                string careOfTemp = string.Empty;
                careOfTemp = "Careoftemp" + uniqueNumber;
                string careOfPerm = string.Empty;
                careOfPerm = "Careofperm" + uniqueNumber;
                string careOfEmergency = string.Empty;
                careOfEmergency = "Careofemergency" + uniqueNumber;

                addressFirstLine = "AddressFirstline";
                addressSecondLine = "AddressSecondline";
                TelephoneNo = $"{telephone}" + _helper.GenerateRandomDigits(6);

                LogInfo("====================Test Method Execution has started=================");
                LogInfo($"AddressType: {addressType}, Country: {country},AddressFirstLine: {addressFirstLine},AddressSecondLine: {addressSecondLine}, Region: {region}, Pincode: {pincode}, City: {city}, TelephoneNo.: {TelephoneNo}, TempSuccessMessage: {TempSuccessMsg}" +
                    $"PermSuccessMessage: {PermSuccessMsg}, EmergencySuccessMessage: {EmergencySuccessMsg}");

                //LogoutWD application
                LogoutWD();
                // Launching the App Instance
                LaunchApp();

                // Login with the test user account of that specific country
                LoginToWD(testUser, testUserPassword);

                NavigateToInboxByGlobalSearch("Human Resources", "Personal Profile");
                WaitForMoment(2);
                _inboxAction.SelectFirstInboxRecord();
                WaitForMoment(2);
                _childInboxAction.ClickOnChildInboxeItem("Personal Profile", "Address");
                WaitForMoment(2);
                _childInboxAction.ClickOnFirstChildInboxeItem("Personal Profile", "Address");
                WaitForMoment(3);
                _childInboxAction.ClickOnCreateButton();
                WaitForMoment(3);
                _hrAddressAction.CreateAddressDetails("Permanent Residence", careOfPerm, addressFirstLine, addressSecondLine, region, city, pincode, TelephoneNo, country, PermSuccessMsg);
                WaitForMoment(1);

                //Create Temporary Address
                _childInboxAction.ClickOnCreateButton();
                WaitForMoment(3);
                _hrAddressAction.CreateAddressDetails("Temporary Residence", careOfTemp, addressFirstLine, addressSecondLine, region, city, pincode, TelephoneNo, country, TempSuccessMsg);
                WaitForMoment(1);

                //Create Emergency Contact
                _childInboxAction.ClickOnCreateButton();
                WaitForMoment(3);
                _hrAddressAction.CreateAddressDetails("Emergency Contact", careOfEmergency, addressFirstLine, addressSecondLine, region, city, pincode, TelephoneNo, country, EmergencySuccessMsg);
                WaitForMoment(1);

                //Verify Created Addresses are listed in Address tab
                _hrBankAction.FilterDataBySearch(careOfPerm);
                WaitForMoment(1);
                _hrAddressAction.VerifyPersonalAddressField(careOfPerm);
                WaitForMoment(1);

                _hrBankAction.FilterDataBySearch(careOfTemp);
                WaitForMoment(1);
                _hrAddressAction.VerifyPersonalAddressField(careOfTemp);
                WaitForMoment(1);

                _hrBankAction.FilterDataBySearch(careOfEmergency);
                WaitForMoment(1);
                _hrAddressAction.VerifyPersonalAddressField(careOfEmergency);
                WaitForMoment(1);

                screenshotFileName = string.Empty;
                LogInfo("====================Test Method Execution has Completed=================");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        [TestCategory("HRTest")]
        [TestCategory("HRAddressTest")]
        [Description("Delete Temporary Address From Profile Page;;")]
        [Owner("vineeth.pamuexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"HR_USATempAddress_286656.csv", "HR_USATempAddress_286656#csv", DataAccessMethod.Sequential)]
        public void TC_331875_DeleteTemporaryAddress_ProfilePage()
        {
            try
            {
                string country = this.TestContext.DataRow["country"].ToString();
                string region = this.TestContext.DataRow["region"].ToString();
                string pincode = this.TestContext.DataRow["pincode"].ToString();
                string city = this.TestContext.DataRow["city"].ToString();
                string telephone = this.TestContext.DataRow["telephone"].ToString();
                string addressType = this.TestContext.DataRow["addressType"].ToString();
                string message = this.TestContext.DataRow["message"].ToString();
                string testUser = this.TestContext.Properties["HR_USOrigin"].ToString();
                string testUserPassword = TestContext.Properties["HRPassword"].ToString();
                string endNowMessage = TestContext.DataRow["endNowMessage"].ToString();

                LogInfo($"testUser: {testUser}, testUserPassword: {testUserPassword}");
                string careOf = string.Empty;
                string addressFirstLine = string.Empty;
                string addressSecondLine = string.Empty;
                string TelephoneNo = string.Empty;
                string uniqueNumber = _helper.GenerateUniqueRandomNumber();
                string countrySmallCase = country.ToLower();
                careOf = $"Careof{countrySmallCase}" + uniqueNumber;
                addressFirstLine = "AddressFirstline";
                addressSecondLine = "AddressSecondline";
                TelephoneNo = $"{telephone}" + _helper.GenerateRandomDigits(6);

                LogInfo("====================Test Method Execution has started=================");
                LogInfo($"AddressType: {addressType}, Country: {country},CareOf: {careOf},AddressFirstLine: {addressFirstLine},AddressSecondLine: {addressSecondLine}, Region: {region}, Pincode: {pincode}, City: {city}, TelephoneNo.: {TelephoneNo}, EndNowSuccessMessage: {endNowMessage}");

                //LogoutWD application
                LogoutWD();
                // Launching the App Instance
                LaunchApp();

                // Login with the test user account of that specific country
                LoginToWD(testUser, testUserPassword);

                WaitForMoment(2);
                _homeAction.ClickOnProfileImage();
                _homeAction.ViewLoggedInUserProfile();
                WaitForMoment(2);
                _hrAddressAction.SelectAddressAccountMenuOption();
                WaitForMoment(2);
                _childInboxAction.ClickOnCreateButton();
                WaitForMoment(2);
                _hrAddressAction.CreateAddressDetails(addressType, careOf, addressFirstLine, addressSecondLine, region, city, pincode, TelephoneNo, country, message);
                WaitForMoment(1);

                //Verify End Now Action for Temporary Address
                _hrAddressAction.SelectAddressAccountMenuOption();
                WaitForMoment(1);
                _hrAddressAction.ClickDeleteAddressButton(careOf);
                WaitForMoment(1);
                _hrAddressAction.ClickOnOk();
                _hrAddressAction.ValidatePopUpMessage(endNowMessage);

                _homeAction.ClickOnHomeButton();
                NavigateToInboxByGlobalSearch("Human Resources", "Personal Profile");
                WaitForMoment(2);
                _inboxAction.SelectFirstInboxRecord();
                WaitForMoment(2);
                _childInboxAction.ClickOnChildInboxeItem("Personal Profile", "Address");
                WaitForMoment(2);
                _childInboxAction.ClickOnFirstChildInboxeItem("Personal Profile", "Address");
                WaitForMoment(1);
                _contactsAction.ClickOnRefreshData();
                _hrBankAction.FilterDataBySearch(careOf);
                bool flag = _hrAddressAction.VerifyRecordPresent(careOf);
                LogInfo("Temporary Address present in Address Inbox after deleted flag: " + flag);
                Assert.IsFalse(flag, "Temporary Address Record still displayed in Address Inbox after deleted");
                WaitForMoment(2);

                screenshotFileName = string.Empty;
                LogInfo("====================Test Method Execution has Completed=================");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }
        #endregion


        #region HR EEO
        [TestMethod]
        [TestCategory("HRTest")]
        [TestCategory("HREEO")]
        [Description("Self Identification not there for Non US users;;")]
        [Owner("vineeth.pamuexternal@westpharma.com")]
        public void TC_415674_SelfIdentificationNotPreset_NonUSAUsers()
        {
            try
            {
                
                string testUser = this.TestContext.Properties["HR_GermanyOrigin"].ToString();
                string testUserPassword = TestContext.Properties["HRPassword"].ToString();
                
                LogInfo("====================Test Method Execution has started=================");
                //LogoutWD application
                LogoutWD();
                // Launching the App Instance
                LaunchApp();

                // Login with the test user account of that specific country
                LoginToWD(testUser, testUserPassword);

                WaitForMoment(2);
                _homeAction.ClickOnProfileImage();
                _homeAction.ViewLoggedInUserProfile();
                WaitForMoment(2);
               
                bool flag = _hrSelfIdentificationAction.VerifySelfIdentificationMenuOptionPresent();
                LogInfo("Self Identification Menu Option Present: " + flag);
                Assert.IsFalse(flag, "Self Identification present for Non USA User");
                WaitForMoment(2);

                screenshotFileName = string.Empty;
                LogInfo("====================Test Method Execution has Completed=================");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        [TestCategory("HRTest")]
        [TestCategory("HREEO")]
        [Description("Self Identification present for US users;;")]
        [Owner("vineeth.pamuexternal@westpharma.com")]
        public void TC_415680_SelfIdentificationPreset_USAUsers()
        {
            try
            {

                string testUser = this.TestContext.Properties["HR_USOrigin"].ToString();
                string testUserPassword = TestContext.Properties["HRPassword"].ToString();

                LogInfo("====================Test Method Execution has started=================");
                //LogoutWD application
                LogoutWD();
                // Launching the App Instance
                LaunchApp();

                // Login with the test user account of that specific country
                LoginToWD(testUser, testUserPassword);

                WaitForMoment(2);
                _homeAction.ClickOnProfileImage();
                _homeAction.ViewLoggedInUserProfile();
                WaitForMoment(2);

                bool flag = _hrSelfIdentificationAction.VerifySelfIdentificationMenuOptionPresent();
                LogInfo("Self Identification Menu Option Present: " + flag);
                Assert.IsTrue(flag, "Self Identification Not present for USA User");


                //Select Self Identification and click on Edit Icon 
                _hrSelfIdentificationAction.selectSelfIdentificationMenu();
                _hrSelfIdentificationAction.ClickEditSelfIdentification();
                WaitForMoment(2);

                screenshotFileName = string.Empty;
                LogInfo("====================Test Method Execution has Completed=================");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        [TestCategory("HRTest")]
        [TestCategory("HREEO")]
        [Description("Mandatory fields required pop up Message EEO Page;;")]
        [Owner("vineeth.pamuexternal@westpharma.com")]
        public void TC_415715_EEO_MandatoryRequiredMessage()
        {
            try
            {

                string testUser = this.TestContext.Properties["HR_USOrigin"].ToString();
                string testUserPassword = TestContext.Properties["HRPassword"].ToString();

                LogInfo("====================Test Method Execution has started=================");
                //LogoutWD application
                LogoutWD();
                // Launching the App Instance
                LaunchApp();

                // Login with the test user account of that specific country
                LoginToWD(testUser, testUserPassword);

                WaitForMoment(2);
                _homeAction.ClickOnProfileImage();
                _homeAction.ViewLoggedInUserProfile();
                WaitForMoment(2);

                //Select Self Identification and click on Edit Icon 
                _hrSelfIdentificationAction.selectSelfIdentificationMenu();
                _hrSelfIdentificationAction.ClickEditSelfIdentification();
                WaitForMoment(2);

                //Clear Field Values in EEO Page
                _hrSelfIdentificationAction.clearFieldValues_SelfIdentification();

                //Click Save to verify mandatory fields required message is displayed
                _hrSelfIdentificationAction.ClickOnSave();
                _hrBankAction.ValidatePopUpMessage("Please enter all fields");
                _hrSelfIdentificationAction.ClickOkButton();
                screenshotFileName = string.Empty;
                LogInfo("====================Test Method Execution has Completed=================");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        [TestCategory("HRTest")]
        [TestCategory("HREEO")]
        [Description("Submit EEO Ethnicity as Hisplanic Latino;;")]
        [Owner("vineeth.pamuexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"HR_SubmitEEO_415753.csv", "HR_SubmitEEO_415753#csv", DataAccessMethod.Sequential)]
        public void TC_415753_SubmitEEO_HispanicLatino()
        {
            try
            {
                string ethnicity = this.TestContext.DataRow["Ethnicity"].ToString();
                string race = this.TestContext.DataRow["Race"].ToString();
                string veteranStatus = this.TestContext.DataRow["VeteranStatus"].ToString();
                string disabilityStatus = this.TestContext.DataRow["DisabilityStatus"].ToString();
                string message = this.TestContext.DataRow["message"].ToString();
                string protectedVeteranType = this.TestContext.DataRow["protectedVeteranType"].ToString();
                string testUser = this.TestContext.Properties["HR_USOrigin"].ToString();
                string testUserPassword = TestContext.Properties["HRPassword"].ToString();

                LogInfo($"Ethnicity: {ethnicity}, Race: {race}, Veteran Status: {veteranStatus}, Disability Status: {disabilityStatus}, Message: {message}");
                LogInfo("====================Test Method Execution has started=================");
                //LogoutWD application
                LogoutWD();
                // Launching the App Instance
                LaunchApp();

                // Login with the test user account of that specific country
                LoginToWD(testUser, testUserPassword);

                WaitForMoment(2);
                _homeAction.ClickOnProfileImage();
                _homeAction.ViewLoggedInUserProfile();
                WaitForMoment(2);

                //Select Self Identification and click on Edit Icon 
                _hrSelfIdentificationAction.selectSelfIdentificationMenu();
                _hrSelfIdentificationAction.ClickEditSelfIdentification();
                WaitForMoment(2);

                //Submit EEO
                _hrSelfIdentificationAction.EditSelfIdentification_EEO(ethnicity, race, veteranStatus, protectedVeteranType, disabilityStatus);
                _hrBankAction.ValidatePopUpMessage(message);
                _hrSelfIdentificationAction.ClickOkButton();

                //Verify Self ID updated successfully
                _hrSelfIdentificationAction.selectSelfIdentificationMenu();
                bool flag = _hrAddressAction.VerifyRecordPresent(ethnicity);
                Assert.IsTrue(flag, "Ethnicity is not updated for Self ID ");
                flag = _hrAddressAction.VerifyRecordPresent(veteranStatus);
                Assert.IsTrue(flag, "Veteran Status is not updated for Self ID ");
                flag = _hrAddressAction.VerifyRecordPresent(protectedVeteranType);
                Assert.IsTrue(flag, "Veteran Type is not updated for Self ID ");
                flag = _hrAddressAction.VerifyRecordPresent(disabilityStatus);
                Assert.IsTrue(flag, "Disability Status is not updated for Self ID ");
                screenshotFileName = string.Empty;
                LogInfo("====================Test Method Execution has Completed=================");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        [TestCategory("HRTest")]
        [TestCategory("HREEO")]
        [Description("Submit EEO Ethnicity as Not Hisplanic Latino;;")]
        [Owner("vineeth.pamuexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"HR_SubmitEEO_415766.csv", "HR_SubmitEEO_415766#csv", DataAccessMethod.Sequential)]
        public void TC_415766_SubmitEEO_NotHispanicLatino()
        {
            try
            {
                string ethnicity = this.TestContext.DataRow["Ethnicity"].ToString();
                string race = this.TestContext.DataRow["Race"].ToString();
                string veteranStatus = this.TestContext.DataRow["VeteranStatus"].ToString();
                string disabilityStatus = this.TestContext.DataRow["DisabilityStatus"].ToString();
                string message = this.TestContext.DataRow["message"].ToString();
                string protectedVeteranType = this.TestContext.DataRow["protectedVeteranType"].ToString();
                string testUser = this.TestContext.Properties["HR_USOrigin"].ToString();
                string testUserPassword = TestContext.Properties["HRPassword"].ToString();

                LogInfo($"Ethnicity: {ethnicity}, Race: {race}, Veteran Status: {veteranStatus}, Disability Status: {disabilityStatus}, Message: {message}");
                LogInfo("====================Test Method Execution has started=================");
                //LogoutWD application
                LogoutWD();
                // Launching the App Instance
                LaunchApp();

                // Login with the test user account of that specific country
                LoginToWD(testUser, testUserPassword);

                WaitForMoment(2);
                _homeAction.ClickOnProfileImage();
                _homeAction.ViewLoggedInUserProfile();
                WaitForMoment(2);

                //Select Self Identification and click on Edit Icon 
                _hrSelfIdentificationAction.selectSelfIdentificationMenu();
                _hrSelfIdentificationAction.ClickEditSelfIdentification();
                WaitForMoment(2);

                //Submit EEO
                _hrSelfIdentificationAction.EditSelfIdentification_EEO(ethnicity, race, veteranStatus, protectedVeteranType, disabilityStatus);
                _hrBankAction.ValidatePopUpMessage(message);
                _hrSelfIdentificationAction.ClickOkButton();

                //Verify Self ID updated successfully
                _hrSelfIdentificationAction.selectSelfIdentificationMenu();
                bool flag = _hrAddressAction.VerifyRecordPresent(ethnicity);
                Assert.IsTrue(flag, "Ethnicity is not updated for Self ID ");
                flag = _hrAddressAction.VerifyRecordPresent(race);
                Assert.IsTrue(flag, "Race is not updated for Self ID ");
                flag = _hrAddressAction.VerifyRecordPresent(veteranStatus);
                Assert.IsTrue(flag, "Veteran Status is not updated for Self ID ");
                flag = _hrAddressAction.VerifyRecordPresent(protectedVeteranType);
                Assert.IsTrue(flag, "Veteran Type is not updated for Self ID ");
                flag = _hrAddressAction.VerifyRecordPresent(disabilityStatus);
                Assert.IsTrue(flag, "Disability Status is not updated for Self ID ");
                screenshotFileName = string.Empty;
                LogInfo("====================Test Method Execution has Completed=================");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        [TestCategory("HRTest")]
        [TestCategory("HREEO")]
        [Description("Submit EEO Ethnicity as Protected Veteran;;")]
        [Owner("vineeth.pamuexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"HR_SubmitEEO_415791.csv", "HR_SubmitEEO_415791#csv", DataAccessMethod.Sequential)]
        public void TC_415791_SubmitEEO_ProtectedVeteran()
        {
            try
            {
                string ethnicity = this.TestContext.DataRow["Ethnicity"].ToString();
                string race = this.TestContext.DataRow["Race"].ToString();
                string veteranStatus = this.TestContext.DataRow["VeteranStatus"].ToString();
                string disabilityStatus = this.TestContext.DataRow["DisabilityStatus"].ToString();
                string message = this.TestContext.DataRow["message"].ToString();
                string protectedVeteranType = this.TestContext.DataRow["protectedVeteranType"].ToString();
                string testUser = this.TestContext.Properties["HR_USOrigin"].ToString();
                string testUserPassword = TestContext.Properties["HRPassword"].ToString();

                LogInfo($"Ethnicity: {ethnicity}, Race: {race}, Veteran Status: {veteranStatus}, Procted Veteran Type: {protectedVeteranType}, Disability Status: {disabilityStatus}, Message: {message}");
                LogInfo("====================Test Method Execution has started=================");
                //LogoutWD application
                LogoutWD();
                // Launching the App Instance
                LaunchApp();

                // Login with the test user account of that specific country
                LoginToWD(testUser, testUserPassword);

                WaitForMoment(2);
                _homeAction.ClickOnProfileImage();
                _homeAction.ViewLoggedInUserProfile();
                WaitForMoment(2);

                //Select Self Identification and click on Edit Icon 
                _hrSelfIdentificationAction.selectSelfIdentificationMenu();
                _hrSelfIdentificationAction.ClickEditSelfIdentification();
                WaitForMoment(2);

                //Submit EEO
                _hrSelfIdentificationAction.EditSelfIdentification_EEO(ethnicity, race, veteranStatus, protectedVeteranType, disabilityStatus);
                _hrBankAction.ValidatePopUpMessage(message);
                _hrSelfIdentificationAction.ClickOkButton();

                //Verify Self ID updated successfully
                _hrSelfIdentificationAction.selectSelfIdentificationMenu();
                bool flag = _hrAddressAction.VerifyRecordPresent(ethnicity);
                Assert.IsTrue(flag, "Ethnicity is not updated for Self ID ");
                flag = _hrAddressAction.VerifyRecordPresent(veteranStatus);
                Assert.IsTrue(flag, "Veteran Status is not updated for Self ID ");
                flag = _hrAddressAction.VerifyRecordPresent(disabilityStatus);
                Assert.IsTrue(flag, "Disability Status is not updated for Self ID ");
                screenshotFileName = string.Empty;
                LogInfo("====================Test Method Execution has Completed=================");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        [TestCategory("HRTest")]
        [TestCategory("HREEO")]
        [Description("Reset EEO Action;;")]
        [Owner("vineeth.pamuexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"HR_SubmitEEO_415766.csv", "HR_SubmitEEO_415766#csv", DataAccessMethod.Sequential)]
        public void TC_415713_ResetEEOAction()
        {
            try
            {
                string ethnicity = this.TestContext.DataRow["Ethnicity"].ToString();
                string race = this.TestContext.DataRow["Race"].ToString();
                string veteranStatus = this.TestContext.DataRow["VeteranStatus"].ToString();
                string disabilityStatus = this.TestContext.DataRow["DisabilityStatus"].ToString();
                string message = this.TestContext.DataRow["message"].ToString();
                string protectedVeteranType = this.TestContext.DataRow["protectedVeteranType"].ToString();
                string testUser = this.TestContext.Properties["HR_USOrigin"].ToString();
                string testUserPassword = TestContext.Properties["HRPassword"].ToString();

                LogInfo($"Ethnicity: {ethnicity}, Race: {race}, Veteran Status: {veteranStatus}, Disability Status: {disabilityStatus}, Message: {message}");
                LogInfo("====================Test Method Execution has started=================");
                //LogoutWD application
                LogoutWD();
                // Launching the App Instance
                LaunchApp();

                // Login with the test user account of that specific country
                LoginToWD(testUser, testUserPassword);

                WaitForMoment(2);
                _homeAction.ClickOnProfileImage();
                _homeAction.ViewLoggedInUserProfile();
                WaitForMoment(2);

                //Select Self Identification and click on Edit Icon 
                _hrSelfIdentificationAction.selectSelfIdentificationMenu();
                _hrSelfIdentificationAction.ClickEditSelfIdentification();
                WaitForMoment(2);

                //Submit EEO
                _hrSelfIdentificationAction.ResetFunctionality_EEO(ethnicity, race, veteranStatus, protectedVeteranType, disabilityStatus);
                LogInfo("====================Test Method Execution has Completed=================");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }
        #endregion

        #region HR ESPP
        [TestMethod]
        [TestCategory("HRTest")]
        [TestCategory("HRESPP")]
        [Description("ESPP Inbox not present for Non US users;;")]
        [Owner("vineeth.pamuexternal@westpharma.com")]
        public void TC_421053_ESSPNotPresent_NonUSAUsers()
        {
            try
            {

                string testUser = this.TestContext.Properties["HR_GermanyOrigin"].ToString();
                string testUserPassword = TestContext.Properties["HRPassword"].ToString();

                LogInfo("====================Test Method Execution has started=================");
                //LogoutWD application
                LogoutWD();
                // Launching the App Instance
                LaunchApp();

                // Login with the test user account of that specific country
                LoginToWD(testUser, testUserPassword);

                NavigateToInboxByGlobalSearch("Human Resources", "Personal Profile");
                WaitForMoment(2);
                _inboxAction.SelectFirstInboxRecord();
                WaitForMoment(2);
                _childInboxAction.ClickOnChildInboxeItem("Personal Profile", "Address");
                bool flag = _hrEsppAction.verifyInboxIsPresent("ESPP");
                WaitForMoment(2);

                LogInfo("ESPP Inbox Option Present: " + flag);
                Assert.IsFalse(flag, "ESPP Inbox is present for Non USA User");
                WaitForMoment(2);

                screenshotFileName = string.Empty;
                LogInfo("====================Test Method Execution has Completed=================");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        [TestCategory("HRTest")]
        [TestCategory("HRESPP")]
        [Description("Minimum amount for ESPP is ten;;")]
        [Owner("vineeth.pamuexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"HR_EnrollESPP10Dollars_427187.csv", "HR_EnrollESPP10Dollars_427187#csv", DataAccessMethod.Sequential)]
        public void TC_427187_ESPPMinimumAmountValidation()
        {
            try
            {
                string esppElection = this.TestContext.DataRow["esppElection"].ToString();
                string editExpectedMessage = this.TestContext.DataRow["editExpectedMessage"].ToString();
                string contributionType = this.TestContext.DataRow["contributionType"].ToString();
                string amountPerPayCheck = this.TestContext.DataRow["amountPerPayCheck"].ToString();
                string expectedMessage = this.TestContext.DataRow["expectedMessage"].ToString();
                string testUser = this.TestContext.Properties["HR_USOrigin"].ToString();
                string testUserPassword = TestContext.Properties["HRPassword"].ToString();

                LogInfo("====================Test Method Execution has started=================");

                LogInfo($"ESPP Election: {esppElection}, Contribution Type: {contributionType}, Amount Per Paycheck: {amountPerPayCheck}, " +
                    $"Edit Expected Message: {editExpectedMessage}, Success Message: {expectedMessage}");
                //LogoutWD application
                LogoutWD();
                // Launching the App Instance
                LaunchApp();

                // Login with the test user account of that specific country
                LoginToWD(testUser, testUserPassword);

                NavigateToInboxByGlobalSearch("Human Resources", "Personal Profile");
                WaitForMoment(2);
                _inboxAction.SelectFirstInboxRecord();
                WaitForMoment(2);
                _childInboxAction.ClickOnChildInboxeItem("Personal Profile", "ESPP");
                WaitForMoment(2);
                _childInboxAction.ClickOnFirstChildInboxeItem("Personal Profile", "ESPP");
                WaitForMoment(2);
                bool alreadyEnrolled = _hrEsppAction.verifyESPPEnrolledAndClickEdit(true);
                if (alreadyEnrolled.Equals(true))
                {
                    _hrEsppAction.EditESPP(esppElection, amountPerPayCheck, editExpectedMessage);
                }
                _hrEsppAction.clickOnEnroll();
                _hrEsppAction.EnrollESPP(contributionType, "9", "Deduction amount must be at least $10 per pay period");
                _hrEsppAction.EnrollESPP(contributionType, amountPerPayCheck, expectedMessage);
                screenshotFileName = string.Empty;
                LogInfo("====================Test Method Execution has Completed=================");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        [TestCategory("HRTest")]
        [TestCategory("HRESPP")]
        [Description("Edit ESPP with Withdraw and refund Current Payroll Deduction;;")]
        [Owner("vineeth.pamuexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"HR_EnrollESPP10Dollars_427187.csv", "HR_EnrollESPP10Dollars_427187#csv", DataAccessMethod.Sequential)]
        public void TC_421013_EditESPP_WithdrawAndRefund()
        {
            try
            {
                string esppElection = this.TestContext.DataRow["esppElection"].ToString();
                string editExpectedMessage = this.TestContext.DataRow["editExpectedMessage"].ToString();
                string contributionType = this.TestContext.DataRow["contributionType"].ToString();
                string amountPerPayCheck = this.TestContext.DataRow["amountPerPayCheck"].ToString();
                string expectedMessage = this.TestContext.DataRow["expectedMessage"].ToString();
                string testUser = this.TestContext.Properties["HR_USOrigin"].ToString();
                string testUserPassword = TestContext.Properties["HRPassword"].ToString();

                LogInfo("====================Test Method Execution has started=================");

                LogInfo($"ESPP Election: {esppElection}, Contribution Type: {contributionType}, Amount Per Paycheck: {amountPerPayCheck}, " +
                    $"Edit Expected Message: {editExpectedMessage}, Success Message: {expectedMessage}");
                //LogoutWD application
                LogoutWD();
                // Launching the App Instance
                LaunchApp();

                // Login with the test user account of that specific country
                LoginToWD(testUser, testUserPassword);

                NavigateToInboxByGlobalSearch("Human Resources", "Personal Profile");
                WaitForMoment(2);
                _inboxAction.SelectFirstInboxRecord();
                WaitForMoment(2);
                _childInboxAction.ClickOnChildInboxeItem("Personal Profile", "ESPP");
                WaitForMoment(2);
                _childInboxAction.ClickOnFirstChildInboxeItem("Personal Profile", "ESPP");
                WaitForMoment(2);
                bool alreadyEnrolled = _hrEsppAction.verifyESPPEnrolledAndClickEdit(true);
                if (alreadyEnrolled.Equals(true))
                {
                    _hrEsppAction.EditESPP(esppElection, amountPerPayCheck, editExpectedMessage);
                }
                else
                {
                    _hrEsppAction.clickOnEnroll();
                    WaitForMoment(2);
                    _hrEsppAction.EnrollESPP(contributionType, amountPerPayCheck, expectedMessage);
                    WaitForMoment(2);
                    _hrEsppAction.verifyESPPEnrolledAndClickEdit(true);
                    WaitForMoment(2);
                    _hrEsppAction.EditESPP(esppElection, amountPerPayCheck, editExpectedMessage);
                }
                WaitForMoment(2);
                alreadyEnrolled = _hrEsppAction.verifyESPPEnrolledAndClickEdit(true);
                Assert.IsFalse(alreadyEnrolled);
                WaitForMoment(2);
                _hrEsppAction.clickOnEnroll();
                WaitForMoment(2);
                _hrEsppAction.EnrollESPP(contributionType, amountPerPayCheck, expectedMessage);
                screenshotFileName = string.Empty;
                LogInfo("====================Test Method Execution has Completed=================");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        [TestCategory("HRTest")]
        [TestCategory("HRESPP")]
        [Description("Edit ESPP Change Deduction Amount;;")]
        [Owner("vineeth.pamuexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"HR_ESPP_ChangeDeduction_417746.csv", "HR_ESPP_ChangeDeduction_417746#csv", DataAccessMethod.Sequential)]
        public void TC_417746_EditESPP_ChangeDeductionAmount()
        {
            try
            {
                string esppElection = this.TestContext.DataRow["esppElection"].ToString();
                string contributionType = this.TestContext.DataRow["contributionType"].ToString();
                string amountPerPayCheck = _helper.GenerateRandomDigits(3);
                string expectedMessageContext = this.TestContext.DataRow["expectedMessage"].ToString();
                string expectedMessage = expectedMessageContext.Replace("{amount}", amountPerPayCheck);
                string enrolledMessage = this.TestContext.DataRow["enrollMessage"].ToString();
                string testUser = this.TestContext.Properties["HR_USOrigin"].ToString();
                string testUserPassword = TestContext.Properties["HRPassword"].ToString();

                LogInfo("====================Test Method Execution has started=================");

                LogInfo($"ESPP Election: {esppElection}, Contribution Type: {contributionType}, Amount Per Paycheck: {amountPerPayCheck}, " +
                    $"Success Message: {expectedMessage}, Enrolled Message: {enrolledMessage}");
                //LogoutWD application
                LogoutWD();
                // Launching the App Instance
                LaunchApp();

                // Login with the test user account of that specific country
                LoginToWD(testUser, testUserPassword);

                NavigateToInboxByGlobalSearch("Human Resources", "Personal Profile");
                WaitForMoment(2);
                _inboxAction.SelectFirstInboxRecord();
                WaitForMoment(2);
                _childInboxAction.ClickOnChildInboxeItem("Personal Profile", "ESPP");
                WaitForMoment(2);
                _childInboxAction.ClickOnFirstChildInboxeItem("Personal Profile", "ESPP");
                WaitForMoment(2);
                bool alreadyEnrolled = _hrEsppAction.verifyESPPEnrolledAndClickEdit(true);
                if (alreadyEnrolled.Equals(true))
                {
                    _hrEsppAction.EditESPP(esppElection, amountPerPayCheck, expectedMessage);
                }
                else
                {
                    _hrEsppAction.clickOnEnroll();
                    WaitForMoment(2);
                    _hrEsppAction.EnrollESPP(contributionType, amountPerPayCheck, enrolledMessage);
                    WaitForMoment(2);
                    _hrEsppAction.verifyESPPEnrolledAndClickEdit(true);
                    WaitForMoment(2);
                    amountPerPayCheck = _helper.GenerateRandomDigits(3);
                    string expectedMessageEdit = expectedMessageContext.Replace("{amount}", amountPerPayCheck);
                    _hrEsppAction.EditESPP(esppElection, amountPerPayCheck, expectedMessageEdit);
                }
               
                screenshotFileName = string.Empty;
                LogInfo("====================Test Method Execution has Completed=================");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        [TestCategory("HRTest")]
        [TestCategory("HRESPP")]
        [Description("Edit ESPP with Discontinue Current Payroll Deductions No Refund;;")]
        [Owner("vineeth.pamuexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"HR_ESPP_Discontinue_421013.csv", "HR_ESPP_Discontinue_421013#csv", DataAccessMethod.Sequential)]
        public void TC_421030_EditESPP_Discontinue()
        {
            try
            {
                string esppElection = this.TestContext.DataRow["esppElection"].ToString();
                string editExpectedMessage = this.TestContext.DataRow["expectedMessage"].ToString();
                string contributionType = this.TestContext.DataRow["contributionType"].ToString();
                string amountPerPayCheck = _helper.GenerateRandomDigits(3);
                string enrollMessage = this.TestContext.DataRow["enrollMessage"].ToString();
                string testUser = this.TestContext.Properties["HR_USOrigin"].ToString();
                string testUserPassword = TestContext.Properties["HRPassword"].ToString();

                LogInfo("====================Test Method Execution has started=================");

                LogInfo($"ESPP Election: {esppElection}, Contribution Type: {contributionType}, Amount Per Paycheck: {amountPerPayCheck}, " +
                    $"Edit Expected Message: {editExpectedMessage}, Success Enroll Message: {enrollMessage}");
                //LogoutWD application
                LogoutWD();
                // Launching the App Instance
                LaunchApp();

                // Login with the test user account of that specific country
                LoginToWD(testUser, testUserPassword);

                NavigateToInboxByGlobalSearch("Human Resources", "Personal Profile");
                WaitForMoment(2);
                _inboxAction.SelectFirstInboxRecord();
                WaitForMoment(2);
                _childInboxAction.ClickOnChildInboxeItem("Personal Profile", "ESPP");
                WaitForMoment(2);
                _childInboxAction.ClickOnFirstChildInboxeItem("Personal Profile", "ESPP");
                WaitForMoment(2);
                bool alreadyEnrolled = _hrEsppAction.verifyESPPEnrolledAndClickEdit(true);
                if (alreadyEnrolled.Equals(true))
                {
                    _hrEsppAction.EditESPP(esppElection, amountPerPayCheck, editExpectedMessage);
                }
                else
                {
                    _hrEsppAction.clickOnEnroll();
                    WaitForMoment(2);
                    _hrEsppAction.EnrollESPP(contributionType, amountPerPayCheck, enrollMessage);
                    WaitForMoment(2);
                    _hrEsppAction.verifyESPPEnrolledAndClickEdit(true);
                    WaitForMoment(2);
                    _hrEsppAction.EditESPP(esppElection, amountPerPayCheck, editExpectedMessage);
                }
                alreadyEnrolled = _hrEsppAction.verifyESPPEnrolledAndClickEdit(true);
                Assert.IsFalse(alreadyEnrolled);
                WaitForMoment(2);
                _hrEsppAction.clickOnEnroll();
                WaitForMoment(2);
                _hrEsppAction.EnrollESPP(contributionType, amountPerPayCheck, enrollMessage);
                screenshotFileName = string.Empty;
                LogInfo("====================Test Method Execution has Completed=================");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        [TestCategory("HRTest")]
        [TestCategory("HRESPP")]
        [Description("Create ESPP Value Amount;;")]
        [Owner("vineeth.pamuexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"HR_EnrollESPPValue_417703.csv", "HR_EnrollESPPValue_417703#csv", DataAccessMethod.Sequential)]
        public void TC_417703_CreateESPP_ValueAmount()
        {
            try
            {
                string esppElection = this.TestContext.DataRow["esppElection"].ToString();
                string editExpectedMessage = this.TestContext.DataRow["editExpectedMessage"].ToString();
                string contributionType = this.TestContext.DataRow["contributionType"].ToString();
                string amountPerPayCheck = _helper.GenerateRandomDigits(3);
                string enrollMessage = this.TestContext.DataRow["expectedMessage"].ToString();
                enrollMessage = enrollMessage.Replace("{amount}", amountPerPayCheck);
                string testUser = this.TestContext.Properties["HR_USOrigin"].ToString();
                string testUserPassword = TestContext.Properties["HRPassword"].ToString();

                LogInfo("====================Test Method Execution has started=================");

                LogInfo($"ESPP Election: {esppElection}, Contribution Type: {contributionType}, Amount Per Paycheck: {amountPerPayCheck}, " +
                    $"Edit Expected Message: {editExpectedMessage}, Success Enroll Message: {enrollMessage}");
                //LogoutWD application
                LogoutWD();
                // Launching the App Instance
                LaunchApp();

                // Login with the test user account of that specific country
                LoginToWD(testUser, testUserPassword);

                NavigateToInboxByGlobalSearch("Human Resources", "Personal Profile");
                WaitForMoment(2);
                _inboxAction.SelectFirstInboxRecord();
                WaitForMoment(2);
                _childInboxAction.ClickOnChildInboxeItem("Personal Profile", "ESPP");
                WaitForMoment(2);
                _childInboxAction.ClickOnFirstChildInboxeItem("Personal Profile", "ESPP");
                WaitForMoment(2);
                bool alreadyEnrolled = _hrEsppAction.verifyESPPEnrolledAndClickEdit(true);
                if (alreadyEnrolled.Equals(true))
                {
                    _hrEsppAction.EditESPP(esppElection, amountPerPayCheck, editExpectedMessage);
                    WaitForMoment(2);
                    _hrEsppAction.clickOnEnroll();
                    WaitForMoment(2);
                    _hrEsppAction.EnrollESPP(contributionType, amountPerPayCheck, enrollMessage, true);
                    WaitForMoment(2);
                }
                else
                {
                    _hrEsppAction.clickOnEnroll();
                    WaitForMoment(2);
                    _hrEsppAction.EnrollESPP(contributionType, amountPerPayCheck, enrollMessage, true);
                    WaitForMoment(2);
                }
                alreadyEnrolled = _hrEsppAction.verifyESPPEnrolledAndClickEdit(true);
                Assert.IsTrue(alreadyEnrolled);
                screenshotFileName = string.Empty;
                LogInfo("====================Test Method Execution has Completed=================");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        [TestCategory("HRTest")]
        [TestCategory("HRESPP")]
        [Description("Create ESPP Percentage;;")]
        [Owner("vineeth.pamuexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"HR_EnrollESPPPercentage_417717.csv", "HR_EnrollESPPPercentage_417717#csv", DataAccessMethod.Sequential)]
        public void TC_417717_CreateESPP_Percentage()
        {
            try
            {
                string esppElection = this.TestContext.DataRow["esppElection"].ToString();
                string editExpectedMessage = this.TestContext.DataRow["editExpectedMessage"].ToString();
                string contributionType = this.TestContext.DataRow["contributionType"].ToString();
                string amountPerPayCheck = _helper.GenerateRandomDigits(3);
                string enrollMessage = this.TestContext.DataRow["expectedMessage"].ToString();
                enrollMessage = enrollMessage.Replace("{amount}", amountPerPayCheck);
                string testUser = this.TestContext.Properties["HR_USOrigin"].ToString();
                string testUserPassword = TestContext.Properties["HRPassword"].ToString();

                LogInfo("====================Test Method Execution has started=================");

                LogInfo($"ESPP Election: {esppElection}, Contribution Type: {contributionType}, Amount Per Paycheck: {amountPerPayCheck}, " +
                    $"Edit Expected Message: {editExpectedMessage}, Success Enroll Message: {enrollMessage}");
                //LogoutWD application
                LogoutWD();
                // Launching the App Instance
                LaunchApp();

                // Login with the test user account of that specific country
                LoginToWD(testUser, testUserPassword);

                NavigateToInboxByGlobalSearch("Human Resources", "Personal Profile");
                WaitForMoment(2);
                _inboxAction.SelectFirstInboxRecord();
                WaitForMoment(2);
                _childInboxAction.ClickOnChildInboxeItem("Personal Profile", "ESPP");
                WaitForMoment(2);
                _childInboxAction.ClickOnFirstChildInboxeItem("Personal Profile", "ESPP");
                WaitForMoment(2);
                bool alreadyEnrolled = _hrEsppAction.verifyESPPEnrolledAndClickEdit(true);
                if (alreadyEnrolled.Equals(true))
                {
                    _hrEsppAction.EditESPP(esppElection, amountPerPayCheck, editExpectedMessage);
                    WaitForMoment(2);
                    _hrEsppAction.clickOnEnroll();
                    WaitForMoment(2);
                    _hrEsppAction.EnrollESPP(contributionType, amountPerPayCheck, enrollMessage);
                    WaitForMoment(2);
                }
                else
                {
                    _hrEsppAction.clickOnEnroll();
                    WaitForMoment(2);
                    _hrEsppAction.EnrollESPP(contributionType, amountPerPayCheck, enrollMessage);
                    WaitForMoment(2);
                }
                alreadyEnrolled = _hrEsppAction.verifyESPPEnrolledAndClickEdit(true);
                Assert.IsTrue(alreadyEnrolled);
                screenshotFileName = string.Empty;
                LogInfo("====================Test Method Execution has Completed=================");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }
        #endregion
    }
}
