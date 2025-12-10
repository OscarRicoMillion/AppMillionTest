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
        /// Supports both local execution (from project root) and pipeline execution (from bin output).
        /// </summary>
        /// <returns>The configured app path.</returns>
        /// <exception cref="FileNotFoundException">Thrown when the app file is not found.</exception>
        public string GetAppPath()
        {
            var appName = Root.GetValue<string>("AppPath") ?? "MillionAndUp.app";
            var currentDir = Directory.GetCurrentDirectory();

            // Strategy 1: Check in current directory (pipeline - App copied to bin/Debug/net9.0)
            var pathInCurrentDir = Path.Combine(currentDir, "App", appName);
            Console.WriteLine($"🔍 Checking path in current dir: {pathInCurrentDir}");
            if (Directory.Exists(pathInCurrentDir))
            {
                Console.WriteLine($"✅ App found at: {pathInCurrentDir}");
                return pathInCurrentDir;
            }

            // Strategy 2: Navigate from bin/Debug/net9.0 to project root (local execution)
            var projectRoot = Directory.GetParent(currentDir)?.Parent?.Parent?.FullName;
            if (projectRoot != null)
            {
                var pathInProjectRoot = Path.Combine(projectRoot, "App", appName);
                Console.WriteLine($"🔍 Checking path in project root: {pathInProjectRoot}");
                if (Directory.Exists(pathInProjectRoot))
                {
                    Console.WriteLine($"✅ App found at: {pathInProjectRoot}");
                    return pathInProjectRoot;
                }
            }

            // Strategy 3: Check if appName is already a full path
            Console.WriteLine($"🔍 Checking if appName is full path: {appName}");
            if (Directory.Exists(appName))
            {
                Console.WriteLine($"✅ App found at: {appName}");
                return appName;
            }

            // Not found in any location
            throw new FileNotFoundException(
                $"App bundle not found in any of these locations:\n" +
                $"  1. {pathInCurrentDir}\n" +
                $"  2. {(projectRoot != null ? Path.Combine(projectRoot, "App", appName) : "N/A")}\n" +
                $"  3. {appName}\n" +
                $"Current directory: {currentDir}"
            );
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
    }
}
