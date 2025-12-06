@DataSource:../../DataSource/UserInformation.csv
Feature: Activity Notes Features

  @notes
  Scenario: Create a regular note
    Given the user opens the Million app
    When enters the username "<user>"
    And taps the Continue button
    When enters the OTP "<OtpCode>"
    Then the lead list should load with the user icon visible
    When picks a lead from the list
    And taps the add icon to create an activity
    When chooses the 'NOTE' option
    And types the note text 'Test automation note'
    And hits the Save Notes button
    Then the activity should show the note text, today's date, and the agent name 'by Agente Calidad stage'
    And goes back to the lead list
    When taps the user icon
    And selects the Sing out option
    Then the user should be redirected to the login screen


