#r "Newtonsoft.Json"
#r "Microsoft.ApplicationInsights"

using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;

public static IActionResult Run(HttpRequest req, ILogger log)
{    

    var appInsights = GetTelemetryClient();
    string time = $"NOW: {DateTime.Now}";

    appInsights.TrackTrace(time, SeverityLevel.Verbose);            // 0 - Verbose
    appInsights.TrackTrace(time, SeverityLevel.Information);        // 1 - Information
    appInsights.TrackTrace(time, SeverityLevel.Warning);            // 2 - Warning
    appInsights.TrackTrace(time, SeverityLevel.Error);              // 3 - Error
    appInsights.TrackTrace(time, SeverityLevel.Critical);           // 4 - Critical

    /* 
        TODO: Look later for the way to use log appender to App Insights

        log.LogInformation("C# HTTP trigger function processed a request.");
        log.LogWarning("C# HTTP trigger function processed a request.");
        log.LogError("C# HTTP trigger function processed a request.");
    */
    string responseMessage = string.IsNullOrEmpty(time)
        ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
        : time;

    return new OkObjectResult(responseMessage);
}


// Get Telemetry Client Function 
private static TelemetryClient GetTelemetryClient()
{
    var telemetryClient = new TelemetryClient();
    telemetryClient.InstrumentationKey = [--Insert-Instrumentation-Key--Or-Use-Configuration-Var--];
    return telemetryClient;
}


