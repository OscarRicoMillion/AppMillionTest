using AppMillionTest.Drivers;
using AppMillionTest.Pages;
using Reqnroll;

namespace AppMillionTest.StepDefinitions
{
    [Binding]
    public class LoginUserSteps
    {
        private readonly LoginUserPage loginUserPage;


        public LoginUserSteps()
        {
            var driver = IOSDriverFactory.Driver;
            loginUserPage = new LoginUserPage(driver);

        }

        [Given("the user opens the Million app")]
        public void GivenTheUserOpensTheMillionApp()
        {
            IOSDriverFactory.LaunchApp();
        }

        [When("enters the username \"(.*)\"")]
        public void WhenEntersTheUsername(string username)
        {
              loginUserPage.EnterUsername(username);
        }

        [When("taps the Continue button")]
        public void WhenTapsTheContinueButton()
        {
            loginUserPage.ClickContinueButton();
        }






    }
}
