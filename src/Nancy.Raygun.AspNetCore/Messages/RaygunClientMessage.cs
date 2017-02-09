using System.Reflection;

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
