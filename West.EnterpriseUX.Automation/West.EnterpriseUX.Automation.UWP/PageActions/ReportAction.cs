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
    public class ReportAction : BaseAction
    {
        private readonly WindowsDriver<WindowsElement> _session;
        private readonly ReportPage _pageInstance;

        public ReportAction(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
            _pageInstance = new ReportPage(_session);
        }
        public void EnterOrderNumber(string pannel,string value)
        {
            IList<WindowsElement> Picker = _pageInstance.OrderNumberPick();
            if (pannel.Equals("Reprint"))
            {
                Picker[4].Click();
            }
            if (pannel.Equals("Audit Report"))
            {
                Picker[9].Click();
            }
            _pageInstance.SearchTextBox.Clear();
            WaitForMoment(1);
            _pageInstance.SearchTextBox.SendKeys(value);
            WaitForMoment(3);
            IList<WindowsElement> OrgerNumber = _pageInstance.GetColumnText(value);
            OrgerNumber[0].Click();
            WaitForMoment(1);
        }
        public void ClickButton(string ButtonName)
        {
            IList<WindowsElement> Button = _pageInstance.Button();
            if (ButtonName.Equals("Reprint"))
            {
                Button[4].Click();

            }
            if (ButtonName.Equals("Cancel"))
            {
                Button[3].Click();

            }
            WaitForMoment(1);
        }
        public int ReprintCount( )
        {
            IList<WindowsElement> CheckBox = _pageInstance.ReprintTab();
            string Reprintcount= CheckBox[1].Text;
            int Count = Int32.Parse(Reprintcount);
            return Count;
        }
        public void OpenSequenceNo()
        {
            IList<WindowsElement> Picker = _pageInstance.OrderNumberPick();
            Picker[8].Click();
        }
    }
}