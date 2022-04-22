using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace West.EnterpriseUX.Automation.UWP.PageObjects
{
    class ActivitiesPage : BasePage
    {
        protected WindowsDriver<WindowsElement> _session;

        public ActivitiesPage(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
        }

        public WindowsElement CreateCalendarConstruct => FindElement("XPath:.//*[contains(@Name,'Create Calendar Construct')]");
   
        public WindowsElement GetDateInCalender(String dateText)
        {
            return  FindElement("XPath:.//*[contains(@Name,'" + dateText + "') or contains(@AutomationId,'" + dateText + "')]");
        }

        public WindowsElement ButtonByName(String name)
        {
            return FindElement("XPath:.//Button[@Name='" + name + "']");
        }

        public IList<WindowsElement> ButtonListByName(String name)
        {
            return FindElements("XPath:.//Button[@Name='" + name + "']");
        }

        public WindowsElement SelectElementByLabel(string label)
        {
            return FindElement("XPath:.//*[@Name='" + label + "']/../../../following-sibling::*//*[contains(@ClassName,'ComboBox')]");
        }

        public WindowsElement ElementByLabel(string label)
        {
            return FindElement("XPath:.//*[@Name='" + label + "']/../../../following-sibling::*//*[contains(@ClassName,'TextBox')]");
        }
        public WindowsElement Radiobutton(string radiobtnName)
        {
            return FindElement("XPath:.//*[@Name='" + radiobtnName + "' and @ClassName='RadioButton']");
        }
        public WindowsElement Tab(string tabText)
        {
            return FindElement("XPath:.//*[@Name='" + tabText + "' and @ClassName='TextBlock']");
        }
        public WindowsElement Link => FindElement("XPath:.//*[contains(@Name,'Link')]/../../../following-sibling::*//*[contains(@ClassName,'TextBox')]");
        public WindowsElement SelectLinkByLabel(string label)
        {
            return FindElement("XPath:.//*[contains(@Name,'"+label+"')]/../../../following-sibling::*//*[contains(@ClassName,'TextBox')]");
        }
        public IList<WindowsElement> CreatedActivityByNameInCalender(string activity)
        {
            return FindElements("XPath:.//*[contains(@Name,'Activities On')]/following-sibling::*//*[contains(@Name,'" + activity + "')]");
        }
        public IList<WindowsElement> CreatedActivitySubjectByNameInCalender(string activity,string label)
        {
            return FindElements("XPath:.//*[contains(@Name,'Activities On -')]/following-sibling::*//*[contains(@Name,'" + activity + "')]/following-sibling::*[contains(@Name,'"+label+" -')]");
        }
        public IList<WindowsElement> CreatedActivityTimeByNameInCalender(string activity)
        {
            return FindElements("XPath:.//*[contains(@Name,'Activities On -')]/following-sibling::*//*[contains(@Name,'" + activity + "')]/following-sibling::*[contains(@Name,'Time -')]");
        }
    }
}
