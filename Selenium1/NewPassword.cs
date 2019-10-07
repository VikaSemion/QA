using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace Selenium1
{
    class NewPassword
    {

        [SetUp]
        public void Setup()
        {
            DriverCollection.driver = new ChromeDriver();
            DriverCollection.driver.Navigate().GoToUrl("https://s2.demo.opensourcecms.com/orangehrm/symfony/web/index.php/auth/login");
            Console.WriteLine("URL was opened.");
        }
        [Test]
        public void ChangePassSuccessful()
        {
            PageObject page = new PageObject();
            page.addLoginPassword("opensourcecms", "opensourcecms");
            Console.WriteLine("UN and PW were entered.Login button was clicked.");
            page.ChangePass.Click();
            DriverCollection.driver.SwitchTo().Frame(page.frame);
            page.FillNewPass("opensourcecms", "opensourcecms", "opensourcecms");
            Assert.AreEqual("Successfully Changed", page.SuccessPass.Text);
        }

        [Test]
        public void ChangePassBlankNewPassAndRepeat()
        {
            PageObject page = new PageObject();
            page.addLoginPassword("opensourcecms", "opensourcecms");
            Console.WriteLine("UN and PW were entered.Login button was clicked.");
            page.ChangePass.Click();
            DriverCollection.driver.SwitchTo().Frame(page.frame);
            page.FillNewPass("opensourcecms", "", "");
            Assert.AreEqual("Required", page.NewPassRequired.Text);
            Assert.AreEqual("Required", page.ConfirmedNewPassRequired.Text);
        }

        [Test]
        public void ChangePassBlankRepeatPass()
        {
            PageObject page = new PageObject();
            page.addLoginPassword("opensourcecms", "opensourcecms");
            Console.WriteLine("UN and PW were entered.Login button was clicked.");
            page.ChangePass.Click();
            DriverCollection.driver.SwitchTo().Frame(page.frame);
            page.FillNewPass("opensourcecms", "newpassword", "");
            Assert.AreEqual("Required", page.ConfirmedNewPassDoesntMatch.Text);
        }

        [Test]
        public void ChangePassNewDoesntMatch()
        {
            PageObject page = new PageObject();
            page.addLoginPassword("opensourcecms", "opensourcecms");
            Console.WriteLine("UN and PW were entered.Login button was clicked.");
            page.ChangePass.Click();
            DriverCollection.driver.SwitchTo().Frame(page.frame);
            page.FillNewPass("opensourcecms", "newpassword", "newpass");
            Assert.AreEqual("Passwords do not match", page.ConfirmedNewPassDoesntMatch.Text);
        }

        [Test]
        public void ChangePassWrongCurrentPass()
        {
            PageObject page = new PageObject();
            page.addLoginPassword("opensourcecms", "opensourcecms");
            Console.WriteLine("UN and PW were entered.Login button was clicked.");
            page.ChangePass.Click();
            DriverCollection.driver.SwitchTo().Frame(page.frame);
            page.FillNewPass("open", "newpassword", "newpassword");
            Assert.AreEqual("Current Password Is Wrong", page.WrongCurrentPass.Text);
        }

        [TearDown]
        public void Cleanup()
        {
           DriverCollection.driver.Quit();
        }
    }
}
