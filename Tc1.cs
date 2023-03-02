using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using appiumpractice.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Chrome;

namespace appiumpractice
{
	public class Tc1 : Base
    {


        [Test()]
        public void TestCase()
        {
           
            
            BeforeClass();
            BeforeTest();
            InitializeHrms();
            string Path = "/Users/mathew.daion/Projects/appiumpractice/appiumpractice/Reports";
            //ExtentStart();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            AndroidElement user = driver.FindElementByXPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.view.View/android.view.View/android.view.View/android.view.View/android.widget.ScrollView/android.widget.ImageView[2]");
            user.Click();
            user.SendKeys("daionmathew");

            AndroidElement pass = driver.FindElementByXPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.view.View/android.view.View/android.view.View/android.view.View/android.widget.ScrollView/android.widget.ImageView[3]");
            pass.Click();
            pass.SendKeys("passjklzdjx");
            //ExtentStop();

            Console.WriteLine("gjhfgjhgj");
            TearDownAndroid();
            PassTest();
            AfterTest();
            AfterClass();
        }

    }
}

