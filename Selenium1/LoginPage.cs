using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Selenium1
{
    [TestFixture]
    public class LoginPage
    {
       
        static void Main(string[] args)
        {

        }

        [SetUp]
        public void Setup()
        {
            DriverCollection.driver = new ChromeDriver();
            DriverCollection.driver.Navigate().GoToUrl("https://s2.demo.opensourcecms.com/orangehrm/symfony/web/index.php/auth/login");
            Console.WriteLine("URL was opened.");
        }

       
        [Test]
        public void ValidLoginValidPass()
        {
            PageObject page = new PageObject();
            page.addLoginPassword("opensourcecms", "opensourcecms");
            Console.WriteLine("UN and PW were entered.Login button was clicked.");

            Assert.AreEqual(DriverCollection.driver.Url,
           "https://s2.demo.opensourcecms.com/orangehrm/index.php");
        }

        [Test]
        public void SecurityNavigation()
        {
            PageObject page = new PageObject();
            page.addLoginPassword("opensourcecms", "opensourcecms");
            Console.WriteLine("UN and PW were entered.Login button was clicked.");



            page.returnToLogin();
            Console.WriteLine("Login button was clicked the second time.");

            Assert.AreEqual("Username cannot be empty", page.ResultOfPage());
        }

        [Test]
        public void InvalidLoginValidPass()
        {
            PageObject page = new PageObject();
            page.addLoginPassword("1", "opensourcecms");
            Console.WriteLine("UN and PW were entered.Login button was clicked.");

            Assert.AreEqual(DriverCollection.driver.Url, 
            "https://s2.demo.opensourcecms.com/orangehrm/symfony/web/index.php/auth/validateCredentials");
            Assert.AreEqual("Invalid credentials", page.ResultOfPage());
        }

        [Test]
        public void ValidLoginInvalidPass()
        {
            PageObject page = new PageObject();
            page.addLoginPassword("opensourcecms", "1");
            Console.WriteLine("UN and PW were entered.Login button was clicked.");

            Assert.AreEqual(DriverCollection.driver.Url,
            "https://s2.demo.opensourcecms.com/orangehrm/symfony/web/index.php/auth/validateCredentials");
            Assert.AreEqual("Invalid credentials", page.ResultOfPage());
        }

        [Test]
        public void InvalidLoginInvalidPass()
        {
            PageObject page = new PageObject();
            page.addLoginPassword("1", "1");
            Console.WriteLine("UN and PW were entered.Login button was clicked.");

            Assert.AreEqual(DriverCollection.driver.Url,
            "https://s2.demo.opensourcecms.com/orangehrm/symfony/web/index.php/auth/validateCredentials");
            Assert.AreEqual("Invalid credentials", page.ResultOfPage());
        }

        [Test]
        public void ValidLoginSensitivePass()
        {
            PageObject page = new PageObject();
            page.addLoginPassword("opensourcecms", "opensoUrcecms");
            Console.WriteLine("UN and PW were entered.Login button was clicked.");

            Assert.AreEqual(DriverCollection.driver.Url,
            "https://s2.demo.opensourcecms.com/orangehrm/symfony/web/index.php/auth/validateCredentials");
            Assert.AreEqual("Invalid credentials", page.ResultOfPage());
        }

        [Test]
        public void NonsensativeLoginValidPass()
        {
            PageObject page = new PageObject();
            page.addLoginPassword("OPENSOURCECMS", "opensourcecms");
            Console.WriteLine("UN and PW were entered.Login button was clicked.");

            Assert.AreEqual(DriverCollection.driver.Url,
           "https://s2.demo.opensourcecms.com/orangehrm/index.php");
        }

        [Test]
        public void ValidLoginBlankPass()
        {
            PageObject page = new PageObject();
            page.addLoginPassword("opensourcecms", "");
            Console.WriteLine("UN and PW were entered.Login button was clicked.");

            Assert.AreEqual("Password cannot be empty", page.ResultOfPage());
        }

        [Test]
        public void BlankLoginValidPass()
        {
            PageObject page = new PageObject();
            page.addLoginPassword("", "opensourcecms");
            Console.WriteLine("UN and PW were entered.Login button was clicked.");

            Assert.AreEqual("Username cannot be empty", page.ResultOfPage());
        }

        [Test]
        public void BlankLoginBlankPass()
        {
            PageObject page = new PageObject();
            page.addLoginPassword("", "");
            Console.WriteLine("UN and PW were entered.Login button was clicked.");

            Assert.AreEqual("Username cannot be empty", page.ResultOfPage());
        }


        [Test]
        public void PathFacebook()
        {
            PageObject page = new PageObject();
            page.FacebookPage();
            Console.WriteLine("Button Facebook was clicked.");
            
            Assert.AreEqual("https://www.facebook.com/OrangeHRM",
                DriverCollection.driver.Url);
        }

        [Test]
        public void PathTwitter()
        {
            PageObject page = new PageObject();
            page.TwitterPage();
            Console.WriteLine("Button Twitter was clicked.");

            Assert.AreEqual("https://twitter.com/orangehrm",
                DriverCollection.driver.Url);
        }

        [Test]
        public void PathYoutube()
        {
            PageObject page = new PageObject();
            page.YoutubePage();
            Console.WriteLine("Button Youtube was clicked.");

            Assert.AreEqual("https://www.youtube.com/results?search_query=orangehrm&search_type=",
                DriverCollection.driver.Url);
        }

        [Test]
        public void PathOrangeHRM()
        {
            PageObject page = new PageObject();
            page.OrangeHRMPage();
            Console.WriteLine("Button OrabgeHRM was clicked.");

            Assert.AreEqual("https://www.orangehrm.com/",
                DriverCollection.driver.Url);
        }


        [TearDown]
        public void Cleanup()
        {
            DriverCollection.driver.Quit();
        }


    }
}
