using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TechService.BlazorClient;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// HttpClient apuntando al backend API en Azure App Service
var apiBaseUrl = builder.Configuration["ApiBaseUrl"] ?? "https://techserviceapi-g0a4h6daeghqg9fv.westus3-01.azurewebsites.net/";
builder.Services.AddScoped(sp => new HttpClient 
{ 
    BaseAddress = new Uri(apiBaseUrl.EndsWith('/') ? apiBaseUrl : $"{apiBaseUrl}/") 
});

await builder.Build().RunAsync();
