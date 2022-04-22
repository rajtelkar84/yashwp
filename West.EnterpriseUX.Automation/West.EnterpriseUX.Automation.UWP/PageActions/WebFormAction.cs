using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using West.EnterpriseUX.Automation.UWP.PageObjects;

namespace West.EnterpriseUX.Automation.UWP.PageActions
{
    public class WebFormAction : BaseAction
    {
        private readonly WindowsDriver<WindowsElement> _session;
        private readonly WebFormPage _pageInstance;

        public WebFormAction(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
            _pageInstance = new WebFormPage(_session);
        }

        public void ClickOnWebForm()
        {
            ClickElement(_pageInstance.CreateWebForm);
            LogInfo("Clicked on create web form");
            WaitForLoadingToDisappear();
        }

        public void ClickOnEditWebForm()
        {
            ClickElement(_pageInstance.EditWebForm);
            LogInfo("Clicked on create web form");
            WaitForLoadingToDisappear();
        }

        public void EnterName(String name)
        {
            ClickClearEnterText(_pageInstance.Name, name);
            LogInfo("Entered Name");
        }

        public void EnterSubject(String subject)
        {
            ClickClearEnterText(_pageInstance.Subject, subject);
            LogInfo("Entered subject");
        }

        public void SelectWebForm(String webform)
        {
            EnterText(_pageInstance.WebForm, webform);
            LogInfo("Selected web form");
        }

        public void SelectReference(String reference)
        {
            EnterText(_pageInstance.Reference, reference);
            LogInfo("Selected reference");
        }

        public string SelectLink()
        {
            String selectedValue = string.Empty;
            //EnterText(_pageInstance.Link, link);
            ClickElement(_pageInstance.Link);
            WaitForMoment(.25);
            EnterText(_pageInstance.Link, Keys.Down);
            WaitForMoment(.25);
            EnterText(_pageInstance.Link, Keys.Down);
            WaitForMoment(.25);
            EnterText(_pageInstance.Link, Keys.Return);
            WaitForMoment(.25);
            selectedValue = GetAttribute(_pageInstance.Link, "Value.Value");
            LogInfo("Selected link");
            return selectedValue;
            
        }

        public void SelectStartDate()
        {
            var date = DateTime.Now;
            EnterText(_pageInstance.StartDate, date.ToString("MMM dd, yyyy"));
            LogInfo("Selected start date");
        }

        public void SelectStartTime(String startTime)
        {
            ClickClearEnterText(_pageInstance.StartTime, startTime);
            LogInfo("Selected start Time");
        }

        public void ClickCreateButton()
        {
            ClickElement(_pageInstance.CreateWebFormButton);
            LogInfo("Clicked on create web form button");
            WaitForLoadingToDisappear();
        }

        public void ClickUpdateButton()
        {
            ClickElement(_pageInstance.UpdateWebFormButton);
            LogInfo("Clicked on update web form button");
            WaitForLoadingToDisappear();
        }

        /// <summary>
        /// To Web form Information
        /// </summary>
        /// <param name="name"></param>
        /// <param name="subject"></param>
        /// <param name="webForm"></param>
        /// <param name="reference"></param>
        /// <param name="startTime"></param>

        public string EnterWebForm(String name = "Name", String subject = "Subject", string webForm = "Bright Verify", string reference = "Prospect"
            , string startTime = "09:00 PM")
        {
            EnterName(name);
            EnterSubject(subject);
            SelectWebForm(webForm);
            SelectReference(reference);
            String selectedLink = SelectLink();
            //SelectStartDate();
            SelectStartTime(startTime);
            return selectedLink;
        }


        public void ValidateCreatedWebformInInboxGrid(String subject, String status, String type, String regarding)
        {
            WaitForLoadingToDisappear();
            WaitForMoment(2);
            List<String> firstRowValues = GetFirstRowValues();
            Assert.AreEqual(subject, firstRowValues[0]);
            Assert.AreEqual(status, firstRowValues[1]);
            Assert.AreEqual(type, firstRowValues[2]);        
            Assert.AreEqual(regarding, firstRowValues[4]);
            LogInfo("Verified created web form in inbox grid");
        }

        public List<String> GetFirstRowValues()
        {
            List<String> values = new List<String>();
            IList<WindowsElement> rowValues = _pageInstance.ValuebyRowAndColumnInGrid();
            if (rowValues.Equals(null))
            {
                rowValues = _pageInstance.ValuebyRowAndColumnInGrid();
            }
            for (int i = 0; i < rowValues.Count; i++)
            {
                values.Add(rowValues[i].Text);
            }

            return values;
        }

        public void ClickOnWebFormTab()
        {
            ClickElement(_pageInstance.CreateWebFormTab);
            LogInfo("Clicked on create web form tab");
            WaitForLoadingToDisappear();
        }

        public void ValidateWebFormInUpdatePage(List<String> input)
        {
            Assert.AreEqual(input[0], GetAttribute(_pageInstance.Subject, "Value.Value"));
            Assert.AreEqual(input[4], GetAttribute(_pageInstance.Link, "Value.Value"));
           
        }
    }
}
