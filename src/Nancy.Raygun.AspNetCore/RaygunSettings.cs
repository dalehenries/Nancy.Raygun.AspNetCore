using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Nancy.Raygun.AspNetCore
{
    public class RaygunSettings
    {
        private const string DefaultApiEndPoint = "https://api.raygun.io/entries";

        private static RaygunSettings _settings;
            //ConfigurationManager.GetSection("RaygunSettings") as RaygunSettings;




        public static RaygunSettings Settings
        {
            get
            {
                if (_settings != null) return _settings;

                var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();



                _settings = new RaygunSettings()
                {
                    ApiEndpoint = new Uri(DefaultApiEndPoint),
                    ApiKey = config.GetSection("RaygunSettings")?.GetSection("ApiKey").Value ?? ""
                };

                return _settings;
            }
        }

        public string ApiKey { get; set; }

        public Uri ApiEndpoint { get; set; }
    }
}