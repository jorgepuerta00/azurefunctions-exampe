namespace IkeaAssignmentCore
{
    using System.IO;
    using Microsoft.Extensions.Configuration;

    public class AppConfiguration
    {
        private string _StorageConnectionString = string.Empty;
        private string _UnsplashUrl = string.Empty;
        private string _UnsplashUrlStatistics = string.Empty;
        private readonly string _FileName;

        public AppConfiguration(string filename)
        {
            _FileName = filename;
            BuildConfiguration();
        }

        public AppConfiguration()
        {
            _FileName = "local.settings.json";
            BuildConfiguration();
        }

        private void BuildConfiguration()
        {
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), _FileName);
            configurationBuilder.AddJsonFile(path, false);

            var root = configurationBuilder.Build();

            _StorageConnectionString = root.GetSection("StorageConnectionString").Value;
            _UnsplashUrl = root.GetSection("UnsplashUrl").Value;
            _UnsplashUrlStatistics = root.GetSection("UnsplashUrlStatistics").Value;
        }

        public string StorageConnectionString()
        {
            return _StorageConnectionString;
        }

        public string UnsplashUrl()
        {
            return _UnsplashUrl;
        }

        public string UnsplashUrlStatistics()
        {
            return _UnsplashUrlStatistics;
        }
    }
}
