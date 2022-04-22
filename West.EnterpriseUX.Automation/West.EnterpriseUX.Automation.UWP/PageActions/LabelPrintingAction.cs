using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using West.EnterpriseUX.Automation.UWP.PageObjects;
using West.EnterpriseUX.Automation.UWP.Utilities;

namespace West.EnterpriseUX.Automation.UWP.PageActions
{
    public class LabelPrintingAction : BaseAction
    {
        private readonly WindowsDriver<WindowsElement> _session;
        private readonly LabelPrintingPage _pageInstance;

        public LabelPrintingAction(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
            _pageInstance = new LabelPrintingPage(_session);
        }
        public void VerifyPageTitle(string pageTitle)
        {
            IList<WindowsElement> pageName = _pageInstance.GetPageTitle;
            Assert.AreEqual(pageTitle, pageName[0].Text, $" Page title: {pageName[0].Text} is not matching the expected title: {pageTitle}");

            if (pageTitle.Equals("Label Printing"))
            {
                WaitForMoment(1);
               IList<WindowsElement> ErrorPopUpOK = _pageInstance.ErrorField("OK");
               ErrorPopUpOK[0].Click();
               WaitForMoment(1);
            }
        }
   
        //Updated UI Code Generic Picker
        public void EnterOrderValueInTextBox(string value, string LabelType)
        {
            IList<WindowsElement> ReasonForVarianceUWP_Container = _pageInstance.ReasonForVarianceUWP_Container();
            ReasonForVarianceUWP_Container[0].Click();
            WaitForMoment(2);

           _pageInstance.SearchTextBox.Clear();
            WaitForMoment(1);
           _pageInstance.SearchTextBox.SendKeys(value);
            WaitForMoment(3);
            IList<WindowsElement> OrgerNumber = _pageInstance.GetColumnText(value);
            OrgerNumber[0].Click();
            WaitForMoment(1);
        }
        public void EnterMaterialValueInTextBox(string value)
        {
            _pageInstance.MaterialField.Clear();
            _pageInstance.MaterialField.SendKeys(value);
        }
        public void EnterPrinterValueInTextBox(string value)
        {
            _pageInstance.PrinterSearchField.Clear();
            _pageInstance.PrinterSearchField.SendKeys(value);
        }
        public void EnterQuantityTextBox(string value)
        {
            _pageInstance.NoOfLabelField.Clear();
            _pageInstance.NoOfLabelField.SendKeys(value);
        }
        public void EnterNoOfLabelInTextBox(string value)
        {
            _pageInstance.NoOfLabelField.Clear();
            _pageInstance.NoOfLabelField.SendKeys(value);
        }
        public void EnterWorkCenterValuelInTextBox(string value)
        {
            _pageInstance.WorkCenterDropdown.Click();
            WaitForMoment(1);
            IList<WindowsElement> inboxesList = _pageInstance.InboxListFromDropdown(value);
            MouseClickOnWindowsElement(inboxesList[0]);
            WaitForMoment(1);
        }
        public void EnterBatchValuelInTextBox(string value)
        {
            _pageInstance.BatchDropdown.Click();
            WaitForMoment(1);
            IList<WindowsElement> inboxesList = _pageInstance.InboxListFromDropdown(value);
            MouseClickOnWindowsElement(inboxesList[0]);
            WaitForMoment(1);
        }
        public void EnterWorkCenterValuelInTextBox(string value, string Action)
        {
            if (Action.Equals("Clear"))
            {
                _pageInstance.WorkCenterInputField.Clear();
                WaitForMoment(1);
            }
            IList<WindowsElement> inboxesList = _pageInstance.InboxListFromDropdown(value);
            MouseClickOnWindowsElement(inboxesList[0]);
            WaitForMoment(1);
        }
        public void EnterPrinterValueFromDropdown(string value)
        {
            _pageInstance.PrinterDropdown.Click();
            WaitForMoment(1);
            IList<WindowsElement> inboxesList = _pageInstance.InboxListFromDropdown(value);
            MouseClickOnWindowsElement(inboxesList[0]);
            WaitForMoment(1);
        }
        public void ClickPrintButton()
        {
            IList<WindowsElement> actionOption = _pageInstance.PrintButton();
            actionOption[0].Click();
        }
        public void VerifyPrintButtonEnableOrDisable(bool Value)
        {
            IList<WindowsElement> actionOption = _pageInstance.PrintButton();
            bool Visibility = actionOption[0].Enabled;
            Assert.AreEqual(Value, Visibility);
        }
        public void ClickPrintPreviewButton()
        {
            IList<WindowsElement> actionOption = _pageInstance.PrintPriewButton();
            actionOption[0].Click();
        }
        public void VerifyPDF()
        {
            IList<WindowsElement> PDF = _pageInstance.NextPageBtn;
            PDF = _pageInstance.PreviousPageBtn;
            PDF = _pageInstance.ZoomInBtn;
            PDF = _pageInstance.ZoomOutBtn;
            Assert.AreEqual(PDF.Count.Equals(4), $"PDF is not displayed");
        }
        public void VerifyPopUpOpen()
        {
            IList<WindowsElement> popUpAction = _pageInstance.PopUp();
            Assert.AreEqual("Label printed Succesfully", popUpAction[0].Text, $"Label print Pop is not Succesfully open");
        }
        public void VerifyErrorPopUp(string Popup,string errorField)
        {
            IList<WindowsElement> popUpAction = _pageInstance.ErrorPopUp();

            if (Popup.Equals("Error"))
            {
                Assert.AreEqual("Error", popUpAction[0].Text, $"Error message pop up is not appear");
            }
          
            if (Popup.Equals("Attention"))
            {
                Assert.AreEqual("Attention", popUpAction[0].Text, $"Attention message pop up is not appear");
            }
            if (Popup.Equals("No Error"))
            {
                Assert.AreNotEqual("Error", popUpAction[0].Text, $"Attention message pop up is appear");
            }

            if (errorField.Equals("Invalid Material"))
            {
                //Invalid Material
                IList<WindowsElement> materialErrorPopUp = _pageInstance.ErrorField(errorField);
                Assert.AreEqual("Invalid Material", materialErrorPopUp[0].Text, $"Invalid Material Error message not appear");
            }
            if (errorField.Equals("Overdelivery is not permitted (Check entry)"))
            {
                //Overdelivery is not permitted (Check entry)
                IList<WindowsElement> materialErrorPopUp = _pageInstance.ErrorField(errorField);
                Assert.AreEqual("Overdelivery is not permitted (Check entry)", materialErrorPopUp[0].Text, $"Error message is not correct");
            }
            if (errorField.Equals("End Date should not be before start date"))
            {
                //End Date should not be before start date
                IList<WindowsElement> materialErrorPopUp = _pageInstance.ErrorField(errorField);
                Assert.AreEqual("End Date should not be before start date", materialErrorPopUp[0].Text, $"Error message is not correct");
            }          
        }
        public void VerifySucceddPopUp(string Popup, string ErrorField,string OrderId)
        {
            IList<WindowsElement> popUpAction = _pageInstance.ErrorPopUp();

            if (Popup.Equals("Success"))
            {
                Assert.AreEqual("Success", popUpAction[0].Text, $"Error message pop up is not appear");
            }

            if (ErrorField.Equals("Final time confirmation"))
            {
                //Final time confirmation successfully
                IList<WindowsElement> message = _pageInstance.ErrorField(ErrorField);
                Assert.AreEqual("Final time confirmation successfully performed on operation 21  of order " + OrderId + "", message[0].Text, $"Message is not correct");
            }
        }
        public void VerifyLabelPrintingOptions(string labelOption, int hierarchy)
        {
            IList<WindowsElement> labelPrintingOptions = _pageInstance.LabelPrintingOptions;
            Assert.AreEqual(labelOption, labelPrintingOptions[hierarchy + 1].Text, $"Select Label option is incorrect");
        }
        public void SelectLabel(string locatorName)
        {
            //Chnage the Logic Flow 
            WaitForMoment(1);
            IList<WindowsElement> ErrorPopUp = _pageInstance.ErrorField("Error");
            var X= ErrorPopUp[0].Text;
            if (X.Equals("Error"))
            {
                IList<WindowsElement> ErrorPopUpOK = _pageInstance.ErrorField("OK");
                ErrorPopUpOK[0].Click();
                WaitForMoment(1);
            }
            IList<WindowsElement> option = _pageInstance.LabelOption(locatorName);
            option[0].Click();
            WaitForMoment(3);
        }
        public void ClckOkPopUP()
        {
            _pageInstance.SuccessPopUpOK.Click();
            WaitForMoment(2);
        }
        public void LabelPrintingGridScroll(string Direction)
        {
            if (Direction.Equals("Up"))
            {
                IList<WindowsElement> option = _pageInstance.ScrollUp();
                option[0].Click();
                WaitForMoment(1);

                option[0].Click();
                WaitForMoment(1);
            }

            if (Direction.Equals("Down"))
            {
                IList<WindowsElement> option = _pageInstance.ScrollDown();
                option[0].Click();
                WaitForMoment(1);

                option[0].Click();
                WaitForMoment(1);

            }
        }
        public void ClickOnDetailsAction()
        {
            IList<WindowsElement> option = _pageInstance.ClickDetails();
            option[2].Click();
            WaitForMoment(2);
        }
        public void VerifyOrderID(string value, string LabelType)
        {
            WaitForMoment(3);

            if (LabelType.Equals("Weighment"))
            {
                IWebElement OrderId = _pageInstance.WeighmentOrderField;
                Assert.AreEqual(OrderId.Text, value);
            }

            if (LabelType.Equals("Process"))
            {
                IList<WindowsElement> Oder = _pageInstance.OrderField;
                Assert.AreEqual(Oder[0].Text, value);
            }
        }
    }
}
