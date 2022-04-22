using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using West.EnterpriseUX.Automation.UWP.PageObjects;

namespace West.EnterpriseUX.Automation.UWP.PageActions
{
    public class HRBankAction : BaseAction
    {
        private readonly WindowsDriver<WindowsElement> _session;
        private readonly HRBankPage _pageInstance;

        public HRBankAction(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
            _pageInstance = new HRBankPage(_session);
        }
        public void SelectBankType(string bankType)
        {
            _pageInstance.BankTypeCombobox.Click();
            WaitForMoment(0.3);
            _pageInstance.SelectBankType(bankType).Click();
        }
        public void EnterPayeeName(string payeeName)
        {
            _pageInstance.PayeeNameEdit.Clear();
            _pageInstance.PayeeNameEdit.SendKeys(payeeName);
            WaitForMoment(0.3);
        }
        public void EnterBankAccountNumber(string accountNumber)
        {
            _pageInstance.BankAccountEdit.Clear();
            _pageInstance.BankAccountEdit.SendKeys(accountNumber);
            WaitForMoment(0.3);
        }

        public void SelectBankKey()
        {
            List<string> availableBankKeys = new List<string>();
            WaitForMoment(1);
            _pageInstance.BankKeyCombobox.Click();
            WaitForMoment(0.3);
            IList<WindowsElement> bankKeys = _pageInstance.BankKeys;

            foreach (WindowsElement bankKey in bankKeys)
            {
                bool isDisplayed = bankKey.Displayed;
                if (isDisplayed)
                {
                    availableBankKeys.Add(bankKey.Text);
                }
            }
            _pageInstance.SelectBankKey(availableBankKeys[1]).Click();
        }
        public void EnterAmountValue(string amount)
        {
            _pageInstance.BankAmountEdit.Click();
            _pageInstance.BankAmountEdit.Clear();
            _pageInstance.BankAmountEdit.SendKeys(amount);
            WaitForMoment(0.3);
        }
        public void GenerateAccountNumberBankKeyUsingIBAN(string iBAN)
        {
            _pageInstance.IBANEdit.Clear();
            _pageInstance.IBANEdit.SendKeys(iBAN);
            WaitForMoment(0.3);
            _pageInstance.IBANGeneratorImage.Click();
        }
        public void ClickOnSave()
        {
            _pageInstance.SaveButton.Click();
            WaitForMoment(0.3);
        }
        public void ClickOnOk()
        {
            _pageInstance.AcknowledgementOkButton.Click();
            WaitForMoment(0.3);
        }
        public void VerifyBankField(string fieldValue)
        {
            WindowsElement bankField = _pageInstance.SearchingText(fieldValue);
            Assert.AreEqual(fieldValue, bankField.Text, $"Field Value {bankField.Text} is not as expected value {fieldValue}");
        }
        public void VerifyIBANGenerationFunctionlaity()
        {
            string bankAccountNumber = _pageInstance.BankAccountEdit.Text;
            string bankKey = _pageInstance.BankKeyCombobox.Text;
            Assert.IsFalse(string.IsNullOrEmpty(bankAccountNumber), $"Bank Account number did not generated from the IBAN/Account Field is Empty before saving");
            Assert.IsFalse(string.IsNullOrEmpty(bankKey), $"Bank Key did not generated from the IBAN/Key Field is Empty before saving");
        }
        public string GetBankType(int bankTypeNo)
        {
            string bankType = string.Empty;
            switch (bankTypeNo)
            {
                case 1:
                    bankType = "Main Bank";
                    break;
                case 2:
                    bankType = "Travel Expenses";
                    break;
                case 3:
                    bankType = "Other Bank";
                    break;
                default:
                    break;
            }
            return bankType;
        }

