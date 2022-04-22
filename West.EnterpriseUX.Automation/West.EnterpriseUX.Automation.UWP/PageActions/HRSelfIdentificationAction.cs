using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using West.EnterpriseUX.Automation.UWP.PageObjects;
using System.IO;

namespace West.EnterpriseUX.Automation.UWP.PageActions
{
    public class HRSelfIdentificationAction : BaseAction
    {
        private readonly WindowsDriver<WindowsElement> _session;
        private readonly HRSelfIdentificationPage _pageInstance;

        public HRSelfIdentificationAction(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
            _pageInstance = new HRSelfIdentificationPage(_session);
        }
       
        
        public Boolean VerifySelfIdentificationMenuOptionPresent()
        {
            bool temp = false;
            try
            {
                if (_pageInstance.selfIdentificationMenuOption.Displayed)
                {
                    temp = true;
                }
                else
                {
                    temp = false;
                }
            }
            catch (Exception)
            {
                temp = false;
            }
            
            return temp;
           
        }

        public void selectSelfIdentificationMenu()
        {
            WaitForLoadingToDisappear();
            WaitForMoment(1);
            _pageInstance.selfIdentificationMenuOption.Click();
        }
        public void ClickEditSelfIdentification()
        {
            WaitForLoadingToDisappear();
            WaitForMoment(1);
            _pageInstance.selfIdentificationImage.Click();
            WaitForLoadingToDisappear();
            WaitForMoment(1);
            bool flag = _pageInstance.appBarSelfIdentification.Displayed;
        }
       
        public void clearFieldValues_SelfIdentification()
        {
            WaitForLoadingToDisappear();
            _pageInstance.EthnicityTextBox.Clear();
            _pageInstance.VeteranStatusTextBox.Clear();
            _pageInstance.StatusTextBox.Clear();

        }

        public void ClickOkButton()
        {
            _pageInstance.OkButton.Click();
            WaitForMoment(0.3);
        }
        public void ClickOnSave()
        {
            _pageInstance.SaveButton.Click();
            WaitForMoment(0.3);
        }

        public void EditSelfIdentification_EEO(string Ethnicity, string Race, string VeteranStatus, string ProtectedVeteranType, string DisabilityStatus)
        {
            WaitForLoadingToDisappear();
            
            //Select Ethnicity
            IList<WindowsElement> ethnicityPickerList =  _pageInstance.EthnicityPicker;
            ClickElement(ethnicityPickerList[ethnicityPickerList.Count-1]);
            SearchAndSelectValueFromPicker(Ethnicity);

            //Select Race I identify as if Ethnicity is Not Hispanic/Latino
            if(Ethnicity.ToLower().Equals("not hispanic/latino"))
            {
                IList<WindowsElement> racePickerList = _pageInstance.RacePicker;
                ClickElement(racePickerList[racePickerList.Count - 1]);
                SearchAndSelectValueFromPicker(Race);
            }

            
            //Select Veteran Status
            IList<WindowsElement> veteranStatusPickerList = _pageInstance.VeteranStatusPicker;
            ClickElement(veteranStatusPickerList[veteranStatusPickerList.Count - 1]);
            SearchAndSelectValueFromPicker(VeteranStatus);

            //Select Protected Veteran Type if Veteran status is Protected Veteran
            if (VeteranStatus.ToLower().Equals("protected veteran"))
            {
                selectProtectedVeteranType(ProtectedVeteranType);
            }
            //Select Discharge date when protected veteran type is Recently separated veteran
            if(ProtectedVeteranType.ToLower().Contains("recently separated veteran"))
            {
                SelectDischargeDate();
                WaitForMoment(0.6);
            }
            //Select Disability Status
            IList<WindowsElement> disabilityStatusPickerList = _pageInstance.DisabilityStatusPicker;
            ClickElement(disabilityStatusPickerList[disabilityStatusPickerList.Count - 1]);
            SearchAndSelectValueFromPicker(DisabilityStatus);
            
            ClickOnSave();
        }

        public void SearchAndSelectValueFromPicker(string value)
        {
            _pageInstance.SearchInGrid.Click();
            WaitForMoment(0.3);
            _pageInstance.SearchInGrid.SendKeys(value);
            WaitForMoment(0.3);
            _pageInstance.SearchButtonInPopUp.Click();
            WaitForMoment(0.3);
            _pageInstance.SelectSearchValue(value).Click();
        }

