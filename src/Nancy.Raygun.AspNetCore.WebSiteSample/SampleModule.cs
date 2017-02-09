using System;

namespace Nancy.Raygun.AspNetCore.WebSiteSample
{
    public class SampleModule : NancyModule
    {
        public SampleModule()
        {
            Get("/", _ =>
            {
                throw new Exception("Testing Exceptions");
            });
        }
    }
}