        public void CreateBankDetails(string payeeName, string iBANNumber, string bankAccountNumber, string amount, string country)
        {
            Random random = new Random();
            string bankType = GetBankType(random.Next(1, 3));

            EnterPayeeName(payeeName);

            if (iBANNumber.ToLower().Contains("na"))
            {
                if (bankType.ToLower().Contains("other bank"))
                {
                    EnterBankAccountNumber(bankAccountNumber);
                    SelectBankKey();
                    EnterAmountValue(amount);
                }
                else
                {
                    EnterBankAccountNumber(bankAccountNumber);
                    SelectBankKey();
                }
            }
            else
            {
                if (bankType.ToLower().Contains("other bank"))
                {
                    GenerateAccountNumberBankKeyUsingIBAN(iBANNumber);
                    EnterAmountValue(amount);
                }
                else
                {
                    GenerateAccountNumberBankKeyUsingIBAN(iBANNumber);
                }
            }
            VerifyIBANGenerationFunctionlaity();

            ClickOnSave();
            WaitForMoment(2);
            TakeScreenshot("CreateBankDetails_" + country);
            ClickOnOk();
            WaitForMoment(5);
        }
        public void NavigateToUpdateBankDetailsPage(string country)
        {
            IList<WindowsElement> personalAddress = _pageInstance.UpdateImage;
            if (personalAddress.Count > 0)
            {
                _pageInstance.UpdateImage[0].Click();
                WaitForMoment(1);
                _pageInstance.UpdateButton.Click();
                WaitForMoment(1);
                WaitForLoadingToDisappear();
            }
            else
            {
                LogInfo($"Bank Details not present to update for this country: {country} ");
                Assert.Fail($"Bank Details not present to update for this country: {country} ");
            }
        }
        public void UpdateBankDetails(string payeeName, string bankAccountNumber, string country)
        {
            EnterPayeeName(payeeName);
            WaitForMoment(1);
            EnterBankAccountNumber(bankAccountNumber);
            WaitForMoment(1);
            ClickOnSave(); 
            WaitForMoment(1);
            TakeScreenshot("UpdateBankDetails_" + country);
            ClickOnOk();
        }
        public void FilterDataBySearch(string value)
        {
            EnterSearchValue(value);
            WaitForMoment(1);
            ClickOnSearchButton();
            WaitForLoadingToDisappear();
        }
        public void EnterSearchValue(string value)
        {
            _pageInstance.SearchEditInGrid.Clear();
            _pageInstance.SearchEditInGrid.SendKeys(value);
        }
        public void ClickOnSearchButton()
        {
            _pageInstance.SearchButtonInGrid.Click();
            WaitForLoadingToDisappear();
        }
        public void VerifyPersonalAddressField(string fieldValue)
        {
            WindowsElement addressField = _pageInstance.SearchingText(fieldValue);
            Assert.AreEqual(fieldValue, addressField.Text, $"Field Value {addressField.Text} is not as expected value {fieldValue}");
        }
        public void ClickOnReset()
        {
            _pageInstance.ResetButton.Click();
            WaitForMoment(0.3);
        }

        public void SelectRoutingNumber()
        {
            _pageInstance.RoutingNumberImage.Click();
            WaitForMoment(3);
            _pageInstance.SelectBankKeyValue.Click();
        }

        public void EnterConfirmBankAccountNumber(string accountNumber)
        {
            _pageInstance.ConfirmBankAccountEdit.Clear();
            _pageInstance.ConfirmBankAccountEdit.SendKeys(accountNumber);
            WaitForMoment(0.3);
        }

        public void ValidatePopUpMessage(string expectedMessage)
        {
            WaitForElementToAppear(expectedMessage);
            Assert.IsTrue(_pageInstance.PopUpDialogMessage.Displayed);
            string popUpMessage = _pageInstance.PopUpDialogMessage.Text;
            Assert.AreEqual(expectedMessage, popUpMessage);
        }

        public void SelectBankAction(string BankType)
        {
            WaitForLoadingToDisappear();
            WaitForMoment(2);
            IList<WindowsElement> bankTypes= _pageInstance.BankMoreActionButton(BankType);
            bankTypes[0].Click();
        }

        public void SelectEndNow()
        {
            IList<WindowsElement> EndNowElementsList = _pageInstance.BankEndNowAction;
            foreach (WindowsElement EndNowElement in EndNowElementsList)
            {
                bool isDisplayed = EndNowElement.Displayed;
                if (isDisplayed)
                {
                    EndNowElement.Click();
                    break;
                }
            }
        }

        public void VerifyBankDetailsResetFunctionality(string payeeName, string iBANNumber, string bankAccountNumber, string amount, string country, string bankCountrolKey, string bank)
        {
            Random random = new Random();
            string bankType = bank;
            SelectBankType(bankType);

            EnterPayeeName(payeeName);

            if (bankType.ToLower().Contains("other bank"))
            {
                EnterBankAccountNumber(bankAccountNumber);
                EnterConfirmBankAccountNumber(bankAccountNumber);
                EnterAmountValue(amount);
                SelectRoutingNumber();
                SelectBankControlKey(bankCountrolKey);
                string bankCountry = _pageInstance.BankCountryEdit.Text;
                LogInfo("bank Country: " + bankCountry);
                if(bankCountry.Equals("Germany"))
                    GenerateAccountNumberBankKeyUsingIBAN(iBANNumber);

            }
            else
            {
                EnterBankAccountNumber(bankAccountNumber);
                EnterConfirmBankAccountNumber(bankAccountNumber);
                SelectRoutingNumber();
                SelectBankControlKey(bankCountrolKey);
                string bankCountry = _pageInstance.BankCountryEdit.Text;
                LogInfo("bank Country: " + bankCountry);
                if (bankCountry.Equals("Germany"))
                    GenerateAccountNumberBankKeyUsingIBAN(iBANNumber);
            }

            ClickOnReset();
            WaitForMoment(1);

            ValidatePopUpMessage("Are you sure you want to reset the details?");

            ClickCancelButton();
            WaitForMoment(1);
            Assert.IsNotNull(_pageInstance.BankAccountEdit.Text);
            ClickOnReset();
            WaitForMoment(1);
            ClickOkButton();
            WaitForMoment(1);
            string AccountNumber = _pageInstance.BankAccountEdit.GetAttribute("Value.Value");
            Assert.IsNull(AccountNumber);
            TakeScreenshot("ResetBankFuncitonality");
        }

