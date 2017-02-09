using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Nancy.Owin;

namespace Nancy.Raygun.AspNetCore.WebSiteSample
{
    public class Startup
    {

        public Startup(IHostingEnvironment env)
        {

        }
        public void Configure(IApplicationBuilder app)
        {
            app.UseOwin(x => x.UseNancy());
        }
    }
}