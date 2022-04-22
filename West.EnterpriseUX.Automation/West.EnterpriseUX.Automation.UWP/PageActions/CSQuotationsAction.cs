using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using West.EnterpriseUX.Automation.UWP.PageObjects;

namespace West.EnterpriseUX.Automation.UWP.PageActions
{
    public class CSQuotationsAction : BaseAction
    {
        private readonly WindowsDriver<WindowsElement> _session;
        private readonly CSQuotationsPage _pageInstance;

        public CSQuotationsAction(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
            _pageInstance = new CSQuotationsPage(_session);
        }
        public void VerifyDetailsbutton()
        {
            Boolean isDisplayed = _pageInstance.ViewDetailsbutton.Displayed;
            if (isDisplayed == true)
            {
                _pageInstance.ViewDetailsbutton.Click();
                LogInfo($"Page loaded successfully and Details Button is present");
            }
            else
            {
                LogInfo($"Page not loaded");
                Assert.Fail($"Customers Inbox dashboard not Present");
            }
        }
        public void VerifyDetailedActionButton(int rowNumber/*string detailedAction*/)
        {
            WaitForMoment(1);
            IList<WindowsElement> detailedActionMenu = _pageInstance.DetailActionRowAll(rowNumber);
            MouseClickOnBottomCenterOfWindowsElement(detailedActionMenu[0]);
            //string value = _pageInstance.SelectOptioninMenu(detailedAction).Text;
            //Assert.AreEqual(detailedAction, value);
            //_pageInstance.SelectOptioninMenu(detailedAction).Click();
        }
        public void ClickOnMoreExpand()
        {
            WaitForMoment(0.3);
            _pageInstance.MoreExpand.Click();
        }
        public void CloseExpand()
        {
            _pageInstance.CloseExpand.Click();
        }
        public void ClickOnMoreCollaborationBeta()
        {
            _pageInstance.MoreCollaborationBeta.Click();
            WaitForMoment(0.3);
        }
        public void ClickOnViewDetailsbutton()
        {
            _pageInstance.ViewDetailsbutton.Click();
            WaitForMoment(0.3);
        }
    }
}