        public void ClickOkButton()
        {
            _pageInstance.OkButton.Click();
            WaitForMoment(0.3);
        }
        public void ClickCancelButton()
        {
            _pageInstance.CancelButton.Click();
            WaitForMoment(0.3);
        }

        public void SelectBankControlKey(string bankControlKey)
        {
            _pageInstance.BankControlKeyCombobox.Click();
            WaitForMoment(0.3);
            _pageInstance.SelectBankType(bankControlKey).Click();
        }

        public void SelectBankAccountMenuOption()
        {
            WaitForLoadingToDisappear();
            WaitForMoment(1);
            _pageInstance.BankAccount.Click();
        }

        /// <summary>
        /// Create Bank will create bank with given parameters
        /// </summary>
        /// <param name="bankType"> Type of Bank. Accepts - Main Bank / Others </param>
        /// <param name="bankCountry"> Bank Country </param>
        /// <param name="bankAccountNumber"> </param>
        /// <param name="bankControlKey"> Type of Bank. Accepts - Main Bank / Others </param>
        /// <param name="CreateMessage">Bank created confirmation pop up message </param>
        /// <param name="iBANNumber"> </param>
        /// <param name="shareAmount"> Share Amount for Other Bank </param>
        /// <param name="sharePercentage">Share Percentage for Other Bank </param>
        public void CreateBank(string bankType, string bankCountry, string payeeName, string bankAccountNumber, string confirmBankAccountNumber, string bankControlKey, string CreateMessage, string iBANNumber, string shareAmount, string sharePercentage)
        {
            WaitForLoadingToDisappear();
            string country = _pageInstance.BankCountryEdit.Text;
            Assert.AreEqual(bankCountry, country, true, "Bank Country value is not as expected");
            if(country.Equals("USA"))
            {
                SelectBankType(bankType);
                SelectTomorrowStartDate();
                EnterPayeeName(payeeName);
                EnterBankAccountNumber(bankAccountNumber);
                if (!confirmBankAccountNumber.Equals(""))
                {
                    EnterConfirmBankAccountNumber(confirmBankAccountNumber);
                }
                SelectRoutingNumber();
                SelectBankControlKey(bankControlKey);
                if (bankType.Equals(GetBankType(3)))
                    EnterAmountValue(shareAmount);
            }
            else if (country.Equals("India"))
            {
                EnterPayeeName(payeeName);
                EnterBankAccountNumber(bankAccountNumber);
                SelectIFSCCode();
            }
            else if (country.Equals("Germany"))
            {
                EnterPayeeName(payeeName);
                GenerateAccountNumberBankKeyUsingIBAN(iBANNumber);
                VerifyIBANGenerationFunctionlaity();
            }

            if (bankType.Equals(GetBankType(1)))
            {
                ClickOnSave();
            }
            else if(bankType.Equals(GetBankType(3)))
            {
                ClickOnSave();
                string actualPopUpMessage = _pageInstance.PopUpDialogMessage.Text;
                string shareErrorAlert = "Please provide share amount instead of share percentage. Your other bank(s) already have a share amount";

                if (shareErrorAlert.Equals(actualPopUpMessage))
                {
                    ClickOkButton();
                    WaitForMoment(2);
                    EnterAmountValue(shareAmount);
                    ClickOnSave();
                }
                else if((!CreateMessage.Equals(actualPopUpMessage))&&(!CreateMessage.Equals(shareErrorAlert)))
                {
                    ClickOkButton();
                    WaitForMoment(2);
                    EnterSharePercentage(sharePercentage);
                    ClickOnSave();
                }
                
            }
                WaitForMoment(2);
            TakeScreenshot("CreateBankDetails_" + country);
            ValidatePopUpMessage(CreateMessage);
            ClickOkButton();
            WaitForMoment(5);
        }

        public void EnterSharePercentage(string percentage)
        {
            _pageInstance.BankSharePercentage.Clear();
            _pageInstance.BankSharePercentage.SendKeys(percentage);
            WaitForMoment(0.3);
        }

