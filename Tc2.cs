using System;
using appiumpractice.Utilities;

namespace appiumpractice
{
	public class Tc2 : Base
	{
        [Test()]
        public void TestCase()
        {
            InitializeGeneral();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);


            driver.FindElementByXPath("//*[@text='Enter name here']").Click();
            driver.FindElementById("com.androidsample.generalstore:id/radioMale").Click();
        }   

    }
}

