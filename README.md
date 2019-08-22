# GravySoft.Razor.StringGenerator [![NuGet Logo](https://raw.githubusercontent.com/NuGet/Media/master/Images/MainLogo/32x32/nuget_32.png)](https://www.nuget.org/packages/GravySoft.Razor.StringGenerator)

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