# AppMillionTest - Appium .NET Test Automation

Mobile test automation project for MillionAndUp iOS app using:
- **Appium WebDriver 8.0.1** - Mobile automation framework
- **.NET 9.0** - Target framework
- **Reqnroll 3.2.1** - BDD/Gherkin testing framework
- **NUnit 4.2.2** - Test runner
- **Microsoft.Extensions.Configuration 9.0.0** - Configuration management

## Requirements
1. .NET 9 SDK
2. Appium Server running on `http://127.0.0.1:4723`
3. Xcode with iOS Simulator
4. MillionAndUp.app bundle in the `App/` folder

## Run Tests
\`\`\`bash
# Run all tests
dotnet test

# Build project
dotnet build
\`\`\`

## Project Structure

### **Features/**
Gherkin feature files written in English using BDD syntax with Given/When/Then steps.

### **StepDefinitions/**
NUnit test classes that implement the Gherkin steps defined in feature files.

### **Pages/**
Page Object Model classes representing app screens.

### **Locators/**
Accessibility ID and XPath locators organized by screen.

### **Drivers/**
Appium IOSDriver lifecycle management with Singleton pattern.

### **Configuration/**
Configuration management layer for reading application settings.
- **ConfigService.cs** - Singleton service loading `appsettings.json` with methods to access configuration values
- **appsettings.json** - Centralized configuration for credentials, device settings, and execution mode

### **Infrastructure/**
Infrastructure services that interact with external systems or perform actions with side effects.
- **ScreenshotService.cs** - Captures and saves screenshots on test failure to `Reports/` folder

### **Utilities/**
Reusable helper classes and common methods for test execution.

### **Hooks/**
Reqnroll hooks managing test lifecycle (session, scenario, and step levels).

### **DataSource/**
CSV files for data-driven testing scenarios.

### **Reports/**
Output folder for test execution artifacts (screenshots, logs).

### **App/**
iOS application bundle folder containing `MillionAndUp.app/`.

## Architecture Patterns

- **Singleton Pattern** - IOSDriverFactory and ConfigService
- **Page Object Model** - Screen interactions encapsulated in page classes
- **BDD with Reqnroll** - Gherkin syntax for readable test scenarios
- **Data-Driven Testing** - CSV data sources for parameterized tests