        public void selectProtectedVeteranType(string types)
        {
            string[] veteranTypes = types.Split('*');
            foreach(string veteranType in veteranTypes)
            {
                IList<WindowsElement> veteranTypeElements = _pageInstance.protectedVeteranType(veteranType);
                veteranTypeElements[(veteranTypeElements.Count-1)].Click();
            }
        }

        public void SelectDischargeDate()
        {
            WaitForLoadingToDisappear();
            _pageInstance.calendarDatePicker.Click();
            WaitForMoment(1);
            IList<WindowsElement> dateItems = _pageInstance.CalendarPopUpDateItems;
            if (dateItems.Count > 1)
                dateItems[(dateItems.Count-1)].Click();
        }

        public string fetchFieldValue(string fieldName)
        {
            string value = _pageInstance.SelfIDTextBox(fieldName).GetAttribute("Value.Value");
            return value;
        }

        public void ResetFunctionality_EEO(string Ethnicity, string Race, string VeteranStatus, string ProtectedVeteranType, string DisabilityStatus)
        {
            WaitForLoadingToDisappear();

            string initialEthnicity = fetchFieldValue("Ethnicity");
            string initialVeteranStatus = fetchFieldValue("Veteran Status");
            string initialDisabilityStatus = fetchFieldValue("Status");

            LogInfo($"Initial Ethnicity: {initialEthnicity}, Initial Veteran Status: {initialVeteranStatus}, Initial Disability Status: {initialDisabilityStatus}");

            //Select Ethnicity
            IList<WindowsElement> ethnicityPickerList = _pageInstance.EthnicityPicker;
            ClickElement(ethnicityPickerList[ethnicityPickerList.Count - 1]);
            SearchAndSelectValueFromPicker(Ethnicity);

            //Select Race I identify as if Ethnicity is Not Hispanic/Latino
            if (Ethnicity.ToLower().Equals("not hispanic/latino"))
            {
                IList<WindowsElement> racePickerList = _pageInstance.RacePicker;
                ClickElement(racePickerList[racePickerList.Count - 1]);
                SearchAndSelectValueFromPicker(Race);
            }

            //Select Veteran Status
            IList<WindowsElement> veteranStatusPickerList = _pageInstance.VeteranStatusPicker;
            ClickElement(veteranStatusPickerList[veteranStatusPickerList.Count - 1]);
            SearchAndSelectValueFromPicker(VeteranStatus);

            //Select Protected Veteran Type if Veteran status is Protected Veteran
            if (VeteranStatus.ToLower().Equals("protected veteran"))
            {
                selectProtectedVeteranType(ProtectedVeteranType);
            }
            //Select Discharge date when protected veteran type is Recently separated veteran
            if (ProtectedVeteranType.ToLower().Contains("recently separated veteran"))
            {
                SelectDischargeDate();
                WaitForMoment(0.6);
            }
            //Select Disability Status
            IList<WindowsElement> disabilityStatusPickerList = _pageInstance.DisabilityStatusPicker;
            ClickElement(disabilityStatusPickerList[disabilityStatusPickerList.Count - 1]);
            SearchAndSelectValueFromPicker(DisabilityStatus);

            ClickOnReset();
            WaitForMoment(1);
            
            string afterResetEthnicity = fetchFieldValue("Ethnicity");
            string afterResetVeteranStatus = fetchFieldValue("Veteran Status");
            string afterResetDisabilityStatus = fetchFieldValue("Status");
            Assert.AreEqual(initialEthnicity, afterResetEthnicity);
            Assert.AreEqual(initialVeteranStatus, afterResetVeteranStatus);
            Assert.AreEqual(initialDisabilityStatus, afterResetDisabilityStatus);
            LogInfo("======Reset EEO Functionality Validated Successfully======");
        }

        public void ClickOnReset()
        {
            _pageInstance.ResetButton.Click();
            WaitForMoment(0.3);
        }
        public void ValidatePopUpMessage(string expectedMessage)
        {
            WaitForElementToAppear(expectedMessage);
            Assert.IsTrue(_pageInstance.PopUpDialogMessage.Displayed);
            string popUpMessage = _pageInstance.PopUpDialogMessage.Text;
            Assert.AreEqual(expectedMessage, popUpMessage);
        }
        public void ClickOnOk()
        {
            _pageInstance.AcknowledgementOkButton.Click();
            WaitForMoment(0.3);
        }
    }
}

