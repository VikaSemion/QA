using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium1
{
    class PageObject
    {
        public PageObject()
        {
            PageFactory.InitElements(DriverCollection.driver, this);
        }

        [FindsBy(How = How.Id, Using = "txtUsername")]
        public IWebElement Login { get; set; }

        [FindsBy(How = How.Id, Using = "txtPassword")]
        public IWebElement Password { get; set; }

        [FindsBy(How = How.Id, Using = "btnLogin")]
        public IWebElement LogBut { get; set; }

        [FindsBy(How = How.Id, Using = "spanMessage")]
        public IWebElement Result { get; set; }

        [FindsBy(How = How.Id, Using = "changeUserPassword_currentPassword")]
        public IWebElement CurrentPass { get; set; }

        [FindsBy(How = How.Id, Using = "changeUserPassword_newPassword")]
        public IWebElement NewPass { get; set; }

        [FindsBy(How = How.Id, Using = "changeUserPassword_confirmNewPassword")]
        public IWebElement ConfirmedNewPass { get; set; }

        [FindsBy(How = How.Id, Using = "rightMenu")]
        public IWebElement frame { get; set; }

        [FindsBy(How = How.Id, Using = "messageBalloon_warning")]
        public IWebElement WrongCurrentPass { get; set; }

        [FindsBy(How = How.Id, Using = "messageBalloon_success")]
        public IWebElement SuccessPass { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='btnSave']")]
        public IWebElement SavePassBut { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='spanSocialMedia']/a[2]/img")]
        public IWebElement Facebook { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='spanSocialMedia']/a[3]/img")]
        public IWebElement Twitter { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='spanSocialMedia']/a[4]/img")]
        public IWebElement Youtube { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#spanCopyright > a")]
        public IWebElement OrangeHRM { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#option-menu > li:nth-child(2) > a")]
        public IWebElement ChangePass { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#frmChangePassword > label:nth-child(8)")]
        public IWebElement NewPassRequired { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#frmChangePassword > label:nth-child(13)")]
        public IWebElement ConfirmedNewPassRequired { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#frmChangePassword > label.error")]
        public IWebElement ConfirmedNewPassDoesntMatch { get; set; }




        public string ResultOfPage()
        {
            return Result.Text;
        }


        public void addLoginPassword(string login, string password)
        {
            Login.SendKeys(login);
            Password.SendKeys(password);
            LogBut.Click();
        }

        public void SwitchToTab()
        {
            var browserTabs = DriverCollection.driver.WindowHandles;
            DriverCollection.driver.SwitchTo().Window(browserTabs[1]);
        }

        public void returnToLogin()
        {
            DriverCollection.driver.Navigate().GoToUrl("https://s2.demo.opensourcecms.com/orangehrm/symfony/web/index.php/auth/login");
            LogBut.Click();
        }

        public void FacebookPage()
        {
            Facebook.Click();
            SwitchToTab();
        }

        public void TwitterPage()
        {
            Twitter.Click();
            SwitchToTab();
        }

        public void YoutubePage()
        {
            Youtube.Click();
            SwitchToTab();
        }

        public void OrangeHRMPage()
        {
            OrangeHRM.Click();
            SwitchToTab();
        }

        public void FillNewPass(string currentPass, string newPass, string confirmedNewPass)
        {

            SavePassBut.Click();
            CurrentPass.SendKeys(currentPass);
            NewPass.SendKeys(newPass);
            ConfirmedNewPass.SendKeys(confirmedNewPass);
            SavePassBut.Click();
        }


    }
}
