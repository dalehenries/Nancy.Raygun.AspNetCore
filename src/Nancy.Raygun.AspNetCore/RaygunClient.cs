using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Nancy.Raygun.AspNetCore.Messages;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Nancy.Raygun.AspNetCore
{
    public class RaygunClient
    {
        private readonly string _apiKey;

        /// <summary>
        ///     Initializes a new instance of the <see cref="RaygunClient" /> class.
        /// </summary>
        /// <param name="apiKey">The API key.</param>
        public RaygunClient(string apiKey)
        {
            _apiKey = apiKey;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="RaygunClient" /> class.
        ///     Uses the ApiKey specified in the config file.
        /// </summary>
        public RaygunClient()
            : this(RaygunSettings.Settings.ApiKey)
        {
            
        }

        public void SendInBackground(NancyContext context, Exception exception, IList<string> tags = null, IDictionary userCustomData = null, string version = null)
        {
            var message = BuildMessage(context, exception);
            message.Details.Tags = tags;
            message.Details.Version = version;
            message.Details.UserCustomData = userCustomData;
            Send(message);
        }

        public void SendInBackground(Exception exception, IList<string> tags = null, IDictionary userCustomData = null, string version = null)
        {
            SendInBackground(null, exception, tags, userCustomData, version);
        }

        internal RaygunMessage BuildMessage(NancyContext context, Exception exception)
        {
            var message = RaygunMessageBuilder.New
                                              .SetHttpDetails(context)
                                              .SetEnvironmentDetails()
                                              .SetMachineName(Environment.MachineName)
                                              .SetExceptionDetails(exception)
                                              .SetClientDetails()
                                              .SetVersion()
                                              .SetUser((context == null || context.CurrentUser == null) ? null : context.CurrentUser.Identity.Name)
                                              .Build();

            return message;
        }

        private static HttpClient Client = new HttpClient();

        public void Send(RaygunMessage raygunMessage)
        {
            if (Client.DefaultRequestHeaders.Contains("X-ApiKey") == false)
            {
                Client.DefaultRequestHeaders.Add("X-ApiKey", _apiKey);
            }

            ThreadPool.QueueUserWorkItem( c =>
            {

                var json = JsonConvert.SerializeObject(raygunMessage);
                var result =  Client.PostAsync(RaygunSettings.Settings.ApiEndpoint,
                        new StringContent(json, Encoding.UTF8, "application/json")).Result;

                if (result.StatusCode != System.Net.HttpStatusCode.Accepted)
                {
                    Trace.WriteLine(string.Format("Error Logging Exception to Raygun.io {0} - {1}", result.StatusCode, result.ReasonPhrase));
                }
               
            });
        }
    }
}
