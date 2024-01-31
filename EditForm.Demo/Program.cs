using EditForm.Demo;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazor.EditForm.Configuration;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

var services = builder.Services;
services.AddAppBlazorServerServices();
services.AddAppBlazorWASMServices();
services.AddAppWASMServerServices();


builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
