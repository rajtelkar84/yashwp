
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
    public class PhysicalInventoryAction : BaseAction
    {
        private readonly WindowsDriver<WindowsElement> _session;
        private readonly PhysicalInevntoryPage _pageInstance;
        public PhysicalInventoryAction(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
            _pageInstance = new PhysicalInevntoryPage(_session);
        }
        public string VerifyNoButton()
        {
            WaitForMoment(0.5);
            string str = _pageInstance.PopUpNoBtn.Text;
            ClickElement(_pageInstance.PopUpNoBtn);
            return str;
        }
        public string VerifyYesButton()
        {
            WaitForMoment(0.5);
            string str = _pageInstance.PopUpYesBtn.Text;
            ClickElement(_pageInstance.PopUpYesBtn);
            return str;
        }
        public string VerifyPopUpText()
        {
            WaitForMoment(0.7);
            return _pageInstance.PopUpDialogMessage.Text;
        }
        public void ClickBatchAction(string actionName)
        {
            MouseClickOnCenterOfWindowsElement(_pageInstance.ClickOnBatchAction(actionName));
        }
        public string VerifyPopUpDialogTitle()
        {
            WaitForMoment(0.3);
            return _pageInstance.PopUpDialogTitle.Text;
        }
        public string ReadColumText(int rowNum, int columnNum)
        {
            WaitForMoment(0.3);
            return _pageInstance.GetColumnText(rowNum, columnNum).Text;
        }
        public void ClickOnOkButton()
        {
            WaitForMoment(0.2);
            ClickElement(_pageInstance.PopUpOkBtn);
        }
        public void EnterValueInActualQualityTextBox(string quality)
        {
            WaitForMoment(3);
            IList<WindowsElement> elements = _pageInstance.ActualQualityTxt;
            Console.WriteLine(elements.Count);
            if (elements.Count > 0)
            {
                foreach (WindowsElement element in elements)
                {
                    Console.WriteLine(element.Displayed);
                    WaitForMoment(1);
                    element.Click();
                    WaitForMoment(2);
                    element.Clear();
                    WaitForMoment(2);
                    element.Clear();
                    WaitForMoment(1);
                    element.SendKeys(quality);
                    WaitForMoment(2);
                    element.Clear();
                    WaitForMoment(1);
                    element.SendKeys(quality);
                }
            }
            else
                LogInfo("*******Card is not Present");
        }
        public void ClickOnCountButton()
        {
            WaitForMoment(2);
            ClickElement(_pageInstance.countButton);
        }
        public void ClickOnPostButton()
        {
            WaitForMoment(4);
            ClickElement(_pageInstance.postButton);
        }
        public void VerifyActualQuality(string quality)
        {
            WaitForMoment(2);
            IList<WindowsElement> elements = _pageInstance.ActualContent;
            Boolean actualqualityValue = elements.ElementAt(0).Text.Contains(quality);
            Assert.IsTrue(actualqualityValue, "Actual Quality value is not updated properly after click on count button");
        }
        public int popText()
        {
            int flag = 0;
            WaitForMoment(0.3);
            if (_pageInstance.poupText.Count > 0)
            {
                flag = 1;
            }
            return flag;
        }
        public void VerifyPhysicalInventoryStatus(string status)
        {
            WaitForMoment(2);
            Assert.AreEqual(status, _pageInstance.ListView.Text);
        }
        public void ActivePIDocuments()
        {
            WaitForMoment(2);
            _pageInstance.activePIDocumentsDashLabel.Click();
            WaitForMoment(2);
        }
        public void All()
        {
            WaitForMoment(2);
            _pageInstance.allDashboardLabel.Click();
            WaitForMoment(2);
        }
        public void CountedPIDocuments()
        {
            WaitForMoment(2);
            _pageInstance.countedPIDocumentDashLabel.Click();
            WaitForMoment(3);
        }
        public string PIDocPagePostButton()
        {
            WaitForMoment(2);
            return _pageInstance.PIDocPagePostButton.GetAttribute("IsEnabled");
        }
        public string PIDocPageCountButton()
        {
            WaitForMoment(2);
            return _pageInstance.PIDocPageCountButton.GetAttribute("IsEnabled");
        }
        public void PIListViewCheckBox()
        {
            WaitForMoment(2);
            IList<WindowsElement> elements = _pageInstance.PIListViewCheckBox;
            elements.ElementAt(0).Click();
            WaitForMoment(2);
        }
    }
}
