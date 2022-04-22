using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using West.EnterpriseUX.Automation.UWP.PageObjects;
using System.IO;
using OpenQA.Selenium.Interactions;

namespace West.EnterpriseUX.Automation.UWP.PageActions
{
    public class HRESPPAction : BaseAction
    {
        private readonly WindowsDriver<WindowsElement> _session;
        private readonly HRESPPPage _pageInstance;
        private static Random random = new Random();
        public HRESPPAction(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
            _pageInstance = new HRESPPPage(_session);
        }
        public IList<WindowsElement> GetAllInboxes()
        {
            IList<WindowsElement> inboxList = _pageInstance.InboxList;
            return inboxList;
        }

        public Boolean verifyInboxIsPresent(string inboxName)
        {
            IList<WindowsElement> windowsElements = GetAllInboxes();
            bool temp = false;
            foreach (WindowsElement windowsElement in windowsElements)
            {
                string name = windowsElement.Text;
                LogInfo("Inbox Name : " + name);
                if (name.ToLower().Equals(inboxName.ToLower()))
                {
                    temp = true;
                    break;
                }
            }
            return temp;
        }

        public Boolean verifyESPPEnrolledAndClickEdit(bool clickEdit)
        {
            bool temp = false;
            IList<WindowsElement> windowsElements = _pageInstance.moreImage;
                foreach(WindowsElement windowElement in windowsElements)
                {
                    windowElement.Click();
                    WaitForMoment(0.6);
                    try
                    {
                        if (_pageInstance.editAction.Displayed)
                        {
                            if(clickEdit.Equals(true))
                                _pageInstance.editAction.Click();
                        temp = true;
                        }
                            
                    }catch(Exception ex)
                    {
                        
                        LogInfo("Pick next ESPP Record: "+ex.Message);
                    }
                }
            return temp;
            
        }

        public void EditESPP(string esppElection, string amountPerPayCheck, string expectedMessage)
        {
            WaitForLoadingToDisappear();
            bool fieldPresent = _pageInstance.SelectSearchValueContains("Current Contribution").Displayed;
            fieldPresent = _pageInstance.SelectSearchValueContains("Last Modified Date").Displayed;
            _pageInstance.ESPPElectionImage.Click();
            WaitForMoment(1);
            _pageInstance.SearchInGrid.Click();
            _pageInstance.SearchInGrid.SendKeys(esppElection);
            WaitForMoment(1);
            _pageInstance.SearchButtonInSelectWindow.Click();
            WaitForMoment(1);
            _pageInstance.SelectSearchValue(esppElection).Click();
            WaitForMoment(1);
            if(esppElection.ToLower().Equals("change deduction amount"))
            {
                _pageInstance.EstimatedAmountPerPayCheckEdit.Click();
                _pageInstance.EstimatedAmountPerPayCheckEdit.Clear();
                _pageInstance.EstimatedAmountPerPayCheckEdit.SendKeys(amountPerPayCheck);
               
            }
            IList<WindowsElement> checkBoxList = _pageInstance.checkBoxAuthorize;
            foreach (var checkBox in checkBoxList)
            {
                bool flag = checkBox.Selected;
                if (flag.Equals(false))
                    checkBox.Click();
                WaitForMoment(1);
            }
            _pageInstance.SubmitButton.Click();
            ValidatePopUpMessage("Are you sure you want to submit?");
            ClickOnOk();
            WaitForMoment(5);
            string successMessage = _pageInstance.PopUpDialogMessage.Text;
            if (!successMessage.Contains(expectedMessage))
                Assert.Fail("Submit is unsuccessful and message is not as expected. Actual:  " + successMessage);
            ClickOnOk();
            WaitForLoadingToDisappear();
            WaitForMoment(2);
        }

        public void ValidatePopUpMessage(string expectedMessage)
        {
            WaitForElementToAppear(expectedMessage);
            Assert.IsTrue(_pageInstance.PopUpDialogMessage.Displayed);
            string popUpMessage = _pageInstance.PopUpDialogMessage.Text;
            Assert.AreEqual(expectedMessage, popUpMessage);
        }
        public void ClickOnOk()
        {
            _pageInstance.AcknowledgementOkButton.Click();
            WaitForMoment(0.3);
        }