        public void SelectIFSCCode()
        {
            _pageInstance.IFSCImage.Click();
            WaitForMoment(3);
            _pageInstance.SelectBankKeyValue.Click();
        }

        public void ValidateDisplayedBankFields(string Country)
        {
            if (Country.Equals("Germany"))
            {
                //Verify BankType field is present and is disabled
                bool bankTypeBool = _pageInstance.BankTypeCombobox.Enabled;
                Assert.IsFalse(bankTypeBool);
                
                //Verify Bank Country field is present and is disabled
                string countryActul = _pageInstance.BankCountryEdit.Text;
                Assert.AreEqual(Country, countryActul, true, "Bank Country value is not as expected");
                Assert.IsFalse(_pageInstance.BankCountryEdit.Enabled);

                //Verfiy Payee field is present and enabled
                Assert.IsTrue(_pageInstance.PayeeNameEdit.Enabled);

                //Verify BankAccount field is present and enabled
                Assert.IsTrue(_pageInstance.BankAccountEdit.Enabled);

                //Verify IBAN Generator field is present and enabled
                Assert.IsTrue(_pageInstance.IBANGeneratorImage.Enabled);

            }
        }

        public void SelectTomorrowStartDate()
        {
            WaitForLoadingToDisappear();
            _pageInstance.calendarDatePicker.Click();
            IList<WindowsElement> dateItems = _pageInstance.CalendarPopUpDateItems;
            if(dateItems.Count>1)
            dateItems[1].Click();
        }
        
        
        /// <summary>
        /// Update Bank Details Based on Country
        /// </summary>
        /// <param name="bankType"></param>
        /// <param name="bankCountry"></param>
        /// <param name="payeeName"></param>
        /// <param name="bankAccountNumber"></param>
        /// <param name="confirmBankAccountNumber"></param>
        /// <param name="bankControlKey"></param>
        /// <param name="updateMessage"></param>
        /// <param name="iBANNumber"></param>
        /// <param name="shareAmount"></param>
        /// <param name="sharePercentage"></param>
        public void UpdateBankDetailsCountryBased(string bankType, string bankCountry, string payeeName, string bankAccountNumber, string confirmBankAccountNumber, string bankControlKey, string updateMessage, string iBANNumber, string shareAmount, string sharePercentage)
        {
            WaitForLoadingToDisappear();
            string country = _pageInstance.BankCountryEdit.Text;
            Assert.AreEqual(bankCountry, country, true, "Bank Country value is not as expected");
            if (country.Equals("USA"))
            {
                if(!string.IsNullOrEmpty(shareAmount))
                {
                    EnterAmountValue(shareAmount);
                }
                Assert.IsTrue(_pageInstance.calendarDatePicker.Enabled);
                Assert.IsTrue(_pageInstance.BankSharePercentage.Enabled);
            }
            
            if (bankType.Equals(GetBankType(1)))
            {
                ClickOnSave();
            }
            else if (bankType.Equals(GetBankType(3)))
            {
                ClickOnSave();
                string actualPopUpMessage = _pageInstance.PopUpDialogMessage.Text;
                string shareErrorAlert = "Please provide share amount instead of share percentage. Your other bank(s) already have a share amount";

                if (shareErrorAlert.Equals(actualPopUpMessage))
                {
                    ClickOkButton();
                    WaitForMoment(2);
                    EnterAmountValue(shareAmount);
                    ClickOnSave();
                }
                else if ((!updateMessage.Equals(actualPopUpMessage)) && (!updateMessage.Equals(shareErrorAlert)))
                {
                    ClickOkButton();
                    WaitForMoment(2);
                    EnterSharePercentage(sharePercentage);
                    ClickOnSave();
                }

            }
            WaitForMoment(2);
            TakeScreenshot("updateBankDetails" + country);
            ValidatePopUpMessage(updateMessage);
            ClickOkButton();
            WaitForMoment(5);
        }

        public void SelectEditAction()
        {
            IList<WindowsElement> EditElementsList = _pageInstance.BankEditAction;
            foreach (WindowsElement EditElement in EditElementsList)
            {
                bool isDisplayed = EditElement.Displayed;
                if (isDisplayed)
                {
                    EditElement.Click();
                    break;
                }
            }
        }

        public void VerifyDeleteActionPresent(string bankType)
        {
            if (bankType.Equals(GetBankType(1)))
            {
                try
                {
                    bool isDisplayed = _pageInstance.BankDeleteAction.Displayed;
                    Assert.IsFalse(isDisplayed);
                }catch(Exception ex)
                {
                    LogInfo("Exception Message: "+ex.Message);
                    LogInfo("Exception:  " + ex);
                }
            }
               
        }
    }
}
