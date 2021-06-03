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

````



