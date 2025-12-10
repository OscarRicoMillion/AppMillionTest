using Microsoft.Extensions.Configuration;

namespace AppMillionTest.Configuration
{
    /// <summary>
    /// Singleton service for loading and accessing application configuration.
    /// </summary>
    public sealed class ConfigService
    {
        /// <summary>
        /// Singleton instance
        /// </summary>
        private static readonly Lazy<ConfigService> lazy = new Lazy<ConfigService>(() => new ConfigService());

        /// <summary>
        /// Gets the singleton instance of the ConfigService.
        /// </summary>
        public static ConfigService Instance { get { return lazy.Value; } }

        /// <summary>
        /// Configuration root
        /// </summary>
        public IConfigurationRoot Root { get; }

        /// <summary>
        /// Initializes a new instance of the ConfigService class.
        /// Loads configuration from appsettings.json at project root.
        /// </summary>
        private ConfigService()
        {
            Root = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                .Build();
        }

        /// <summary>
        /// Gets the username for authentication.
        /// </summary>
        /// <returns>The configured username.</returns>
        public string GetUserName()
        {
            return Root.GetValue<string>("UserName")
            ?? throw new InvalidOperationException("UserName is not configured in appsettings.json");   
        }

        /// <summary>
        /// Gets the OTP code for authentication.
        /// </summary>
        /// <returns>The configured OTP code.</returns>
        public string GetOtpCode()
        {
            return Root.GetValue<string>("OtpCode")
            ?? "1111";    
        }

        /// <summary>
        /// Gets the path to the .app bundle.
        /// </summary>
        /// <returns>The configured app path.</returns>
        /// <exception cref="FileNotFoundException">Thrown when the app bundle is not found.</exception>
        public string GetAppPath()
        {
            var appName = Root.GetValue<string>("AppPath") ?? "MillionAndUp.app";
            
            // Navigate from bin/Debug/net9.0 to project root
            var currentDir = Directory.GetCurrentDirectory();
            var projectRoot = Directory.GetParent(currentDir)?.Parent?.Parent?.FullName 
                ?? throw new InvalidOperationException("Unable to determine project root directory");
            
            var appPath = Path.Combine(projectRoot, "App", appName);
            
            return Directory.Exists(appPath) 
                ? appPath 
                : throw new FileNotFoundException($"App bundle not found at: {appPath}");
        }


        /// <summary>
        /// Gets the device name from appsettings.json.
        /// </summary>
        /// <returns>The configured device name.</returns>
        public string  GetDeviceName()
        {
            return Root.GetValue<string>("DeviceName")
            ?? "iPhone 17 Pro Max";
        }

        /// <summary>
        /// Gets the platform version from appsettings.json.
        /// </summary>
        /// <returns>The configured platform version.</returns>
        public string GetPlatformVersion()
        {
            return Root.GetValue<string>("PlatformVersion")
            ?? "26.1";
        }

        /// <summary>
        /// Gets the environment configuration indicating if running in pipeline.
        /// </summary>
        /// <returns>True if running in pipeline, false otherwise.</returns>   
        public bool GetEnviromentConfig()
        {
            return Root.GetValue<bool?>("RunConfiguration:IsPipeline")
            ?? true;
                 
        }

        /// <summary>
        /// Gets the Azure Blob Storage connection string from appsettings.json.
        /// </summary>
        /// <returns>The configured Azure Blob Storage connection string.</returns>
        public string GetAzureStorageConnectionString()
        {
            return Root.GetValue<string>("AzureStorage:ConnectionString")
                ?? throw new InvalidOperationException("AzureStorage:ConnectionString is not configured in appsettings.json");   
        }

        /// <summary>
        /// Gets the Azure Blob Storage container name from appsettings.json.
        /// </summary>
        /// <returns>The configured container name.</returns>
        public string GetAzureStorageContainerName()
        {
            return Root.GetValue<string>("AzureStorage:ContainerName")
                ?? "mobile-test-screenshots";   
        }

    }
}
