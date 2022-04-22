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
    public class InventoryDashboardAction : BaseAction
    {
        private readonly WindowsDriver<WindowsElement> _session;
        private readonly InventoryDashboardPage _pageInstance;

        public InventoryDashboardAction(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
            _pageInstance = new InventoryDashboardPage(_session);
        }
        public void EnterPlant(string value)
        {
            IList<WindowsElement> Picker = _pageInstance.PlantPicker();
            Picker[5].Click();
            _pageInstance.SearchTextBox.Clear();
            WaitForMoment(1);
            _pageInstance.SearchTextBox.SendKeys(value);
            WaitForMoment(4);
            IList<WindowsElement> OrgerNumber = _pageInstance.GetColumnText(value);
            OrgerNumber[0].Click();
            WaitForMoment(1);
        }
        public void VerifyField(string Value)
        {
            IList<WindowsElement> ValueText = _pageInstance.GetColumnText(Value);
            Assert.AreEqual(Value, ValueText[0].Text, $"Added Componet Detail: {ValueText[0].Text} is not matching the expected component detail: {Value}");
        }
        public void SelectFromDropDown(string entryText, String label)
        {
            EnterText(_pageInstance.SelectTimeInterval(label), entryText);
        }
    }
}