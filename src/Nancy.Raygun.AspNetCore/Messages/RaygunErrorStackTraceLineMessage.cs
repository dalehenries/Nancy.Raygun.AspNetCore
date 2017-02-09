using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nancy.Raygun.AspNetCore.Messages
{
    public class RaygunErrorStackTraceLineMessage
    {
        public int LineNumber { get; set; }
        public string ClassName { get; set; }
        public string FileName { get; set; }
        public string MethodName { get; set; }
    }
}
