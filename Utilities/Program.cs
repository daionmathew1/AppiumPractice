using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace appiumpractice.Utilities
{
    class Program
    {
        static void Reports(string[] args)
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
            extent.Flush();
        }
    }
}
