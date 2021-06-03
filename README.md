# azure-functions-csharp-scripts


Function test time setting in server and basic configuration for .net trace logging in Azure Functions (C# Scripts)

## To Configure Time Settings

Add WEBSITE_TIME_ZONE var to App Settings Configuration

For Chilean Time for example set: 
WEBSITE_TIME_ZONE="Pacific SA Standard Time"

![App Setting](https://docs.microsoft.com/en-us/azure/app-service/media/configure-common/open-ui.png)

## Use AppInight Client Class

1. Add Microsoft.ApplicactionInsight package to script with #r Directive
1. Add the following references references:
   - Microsoft.ApplicationInsights
   - Microsoft.ApplicationInsights.DataContracts
1. Add a function that return the Client Reference as the code show
1. Use the function specifying SeverityLevel (0-Verbose ... 4-Critical )


````C#
...
#r "Microsoft.ApplicationInsights"
...
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
...

public static IActionResult Run(HttpRequest req, ILogger log)
{    

    var appInsights = GetTelemetryClient();

    ...
    
    appInsights.TrackTrace(time, SeverityLevel.Verbose);            // 0 - Verbose
    appInsights.TrackTrace(time, SeverityLevel.Information);        // 1 - Information
    appInsights.TrackTrace(time, SeverityLevel.Warning);            // 2 - Warning
    appInsights.TrackTrace(time, SeverityLevel.Error);              // 3 - Error
    appInsights.TrackTrace(time, SeverityLevel.Critical);           // 4 - Critical

    ...
    
    return new OkObjectResult(responseMessage);
}



// Get Telemetry Client Function 
private static TelemetryClient GetTelemetryClient()
{
    var telemetryClient = new TelemetryClient();
    telemetryClient.InstrumentationKey = [--Insert-Instrumentation-Key--Or-Use-Configuration-Var--];
    return telemetryClient;
}

````
