using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Threading;

namespace West.EnterpriseUX.Automation.MobileNew
{
    public class KpisPage : AppiumKeywords
    {
        public static AppiumDriver<IWebElement> _driver;
 
        public KpisPage(AppiumDriver<IWebElement> driver) : base(driver)
        {
            _driver = driver;
        }

        #region KpisPage Elements

        public IWebElement KpisAbstractionTabTitle => WaitAndFindElement(androidLocator: MobileBy.XPath("//*[@text='KPIS']"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> GetKPIToZoom(string kpiName)
        {
            return WaitAndFindElements(androidLocator: MobileBy.XPath("//*[contains(@text, '" + kpiName + "') and @content-desc='Title']/parent::*/parent::*/parent::*/descendant::*[@content-desc='zoomIcon']"), iosLocator: MobileBy.XPath(""));
        }
        public IList<IWebElement> GetKPIToRefresh(string kpiName)
        {
            return WaitAndFindElements(androidLocator: MobileBy.XPath("//*[contains(@text, '" + kpiName + "') and @content-desc='Title']/parent::*/parent::*/following-sibling::*/following-sibling::*/descendant::*[@content-desc='RefreshBlock']"), iosLocator: MobileBy.XPath(""));
        }
        public IList<IWebElement> GetKPIToFavorite(string kpiName)
        {
            return WaitAndFindElements(androidLocator: MobileBy.XPath("//*[contains(@text, '" + kpiName + "') and @content-desc='Title']/parent::*/parent::*/following-sibling::*/following-sibling::*/descendant::*[@content-desc='Favourite']"), iosLocator: MobileBy.XPath(""));
        }
        public IList<IWebElement> KpiPageTitle => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='PageTitleLabel']"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> GetKPIToApplyFilterOn(string kpiName)
        {
            return WaitAndFindElements(androidLocator: MobileBy.XPath("//*[contains(@text, '" + kpiName + "') and @content-desc='Title']/parent::*/parent::*/following-sibling::*/following-sibling::*/descendant::*[@content-desc='MicroFilter']"), iosLocator: MobileBy.XPath(""));
        }
        public IList<IWebElement> GetMicroFilterOption(string option)
        {
            return WaitAndFindElements(androidLocator: MobileBy.XPath("//*[contains(@text, '" + option + "') and @content-desc='Name']"), iosLocator: MobileBy.XPath(""));
        }
        public IList<IWebElement> AppliedMicroFilterText => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='AppliedMicroFilterText']"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> GetExpanderIconOfKPI(string kpiName)
        {
            return WaitAndFindElements(androidLocator: MobileBy.XPath("//*[contains(@text, '" + kpiName + "') and @content-desc='Title']/parent::*/parent::*/following-sibling::*/following-sibling::*/descendant::*[@content-desc='expanderIcon']"), iosLocator: MobileBy.XPath(""));
        }
        public IList<IWebElement> EditIcon => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='Edit']"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> GetAllKPIsTitles => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='Title']"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> ExpanderIcon => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='expanderIcon']"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> DeleteIcon => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='Delete']"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> ConfirmButton => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@text='YES']"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> UserCreatedTab => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[contains(@text,'Created ')]"), iosLocator: MobileBy.XPath(""));
        public IWebElement SelectAggregationTypeForKPIValues(string aggregationName)
        {
            return WaitAndFindElement(androidLocator: MobileBy.XPath("//*[contains(@content-desc, '" + aggregationName + "']"), iosLocator: MobileBy.XPath(""));
        }
        public IList<IWebElement> FieldAggregationTab => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='FieldSelected tab']"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> ChartAggregationTab => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='ChartSelected tab']"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> KPIValueTextField => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='ChartName']"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> PropertyFieldCombobox => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc=' Input Field']"), iosLocator: MobileBy.XPath(""));
        public IWebElement SelectProperty(string value)
        {
            return WaitAndFindElement(androidLocator: MobileBy.XPath("//*[contains(@text,'" + value + "')]"), iosLocator: MobileBy.XPath(""));
        }
        public IList<IWebElement> KPIConfigSaveButton => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='Create']"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> ShowPreviewButton => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='Kpipreview']"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> BackButton => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='back']"), iosLocator: MobileBy.XPath(""));
        public IWebElement GetKPIHeaderName(string value)
        {
            return WaitAndFindElement(androidLocator: MobileBy.XPath("//*[contains(@text,'" + value + "')]"), iosLocator: MobileBy.XPath(""));
        }

        #endregion KpisPage Elements

        #region KpisPage Actions

        public void SelectKPIToZoom(string kpiName)
        {
            try
            {
                //IList<IWebElement> zoomButton = GetKPIToZoom(kpiName);

                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
                while (GetKPIToZoom(kpiName).Count == 0)
                {
                    ScrollUp();
                }
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

                GetKPIToZoom(kpiName)[0].Click();
                WaitForMoment(2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"{kpiName} KPI is not available/configured to Zoom");
            }
        }

        public void SelectKPIToRefresh(string kpiName)
        {
            try
            {
                //IList<IWebElement> refreshButton = GetKPIToRefresh(kpiName);

                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
                while (GetKPIToRefresh(kpiName).Count == 0)
                {
                    ScrollUp();
                }
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

                GetKPIToRefresh(kpiName)[0].Click();
                WaitForMoment(2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"{kpiName} KPI is not available/configured to Zoom");
            }
        }

        public void SelectKPIToApplyFilterOn(string kpiName)
        {
            try
            {
                //IList<IWebElement> filterButton = GetKPIToApplyFilterOn(kpiName);

                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
                while (GetKPIToApplyFilterOn(kpiName).Count == 0)
                {
                    ScrollUp();
                }
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

                GetKPIToApplyFilterOn(kpiName)[0].Click();
                WaitForMoment(2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"{kpiName} KPI is not available/configured to Zoom");
            }
        }

        public FilterPage SelectMicroFilterOption(string option)
        {
            try
            {
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
                while (GetMicroFilterOption(option).Count == 0)
                {
                    ScrollUpInMicroFilterView();
                }
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

                GetMicroFilterOption(option)[0].Click();
                WaitForMoment(3);
                return new FilterPage(_driver);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"{option} Micro filter option is not available");
            }
            return null;
        }

        public void VerifyKpiPageTitle(string kpiName)
        {
            try
            {
                WaitForMoment(2);
                Assert.IsTrue(KpiPageTitle.Count > 0);
                Assert.IsTrue(KpiPageTitle[0].Displayed);
                Assert.IsTrue(KpiPageTitle[0].Text.Equals(kpiName));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"{kpiName} KPI is not Zoomed in.");
            }
        }

        public void SelectKPIToFavorite(string kpiName)
        {
            try
            {
                //IList<IWebElement> favoriteIcon = GetKPIToFavorite(kpiName);

                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
                while (GetKPIToFavorite(kpiName).Count == 0)
                {
                    ScrollUp();
                }
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

                GetKPIToFavorite(kpiName)[0].Click();
                WaitForMoment(5);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"{kpiName} KPI is not available/configured to Zoom");
            }
        }

        public void SelectKPIToEdit(string kpiName)
        {
            try
            {
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
                while (GetExpanderIconOfKPI(kpiName).Count == 0)
                {
                    ScrollUp();
                }
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

                GetExpanderIconOfKPI(kpiName)[0].Click();
                WaitForMoment(1);
                EditIcon[0].Click();
                WaitForMoment(5);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"{kpiName} KPI is not available for configuration");
            }
        }

        public void SelectKPIToDelete(string kpiName)
        {
            try
            {
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
                while (GetExpanderIconOfKPI(kpiName).Count == 0)
                {
                    ScrollUp();
                }
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

                GetExpanderIconOfKPI(kpiName)[0].Click();
                WaitForMoment(1);
                DeleteIcon[0].Click();
                WaitForMoment(1);
                ConfirmButton[0].Click();
                WaitForMoment(20);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"{kpiName} KPI is not available to delete");
            }
        }

        public void DeleteAllUserCreatedKPIs()
        {
            IList<IWebElement> kpiTitles = GetAllKPIsTitles;

            while (kpiTitles.Count > 0)
            {
                ExpanderIcon[0].Click();
                WaitForMoment(1);
                DeleteIcon[0].Click();
                WaitForMoment(1);
                ConfirmButton[0].Click();
                WaitForMoment(20);
            }
        }

        public void SelectUserCreatedTab()
        {
            if (UserCreatedTab.Count > 0)
            {
                UserCreatedTab[0].Click();
            }
        }

        public void ConfigureKPIWithValue(string aggregateType, string kpiTemplateName, string propertyValue)
        {
            SelectAggregationType(aggregateType);
            EnterKPIValueTitle(kpiTemplateName);
            SelectPropertyValue(propertyValue);
            ClickOnShowPreview();
            ClickOnBackButton();
            ClickOnSaveButton();
        }

        public void SelectAggregationType(string aggregationType)
        {
            IList<IWebElement> aggregateTab;

            if (aggregationType.Equals("Field"))
            {
                aggregateTab = FieldAggregationTab;

                if(aggregateTab.Count > 0)
                {
                    aggregateTab[0].Click();
                    LogInfo("Clicked on Field aggregate tab");
                }
            }

            if (aggregationType.Equals("Chart"))
            {
                aggregateTab = ChartAggregationTab;

                if (aggregateTab.Count > 0)
                {
                    aggregateTab[0].Click();
                    LogInfo("Clicked on Chart aggregate tab");
                }
            }
        }

        public void EnterKPIValueTitle(string kpiTitle)
        {
            if(KPIValueTextField.Count > 0)
            {
                KPIValueTextField[0].Click();
                KPIValueTextField[0].Clear();
                KPIValueTextField[0].SendKeys(kpiTitle);
                WaitForMoment(1);
                _driver.HideKeyboard();
            }
        }

        public void SelectPropertyValue(string propertyValue)
        {
            if(PropertyFieldCombobox.Count > 0)
            {
                PropertyFieldCombobox[0].Click();
                PropertyFieldCombobox[0].Clear();
                PropertyFieldCombobox[0].SendKeys(propertyValue);
                WaitForMoment(1);
            }
            _driver.HideKeyboard();
            WaitForMoment(1);
            IWebElement propertyValueElement = SelectProperty(propertyValue);
            new TouchAction(_driver).Tap(propertyValueElement).Perform();
            new Actions(_driver).SendKeys(Keys.Enter).Perform();
            WaitForMoment(1);
        }

        public void ClickOnSaveButton()
        {
            if(KPIConfigSaveButton.Count > 0)
            {
                KPIConfigSaveButton[0].Click();
                LogInfo("Clicked on Save KPI Button");
                WaitForMoment(2);
            }
        }

        public void ClickOnShowPreview()
        {
            if (ShowPreviewButton.Count > 0)
            {
                ShowPreviewButton[0].Click();
                LogInfo("Clicked on Show Preview Button");
                WaitForMoment(30);
            }
        }

        public void ClickOnBackButton()
        {
            if (BackButton.Count > 0)
            {
                BackButton[0].Click();
                LogInfo("Clicked on Back Button");
                WaitForMoment(2);
            }
        }

        public void VerifyKPIPresent(string kpiName, bool isPresent = false)
        {
            IList<IWebElement> charts = GetKPIToRefresh(kpiName);

            if (isPresent)
            {
                Assert.AreEqual(isPresent, charts.Count > 0, $"KPI Name:{kpiName} is found in the Charts Page after Delete Chart Operation.");
            }
            else
            {
                Assert.AreEqual(isPresent, charts.Count > 0, $"KPI Name:{kpiName} is not found in the Charts Page after Delete Chart Operation.");
            }
        }

        public void VerifyKPIName(string kPIName)
        {
            IWebElement kPITitle = GetKPIHeaderName(kPIName);
            Assert.AreEqual(kPIName, kPITitle.Text, $"KPI Name after zoom {kPITitle.Text} is not as expected value {kPIName}");
        }


        #endregion KpisPage Actions
    }
}
