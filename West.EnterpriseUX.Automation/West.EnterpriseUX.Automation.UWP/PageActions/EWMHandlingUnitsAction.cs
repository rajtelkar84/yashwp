
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Support.UI;
using System.IO;
using West.EnterpriseUX.Automation.UWP.PageObjects;
using West.EnterpriseUX.Automation.UWP.Utilities;
namespace West.EnterpriseUX.Automation.UWP.PageActions
{
    public class EWMHandlingUnitsAction : BaseAction
    {
        private readonly WindowsDriver<WindowsElement> _session;
        private readonly EWMHandlingUnitsPage _pageInstance;
        public EWMHandlingUnitsAction(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
            _pageInstance = new EWMHandlingUnitsPage(_session);
        }
        public void VerifyDetialedAction(int recordNumber, string detailedAction)
        {
            WaitForMoment(2);
            IList<WindowsElement> detailedActionMenu = _pageInstance.DetailActionAllRow(recordNumber);
            MouseClickOnCenterOfWindowsElement(detailedActionMenu[0]);
            string value = _pageInstance.SelectMenuOption(detailedAction).Text;
            Assert.AreEqual(detailedAction, value);
            _pageInstance.SelectMenuOption(detailedAction).Click();

            WaitForMoment(1.5);
        }
        public void ClickDetialedActionMenuButton(int recordNumber)
        {
            WaitForMoment(2);
            IList<WindowsElement> detailedActionMenu = _pageInstance.DetailActionAllRow(recordNumber);
            MouseClickOnCenterOfWindowsElement(detailedActionMenu[0]);
        }
        public void ClickDetialedAction(string detailedAction)
        {
            WaitForMoment(1);
            _pageInstance.SelectMenuOption(detailedAction).Click();
        }
        public void ClickOnPicker(int pickerNum, string value)
        {
            WaitForMoment(1.5);
            IList<WindowsElement> selectPickerIcon = _pageInstance.SelectPicker;
            WaitForMoment(0.2);
            selectPickerIcon[pickerNum].Click();
            WaitForMoment(1);
            _pageInstance.SearchTextBox.Clear();
            WaitForMoment(1.5);
            _pageInstance.SearchTextBox.SendKeys(value);
            WaitForMoment(4);
        }
        private void LogInfo()
        {
            throw new NotImplementedException();
        }
        public void SelectValueFromPicker(int pickerNum, string value)
        {
            //Select value from Picker
            WaitForMoment(2);
            IList<WindowsElement> selectPickerIcon = _pageInstance.SelectPicker;
            WaitForMoment(0.2);
            selectPickerIcon[pickerNum].Click();
            WaitForMoment(1);
            _pageInstance.SearchTextBox.Clear();
            WaitForMoment(1.5);
            _pageInstance.SearchTextBox.SendKeys(value);
            WaitForMoment(4);
            IList<WindowsElement> number = _pageInstance.GetColumnText(value);
            Assert.AreEqual(value, number[0].Text, "Picker values are not loading");
            number[0].Click();
        }
        public void ClickOnBackButton()
        {
            WaitForMoment(1);
            _pageInstance.ClickBackArrow.Click();
        }
        public void ClickOnBatchAction(string batchAction)
        {
            WaitForMoment(1.5);
            _pageInstance.BatchAction(batchAction).Click();
        }
        public void ClickOnPrintHandlingUnitsMasterBtn(string actionName)
        {
            WaitForMoment(1);
            IList<WindowsElement> masterActionElement = _pageInstance.PrintHandlingUnitsMasterBtn(actionName);
            Assert.AreEqual(actionName, masterActionElement[0].Text);
            masterActionElement[0].Click();
        }
        public void SelectBatchCheckbox(int CheckBoxNumber)
        {
            WaitForMoment(1.5);
            _pageInstance.SelectBatchCheckBox(CheckBoxNumber).Click();
        }
        public void ClickOnPrintButton()
        {
            WaitForMoment(1);
            ClickElement(_pageInstance.PrintButton);
        }
        public string VerfiySuccessText(string SuccessText)
        {
            WaitForMoment(2.5);
            string SuccessTxtVal = _pageInstance.SuccessText(SuccessText).Text;
            LogInfo("Success Text" + SuccessTxtVal);
            Boolean SuccessTxtV = SuccessTxtVal.Contains(SuccessText);
            Assert.IsTrue(SuccessTxtV, "Value are not updated successfully");
            return SuccessTxtVal;
        }
        public void ClickOnExpandArrow()
        {
            WaitForMoment(1);
            ClickElement(_pageInstance.ExpandArrow);
        }
        public void ClickOnDeleteIcon()
        {
            WaitForMoment(1);
            ClickElement(_pageInstance.DeleteIcon);
        }
        public void VerificationOfHandlingUnitDetails(string name)
        {
            try
            {
                string actualText = _pageInstance.GetText(name).Text;
                LogInfo("Text" + actualText);
                Boolean textValidation = actualText.Contains(name);
                Assert.IsTrue(textValidation);
            }
            catch (Exception ex)
            {
                LogInfo("Selected Handling Unit details text " + name + "is not Displayed");
            }
        }

        public void VerificationOfToggleDefultState()
        {
            string toggleState = _pageInstance.DestToggle.GetAttribute("Toggle.ToggleState");
            LogInfo("Toggle State" + toggleState);
            Boolean textValidation = toggleState.Contains("0");
            Assert.IsTrue(textValidation);
        }
        public void ClickOnToggleBtn()
        {
            WaitForMoment(0.5);
            ClickElement(_pageInstance.DestToggle);
        }
        public void VerificationofPostButton()
        {
            Boolean PostButton = _pageInstance.PostButtton.Enabled;
            LogInfo("Post Button" + PostButton);
            Assert.IsFalse(PostButton);
        }
        public void VerificationofPrintButton()
        {
            Boolean PrintButton = _pageInstance.PrintButton.Enabled;
            LogInfo("Print Button" + PrintButton);
            Assert.IsFalse(PrintButton, "Print Button is enabled without select all Mandatory fields");
        }
        public void SearchTheText(string text)
        {
            ClickClearEnterText(_pageInstance.SearchTxtBox, text);
            ClickElement(_pageInstance.SearchIcon);
        }
        public void ClickPostButton()
        {
            WaitForMoment(0.5);
            ClickElement(_pageInstance.PostButtton);
        }
        public void ClickOnMasterAction(string MasterActionName)
        {
            WaitForMoment(0.5);
            ClickElement(_pageInstance.MasterAction);
            MouseClickOnCenterOfWindowsElement(_pageInstance.ClickOnMasterAction(MasterActionName));
        }
        public void ClickOnDestinationTab()
        {
            WaitForMoment(1.5);
            ClickElement(_pageInstance.DestinationTab);
        }
        public void ClickOnBatchActionMoreButton()
        {
            if (_pageInstance.BatchActionMoreOptionButton.Count > 0)
            {
                WaitForMoment(1.2);
                ClickElement(_pageInstance.BatchActionMoreOptionButton[0]);
            }
        }
        public void SelectAction(string ActionName)
        {
            MouseClickOnCenterOfWindowsElement(_pageInstance.ClickOnMasterAction(ActionName));
        }
    }
}
