using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Coypu.NUnit;
using Coypu;
using Coypu.Drivers;
using Coypu.NUnit.Matchers;
using Coypu.Drivers.Selenium;

//with Coypu
namespace Selenium1
{
    class MenuNavigation
    {
        protected BrowserSession browser;

        [SetUp]
        public void SetUp()
        {
            browser = new BrowserSession(new SessionConfiguration
            {
                AppHost = "s2.demo.opensourcecms.com",
                Browser = Browser.Chrome
            });
            browser.Visit("/orangehrm/symfony/web/index.php/auth/login");
            browser.FindId("txtUsername").FillInWith("opensourcecms");
            browser.FindId("txtPassword").FillInWith("opensourcecms");

            browser.ClickButton("LOGIN");
        }

        [Test]
        public void MenubarAdmin()
        {
            browser.FindCss("#admin > a > span").Hover();

            Assert.That(browser, Shows.Css("#admin > ul > li:nth-child(1) > a > span", text: "Organization"));
            Assert.That(browser, Shows.Css("#admin > ul > li:nth-child(2) > a > span", text: "Job"));
            Assert.That(browser, Shows.Css("#admin > ul > li:nth-child(3) > a > span", text: "Qualification"));
            Assert.That(browser, Shows.Css("#admin > ul > li:nth-child(4) > a > span", text: "Memberships"));
            Assert.That(browser, Shows.Css("#admin > ul > li:nth-child(5) > a > span", text: "Nationalities"));
            Assert.That(browser, Shows.Css("#admin > ul > li:nth-child(6) > a > span", text: "Users"));
        }

        [Test]
        public void MenubarPIM()
        {
            browser.FindCss("#pim > a > span").Hover();

            Assert.That(browser, Shows.Css("#pim > ul > li:nth-child(1) > a > span", text: "Configuration"));
            Assert.That(browser, Shows.Css("#pim > ul > li:nth-child(2) > a > span", text: "Employee List"));
            Assert.That(browser, Shows.Css("#pim > ul > li:nth-child(3) > a > span", text: "Add Employee"));
            Assert.That(browser, Shows.Css("#pim > ul > li:nth-child(4) > a > span", text: "Reports"));
        }
    /**
        [Test]
        public void MenubarLeave()
        {
            browser.FindCss("#leave > a > span").Hover();

            Assert.That(browser, Shows.Css("#leave > ul > li:nth-child(1) > a > span", text: "Configure"));
            Assert.That(browser, Shows.Css("#leave > ul > li:nth-child(2) > a > span", text: "Leave Summary"));
            Assert.That(browser, Shows.Css("#leave > ul > li:nth-child(3) > a > span", text: "Leave List"));
            Assert.That(browser, Shows.Css("#leave > ul > li:nth-child(4) > a > span", text: "Assign Leave"));
        }

        [Test]
        public void MenubarTime()
        {
            browser.FindCss("#time > a > span").Hover();

            Assert.That(browser, Shows.Css("#time > ul > li:nth-child(1) > a > span", text: "Timesheets"));
            Assert.That(browser, Shows.Css("#time > ul > li:nth-child(2) > a > span", text: "Attendance"));
            Assert.That(browser, Shows.Css("#time > ul > li:nth-child(3) > a > span", text: "Reports"));
        } **/

        [Test]
        public void MenubarRecruitment()
        {
            browser.FindCss("#recruit > a > span").Hover();

            Assert.That(browser, Shows.Css("#recruit > ul > li:nth-child(1) > a > span", text: "Candidates"));
            Assert.That(browser, Shows.Css("#recruit > ul > li:nth-child(2) > a > span", text: "Vacancies"));
        }

        [Test]
        public void MenubarPerformance()
        {
            browser.FindCss("#perform > a > span").Hover();

            Assert.That(browser, Shows.Css("#perform > ul > li:nth-child(1) > a > span", text: "KPI List"));
            Assert.That(browser, Shows.Css("#perform > ul > li:nth-child(2) > a > span", text: "Add KPI"));
            Assert.That(browser, Shows.Css("#perform > ul > li:nth-child(3) > a > span", text: "Copy KPI"));
            Assert.That(browser, Shows.Css("#perform > ul > li:nth-child(4) > a > span", text: "Add Review"));
            Assert.That(browser, Shows.Css("#perform > ul > li:nth-child(5) > a > span", text: "Reviews"));
        }

        [Test]
        public void MenubarHelp()
        {
            browser.FindCss("#help > a > span").Hover();

            Assert.That(browser, Shows.Css("#help > ul > li:nth-child(1) > a > span", text: "Support"));
            Assert.That(browser, Shows.Css("#help > ul > li:nth-child(2) > a > span", text: "Forum"));
            Assert.That(browser, Shows.Css("#help > ul > li:nth-child(3) > a > span", text: "Blog"));
            Assert.That(browser, Shows.Css("#help > ul > li:nth-child(4) > a > span", text: "Training"));
            Assert.That(browser, Shows.Css("#help > ul > li:nth-child(5) > a > span", text: "Add-Ons"));
        }

        [TearDown]
        public void TearDown()
        {
           browser.Dispose();
        }
    }
}
