﻿using System;
using Nancy.Raygun.AspNetCore.Messages;

namespace Nancy.Raygun.AspNetCore
{
    public interface IRaygunMessageBuilder
    {
        RaygunMessage Build();
        IRaygunMessageBuilder SetMachineName(string machineName);
        IRaygunMessageBuilder SetExceptionDetails(Exception exception);
        IRaygunMessageBuilder SetClientDetails();
        IRaygunMessageBuilder SetEnvironmentDetails();
        IRaygunMessageBuilder SetVersion();
        IRaygunMessageBuilder SetUser(string identifier);
    }
}
