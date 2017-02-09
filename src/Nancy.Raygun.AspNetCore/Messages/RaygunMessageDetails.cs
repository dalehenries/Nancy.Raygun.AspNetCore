using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nancy.Raygun.AspNetCore.Messages
{
    public class RaygunMessageDetails
    {
        public string MachineName { get; set; }
        public string Version { get; set; }
        public RaygunErrorMessage Error { get; set; }
        public RaygunRequestMessage Request { get; set; }
        public RaygunUserMessage User { get; set; }
        public RaygunEnvironmentMessage Environment { get; set; }
        public RaygunClientMessage Client { get; set; }
        public IList<string> Tags { get; set; }
        public IDictionary UserCustomData { get; set; }
    }
}
