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
    public class ActivitiesAction : BaseAction
    {
        private readonly WindowsDriver<WindowsElement> _session;
        private readonly ActivitiesPage _pageInstance;

        public ActivitiesAction(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
            _pageInstance = new ActivitiesPage(_session);
        }

        public void ClickOnCreateCalendarConstruct()
        {
            ClickElement(_pageInstance.CreateCalendarConstruct);
            LogInfo("Clicked on create case");
            WaitForLoadingToDisappear();
            WaitForLoadingToDisappear();
        }
        public void SelectFutureOrPastDateFromToday(int numerOfDays)
        {
           String futureDate = GetDateFastOrFutureInFormat(DateTime.Now, "dd/MMMM/yyyy", numerOfDays);
            ClickElement(_pageInstance.GetDateInCalender(futureDate));
            WaitForMoment(2);
        }

        public void SelectFromDropDown(string entryText, String label)
        {
            EnterText(_pageInstance.SelectElementByLabel(label), entryText);
            LogInfo("Entered " + label);
        }
        public void EnterDataByLabel(String enterText, string label)
        {
            WaitForMoment(1);
            ClickClearEnterText(_pageInstance.ElementByLabel(label), enterText);
            LogInfo("Entered " + label);
            WaitForMoment(1);
        }
        public void SelectRadioButton(string buttonName)
        {
            ClickElement(_pageInstance.Radiobutton(buttonName));
            ClickElement(_pageInstance.Radiobutton(buttonName));
            LogInfo("Selected radio button " + buttonName);
        }
        public string SelectLink()
        {
            return SelectFirstValueInDropDown(_pageInstance.Link, "Value.Value");
        }
        public string SelectLinkByLabel(string label)
        {
            return SelectFirstValueInDropDown(_pageInstance.SelectLinkByLabel(label), "Value.Value");
        }
        
        public string GetDataByLabel(string label,string attribute)
        {
            return GetAttribute(_pageInstance.ElementByLabel(label), attribute);
        }
        public void SelectActivity(string activity)
        {
            ClickElement(_pageInstance.ButtonByName("+ Create Activity"));
            WaitForMoment(2);
            SelectFromDropDown(activity, "Select activity");
            WaitForMoment(2);
            ClickElement(_pageInstance.ButtonByName("Create Activity"));
            WaitForLoadingToDisappear();
        }

        public int CountButtonsByName(string buttonName)
        {
            int count = _pageInstance.ButtonListByName(buttonName).Count;
            return count;
        }

        public int CreateActivityButtonCount()
        {
            return CountButtonsByName("+ Create Activity");
        }

        /// <summary>
        /// EnterTask
        /// </summary>
        /// <param name="subject"></param>
        /// <param name="description"></param>
        /// <param name="priority"></param>
        /// <param name="reference"></param>
        /// <param name="status"></param>
        public List<string> EnterTask(string subject="subject",string description="description",string priority="Normal",
            string reference ="Contact",string status = "Open")
        {
            List<String> returnValues = new List<string>();
            EnterDataByLabel(subject, "Subject");
            EnterDataByLabel(description, "Description");
            SelectRadioButton(priority);
            SelectFromDropDown(reference, "Select Reference");
            WaitForLoadingToDisappear();
            string selectedLink = SelectLink();
            SelectRadioButton(status);
            returnValues.Add(selectedLink);
            returnValues.Add(GetDataByLabel("Start Time", "Value.Value"));
            returnValues.Add(GetDataByLabel("Due Time", "Value.Value"));
            return returnValues;
        }
        /// <summary>
        /// EnterAppointement
        /// </summary>
        /// <param name="title"></param>
        /// <param name="location"></param>
        /// <param name="recurrence"></param>
        /// <param name="description"></param>
        /// <param name="relatedTo"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public List<string> EnterAppointement(string title = "Title", string location = "Kansas", string recurrence = "Daily",
            string description = "Description",string relatedTo="Lead", string status = "Open")
        {
            List<String> returnValues = new List<string>();
            EnterDataByLabel(title, "Title");
            SelectLinkByLabel("Required Attendees");
            SelectLinkByLabel("Required Attendees");
            SelectLinkByLabel("Optional Attendees");
            SelectLinkByLabel("Optional Attendees");
            EnterDataByLabel(location, "Location");           
            SelectFromDropDown(recurrence, "Recurrence");
            EnterDataByLabel(description, "Description");
            SelectFromDropDown(relatedTo, "Related To");
            WaitForLoadingToDisappear();
            string selectedLink = SelectLink();
            SelectRadioButton(status);
            returnValues.Add(selectedLink);
            returnValues.Add(GetDataByLabel("Start Time", "Value.Value"));
            returnValues.Add(GetDataByLabel("End Time", "Value.Value"));
            return returnValues;
        }
        /// <summary>
        /// EnterPhoneCall
        /// </summary>
        /// <param name="reference"></param>
        /// <param name="callType"></param>
        /// <param name="phoneCode"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="priority"></param>
        /// <param name="subject"></param>
        /// <param name="description"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public List<string> EnterPhoneCall(string reference = "Contact", string callType = "Incoming", string phoneCode = "US",
           string phoneNumber = "9060666615", string priority = "High", string subject = "Subject",
           string description = "Description", string status = "Open")
        {
            List<String> returnValues = new List<string>();
            SelectFromDropDown(reference, "Select Reference");
            WaitForLoadingToDisappear();
            string selectedLink = SelectLink();
            SelectRadioButton(callType);
            SelectFromDropDown(phoneCode, "Phone number");
            EnterDataByLabel(phoneNumber, "Phone number");
            SelectRadioButton(priority);
            SelectLinkByLabel("Caller");
            SelectLinkByLabel("Recipient");
            EnterDataByLabel(subject, "Subject");
            EnterDataByLabel(description, "Description");
            SelectRadioButton(status);
            returnValues.Add(selectedLink);
            returnValues.Add(GetDataByLabel("Start Time", "Value.Value"));
            returnValues.Add(GetDataByLabel("End Time", "Value.Value"));
            return returnValues;
        }

        public void EnterStartAndDueTime(String startTime,String DueTime)
        {
            EnterDataByLabel(startTime, "Start Time");
            EnterDataByLabel(DueTime, "Due Time");
        }

        public void EnterStartAndEndTime(String startTime, String DueTime)
        {
            EnterDataByLabel(startTime, "Start Time");
            EnterDataByLabel(DueTime, "End Time");
        }

        public void ClickCreateButton()
        {
            ClickElement(_pageInstance.ButtonByName("Create"));
            WaitForLoadingToDisappear();
        }

        public void ClickSetupButton()
        {
            ClickElement(_pageInstance.ButtonByName("Setup"));
            WaitForLoadingToDisappear();
        }

        public void ClickUpdateButton()
        {
            ClickElement(_pageInstance.ButtonByName("Update"));
            WaitForLoadingToDisappear();
        }

        public void ValidateCreatedTaskInCalendar(String activity,string subject,string time,string label)
        {
            WaitForMoment(2);
            WaitForLoadingToDisappear();
            Boolean subjectandTimeValidation = false;
            var subjectElements = _pageInstance.CreatedActivitySubjectByNameInCalender(activity,label);
            var timeElements = _pageInstance.CreatedActivityTimeByNameInCalender(activity);
            for (int task=0;task <subjectElements.Count;task++)
            {
                string  subjectText = GetAttribute(subjectElements[task], "Name");
                String timeText = GetAttribute(timeElements[task ], "Name");
                if(subjectText.Equals(label+" - " + subject) && timeText.Equals("Time - " + time))
                {
                    subjectandTimeValidation = true;
                    break;
                }

            }
            Assert.IsTrue(subjectandTimeValidation);
            LogInfo("Validated activity " + activity + " in calendar construct");
            
        }

        public int NumberOfActivityByName(string activity)
        {
            var element = _pageInstance.CreatedActivityByNameInCalender(activity);
            return element.Count;        
        }

        public void ClickActivityByName(string activity)
        {
            WaitForLoadingToDisappear();
            WaitForMoment(3);
            var element = _pageInstance.CreatedActivityByNameInCalender(activity);
            ClickElement(element[0]);
            WaitForLoadingToDisappear();
        }


        public List<string> EnterCustomerVisit(string subject="Subject",string mediumOfVisit="Plant West",string appointement ="Appointment",
            string account="merck",string businessDevelopmetManager="Tan")
        {
            List<String> returnValues = new List<string>();
            SelectFromDropDown(appointement,"Appointment");
            EnterDataByLabel(subject, "Subject");
            ClickCustomerVisitDetails();
            SelectFromDropDown(account,"Account");
            SelectFromDropDown(mediumOfVisit, "Medium of visit");
            SelectLinkByLabel("West Program Name");
            SelectLinkByLabel("Attendees from West");
            SelectLinkByLabel("Attendees from customer");
            SelectFromDropDown(businessDevelopmetManager,"Business Development Manager");
            returnValues.Add(subject);
            returnValues.Add(GetDataByLabel("Start Time", "Value.Value"));
            returnValues.Add(GetDataByLabel("End Time", "Value.Value"));
            return returnValues;
        }

        public void ClickCustomerVisitDetails()
        {
            ClickElement(_pageInstance.Tab("Customer Visit Details"));
        }
    }
}
