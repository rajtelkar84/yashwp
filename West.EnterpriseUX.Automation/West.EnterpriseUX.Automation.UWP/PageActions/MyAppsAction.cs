using Microsoft.Test.Input;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Automation;
using West.EnterpriseUX.Automation.UWP.PageObjects;

namespace West.EnterpriseUX.Automation.UWP.PageActions
{
    public class MyAppsAction : BaseAction
    {
        private readonly WindowsDriver<WindowsElement> _session;
        private readonly MyAppsPage _pageInstance;

        public MyAppsAction(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
            _pageInstance = new MyAppsPage(_session);
        }
        public void SelectFunction(string functionName)
        {
            IList<WindowsElement> function = _pageInstance.GetElementByText(functionName);
            MouseClickOnWindowsElement(function[0]);
        }
        public IList<WindowsElement> GetAllCategories()
        {
            IList<WindowsElement> allCategoriesList = _pageInstance.MyAppsCategories;
            return allCategoriesList;
        }
        public IList<WindowsElement> GetEachCategoryApps()
        {
            IList<WindowsElement> eachCategoryAppsList = _pageInstance.AppsEachCategory;
            return eachCategoryAppsList;
        }
        public void NavigateToEachApp()
        {
            WaitForLoadingToDisappear();
            IList<WindowsElement> allCategoriesList = GetAllCategories();
            IList<WindowsElement> eachCategoryAppsList;
            string windowName = string.Empty;
            string applicationName = string.Empty;
            bool isNewWindowOpening = false;

            if (allCategoriesList.Count > 0)
            {
                foreach (WindowsElement appCategory in allCategoriesList.Where(x => (x.Text != "All Apps") & (x.Text != "IntraWest")).ToList())
                {
                    WaitForMoment(2);
                    appCategory.Click();

                    eachCategoryAppsList = GetEachCategoryApps();

                    foreach (WindowsElement app in eachCategoryAppsList)
                    {
                        WaitForMoment(2);
                        app.Click();

                        var appName = app.FindElementsByXPath("//Custom/Text[1]");
                        applicationName = appName[0].Text;

                        WaitForMoment(30);
                        AutomationElement rootElement = AutomationElement.RootElement;
                        var winCollection = rootElement.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty,
                               "ApplicationFrameWindow"));

                        foreach (AutomationElement element in winCollection)
                        {
                            windowName = element.Current.Name;

                            if (element.Current.Name.ToLower().Contains(appName[0].Text.ToLower()))
                            {
                                element.SetFocus();

                                WaitForMoment(2);
                                AutomationElement closeAutomationElement = element.FindFirst
                                (TreeScope.Descendants, new PropertyCondition(AutomationElement.AutomationIdProperty,
                                "Close"));

                                WaitForMoment(1);
                                var invokePattern1 = closeAutomationElement.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
                                invokePattern1.Invoke();

                                WaitForMoment(3);
                                AutomationElement okAutomationElement = element.FindFirst
                               (TreeScope.Descendants, new PropertyCondition(AutomationElement.AutomationIdProperty,
                               "okButton"));

                                WaitForMoment(1);
                                System.Windows.Point p = okAutomationElement.GetClickablePoint();
                                Mouse.MoveTo(new Point((int)p.X, (int)p.Y + 20));
                                Mouse.Click(MouseButton.Left);

                                WaitForMoment(2);

                                LogInfo($"Window by name : {windowName} is displaying");

                                isNewWindowOpening = true;
                                break;
                            }
                            else
                            {
                                isNewWindowOpening = false;
                                LogInfo($"Window by name : {windowName} is not matching");
                            }
                        }

                        Assert.IsTrue(isNewWindowOpening, $"On clicking on the App : {applicationName} new window did not displayed.");
                    }
                }
            }
            else
            {
                LogInfo("No Categories available under Apps section");
            }
        }

    }
}
