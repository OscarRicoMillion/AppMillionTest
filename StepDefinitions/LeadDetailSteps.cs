using NUnit.Framework;
using AppMillionTest.Drivers;
using AppMillionTest.Pages;
using Reqnroll;
using OpenQA.Selenium.Appium;
using Allure.NUnit;

namespace AppMillionTest.StepDefinitions
{
    [Binding]
    [AllureNUnit]
    public class LeadDetailSteps
    {
        private readonly LeadDetailPage leadDetailPage;

        public LeadDetailSteps()
        {
            var driver = IOSDriverFactory.Driver;
            leadDetailPage = new LeadDetailPage(driver);
        }

        [When("taps the add icon to create an activity")]
        public void WhenTapsTheAddIconToCreateAnActivity()
        {
            leadDetailPage.ClickAddActivityIcon();
        }
    }
}
