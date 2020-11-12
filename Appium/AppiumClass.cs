using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;

namespace Appium
{
    [TestFixture]
    public class AppiumClass
    {
        public AndroidDriver<AndroidElement> Driver;
        private string numberId = "com.google.android.calculator:id/digit_";

        public void ThisIsTheSetUpMethod()
        {
            var appPath = @"C:\Users\Dimo\Desktop\Calculator_v7.8 (271241277)_apkpure.com.apk";

            AppiumOptions options = new AppiumOptions();
            options.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
            options.AddAdditionalCapability(MobileCapabilityType.DeviceName, "Android 30");
            options.AddAdditionalCapability(MobileCapabilityType.App, appPath);

            Driver = new AndroidDriver<AndroidElement>(new Uri("http://localhost:4723/wd/hub"), options);

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(3000);
        }

        [SetUp]
        public void SetUp()
        {
            ThisIsTheSetUpMethod();
        }

        [Test]
        public void Addition()
        {
            Driver.FindElementById("com.google.android.calculator:id/digit_2").Click();
            Driver.FindElementByAccessibilityId("plus").Click();
            Driver.FindElementByXPath("/hierarchy/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.view.ViewGroup/android.widget.LinearLayout/androidx.slidingpanelayout.widget.SlidingPaneLayout/android.widget.LinearLayout/android.view.ViewGroup[1]/android.widget.Button[2]").Click();
            Driver.FindElementByAccessibilityId("equals").Click();
            AndroidElement result = Driver.FindElementById("com.google.android.calculator:id/result_final");

            Assert.AreEqual(10, Convert.ToInt32(result.Text));
        }

        [TestCase(7,6, ExpectedResult = 42)]
        [TestCase(21, 44, ExpectedResult = 924)]
        [Test]
        public int Multiplication(int firstMultiplier, int secondMultiplier)
        {
            SelectMultiplier(firstMultiplier);
            SelectOperand(Operands.Multiply);
            SelectMultiplier(secondMultiplier);

            AndroidElement formula = Driver.FindElementById("com.google.android.calculator:id/formula");

            Assert.AreEqual($"{firstMultiplier}×{secondMultiplier}", formula.Text);

            SelectOperand(Operands.Equals);

            AndroidElement result = Driver.FindElementById("com.google.android.calculator:id/result_final");

            return Convert.ToInt32(result.Text);
        }

        [Test]
        public void ThemeChange()
        {
            Driver.FindElementByAccessibilityId("More options").Click();
            Driver.FindElementByXPath(@"/hierarchy/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.ListView/android.widget.LinearLayout[2]/android.widget.LinearLayout").Click();

            AndroidElement defaultTheme = Driver.FindElementByXPath(@"/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.support.v7.widget.LinearLayoutCompat/android.widget.FrameLayout/android.widget.ListView/android.widget.CheckedTextView[3]");
            Assert.IsTrue(Convert.ToBoolean(defaultTheme.GetAttribute("checked")));

            Driver.FindElementByXPath(@"/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.support.v7.widget.LinearLayoutCompat/android.widget.FrameLayout/android.widget.ListView/android.widget.CheckedTextView[2]").Click();
            Driver.FindElementById("android:id/button1").Click();

            Driver.FindElementByAccessibilityId("More options").Click();
            Driver.FindElementByXPath(@"/hierarchy/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.ListView/android.widget.LinearLayout[2]/android.widget.LinearLayout").Click();
            AndroidElement darkTheme = Driver.FindElementByXPath(@"/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.support.v7.widget.LinearLayoutCompat/android.widget.FrameLayout/android.widget.ListView/android.widget.CheckedTextView[2]");
            Assert.IsTrue(Convert.ToBoolean(darkTheme.GetAttribute("checked")));
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }

        public void SelectMultiplier(int multiplier)
        {
            if (multiplier > 9)
            {
                int a = multiplier / 10;
                int b = multiplier % 10;
                Driver.FindElementById($"{numberId}{a}").Click();
                Driver.FindElementById($"{numberId}{b}").Click();
            }
            else
            {
                Driver.FindElementById($"{numberId}{multiplier}").Click();
            }
        }

        public void SelectOperand(Operands operand)
        {
            if (operand == Operands.Divide)
            {
                Driver.FindElementByAccessibilityId(operand.ToString().ToLower()).Click();
            }
            else if (operand == Operands.Multiply)
            {
                Driver.FindElementByAccessibilityId(operand.ToString().ToLower()).Click();
            }
            else if (operand == Operands.Minus)
            {
                Driver.FindElementByAccessibilityId(operand.ToString().ToLower()).Click();
            }
            else if (operand == Operands.Plus)
            {
                Driver.FindElementByAccessibilityId(operand.ToString().ToLower()).Click();
            }
            else if (operand == Operands.Equals)
            {
                Driver.FindElementByAccessibilityId(operand.ToString().ToLower()).Click();
            }
        }
    }

    public enum Operands
    {
        Divide,
        Multiply,
        Minus,
        Plus,
        Equals
    }
}
