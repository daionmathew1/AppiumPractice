using System;
using appiumpractice.Utilities;
using OpenQA.Selenium.Appium.Interfaces;

namespace appiumpractice
{
	public class Tc5 : Base
	{
        [Test()]
        public void TestCase()
        {
            InitializeGeneral();
          

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);


            driver.FindElementByXPath("//*[@text='Enter name here']").Click();
            driver.FindElementById("com.androidsample.generalstore:id/radioMale").Click();
            driver.FindElementById("com.androidsample.generalstore:id/spinnerCountry").Click();
            scrollAndClick("Brazil");
        }

    }
}

