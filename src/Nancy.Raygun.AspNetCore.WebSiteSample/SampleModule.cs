using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
