using Allure.NUnit;
using Allure.NUnit.Attributes;
using AppMillionTest.Drivers;
using AppMillionTest.Pages;
using AppMillionTest.Utilities;
using Reqnroll;

namespace AppMillionTest.StepDefinitions
{
    [Binding]
    [AllureNUnit]
    public class LoginUserSteps : CommonMethods // Inherits common methods for iOS testing
    {
        private readonly LoginUserPage loginUserPage;

        /// <summary>
        /// Initializes a new instance of the LoginUserSteps class.
        /// </summary>
        public LoginUserSteps() : base(IOSDriverFactory.Driver)
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
            AddAllureParameters("Username", username);// Log username to Allure report
            loginUserPage.EnterUsername(username);
        }

        [When("taps the Continue button")]
        public void WhenTapsTheContinueButton()
        {
            loginUserPage.ClickContinueButton();
        }






    }
}
