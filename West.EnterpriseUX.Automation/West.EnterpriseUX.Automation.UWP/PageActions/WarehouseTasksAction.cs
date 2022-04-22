
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
    public class WarehouseTasksAction : BaseAction
    {
        private readonly WindowsDriver<WindowsElement> _session;
        private readonly WarehouseTasksPage _pageInstance;
        public WarehouseTasksAction(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
            _pageInstance = new WarehouseTasksPage(_session);
        }
        public void ClickOnCancelTaskBtn()
        {
            WaitForMoment(2);
            ClickElement(_pageInstance.cancelTaskBtn);
        }
        public void ClickOnConfirmTaskBtn()
        {
            WaitForMoment(2);
            ClickElement(_pageInstance.confirmTaskBtn);
        }
        public void MouseHoverToElement(string inboxName)
        {
            WaitForMoment(3);
            IList<WindowsElement> inboxesList = _pageInstance.IndexSearchSideFrame(inboxName);
            MouseHoverOnWindowsElement(inboxesList[0]);
            MouseClickOnCenterOfWindowsElement(_pageInstance.VerticalScrollBar);
        }
        public void VerificationOfRecord(string value)
        {
            WaitForMoment(2);
            if (_pageInstance.row.Count > 0)
            {
                Assert.IsTrue(false, "Record is not remove from warehouse grid after perform" + value + "Operation");
            }
            else
            {
                WaitForMoment(2);
                Assert.IsTrue(true);
            }
        }
        public void VerifyDetialedAction(int recordNumber, string detailedAction)
        {
            WaitForMoment(2);
            IList<WindowsElement> detailedActionMenu = _pageInstance.DetailActionAllRow(recordNumber);
            MouseClickOnCenterOfWindowsElement(detailedActionMenu[0]);
            string value = _pageInstance.SelectMenuOption(detailedAction).Text;
            _pageInstance.SelectMenuOption(detailedAction).Click();
            WaitForMoment(1.5);
        }
        
       public void ClickOnVerticalSmallIncrease()
        {
            for (int i = 0; i < 3; i++)
            {
                WaitForMoment(2);
                ClickElement(_pageInstance.VerticalSmallIncrease);
            }
        }
    }
}
