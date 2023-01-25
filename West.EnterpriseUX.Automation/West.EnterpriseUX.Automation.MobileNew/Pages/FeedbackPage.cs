using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.MultiTouch;
using System;
using System.Collections.Generic;

namespace West.EnterpriseUX.Automation.MobileNew
{
    public class FeedbackPage : AppiumKeywords
    {
        public static AppiumDriver<IWebElement> _driver;
 
        public FeedbackPage(AppiumDriver<IWebElement> driver) : base(driver)
        {
            _driver = driver;
        }

        #region FeedbackPage Elements

        public IWebElement FeedbackPageTitle => WaitAndFindElement(androidLocator: MobileBy.XPath("//*[@text='Feedback']"), iosLocator: MobileBy.XPath("//*[@name='modalPageHeader' and @label='Feedback']"));
        public IWebElement RatingQuestion => WaitAndFindElement(androidLocator: MobileBy.XPath("//*[@text='How would you rate your experience?*']"), iosLocator: MobileBy.XPath("//*[@name='How would you rate your experience?*']"));
        public IList<IWebElement> RatingOptions => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='StarRating']/android.widget.LinearLayout/android.view.ViewGroup"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> Title => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@text='Title']"), iosLocator: MobileBy.XPath("//*[@name='Title']"));
        public IWebElement TitleAsterisk => WaitAndFindElement(androidLocator: MobileBy.XPath("//*[@text='Title']/following-sibling::*"), iosLocator: MobileBy.XPath("(//*[@name='*'])[1]"));
        public IWebElement TitleTextBox => WaitAndFindElement(androidLocator: MobileBy.XPath("//*[@content-desc='feedbackTitle']"), iosLocator: MobileBy.XPath("//*[@name='feedbackTitle']"));
        public IWebElement Description => WaitAndFindElement(androidLocator: MobileBy.XPath("//*[@text='Description']"), iosLocator: MobileBy.XPath("//*[@name='Description']"));
        public IWebElement DescriptionAsterisk => WaitAndFindElement(androidLocator: MobileBy.XPath("//*[@text='Description']/following-sibling::*"), iosLocator: MobileBy.XPath("(//*[@name='*'])[2]"));
        public IWebElement DescriptionTextBox => WaitAndFindElement(androidLocator: MobileBy.XPath("//*[@content-desc='feedbackDescription']"), iosLocator: MobileBy.XPath("//*[@name='feedbackDescription']"));
        public IWebElement EmployeesToNotify => WaitAndFindElement(androidLocator: MobileBy.XPath("//*[@text='Employees to Notify']"), iosLocator: MobileBy.XPath("//*[@name='Employees to Notify']"));
        public IWebElement EmployeesToNotifyComboBox => WaitAndFindElement(androidLocator: MobileBy.XPath("//*[@content-desc='OptionalReceipients Input Field']"), iosLocator: MobileBy.XPath("//*[@name='OptionalReceipients Input Field']"));
        public IList<IWebElement> SelectEmployeeName(string name)
        {
            return WaitAndFindElements(androidLocator: MobileBy.XPath("//*[contains(@text,'" + name + "')]"), iosLocator: MobileBy.XPath("//*[contains(@value,'" + name + "')]"));
        }
        public IList<IWebElement> ConsentText1 => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@text='I agree to include the above screenshot in my feedback.']"), iosLocator: MobileBy.XPath("//*[@name='I agree to include the above screenshot in my feedback.']"));
        public IList<IWebElement> ConsentCheckbox1 => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@text='I agree to include the above screenshot in my feedback.']/preceding-sibling::android.view.ViewGroup/child::android.widget.CompoundButton"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> ConsentText2 => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@text='I agree to share the information on this page with West Digital Team and any other employee mentioned to notify for further assistance.*']"), iosLocator: MobileBy.XPath("//*[@name='I agree to share the information on this page with West Digital Team and any other employee mentioned to notify for further assistance.*']"));
        public IList<IWebElement> ConsentCheckbox2 => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='consentForFeedback']"), iosLocator: MobileBy.XPath("//*[@name='consentForFeedback']"));
        public IList<IWebElement> SubmitButton => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='SubmitButton']"), iosLocator: MobileBy.XPath("//*[@name='Submit']"));
        public IList<IWebElement> OkConfirmation => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@text='OK']"), iosLocator: MobileBy.XPath("//*[contains(@name,'OK')]"));

        #endregion FeedbackPage Elements

        #region FeedbackPage Actions

        public void SelectEmployee(string employeeName)
        {
            try
            {
                if(EmployeesToNotifyComboBox != null)
                {
                    EmployeesToNotifyComboBox.Click();
                    EmployeesToNotifyComboBox.Clear();
                    EmployeesToNotifyComboBox.SendKeys(employeeName);

                    WaitForMoment(3);

                    IList<IWebElement> selectEmployee = SelectEmployeeName(employeeName);
                    int x = selectEmployee[0].Location.X; 
                    int y = selectEmployee[0].Location.Y; 

                    if (selectEmployee.Count > 0)
                    {
                        new TouchAction(_driver).Tap(selectEmployee[0]).Perform();
                        _driver.HideKeyboard();
                    }
                    else
                        LogInfo("selectEmployee element not found");
                }
                else
                {
                    LogInfo("EmployeesToNotifyComboBox is not displayed");
                }
            }
            catch (Exception ex)
            {
                LogInfo("Employee name is not selected");
                LogInfo(ex.ToString());
            }
        }

        public void VerifyTheFieldsOnFeedbackPage(string mobPlatform)
        {
            CheckForCommonElememnts();

            if (mobPlatform.ToLower().Equals("android"))
            {
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
                while (SubmitButton.Count == 0)
                {
                    ScrollUp();
                }
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
                Assert.IsTrue(SubmitButton[0].Displayed);
                Assert.IsFalse(SubmitButton[0].Enabled);
            }

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
            while (Title.Count == 0)
            {
                ScrollDown();
            }
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }

        private void CheckForCommonElememnts()
        {
            Assert.IsTrue(FeedbackPageTitle.Displayed);
            Assert.IsTrue(RatingQuestion.Displayed);
            Assert.IsTrue(Title[0].Displayed);
            Assert.IsTrue(TitleAsterisk.Displayed);
            Assert.IsTrue(TitleTextBox.Displayed);
            Assert.IsTrue(TitleTextBox.Enabled);
            Assert.IsTrue(Description.Displayed);
            Assert.IsTrue(DescriptionAsterisk.Displayed);
            Assert.IsTrue(DescriptionTextBox.Displayed);
            Assert.IsTrue(DescriptionTextBox.Enabled);
            Assert.IsTrue(EmployeesToNotify.Displayed);
            Assert.IsTrue(EmployeesToNotifyComboBox.Displayed);
            Assert.IsTrue(EmployeesToNotifyComboBox.Enabled);

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
            while (ConsentText1.Count == 0)
            {
                ScrollUp();
            }
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            Assert.IsTrue(ConsentText1[0].Displayed);
            //Assert.IsTrue(ConsentCheckbox1[0].Displayed);
            //Assert.IsTrue(ConsentCheckbox1[0].Enabled);

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
            while (ConsentText2.Count == 0)
            {
                ScrollUp();
            }
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            Assert.IsTrue(ConsentText2[0].Displayed);
            Assert.IsTrue(ConsentCheckbox2[0].Displayed);
            Assert.IsTrue(ConsentCheckbox2[0].Enabled);
        }

        public void SelectRating(int num)
        {
            try
            {
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
                while (RatingOptions.Count == 0)
                {
                    ScrollDown();
                }
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
                RatingOptions[num].Click();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.WriteLine("Feedback rating is not selected");
            }   
        }

        public void SelectConsents()
        {
            try
            {
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
                while (ConsentCheckbox2.Count == 0)
                {
                    ScrollUp();
                }
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
                //ConsentCheckbox1[0].Click();
                ConsentCheckbox2[0].Click();
            }
            catch (Exception ex)
            {
                LogError(ex.ToString());
                LogError("Consent is not selected");
            }
        }

        public void VerifyAndSubmitTheFeedback()
        {
            try
            {
                if(SubmitButton.Count > 0)
                {
                    SubmitButton[0].Click();
                }
            }
            catch (Exception ex)
            {
                LogError(ex.ToString());
                LogError("Got an error while submitting the feedback");
            }
        }

        public void VerifyFeedbackConfirmation()
        {
            try
            {
                if (OkConfirmation.Count > 0)
                {
                    OkConfirmation[0].Click();
                }
            }
            catch (Exception ex)
            {
                LogError(ex.ToString());
                LogError("Did not get confirmation while submitting the feedback");
            }
        }

        #endregion FeedbackPage Actions
    }
}
