using System;
using System.Net.Http;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Interfaces;
using Newtonsoft.Json.Linq;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;


namespace appiumpractice.Utilities
{
    public class Base : ExtentReport
    {
        public static AndroidDriver<AndroidElement> driver;


        public AndroidDriver<AndroidElement> InitializeHrms()
        {

            AppiumOptions options = new AppiumOptions();
            options.AddAdditionalCapability(MobileCapabilityType.PlatformName, Startup.ReadFromAppSettings("App"));
            options.AddAdditionalCapability(MobileCapabilityType.DeviceName, Startup.ReadFromAppSettings("DeviceName"));
            options.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, Startup.ReadFromAppSettings("OSVersion"));
            options.AddAdditionalCapability(AndroidMobileCapabilityType.AppPackage, Startup.ReadFromAppSettings("AppPackage"));
            options.AddAdditionalCapability(AndroidMobileCapabilityType.AppActivity, Startup.ReadFromAppSettings("AppActivity"));
            options.AddAdditionalCapability("chromedriverExecutable", @"Users/mathew.daion/Downloads/chromedriver");
            options.AddAdditionalCapability("avdLaunchTimeout", "300000");
            driver = new AndroidDriver<AndroidElement>(new Uri("http://localhost:4723/wd/hub"), options);
            
            return driver;
        }

        public AndroidDriver<AndroidElement> InitializeChrome()
        {

            AppiumOptions options = new AppiumOptions();
            options.AddAdditionalCapability(MobileCapabilityType.PlatformName, Startup.ReadFromAppSettings("App"));
            options.AddAdditionalCapability(MobileCapabilityType.DeviceName, Startup.ReadFromAppSettings("DeviceName"));
            options.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, Startup.ReadFromAppSettings("OSVersion"));
            options.AddAdditionalCapability(AndroidMobileCapabilityType.AppPackage, Startup.ReadFromAppSettings("AppPackage"));
            options.AddAdditionalCapability(AndroidMobileCapabilityType.AppActivity, Startup.ReadFromAppSettings("AppActivity"));
            options.AddAdditionalCapability("chromedriverExecutable", @"Users/mathew.daion/Downloads/chromedriver");
            options.AddAdditionalCapability("avdLaunchTimeout", "300000");



            driver = new AndroidDriver<AndroidElement>(new Uri("http://localhost:4723/wd/hub"), options);

            return driver;
        }


       
        public AndroidDriver<AndroidElement> InitializeGeneral()
        {

            AppiumOptions options = new AppiumOptions();
            options.AddAdditionalCapability(MobileCapabilityType.PlatformName, Startup.ReadFromAppSettings("App"));
            options.AddAdditionalCapability(MobileCapabilityType.DeviceName, Startup.ReadFromAppSettings("DeviceName"));
            options.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, Startup.ReadFromAppSettings("OSVersion"));
            options.AddAdditionalCapability(AndroidMobileCapabilityType.AppPackage, Startup.ReadFromAppSettings("AppPackage"));
            options.AddAdditionalCapability(AndroidMobileCapabilityType.AppActivity, Startup.ReadFromAppSettings("AppActivity"));
            options.AddAdditionalCapability("chromedriverExecutable", @"Users/mathew.daion/Downloads/chromedriver");
            options.AddAdditionalCapability("avdLaunchTimeout", "300000");



            driver = new AndroidDriver<AndroidElement>(new Uri("http://localhost:4723/wd/hub"), options);

            return driver;
        }
        public AndroidDriver<AndroidElement> TearDownAndroid()
        {
            driver.Quit();
            return driver;
        }

        public AndroidDriver<AndroidElement> Screenshot(string name)
        {
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile(name, ScreenshotImageFormat.Png);
            return driver;
        }

        public void scrollAndClick(String visibleText)
        {
            driver.FindElementByAndroidUIAutomator("new UiScrollable(new UiSelector().scrollable(true).instance(0)).scrollIntoView(new UiSelector().textContains(\"" + visibleText + "\").instance(0))").Click();
        }


        public AndroidDriver<AndroidElement> StartRecord()
        {
            driver.StartRecordingScreen(AndroidStartScreenRecordingOptions
                           .GetAndroidStartScreenRecordingOptions()
                           .WithTimeLimit(TimeSpan.FromMinutes(1))
                           .EnableBugReport());

            return driver;
        }

        public AndroidDriver<AndroidElement> StopRecord()
        {
           
            string outputFolder = @"/Users/mathew.daion/Documents";
            String video = driver.StopRecordingScreen();
            byte[] decode = Convert.FromBase64String(video);

           

            string fileName = $"{DateTime.Now:yyyyMMdd-HHmmss}.mp4";
            string filePath = Path.Combine(outputFolder, fileName);
            File.WriteAllBytes(filePath, decode);
            



            return driver;
           

        }

        public AndroidDriver<AndroidElement> Screenshot()
        {
                
                string outputFolder = @"/Users/mathew.daion/Projects/appiumpractice/appiumpractice/bin/Debug/net7.0";

                ITakesScreenshot screenshotDriver = driver as ITakesScreenshot;
                Screenshot screenshot = screenshotDriver.GetScreenshot();

                string fileName = $"{DateTime.Now:yyyyMMdd-HHmmss}.png";

               
                string filePath = Path.Combine(outputFolder, fileName);

                screenshot.SaveAsFile(filePath,ScreenshotImageFormat.Png);

            return driver;


        }


        public ExtentReports extent = new ExtentReports();
        public static ExtentTest test;
        //public static ExtentReports extent;
        //[OneTimeSetUp]
        public void ExtentStart()
        {
            string Path = "/Users/mathew.daion/Projects/appiumpractice/appiumpractice/Reports/file1.html";
            
            var htmlReporter = new ExtentHtmlReporter(Path);
            extent.AttachReporter(htmlReporter);
            
            


        }

        public void ExtentStop()
        {
            var test = extent.CreateTest("My Test");
            test.Log(Status.Info, "Step 1");
            test.Log(Status.Pass, "Step 2");
            extent.Flush();


        }


        public void Reports(string[] args)
        {
            // Initialize the Extent Report
            var extent = new ExtentReports();
            var htmlReporter = new ExtentHtmlReporter("extent.html");
            extent.AttachReporter(htmlReporter);

            // Create a test
            var test = extent.CreateTest("My Test");

            // Add test steps
            test.Log(Status.Info, "Step 1");
            test.Log(Status.Pass, "Step 2");

            // End the test
           



        }

    }

}
