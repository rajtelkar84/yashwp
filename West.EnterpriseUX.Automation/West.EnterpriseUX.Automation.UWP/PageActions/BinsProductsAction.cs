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
    public class BinsProductsAction : BaseAction
    {
        private readonly WindowsDriver<WindowsElement> _session;
        private readonly BinsProductsPage _pageInstance;

        public BinsProductsAction(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
            _pageInstance = new BinsProductsPage(_session);

        }
        public void VerifyBinToBinMovementOption(string detailedAction)
        {
            WaitForMoment(1.5);
            IList<WindowsElement> detailedActionMenu = _pageInstance.SelectOverFlowMenuDot;
            _mouseActions.MoveToElement(detailedActionMenu[4]);
            _mouseActions.Click().Build().Perform();
            //MouseClickOnCenterOfWindowsElement(detailedActionMenu[2]);
            string value = _pageInstance.SelectMenuOption(detailedAction).Text;
            _pageInstance.SelectMenuOption(detailedAction).Click();

            Assert.AreEqual(detailedAction, value); ;
            LogInfo("***************************************");
            LogInfo("Bin - Bin Movement detailed action is present");

        }
        public void VerifyPostButtonIfMandatoryFieldsEmpty()
        {
            Boolean postBtnDestBinsFieldvalidation = _pageInstance.DestinationPostBtn.Enabled;
            Assert.IsFalse(postBtnDestBinsFieldvalidation, "Post button should be disabled until fill all mandatory field ");
        }

        public void VerifyPostButtonIfQualityIsZero()
        {
            string transferQuality = _pageInstance.TransferQualityTxtBox.Text;
            LogInfo("Transfer quality Value" + transferQuality);
            _pageInstance.TransferQualityTxtBox.Clear();
            _pageInstance.TransferQualityTxtBox.SendKeys("0");
            VerifyPostButtonIfMandatoryFieldsEmpty();
            _pageInstance.TransferQualityTxtBox.Clear();
            _pageInstance.TransferQualityTxtBox.SendKeys(transferQuality);
        }
        public void SelectValueFromPicker(string strorageBinvalue)
        {
            //Select Destination Bin value from picker

            WaitForMoment(1.5);
            IList<WindowsElement> selectPickerIcon = _pageInstance.SelectPicker;
            selectPickerIcon[0].Click();
            WaitForMoment(1);
            _pageInstance.SearchTextBox.Clear();
            WaitForMoment(1.5);
            _pageInstance.SearchTextBox.SendKeys(strorageBinvalue);
            WaitForMoment(4);
            IList<WindowsElement> storageBinNumber = _pageInstance.GetColumnText(strorageBinvalue);
            Assert.AreEqual(strorageBinvalue, storageBinNumber[0].Text, "Picker values are not loading");
            storageBinNumber[0].Click();
            WaitForMoment(1);


        }

        public void SelectValueFromReasonCodePicker(string reasonCodeValue)
        {

            //Select Reason code value from Picker
            WaitForMoment(1.5);
            IList<WindowsElement> selectPickerIcon = _pageInstance.SelectPicker;

            selectPickerIcon[2].Click();
            WaitForMoment(1);
            _pageInstance.SearchTextBox.Clear();
            WaitForMoment(1.5);
            _pageInstance.SearchTextBox.SendKeys(reasonCodeValue);
            WaitForMoment(4);
            IList<WindowsElement> reasonCodeNumber = _pageInstance.GetColumnText(reasonCodeValue);
            Assert.AreEqual(reasonCodeValue, reasonCodeNumber[0].Text, "Picker values are not loading");
            reasonCodeNumber[0].Click();

        }

        public void VerifyPopUP(string value)
        {

            WaitForMoment(1);
            _pageInstance.DestinationToggleBtn.Click();
            ClickPostButton();
            string ValidationText = _pageInstance.PopUpText.Text;
             Boolean ValidationTxt = ValidationText.Contains(value);
            Assert.IsTrue(ValidationTxt);
            LogInfo("Bin - Bin Movement ->after post click getting confirmation text" + ValidationText);
            _pageInstance.PopUpCancelBtn.Click();

        }
        public void ClickPostAndProceedButton()
        {
            ClickPostButton();
            WaitForMoment(1);
            _pageInstance.PopUpOkBtn.Click();
        }
        public void ClickPostButton()
        {
            WaitForMoment(1);
           _pageInstance.DestinationPostBtn.Click();
        }
        public void VerifyTheSuccessText()
        {
      
         WaitForMoment(1.5);
         string SuccessTxtVal = _pageInstance.SuccessText.Text;
         LogInfo("Success Text" + SuccessTxtVal);

         Boolean SuccessTxtV = SuccessTxtVal.Contains("Warehouse Order:")&& SuccessTxtVal.Contains("Task:");
         Assert.IsTrue(SuccessTxtV,"Value are not updated successfully in SAP");
       }
  
        public void SelectBatchCheckbox(int CheckBoxNumber)
        {
            WaitForMoment(1.5);
            _pageInstance.SelectBatchCheckBox(CheckBoxNumber).Click();
 
        }
        public void ClickOnBatchBintoBinAction()
        {
            WaitForMoment(1);
            _pageInstance.BatchBinBinMovementTxt.Click();
         }


    }       
}
