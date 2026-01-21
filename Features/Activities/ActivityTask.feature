@DataSource:../../DataSource/UserInformation.csv
Feature: Activity Task Features

  @task
  Scenario: Create a task activity successfully
    Given the user opens the Million app
    When enters the username "<user>"
    And taps the Continue button
    When enters the OTP "<OtpCode>"
    Then the lead list should load with the user icon visible
    When picks a lead from the list
    And taps the add icon to create an activity
    When chooses the 'Task' option
    And fills in the required task fields
    And taps the Save Task button
    Then the lead detail should display the newly created task activity
    And goes back to the lead list
    When taps the user icon
    And selects the Sing out option
    Then the user should be redirected to the login screen
