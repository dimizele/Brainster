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

namespace FinalExam
{
    public class FinalExam
    {
        public IWebDriver Driver;
        private WebDriverWait wait;
        static Random random = new Random();
        string password = "MyPassword";
        string email = "MyEmail@MyDummyEmail.com";
        string naslovNaBaranjeto = RandomStringOnlyLetters(random.Next(13, 19));
        string kategorija = "Цел камион";
        string OdAdresa;
        string DoAdresa;
        string brutoTezina = $"{random.Next(1000, 10000)} kg";
        string vkupenVolumen = $"{random.Next(100, 1000)} m3";
        //string naslovNaBaranjeto = RandomStringOnlyLetters(random.Next(13, 19));

        [SetUp]
        public void SetUp()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(15);
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl("http://138.201.81.153:9095/");
            wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
        }

        [Test]
        public void WhenINavigateToCargoDomICreateBaratel()
        {
            Driver.FindElement(By.CssSelector("span[translate='global.menu.account.register']")).Click();

            Driver.FindElement(By.CssSelector("button[ui-sref='register-client']")).Click();

            new SelectElement(Driver.FindElement(By.Name("clientType"))).SelectByText("Физичко лице");
            Driver.FindElement(By.Name("firstName")).SendKeys(RandomStringOnlyLetters(random.Next(7, 13)));
            Driver.FindElement(By.Name("lastName")).SendKeys(RandomStringOnlyLetters(random.Next(7, 13)));
            Driver.FindElement(By.Name("clientPersonAddress")).SendKeys(RandomStringOnlyLetters(random.Next(7, 13)));
            Driver.FindElement(By.Name("clientPersonCity")).SendKeys(RandomStringOnlyLetters(random.Next(7, 13)));
            Driver.FindElement(By.Name("clientPersonPostalCode")).SendKeys(RandomStringOnlyLetters(random.Next(7, 13)));
            Driver.FindElement(By.CssSelector("div[ng-model='vm.countries.selected']")).Click();
            Driver.FindElement(By.CssSelector("span[country='MK']")).Click();
            Driver.FindElement(By.Name("phoneNumber")).SendKeys(random.Next(100000000, 999999999).ToString());
            Driver.FindElement(By.Name("email")).SendKeys(email);
            Driver.FindElement(By.Name("password")).SendKeys(password);
            Driver.FindElement(By.Name("confirmPassword")).SendKeys(password);
            Driver.FindElement(By.Name("acceptTerms")).Click();
            Driver.FindElement(By.CssSelector("input[ng-click='form.$valid && vm.register()']")).Click();

            wait.Until(ExpectedConditions.UrlMatches("http://138.201.81.153:9095/account-type/register-provider/provider-successful-registration"));
            Assert.AreEqual("http://138.201.81.153:9095/account-type/register-provider/provider-successful-registration", Driver.Url);
        }

        [Test]
        public void WhenINavigateToCargoDomILogInAsBaratelAndICreateABaranje()
        {
            Driver.FindElement(By.Id("login")).Click();

            IWebElement LogInForm = Driver.FindElement(By.ClassName("modal-content"));
            LogInForm.FindElement(By.Id("username")).SendKeys(email);
            LogInForm.FindElement(By.Id("password")).SendKeys(password);
            LogInForm.FindElement(By.TagName("button")).Click();

            Driver.FindElement(By.Id("requestDetailsBtn")).Click();

            Driver.FindElement(By.Name("title")).SendKeys(naslovNaBaranjeto);
            new SelectElement(Driver.FindElement(By.Name("categoryType"))).SelectByText(kategorija);

            IWebElement OdAdresaContainer = Driver.FindElement(By.Name("pickUpAddress"));
            IWebElement OdAdresaInputField = OdAdresaContainer.FindElement(By.TagName("input"));
            OdAdresaInputField.SendKeys("Скопје");
            OdAdresaInputField.SendKeys(Keys.ArrowDown);
            OdAdresaInputField.SendKeys(Keys.Enter);
            OdAdresa = OdAdresaInputField.GetAttribute("value");

            IWebElement DoAdresaContainer = Driver.FindElement(By.Name("deliveryAddress"));
            IWebElement DoAdresaInputField = DoAdresaContainer.FindElement(By.TagName("input"));
            DoAdresaInputField.SendKeys("Скопје");
            DoAdresaInputField.SendKeys(Keys.ArrowDown);
            DoAdresaInputField.SendKeys(Keys.Enter);
            DoAdresa = DoAdresaInputField.GetAttribute("value");

            Driver.FindElement(By.Name("shipmentWeight")).SendKeys(brutoTezina);
            Driver.FindElement(By.Name("totalVolumeUnit")).SendKeys(vkupenVolumen);

            IWebElement TruckTypeContainer = Driver.FindElement(By.ClassName("truck-type"));
            List<IWebElement> allTruckTypes = TruckTypeContainer.FindElements(By.ClassName("col-sm-6 checkbox-container")).ToList();
            int randomTruckType = random.Next(0, allTruckTypes.Count);
            allTruckTypes[randomTruckType].FindElement(By.TagName("input")).Click();
            string truckType = allTruckTypes[randomTruckType].FindElement(By.TagName("label")).Text;
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
            Driver.Dispose();
        }

        public static string RandomStringOnlyLetters(int numberOfLetters)
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            return new string(Enumerable.Repeat(chars, numberOfLetters).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
