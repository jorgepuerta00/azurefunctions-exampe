namespace IkeaAssignmentCore
{
    using System.IO;
    using Microsoft.Extensions.Configuration;

    public class AppConfiguration
    {
        private readonly string _StorageConnectionString = string.Empty;
        private readonly string _UnsplashUrl = string.Empty;
        private readonly string _UnsplashUrlStatistics = string.Empty;

        public AppConfiguration()
        {
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "local.settings.json");
            configurationBuilder.AddJsonFile(path, false);

            var root = configurationBuilder.Build();

            _StorageConnectionString = root.GetSection("StorageConnectionString").Value;
            _UnsplashUrl = root.GetSection("UnsplashUrl").Value;
            _UnsplashUrlStatistics = root.GetSection("UnsplashUrlStatistics").Value;
        }

        public string StorageConnectionString
        {
            get => _StorageConnectionString;
        }

        public string UnsplashUrl
        {
            get => _UnsplashUrl;
        }

        public string UnsplashUrlStatistics
        {
            get => _UnsplashUrlStatistics;
        }
    }
}
