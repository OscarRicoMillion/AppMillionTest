namespace AppMillionTest.Configuration
{
    /// <summary>
    /// Device configuration model to map settings from appsettings.json.
    /// </summary>
    public class DeviceConfiguration
    {
        public string DeviceName { get; set; } = string.Empty;            
        public string PlatformVersion { get; set; } = string.Empty;
        public string Udid { get; set; } = string.Empty;
    }
}