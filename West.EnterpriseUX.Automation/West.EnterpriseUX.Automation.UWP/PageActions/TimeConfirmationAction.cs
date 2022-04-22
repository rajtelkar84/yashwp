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
    public class TimeConfirmationAction : BaseAction
    {
        private readonly WindowsDriver<WindowsElement> _session;
        private readonly TimeConfirmationPage _pageInstance;

        public TimeConfirmationAction(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
            _pageInstance = new TimeConfirmationPage(_session);
        }
        public void EnterOrderValueInTextBox(string value)
        {
            //UI Change 
            //IList<WindowsElement> Picker = _pageInstance.OrderNumberPick();
            //Picker[4].Click();

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
        //public void EnterOrderValueInTextBox(string Page,string value)
        //{
        //    //*****UI of the Module has been changed****
        //    IList<WindowsElement> Picker = _pageInstance.OrderNumberPick();
        //    Picker[4].Click();
        //    _pageInstance.SearchTextBox.Clear();
        //    WaitForMoment(1);
        //    _pageInstance.SearchTextBox.SendKeys(value);
        //    WaitForMoment(4);
        //    IList<WindowsElement> OrgerNumber = _pageInstance.GetColumnText(value);
        //    OrgerNumber[0].Click();
        //    WaitForMoment(1);
        //}
        public void EnterOrderValueInTextBox(string Page, string value)
        {
            //*****UI of the Module has been changed****
            IList<WindowsElement> Picker = _pageInstance.OrderNumberPick();
            if (Page.Equals("Material Stageing"))
            {
                Picker[5].Click();
            }
            if (Page.Equals("Cancel Time Confirmation"))
            {
                Picker[4].Click();
            }
            _pageInstance.SearchTextBox.Clear();
            WaitForMoment(1);
            _pageInstance.SearchTextBox.SendKeys(value);
            WaitForMoment(4);
            IList<WindowsElement> OrgerNumber = _pageInstance.GetColumnText(value);
            OrgerNumber[0].Click();
            WaitForMoment(1);
        }
        public void EnterOperationLaneNumber(string value)
        {
            //*****UI of the Module has been changed****
            //IList<WindowsElement> Picker = _pageInstance.OrderNumberPick();
            //Picker[6].Click();

            IList<WindowsElement> ReasonForVarianceUWP_Container = _pageInstance.ReasonForVarianceUWP_Container();
            ReasonForVarianceUWP_Container[2].Click();
            WaitForMoment(2);

            _pageInstance.SearchTextBox.Clear();
            WaitForMoment(1);
            string[] activity = value.Split(',');
            _pageInstance.SearchTextBox.SendKeys(activity[0]);
            WaitForMoment(4);
            IList<WindowsElement> OrgerNumber = _pageInstance.GetColumnText(activity[0]);
            OrgerNumber[0].Click();
            WaitForMoment(1);
        }
        public void EnterOperationLaneNumber(string page,string value)
        {
            // *****UI of the Module has been changed****
            //_pageInstance.OperationNumberField.Clear();
            //_pageInstance.OperationNumberField.SendKeys(value);
            //WaitForMoment(1);
            //IList<WindowsElement> inboxesList = _pageInstance.InboxListFromDropdown(value);
            //WaitForMoment(1.5);
            //MouseClickOnWindowsElement(inboxesList[0]);
            //WaitForMoment(2);
            IList<WindowsElement> Picker = _pageInstance.OrderNumberPick();
            Picker[6].Click();
            _pageInstance.SearchTextBox.Clear();
            WaitForMoment(1);
            string[] activity = value.Split(',');
            _pageInstance.SearchTextBox.SendKeys(activity[0]);
            WaitForMoment(3);
            IList<WindowsElement> OrgerNumber = _pageInstance.GetColumnText(activity[0]);
            OrgerNumber[0].Click();
            WaitForMoment(1);
        }
        public void VerifyButtonEnableOrDisable(string Button, bool Value)
        {
            if (Button.Equals("Next"))
            {
                IList<WindowsElement> actionOption = _pageInstance.NextButton();
                bool Visibility = actionOption[0].Enabled;
                Assert.AreEqual(Value, Visibility);
            }
            if (Button.Equals("RecentConfirmations"))
            {
                IList<WindowsElement> actionOption = _pageInstance.RecentConfirmationButton();
                bool Visibility = actionOption[0].Enabled;
                Assert.AreEqual(Value, Visibility);
            }
        }
        public void ClickNextButton()
        {
            IList<WindowsElement> actionOption = _pageInstance.NextButton();
            actionOption[0].Click();
        }
        public void ClickRecentConfirmationButton()
        {
            IList<WindowsElement> actionOption = _pageInstance.RecentConfirmation();
            actionOption[0].Click();
        }
        public void VerifyPageTextTimeConfirmation(string Text1, string Text2, string Text3)
        {
            IList<WindowsElement> pageText = _pageInstance.GetText;
            List<string> fieldTest = new List<string>();
            for (int i = 0; i < pageText.Count; i++)
            {
                fieldTest.Add(pageText[i].Text);
            }
            Assert.AreEqual(Text1, fieldTest[11], $" Page title: {fieldTest[11]} is not matching the expected Text: {Text1}");
            Assert.AreEqual(Text2, fieldTest[14], $" Page title: {fieldTest[14]} is not matching the expected Text: {Text2}");
            Assert.AreEqual(Text3, fieldTest[15], $" Page title: {fieldTest[15]} is not matching the expected Text: {Text3}");
        }
        public void VerifyPageText(string Text)
        {
            IList<WindowsElement> columnText = _pageInstance.GetColumnText(Text);
            Assert.AreEqual(Text, columnText[0].Text, $" Recent Confirmation column 1 : {columnText[0].Text} is not matching the expected Text: {Text}");
        }
        public void ClickButton(string ButtonName)
        {
            IList<WindowsElement> Button = _pageInstance.GetColumnText(ButtonName);
            Button[0].Click();
            WaitForMoment(1);
        }
        public void ClickButton(string ButtonName ,int ButtonNo)
        {
            IList<WindowsElement> Button = _pageInstance.GetColumnText(ButtonName);
            Button[ButtonNo-1].Click();
            WaitForMoment(1);
        }
        public void EnterFields(string TextBox, string value)
        {
            IList<WindowsElement> Input = _pageInstance.TextBox();
            IList<WindowsElement> MultiScan = _pageInstance.MultiScan();
            if (TextBox.Equals("Yeild")|| TextBox.Equals("Quantity"))
            {
                Input[0].Clear();
                WaitForMoment(1);
                Input[0].Clear();
                Input[0].SendKeys(value);
                WaitForMoment(1);
                MultiScan[4].Click();
                WaitForMoment(1);

            }
            if (TextBox.Equals("Scrap"))
            {
                Input[1].Clear();
                WaitForMoment(1);
                Input[1].Clear();
                Input[1].SendKeys(value);
            }        
        }
        public void EnterBatch(string Page,string value)
        {
            IList<WindowsElement> Input = null;
            if (Page.Equals("Goods Movement"))
            {
                Input = _pageInstance.BatchTextBox();
                Input[1].Clear();
                Input[1].SendKeys(value);
            }
            if (Page.Equals("Edit"))
            {
                Input = _pageInstance.BatchTextBoxEdit();
                Input[0].Clear();
                Input[0].SendKeys(value);
            }
            WaitForMoment(2);
        }
        public void ConfirmOrder(string Order, string Action)
        {
            if (Order.Equals("Final Confirmation"))
            {
                WaitForMoment(1);
                _pageInstance.FinalConfirmation.Click();
                WaitForMoment(1);
                if (Action.Equals("Confirm"))
                {
                    _pageInstance.ConfirmBtn.Click();
                }
                if (Action.Equals("Cancel"))
                {
                    _pageInstance.CancelBtn.Click();
                }
            }
            if (Order.Equals("Partial Confirmation"))
            {
                WaitForMoment(1);
                _pageInstance.PartialConfirmation.Click();
                WaitForMoment(1);

                if (Action.Equals("Confirm"))
                {
                    _pageInstance.ConfirmBtn.Click();
                }
                if (Action.Equals("Cancel"))
                {
                    _pageInstance.CancelBtn.Click();
                }
            }
        }
        public void ClickSplitBatch()
        {
            _pageInstance.SplitBatchBtn.Click();
            WaitForMoment(2);
        }
        public void ClickAddBatch()
        {
            _pageInstance.AddBatchBtn.Click();
            WaitForMoment(1);
        }
        public void VerifyEditedQuantity(string value)
        {
            IList<WindowsElement> Quantity = _pageInstance.TextBox();
            Assert.AreEqual(value, Quantity[1].Text, $"Edited Quantity : {value} in the splt batch is not matching the expected Quantity: {Quantity[0]}");           
        }
        public void DeleteSplitBatch(int BatchOder)
        {
            IList<WindowsElement> Quantity = _pageInstance.RemoveBatchUWP();
            Quantity[BatchOder-1].Click(); 
        }
        public void VerifyBatchId(string value)
        {
            IList<WindowsElement> BatchId = _pageInstance.BatchTextBox();
            Assert.AreEqual(value, BatchId[1].Text, $"Edited BatchId : {value} is not matching with the expected Quantity: {BatchId[0]}");
        }
        public void FillValue(string value,string Textbox)
        {
            IList<WindowsElement> Button = _pageInstance.FillValue(Textbox);
            Button[0].Clear();
            WaitForMoment(1);
            Button[0].SendKeys(value);
        }
        public void ClickReasonforVariancePicker()
        {
            IList<WindowsElement> Picker = _pageInstance.ReasonForVariancePick();
            Picker[4].Click();
        }
        public void SearchReasonforVarianceAndVerify(string Value)
        {
            _pageInstance.SearchTextBox.Clear();
            WaitForMoment(1);
            _pageInstance.SearchTextBox.SendKeys(Value);

            WaitForMoment(3);

            IList<WindowsElement> columnText = _pageInstance.GetColumnText(Value);
            Assert.AreEqual(Value, columnText[0].Text, $"Reason for Variance value  {columnText[0].Text} is not matching the expected Value: {Value}");
        }
        public void VerifyConfirmationDate(string Row)
        {
            string CurrentDate = DateTime.Now.ToString("M/d/yyyy");
            IList<WindowsElement> DateText = _pageInstance.GetConfirmationDate(Row);
            List<string> DateDisplaying = DateText[5].Text.ToString().Split(' ').ToList();
            Assert.AreEqual(CurrentDate, DateDisplaying[0], $"Configure date value {DateDisplaying[0]} is not matching the expected Value: {CurrentDate}");
        }
        public void VerifyNoteText(string value)
        {
            IList<WindowsElement> Note = _pageInstance.NoteText();
            Assert.AreEqual(value, Note[0].Text, $"Displaying : {Note[0]} is not matching with the expected Note: {value}");
        }
        public void VerifyTmInputValues(string value)
        {
            IList<WindowsElement> Note = _pageInstance.TmInputValues();
            Assert.AreNotEqual(value, Note[1].Text, $"Displaying : {Note[0]} is not correct with respect to the expected : {value}");
        }
        public void VerifyBatchMaterialID(string value, string type)
        {           
            if (type.Equals("Batch"))
            {
                IList<WindowsElement> BatchMaterialNote = _pageInstance.BatchMaterialID();
                Assert.AreEqual(value, BatchMaterialNote[0].Text, $"Non Batch Material Note : {value} is not displaying as per the expected Non Batch Material Note: {BatchMaterialNote[0]}");

                IList<WindowsElement> BatchId = _pageInstance.BatchTextBox();
                Assert.AreEqual("", BatchId[0].Text, $"Batch Material Id : {""} is not matching with the expected Batch Id: {BatchId[0]}");
            }
            if (type.Equals("Non Batch"))
            {
                IList<WindowsElement> NonBatchMaterialNote = _pageInstance.NonBatchMaterialID();
                Assert.AreEqual(value, NonBatchMaterialNote[0].Text, $"Non Batch Material Note : {value} is not displaying as per the expected Non Batch Material Note: {NonBatchMaterialNote[0]}");

                IList<WindowsElement> BatchId = _pageInstance.BatchTextBox();
                Assert.AreEqual("", BatchId[0].Text, $"Non Batch Material Id : {""} is not matching with the expected Batch Id: {BatchId[0]}");
            }
        }
        public void VerifyOrderNumberField( bool Value)
        {
            IList<WindowsElement> actionOption = _pageInstance.VerifyOrderNumberInputField();
            bool Visibility = actionOption[0].Enabled;
            Assert.AreEqual(Value, Visibility);
        }
        public void VerifyTimeComfirmation(string Value)
        {
            IList<WindowsElement> ValueText = _pageInstance.GetColumnText(Value);
            Assert.AreEqual(Value, ValueText[0].Text, $"Added Componet Detail: {ValueText[0].Text} is not matching the expected component detail: {Value}");
        }
        public void EnterComments(string Value)
        {
            _pageInstance.CommentEditor.SendKeys(Value+" Test Comments");
        }
    }    
}