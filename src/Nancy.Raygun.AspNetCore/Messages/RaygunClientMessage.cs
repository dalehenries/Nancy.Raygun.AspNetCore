using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Nancy.Extensions;

namespace Nancy.Raygun.AspNetCore.Messages
{
    public class RaygunClientMessage
    {
        public RaygunClientMessage()
        {
            Name = "Nancy.Raygun";
            Version = typeof(RaygunClient).GetTypeInfo().Assembly.GetName().Version.ToString();
            // TODO: Update this to point to our github project...
            ClientUrl = @"https://github.com/phillip-haydon/Nancy.Raygun";
        }

        public string Name { get; set; }

        public string Version { get; set; }

        public string ClientUrl { get; set; }
    }
}
