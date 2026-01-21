using NUnit.Framework;
using AppMillionTest.Drivers;
using AppMillionTest.Pages;
using Reqnroll;
using OpenQA.Selenium.Appium;
using AppMillionTest.Utilities;
using Allure.NUnit; // si usas las utilidades de Reqnroll

namespace AppMillionTest.StepDefinitions
{
    [Binding]
    [AllureNUnit]
    public class UserSteps
    {
        private readonly UserPage userPage;
        private readonly LoginUserPage loginUserPage;

        private readonly LoadActions loadActions;

        public UserSteps()
        {
            var driver = IOSDriverFactory.Driver;
            userPage = new UserPage(driver);
            loginUserPage = new LoginUserPage(driver);
            loadActions = new LoadActions(driver);
        }

        [When("selects the Sing out option")]
        [Then("selects the Sing out option")]
        public void WhenSelectsTheSingOutOption()
        {
            userPage.ClickSignOutOption();
            userPage.ClickYesOption();
            Assert.That(loadActions.ValidateLoadingIcon(), Is.True, "Loading icon did not behave as expected during log out.");
        }

        [Then("picks the option to change the user status")]
        [When("picks the option to change the user status")]
        public void WhenPicksTheOptionToChangeTheUserStatus()
        {
            userPage.ClickChangeStatusOption();
        }

        [Then("the user status should switch")]
        public void ThenTheUserStatusShouldSwitch()
        {
            var firstStatus = userPage.GetStatusText();
            Console.WriteLine($"✅ First status is '{firstStatus}'.");

            var lastStatus = userPage.ChangeUserStatus();
            Console.WriteLine($"✅ Second status is '{lastStatus}'.");

            if(firstStatus == "Avaliable")
                Assert.That(lastStatus, Is.EqualTo("Do Not Disturb"), "User status did not change to Do Not Disturb.");
            
            else if (firstStatus == "Do Not Disturb")
                Assert.That(lastStatus, Is.EqualTo("Avaliable"), "User status did not change to Avaliable.");               
        }

        [Then("the user should be redirected to the login screen")]
        public void ThenTheUserShouldBeRedirectedToTheLoginScreen()
        {
            // Ensure the login field is visible again (using LoginUserPage)
            var isLoginVisible = loginUserPage.IsLoginScreenVisible();
            Assert.That(isLoginVisible, Is.True, "User was not redirected to the login screen");
        }


    }
}
