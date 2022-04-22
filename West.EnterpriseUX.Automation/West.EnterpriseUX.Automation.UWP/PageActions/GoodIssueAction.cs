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
    public class GoodIssueAction : BaseAction
    {
        private readonly WindowsDriver<WindowsElement> _session;
        private readonly GoodIssuePage _pageInstance;

        public GoodIssueAction(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
            _pageInstance = new GoodIssuePage(_session);
        }
        public void EnterOrderValueInTextBox(string value)
        {
            //*****UI of the Module has been changed****
            //UI may change the below code is for future refrence
            //_pageInstance.OrderNumberField.Clear();
            //_pageInstance.OrderNumberField.SendKeys(value);
            //WaitForMoment(2);

            IList<WindowsElement> Picker = _pageInstance.OrderNumberPick();
            Picker[4].Click();       
            _pageInstance.SearchTextBox.Clear();
             WaitForMoment(1);
            _pageInstance.SearchTextBox.SendKeys(value);
             WaitForMoment(3);
            IList<WindowsElement> OrgerNumber = _pageInstance.GetColumnText(value);
            OrgerNumber[0].Click();
            WaitForMoment(1);
        } 
        public void RemoveBatch()
        {
            _pageInstance.RemoveBatchUWP.Click();
            WaitForMoment(2);         
        }
        public void ClickMaterialPicker()
        {
            IList<WindowsElement> Picker = _pageInstance.MaterialPick();
            Picker[6].Click();
        }
        public void ClickMaterialID(string Value)
        {
            IList<WindowsElement> columnText = _pageInstance.GetColumnText(Value);
            columnText[0].Click();
        }
        public void EnterValue(string Value)
        {
            IList<WindowsElement> columnText = _pageInstance.TextBox();
            columnText[0].Clear();
            columnText[0].SendKeys(Value);
            WaitForMoment(1);
        }
        public void EnterBatch(string value)
        {
            //IList<WindowsElement> Input = _pageInstance.BatchTextBoxEdit();
            //Input[0].Clear();
            //Input[0].SendKeys(value);
            //WaitForMoment(1);

            ////////////////////////
            IList<WindowsElement> Picker = _pageInstance.OrderNumberPick();
            Picker[4].Click();
            _pageInstance.SearchTextBox.Clear();
            WaitForMoment(1);
            string[] batchId = value.Split(' ');
            _pageInstance.SearchTextBox.SendKeys(batchId[0]);
            WaitForMoment(3);
            IList<WindowsElement> OrgerNumber = _pageInstance.GetColumnText(batchId[0]);
            OrgerNumber[0].Click();
            WaitForMoment(1);

        }
       public void RemoveDeleteMaterial(string Action)
        {
            IList<WindowsElement> Remove = _pageInstance.DeleteMaterialItem();
            for (int i = 0; i < Remove.Count; i++)
            {
                Remove[0].Click();
                WaitForMoment(1);
                IList<WindowsElement> Button = _pageInstance.GetColumnText(Action);
                Button[0].Click();
                WaitForMoment(1);
            }                                     
        }
        public void VerifyAddedComponent(string Value)
        {
            IList<WindowsElement> ValueText = _pageInstance.GetColumnText(Value);
            Assert.AreEqual(Value, ValueText[0].Text, $"Added Componet Detail: {ValueText[0].Text} is not matching the expected component detail: {Value}");
        }
        public void VerifyDocumentDate(string DisplayingDate)
        {
            string CurrentDate = DateTime.Now.ToString("dd");
            string CurrentMonth = DateTime.Now.ToString("MMM");
            string CurrentYear = DateTime.Now.ToString("yyyy");

            WaitForMoment(3);

            IList<WindowsElement> DateText = _pageInstance.GetDate(DisplayingDate);
            bool DefaultDate = DateText[0].Enabled;
            Assert.AreEqual(DefaultDate, true, $"Default date is not displaying");

            string DateTextAppearing = DateText[0].Text;
            Assert.IsTrue(DateTextAppearing.Contains(CurrentDate));
            Assert.IsTrue(DateTextAppearing.Contains(CurrentMonth));
            Assert.IsTrue(DateTextAppearing.Contains(CurrentYear));

            WaitForMoment(3);   

            //Get the test details
            DateTime.Now.ToString("MMMM dd, yyy");
            DateTime today = DateTime.Now;
            DateTime tomorrow = today.AddDays(3);
            DateTime yesterday = today.AddDays(-3);

            string TodayInput =today.Day.ToString();
            string TomorrowInput = tomorrow.Day.ToString();
            string yesterdayInput = yesterday.Day.ToString();

            //Open Calender window
            DateText[0].Click();
            WaitForMoment(2);

            //Todays Date
            IList<WindowsElement> DateInput1 = _pageInstance.InputTextBox(TodayInput);
            MouseClickOnWindowsElement(DateInput1[0]);
            WaitForMoment(1);
            _pageInstance.Post.Click();
            WaitForMoment(1);

            //Open Calender window
            DateText[0].Click();
            WaitForMoment(2);

            //yesterday past Date
            IList<WindowsElement> DateInput2 = _pageInstance.InputTextBox(yesterdayInput);
            MouseClickOnCenterOfWindowsElement(DateInput2[0]);

            //Open Calender window
            DateText[0].Click();
            WaitForMoment(2);

            //Click Next Month
            IList<WindowsElement> Next = _pageInstance.InputTextBox("Next");
            Next[0].Click();
            WaitForMoment(1);
            Next[0].Click();
            WaitForMoment(1);

            //Future Date
            IList<WindowsElement> DateInput3 = _pageInstance.InputTextBox(TomorrowInput);
            DateInput3[0].Click();
            WaitForMoment(2);
        }

        public void VerifPostingDate(string DateType,string PastValidation ,string FutureValidation)
        {
            string CurrentDate = DateTime.Now.ToString("dd");
            string CurrentMonth = DateTime.Now.ToString("MMM");
            string CurrentYear = DateTime.Now.ToString("yyyy");

            WaitForMoment(3);

            IList<WindowsElement> DateText = _pageInstance.GetDate(DateType);
            bool DefaultDate = DateText[0].Enabled;
            Assert.AreEqual(DefaultDate, true, $"Default date is not displaying");

            string DateTextAppearing = DateText[0].Text;
            Assert.IsTrue(DateTextAppearing.Contains(CurrentDate));
            Assert.IsTrue(DateTextAppearing.Contains(CurrentMonth));
            Assert.IsTrue(DateTextAppearing.Contains(CurrentYear));

            WaitForMoment(3);

            //Get the test details
            DateTime.Now.ToString("MMMM dd, yyy");
            DateTime today = DateTime.Now;
            DateTime tomorrow = today.AddDays(3);
            DateTime yesterday = today.AddDays(-3);

            string TodayInput = today.Day.ToString();
            string TomorrowInput = tomorrow.Day.ToString();
            string yesterdayInput = yesterday.Day.ToString();

            //Open Calender window
            DateText[0].Click();
            WaitForMoment(2);

            //Todays Date
            IList<WindowsElement> DateInput1 = _pageInstance.InputTextBox(TodayInput);
            MouseClickOnWindowsElement(DateInput1[0]);
            _pageInstance.Post.Click();
            WaitForMoment(1);

            //Open Calender window
            DateText[0].Click();
            WaitForMoment(2);

            //yesterday past Date
            IList<WindowsElement> DateInput2 = _pageInstance.InputTextBox(yesterdayInput);
            DateInput2[0].Click();

            //Open Calender window
            DateText[0].Click();
            WaitForMoment(2);

            //Click Next Month
            IList<WindowsElement> Next = _pageInstance.InputTextBox("Next");
            Next[0].Click();
            WaitForMoment(1);
            Next[0].Click();
            WaitForMoment(1);
            Next[0].Click();
            WaitForMoment(1);
            WaitForMoment(1);
            Next[0].Click();
            WaitForMoment(1);

            //Future Date
            IList<WindowsElement> DateInput3 = _pageInstance.InputTextBox(TomorrowInput);
            DateInput3[0].Click();
            WaitForMoment(2);
            VerifyDateAlertPopUp(PastValidation);
        }
        public void VerifyDateAlertPopUp(string Value)
        {
            IList<WindowsElement> ValueText = _pageInstance.GetColumnText(Value);
            Assert.AreEqual(Value, ValueText[0].Text, $"Selected Date alert message : {ValueText[0].Text} is not matching the expected alert message: {Value}");
        }
        public void VerifyButtonEnableOrDisable(string Button,bool Value)
        {
            IList<WindowsElement> actionOption = _pageInstance.InputTextBox(Button);
            bool Visibility = actionOption[0].Enabled;
            Assert.AreEqual(Value, Visibility);
        }
        public void AddBatch()
        {
            _pageInstance.AddBatchUWP.Click();
            WaitForMoment(2);
        }
        public void SelectUNO()
        {
            _pageInstance.CategoryListDropdown.SendKeys(Keys.ArrowDown);
        }
        public void FetchList(int Hierarchy)
        {
            IList<WindowsElement> ListDisplay = _pageInstance.FetchList();
            ListDisplay[Hierarchy].Click();
        }
        public void CheckComponentMaterial()
        {
            IList<WindowsElement> CheckBox = _pageInstance.GridColumnCheckBox();
            MouseClickOnWindowsElement(CheckBox[2]);
        }
    }
}