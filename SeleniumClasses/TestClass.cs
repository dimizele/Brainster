using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumClasses
{
    [TestFixture]
    public class TestClass
    {
        private IWebDriver Driver;

        [SetUp]
        public void SetUp()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(15);
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl("http://138.201.81.153:9095/");
        }

        [Test]
        public void FirstTest()
        {
            IWebElement tableBody = Driver.FindElement(By.ClassName("table-body"));

            List<IWebElement> allRows = tableBody.FindElements(By.CssSelector("tr[ng-repeat='request in vm.requests | filter:cargo']")).ToList();

            IWebElement firstRow = allRows.First();

            IWebElement firstRowFourthColumn = firstRow.FindElement(By.CssSelector(".table-body__cell.column4"));

            Assert.AreEqual("Вкупна тежина:\r\n350,00 kg\r\nВкупен волумен:\r\n150,00 m3", firstRowFourthColumn.Text);
        }

        [Test]
        public void SecondTest()
        {
            IWebElement tableBody = Driver.FindElement(By.ClassName("table-body"));

            List<IWebElement> categoriesList = tableBody.FindElements(By.ClassName("column5")).ToList();

            int totalNumbersOfTrucks = 0;

            for (int i = 0; i < categoriesList.Count; i++)
            {
                if (categoriesList[i].Text.Equals("Цел камион"))
                {
                    totalNumbersOfTrucks++;
                }
            }

            Assert.AreEqual(2, totalNumbersOfTrucks);
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
            Driver.Dispose();
        }
    }
}
