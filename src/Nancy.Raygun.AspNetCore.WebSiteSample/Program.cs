using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Nancy.Raygun.AspNetCore.WebSiteSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Configure web server hosting, port, etc.
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddCommandLine(args)
                .AddJsonFile(Path.Combine("hosting.json"), false)
                .Build();

            var host = new WebHostBuilder()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseKestrel()
                .UseConfiguration(config)
                .UseStartup<Startup>() // Kick off our custom Startup code...
                .Build();

            host.Run();
        }
    }
}
