using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Appium.Android;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.iOS;

namespace Appium
{
    public class Class1
    {
        public AndroidDriver<AndroidElement> Driver;

        [SetUp]
        public void SetUp()
        {
            var appPath = @"C:\Users\Dimo\Desktop\Calculator_v7.8 (271241277)_apkpure.com.apk";

            AppiumOptions options = new AppiumOptions();
            options.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
            options.AddAdditionalCapability(MobileCapabilityType.DeviceName, "Android 30");
            options.AddAdditionalCapability(MobileCapabilityType.App, appPath);

            Driver = new AndroidDriver<AndroidElement>(new Uri("http://localhost:4723/wd/hub"), options);
        }

        [Test]
        public void Test()
        {
            Driver.FindElementById("com.google.android.calculator:id/digit_2").Click();
            Driver.FindElementByAccessibilityId("plus").Click();
            Driver.FindElementById("com.google.android.calculator:id/digit_2").Click();
            Driver.FindElementByAccessibilityId("equals").Click();
            AndroidElement result = Driver.FindElementById("com.google.android.calculator:id/result_final");

            Assert.AreEqual(4, int.Parse(result.Text));
        }
    }
}
