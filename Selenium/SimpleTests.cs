using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Selenium
{
    [TestFixture]
    public class SimpleTests
    {
        private IWebDriver Driver;

        [SetUp]
        public void SetUp()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            //Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(15);
            Driver.Manage().Window.Maximize();
        }

        [Test]
        public void FirstTest()
        {
            Driver.Navigate().GoToUrl("http://138.201.81.153:9095/");

            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));

            By locatorForOdAdresa = By.CssSelector("input[placeholder='Од адреса...']");

            wait.Until(ExpectedConditions.ElementExists(locatorForOdAdresa));
            
            //Find OdAdresa field
            IWebElement OdAdresa = Driver.FindElement(locatorForOdAdresa);
            IWebElement OdAdresa2 = Driver.FindElement(locatorForOdAdresa);

            wait.Until(ExpectedConditions.ElementToBeClickable(OdAdresa));

            List<IWebElement> lista = new List<IWebElement>()
            {
                OdAdresa,
                OdAdresa2
            };

            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(lista.AsReadOnly()));

            //wait.Until(DotNetSeleniumExtras)

            //Check Element is intractable
            if (OdAdresa.Displayed && OdAdresa.Enabled)
            {
                //Click OdAdresa field
                OdAdresa.Click();

                //Clear OdAdresa field
                OdAdresa.Clear();

                //Write Skopje in OdAdresa field
                OdAdresa.SendKeys("Skopje");
            }

            //Assert we wrote the write thing
            Assert.AreEqual("Skopje", OdAdresa.Text);


            //Close the whole browser
            Driver.Quit();

            //Release the memory of the browser
            Driver.Dispose();
        }

        [Test]
        public void iFrameTestNegative()
        {
            Driver.Navigate().GoToUrl("https://www.w3schools.com/tags/tryit.asp?filename=tryhtml_iframe");

            IWebElement logo = Driver.FindElement(By.ClassName("w3schools-logo"));

            logo.Click();
        }

        [Test]
        public void iFrameTestPositive()
        {
            Driver.Navigate().GoToUrl("https://www.w3schools.com/tags/tryit.asp?filename=tryhtml_iframe");

            //IWebElement firstIFrameElement = Driver.FindElement(By.Id("iframeResult"));

            Driver.SwitchTo().Frame("iframeResult");

            IWebElement h1Tag = Driver.FindElement(By.TagName("h1"));

            Assert.AreEqual("The iframe element", h1Tag.Text);

            IWebElement iFrameElement = Driver.FindElement(By.CssSelector("iframe[title='W3Schools Free Online Web Tutorials']"));

            Driver.SwitchTo().Frame(iFrameElement);

            IWebElement logo = Driver.FindElement(By.ClassName("w3schools-logo"));

            Driver.Navigate().GoToUrl("https://www.google.com/");

            logo.Click();

            Driver.SwitchTo().ParentFrame();

            Assert.AreEqual("The iframe element", h1Tag.Text);

            Driver.SwitchTo().DefaultContent();

            IWebElement mainPageContainer = Driver.FindElement(By.Id("container"));

            //logo.Click();
        }

        [Test]
        public void TabSwitching()
        {
            Driver.Navigate().GoToUrl("http://138.201.81.153:9095/");

            //IWebElement OdAdresa = Driver.FindElement(By.CssSelector("input[placeholder='Од адреса...']"));
            //OdAdresa.Click();
            //OdAdresa.Clear();
            //OdAdresa.SendKeys("Skopje");

            //((IJavaScriptExecutor)Driver).ExecuteScript("window.open();");

            //OdAdresa.Clear();

            //Driver.SwitchTo().Window(Driver.WindowHandles.Last());

            //Driver.Navigate().GoToUrl("https://www.google.com/");

            //OdAdresa.Click();

            //Driver.SwitchTo().Window(Driver.WindowHandles.First());

            //OdAdresa.Click();

            string documentReady;
            int loadingwaitTime = 15;

            for (int i = 0; i < loadingwaitTime; i++)
            {
                documentReady = ((IJavaScriptExecutor)Driver).ExecuteScript("return document.readyState") as string;
                if (documentReady.Equals("complete"))
                {
                    break;
                }

                Thread.Sleep(1000);
            }

            documentReady = ((IJavaScriptExecutor)Driver).ExecuteScript("return document.readyState") as string;


        }

        [Test]
        public void PositiveScenario()
        {
            Driver.Navigate().GoToUrl("https://www.w3schools.com/tags/tryit.asp?filename=tryhtml_iframe");

            Driver.SwitchTo().Frame("iframeResult");

            IWebElement h1Element = Driver.FindElement(By.TagName("h1"));

            IWebElement iFrameElement = Driver.FindElement(By.CssSelector("iframe[title='W3Schools Free Online Web Tutorials']"));

            Driver.SwitchTo().Frame(iFrameElement);

            IWebElement logo = Driver.FindElement(By.ClassName("w3schools-logo"));

            Driver.SwitchTo().ParentFrame();

            Func<By, IWebElement> SearchWebElement = (locator) => Driver.FindElement(locator);

            IWebElement test = Driver.FindElement(By.ClassName(""));

            //IWebElement FindLogo() => Driver.FindElement(By.ClassName("w3schools-logo"));

            Assert.AreEqual("The iframe element", h1Element.Text);
        }

        public IWebElement SearchWebElementFunc(By locator)
        {
            return Driver.FindElement(locator);
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
            Driver.Dispose();
        }
    }
}
