# AppMillionTest - Appium .NET Test Automation

Mobile test automation project for MillionAndUp iOS app using:
- Appium
- .NET 9
- Reqnroll (Cucumber for .NET)
- NUnit

## Requirements
1. .NET 9 SDK
2. Appium Server
3. iOS Simulator/Device with MillionAndUp.app

## Run tests
\`\`\`bash
dotnet test
\`\`\`

## Project Structure
- \`Features/\`: .feature files (Gherkin)
- \`Pages/\`: Page Object Model  
- \`StepDefinitions/\`: Step implementations
- \`Drivers/\`: Appium configuration
- \`Utilities/\`: Helper methods
