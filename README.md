# 📱 AppMillionTest -- Mobile Automation Framework

![.NET](https://img.shields.io/badge/.NET-9.0-512BD4)
![Appium](https://img.shields.io/badge/Appium-8.0.1-5A0FC8)
![Platform-iOS](https://img.shields.io/badge/Platform-iOS-000000)
![Reqnroll](https://img.shields.io/badge/Reqnroll-BDD-0A6EBD)
![NUnit](https://img.shields.io/badge/NUnit-4.2.2-green)

Automated testing framework for the **MillionAndUp iOS application**,
built with Appium, .NET 9, BDD (Reqnroll), and Page Object Model
architecture.\
Designed for scalability, maintainability, and integration with CI/CD
pipelines.

------------------------------------------------------------------------

## 🚀 Features

-   Automated UI testing for iOS using **Appium WebDriver 8.0.1**
-   **BDD** test scenarios with Reqnroll (Gherkin)
-   **Page Object Model (POM)** for clean interaction abstraction
-   Environment-driven **Data Sources (CSV)**
-   Automatic **screenshot capture** on failures
-   Optional integration with **Azure Blob Storage** for evidence
-   Centralized configuration via `appsettings.json`

------------------------------------------------------------------------

## 🛠 Requirements

1.  **.NET 9 SDK**
2.  **Appium Server** running at `http://127.0.0.1:4723`
3.  **Xcode** + iOS Simulator
4.  `MillionAndUp.app` inside `/App` folder

------------------------------------------------------------------------

## ▶️ Run Tests

``` bash
# Run all tests
dotnet test
```

``` bash
# Run tests by tag/category
dotnet test --filter "TestCategory=notes"
```

``` bash
# Build project
dotnet build
```

------------------------------------------------------------------------

## 📱 iOS Simulator Commands

``` bash
# Boot simulator
xcrun simctl boot "iPhone 17 Pro Max"
open -a Simulator
```

``` bash
# List devices
xcrun simctl list devices
```

------------------------------------------------------------------------

## 🧱 Project Structure

    📂 AppMillionTest
     ├── Features/            # Gherkin feature files (Given/When/Then)
     ├── StepDefinitions/     # Reqnroll step bindings with NUnit
     ├── Pages/               # Page Object Model classes
     ├── Locators/            # Accessibility/XPath locators by screen
     ├── Drivers/             # IOSDriver lifecycle (Singleton)
     ├── Configuration/       # ConfigService, device models, settings
     ├── Infrastructure/      # ScreenshotService, AzureBlobService
     ├── Utilities/           # Common helpers and utilities
     ├── Hooks/               # Test lifecycle hooks (session, scenario)
     ├── DataSource/          # Environment-based CSVs
     ├── scripts/             # Automation scripts (set-datasource-env.sh)
     ├── Reports/             # Screenshots, logs, execution artifacts
     └── App/                 # MillionAndUp.app bundle

------------------------------------------------------------------------

## 🧩 Architecture Patterns

  Pattern                       Description
  ----------------------------- ------------------------------------------------
  **Singleton**                 Used in `IOSDriverFactory` and `ConfigService`
  **Page Object Model (POM)**   Encapsulates screen interactions
  **BDD (Reqnroll)**            Test scenarios using Gherkin syntax
  **Data-Driven Testing**       CSV files selected by environment

------------------------------------------------------------------------

## ⚙️ Configuration Layer

### `Configuration/`

-   **ConfigService.cs** -- Loads `appsettings.json`, exposes typed or
    dictionary configuration access\
-   **DeviceConfiguration.cs** -- Device model: Name, PlatformVersion,
    UDID\
-   **appsettings.json** -- Credentials, device settings, environment
    mode, Azure config, execution settings

### ✔ Environment-Driven DataSource (Copy-on-Demand)

**Structure:**
```
DataSource/
 ├── UserInformation.csv  (local environment, versioned)
 ├── stage/
 │   └── UserInformation.csv
 └── prod/
     └── UserInformation.csv
```

**How it works:**

1. **Features always use the same static path:**
   ```gherkin
   @DataSource:../../DataSource/UserInformation.csv
   ```

2. **Before running tests (stage/prod only), execute:**
   ```bash
   bash scripts/copy-datasource.sh
   ```

3. **The script automatically:**
   - **local**: Uses CSV files directly from `DataSource/` root (no copying needed)
   - **stage/prod**: Copies CSV files from `DataSource/<environment>/` to root

**Examples:**
- `"Environment": "local"` → Uses `DataSource/UserInformation.csv` (already there)
- `"Environment": "stage"` → Copies `DataSource/stage/*.csv` → `DataSource/*.csv`
- `"Environment": "prod"` → Copies `DataSource/prod/*.csv` → `DataSource/*.csv`

------------------------------------------------------------------------

## ☁️ Azure Blob Storage Integration

```{=html}
<details>
```
```{=html}
<summary>
```
`<strong>`{=html}Click to expand`</strong>`{=html}
```{=html}
</summary>
```
### Configuration Example (`appsettings.json`)

``` json
"AzureStorage": {
  "ConnectionString": "<secret>",
  "ContainerName": "smoketest"
}
```


### How It Works

-   `ScreenshotService` captures screenshots on test failures.\

-   `AzureBlobService` uploads them to Azure Blob Storage.\

-   Public URL is stored in:

        ScenarioContext["AzureScreenshotUrl"]

    for reporting pipelines.

```{=html}
</details>
```

------------------------------------------------------------------------

## 📌 Useful Commands (Quick Reference)

``` bash
dotnet build
dotnet test
dotnet test --filter "TestCategory=notes"
xcrun simctl boot "iPhone 17 Pro Max"
open -a Simulator
```

------------------------------------------------------------------------

## 👨‍💻 Development Team

**Million Luxury QA / Developer Team**