        public string EnrollESPP(string contributionType, string amountPerPayCheck, string expectedMessage, bool validateFields = false)
        {
            string randomText = RandomString(4);
            if (contributionType.ToLower().Equals("percentage"))
            {
                _pageInstance.percentageSelectedTab.Click();
                WaitForMoment(1);
                validatePercentageSlider();
                selectAuthorizeCheckboxes();
            }
            if (contributionType.ToLower().Equals("value") && (validateFields == true))
            {
                //Validate Amount field is present and does not accept alphanumeric values
                Assert.IsTrue(_pageInstance.EstimatedAmountPerPayCheckEdit.Displayed);
                validateAmountPerPayCheckField(randomText, false);
                validateAmountPerPayCheckField(amountPerPayCheck, true);
            }
            if (contributionType.ToLower().Equals("value"))
            {
                _pageInstance.EstimatedAmountPerPayCheckEdit.Click();
                _pageInstance.EstimatedAmountPerPayCheckEdit.Clear();
                _pageInstance.EstimatedAmountPerPayCheckEdit.SendKeys(amountPerPayCheck);
                selectAuthorizeCheckboxes();
            }
            if ((contributionType.ToLower().Equals("value")) && (validateFields == true))
            {
                _pageInstance.EstimatedAmountPerPayCheckEdit.Clear();
                Assert.IsFalse(_pageInstance.SubmitButton.Enabled);
                validateAmountPerPayCheckField(amountPerPayCheck, true);
            }
            _pageInstance.SubmitButton.Click();
            ValidatePopUpMessage("Are you sure you want to submit?");
            ClickOnOk();
            WaitForMoment(5);
            string successMessage = _pageInstance.PopUpDialogMessage.Text;
            if (!successMessage.Contains(expectedMessage))
                Assert.Fail("Submit is unsuccessful and message is not as expected. Actual:  " + successMessage);
            ClickOnOk();
            return successMessage;
        }

        public void clickOnEnroll()
        {
            WaitForLoadingToDisappear();
            WaitForMoment(1);
            _pageInstance.enrollButton.Click();
            WaitForLoadingToDisappear();
        }


        
        public string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public void validateAmountPerPayCheckField(string amountPerCheck, bool validValue)
        {
            _pageInstance.EstimatedAmountPerPayCheckEdit.Click();
            _pageInstance.EstimatedAmountPerPayCheckEdit.Clear();
            _pageInstance.EstimatedAmountPerPayCheckEdit.SendKeys(amountPerCheck);
            WaitForMoment(1);
            string amountVisible = _pageInstance.EstimatedAmountPerPayCheckEdit.Text;
            if (validValue)
            {
                if (!amountVisible.Contains(amountPerCheck))
                {
                    Assert.Fail("Amount value not as expected");
                }
            }
            else
            {
                if (amountVisible.Contains(amountPerCheck))
                {
                    Assert.Fail("Amount Field accepted alpha numeric values");
                }
            }
            
        }

        public void validatePercentageSlider()
        {
            string selectedSliderText = string.Empty;
            string amount = string.Empty;
            Assert.IsTrue(_pageInstance.percentageSliderThumb.Displayed);
            IList<WindowsElement> sliderValueElements = _pageInstance.percentageSliderText;
           
            foreach(WindowsElement sliderValueElement in sliderValueElements)
            {
                sliderValueElement.Click();
                WaitForMoment(1);
                selectedSliderText = _pageInstance.selectedPercentageText.Text;
                var value = selectedSliderText.Split('$');
                Assert.AreNotEqual(amount, value[1]);
                amount = value[1];
                Assert.IsNotNull(amount);
            }

            LogInfo("slider text: " + selectedSliderText);
            TakeScreenshot("Slider Text");
        }

        public void selectAuthorizeCheckboxes()
        {
            IList<WindowsElement> checkBoxList = _pageInstance.checkBoxAuthorize;
            foreach (var checkBox in checkBoxList)
            {
                bool flag = checkBox.Selected;
                if (flag.Equals(false))
                    checkBox.Click();
                WaitForMoment(1);
            }
        }
    }
}

