using Microsoft.AspNetCore.Builder;
using Nancy.Owin;

namespace Nancy.Raygun.AspNetCore.WebSiteSample
{
    public class Startup
    {

        public void Configure(IApplicationBuilder app)
        {
            app.UseOwin(x => x.UseNancy());
        }
    }
}