using NUnit.Framework;
using AppMillionTest.Drivers;
using AppMillionTest.Pages;
using Reqnroll;
using OpenQA.Selenium.Appium;
using Allure.NUnit; // if you rely on Reqnroll utilities

namespace AppMillionTest.StepDefinitions
{
    [Binding]
    [AllureNUnit]
    public class LeadListSteps
    {
        private readonly LeadListPage leadListPage;
        private readonly UserPage userPage;
        public LeadListSteps()
        {
            var driver = IOSDriverFactory.Driver;
            leadListPage = new LeadListPage(driver);
            userPage = new UserPage(driver);
        }

        [Then("the lead list should load with the user icon visible")]
        public void ThenTheLeadListShouldLoadWithTheUserIconVisible()
        {
            var UserIconVisible = leadListPage.IconUserIsPresent();  

            Assert.That(UserIconVisible, Is.True, "User icon is not visible on the lead list.");
        }

         [When("taps the user icon")]
        public void WhenTapsTheUserIcon()
        {
            leadListPage.ClickUserIcon();
        }

        [When("picks a lead from the list")]
        public void WhenPicksALeadFromTheList()
        {
            leadListPage.ClickFirstLead();
        }
    }
}
