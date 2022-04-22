using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using West.EnterpriseUX.Automation.UWP.PageObjects;
using West.EnterpriseUX.Automation.UWP.Utilities;

namespace West.EnterpriseUX.Automation.UWP.PageActions
{
    public class CreateMaintenanceAction : BaseAction
    {
        private readonly WindowsDriver<WindowsElement> _session;
        private readonly CreateMaintenancePage _pageInstance;

        public CreateMaintenanceAction(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
            _pageInstance = new CreateMaintenancePage(_session);
        }
        public void VerifyField(string Value)
        {
            IList<WindowsElement> ValueText = _pageInstance.GetFieldText(Value);
            Assert.AreEqual(Value, ValueText[0].Text, $"Added Componet Detail: {ValueText[0].Text} is not matching the expected component detail: {Value}");
        }
        public void ClickCheckBox(string Confirmation)
        {
            IList<WindowsElement> CheckBox = _pageInstance.ReferenceNumber();
            if (Confirmation.Equals("Final Confirmation"))
            {
                CheckBox[1].Click();
            }
            if (Confirmation.Equals("File"))
            {
                CheckBox[0].Click();
            }
            if (Confirmation.Equals("Tailgate"))
            {
                CheckBox[0].Click();
            }
            if (Confirmation.Equals("Staging"))
            {
                CheckBox[0].Click();
            }
        }
        public void EnterRefrenceNumber(string Feild, string value)
        {
            ClickElement(_pageInstance.OrderNumberPick(Feild));
            WaitForMoment(2);
            _pageInstance.SearchTextBox.Clear();
            WaitForMoment(1);
            _pageInstance.SearchTextBox.SendKeys(value);
            WaitForMoment(3);
            IList<WindowsElement> OrgerNumber = _pageInstance.GetColumnText(value);
            OrgerNumber[0].Click();
            WaitForMoment(3);
        }
        public void EnterField(string Field, string Value)
        {
            _pageInstance.EnterText(Field).Clear();
            WaitForMoment(1);
            _pageInstance.EnterText(Field).SendKeys(Value);
            WaitForMoment(1);
        }
        public string GetCreatedOrder()
        {
           string dailogPopUp = _pageInstance.DialogPopUp().Text;
           string[] createdOrderNo = dailogPopUp.Split(' ');
           return createdOrderNo[1];
        }
        public void EnterNotification(string value)
        {
            IList<WindowsElement> Picker = _pageInstance.OrderNumberPick();
            Picker[3].Click();
            _pageInstance.SearchTextBox.Clear();
            WaitForMoment(1);
            _pageInstance.SearchTextBox.SendKeys(value);
            WaitForMoment(3);
            IList<WindowsElement> OrgerNumber = _pageInstance.GetColumnText(value);
            OrgerNumber[0].Click();
            WaitForMoment(1);
        }
    }
}