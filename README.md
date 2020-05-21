# GravySoft.Razor.StringGenerator [![Version](https://img.shields.io/nuget/vpre/GravySoft.Razor.StringGenerator)](https://www.nuget.org/packages/GravySoft.Razor.StringGenerator/) [![Downloads](https://img.shields.io/nuget/dt/GravySoft.Razor.StringGenerator)](https://www.nuget.org/packages/GravySoft.Razor.StringGenerator/) [![Build Status](https://api.travis-ci.org/halomademeapc/GravySoft.Razor.StringGenerator.svg?branch=master)](https://travis-ci.org/github/halomademeapc/GravySoft.Razor.StringGenerator)
#### GravySoft.Razor.StringGenerator.AspNetCore [![Version](https://img.shields.io/nuget/vpre/GravySoft.Razor.StringGenerator.AspNetCore)](https://www.nuget.org/packages/GravySoft.Razor.StringGenerator.AspNetCore/) [![Downloads](https://img.shields.io/nuget/dt/GravySoft.Razor.StringGenerator.AspNetCore)](https://www.nuget.org/packages/GravySoft.Razor.StringGenerator.AspNetCore/)
#### GravySoft.Razor.StringGenerator.NetFramework [![Version](https://img.shields.io/nuget/vpre/GravySoft.Razor.StringGenerator.NetFramework)](https://www.nuget.org/packages/GravySoft.Razor.StringGenerator.NetFramework/) [![Downloads](https://img.shields.io/nuget/dt/GravySoft.Razor.StringGenerator.NetFramework)](https://www.nuget.org/packages/GravySoft.Razor.StringGenerator.NetFramework/)

Service for rendering Razor MVC views to strings. This can be used for sending emails, generating PDFs, and any number of things.

**You must also install either GravySoft.Razor.StringGenerator.AspNetCore or GravySoft.Razor.StringGenerator.NetFramework.**

### Usage
1. Inject an ```IRazorViewToStringRenderer``` to your class.
```csharp
private IRazorViewToStringRenderer renderer;
public ExampleClass(IRazorViewToStringRenderer renderer) => this.renderer = renderer;
```

2. Execute your call.
```
string text = await renderer.RenderViewToStringAsync("~/Views/Email.cshtml", new EmailModel
{
    FirstName = "John",
    LastName = "Doe",
    FavoriteColors = new List<string> { "Red", "Purple", "Orange" }
});
```
*Make sure you use the full path of the view*

### Registering Services
The service needs to be registered in as scoped so that it has access to a request HttpContext.

##### Microsoft Dependency Injection (.NET Core & Standalone .NET Framework)
*In Startup.ConfigureServices*
```csharp
services.AddScoped<IRazorViewToStringRenderer, RazorViewToStringRenderer>();
```

##### Ninject (Sitefinity)
*In your NinjectModule*
```csharp
Bind<RazorViewToStringRenderer>().To<IRazorViewToStringRenderer>();
```

### Changelog
**1.0.0**
* Initial Release