using OpenQA.Selenium.Appium.Windows;
using System.Collections.Generic;

namespace West.EnterpriseUX.Automation.UWP.PageObjects
{
    public class MyAppsPage : BasePage
    {
        protected WindowsDriver<WindowsElement> _session;

        public MyAppsPage(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
        }
        public IList<WindowsElement> MyAppsCategories => FindElements("AccessibilityId:AppCategoryName");
        public IList<WindowsElement> AppsEachCategory => FindElements("ClassName:GridViewItem");
    }
}
