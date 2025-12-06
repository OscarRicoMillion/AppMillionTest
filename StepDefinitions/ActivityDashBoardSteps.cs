using NUnit.Framework;
using AppMillionTest.Drivers;
using AppMillionTest.Pages;
using Reqnroll;
using OpenQA.Selenium.Appium;
using AppMillionTest.Utilities;
using System.Globalization;


namespace AppMillionTest.StepDefinitions
{
    [Binding]
    public class ActivityDashBoardSteps : CommonMethods
    {
        private readonly ActivityDashBoardPage activityDashBoardPage;
        private readonly LeadDetailPage leadDetailPage;
        private readonly LoadActions loadActions;
        private readonly ScenarioContext scenarioContext;

        public ActivityDashBoardSteps(ScenarioContext scenarioContext) : base(IOSDriverFactory.Driver)
        {

            activityDashBoardPage = new ActivityDashBoardPage(Driver);
            leadDetailPage = new LeadDetailPage(Driver);
            this.scenarioContext = scenarioContext;
            loadActions = new LoadActions(Driver);

        }

        [When("chooses the '(.*)' option")]
        public void WhenChoosesTheOption(string option)
        {
            activityDashBoardPage.SelectNoteOption();
        }

        [When("types the note text '([^']*)'")]
        public void WhenTypesTheNoteText(string note)
        {
            activityDashBoardPage.EnterNoteText(note);
            scenarioContext["noteText"] = note;
        }

        [When("hits the Save Notes button")]
        public void WhenHitsTheSaveNotesButton()
        {
            activityDashBoardPage.ClickSaveNotes();
            Assert.That(loadActions.ValidateLoadingIcon(), Is.True, "Loading screen did not finish on time.");
        }

        [Then("the activity should show the note text, today's date, and the agent name '([^']*)'")]
        public void ThenTheActivityShouldShowTheNoteDetails(string agentName)
        {
            
            var note = scenarioContext["noteText"] as string;

            // Get the text from the lead detail page and compare
            var actualNote = leadDetailPage.GetLatestNoteText();
            Assert.That(actualNote, Does.Contain(note), "Created note does not match the typed text.");
            Assert.That(actualNote, Does.Contain(agentName), "Created note should include the agent name.");


            var CurrentDate = DateTime.Now.ToString("MMM dd, yyyy", CultureInfo.InvariantCulture);
            Assert.That(actualNote, Does.Contain(CurrentDate), "Created note is missing today's date.");

            Console.WriteLine($"✅ Current date: {CurrentDate}");
            Console.WriteLine($"✅ Expected note: {note}");
            Console.WriteLine($"✅ Actual note: {actualNote}");
            Console.WriteLine($"✅ Expected agent: {agentName}");

        }

        [Then("goes back to the lead list")]
        public void ThenGoesBackToTheLeadList()
        {
            GoBack();
        }

        
        
    }
}
