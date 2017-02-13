# Nancy.Raygun.AspNetCore

Raygun is a service for automatically reporting, tracking and alerting you to errors in your applications. Discover and resolve errors faster than ever before and keep your users happy.

http://raygun.com/

This library is based off of [Nancy.Raygun](https://github.com/phillip-haydon/Nancy.Raygun) which was created for classic .NET Nancy apps. It was based on the original library https://github.com/MindscapeHQ/raygun4net from Mindscape. The purpose of this library is to provide the same functionality for dotnet core Nancy apps.

## Installing Nancy.Raygun.AspNetCore

Using Nuget, install the [Nancy.Raygun.AspNetCore](https://www.nuget.org/packages/Nancy.Raygun.AspNetCore/) package by adding it to you project.json:

```javascript
"frameworks" : {
    "netcoreapp1.0" : {
        "dependencies" : {
            "Nancy.Raygun.AspNetCore": "1.0.0"
        }
    }
}
```

## Configuring Raygun

Add the following code to your appsettings.json:

```javascript
"RaygunSettings": {
  "ApiKey": "YOUR_APP_API_KEY"
}
```

And that's it. Nancy should automatically pull in and setup raygun via `NancyRaygunRegistration` which is an `IApplicationStartup`.

## LICENSE

Nancy.Raygun.AspNetCore is released under the [MIT](License.md) license.
