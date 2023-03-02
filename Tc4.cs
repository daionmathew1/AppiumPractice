using System;
using appiumpractice.Utilities;
using OpenQA.Selenium.Appium.Android;

namespace appiumpractice
{
	public class Tc4 : Base
	{
        [Test()]
        public void TestCase()
        {
            InitializeChrome();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            AndroidElement AcceptButton = driver.FindElementById("com.android.chrome:id/terms_accept");
            AcceptButton.Click();
            AndroidElement YesButton = driver.FindElementById("com.android.chrome:id/positive_butto");
            YesButton.Click();
            driver.Navigate().GoToUrl("https://www.carwale.com/lamborghini-cars/huracan-evo/");
            scrollAndClick("Lamborghini Huracan Evo Price");


        }
    }
}

