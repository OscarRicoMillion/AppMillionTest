@DataSource:../../DataSource/UserInformation.csv
Feature: Login Features

  @login
  Scenario: Successful login and Sing out
    Given the user opens the Million app
    When enters the username "<user>"
    And taps the Continue button
    When enters the OTP "<OtpCode>"
    Then the lead list should load with the user icon visible
    When taps the user icon
    And selects the Sing out option
    Then the user should be redirected to the login screen


  Scenario: Switch user status
    Given the user opens the Million app
    When enters the username "<user>"
    And taps the Continue button
    When enters the OTP "<OtpCode>"
    Then the lead list should load with the user icon visible
    When taps the user icon
    And picks the option to change the user status
    Then the user status should switch
    When selects the Sing out option
    Then the user should be redirected to the login screen




