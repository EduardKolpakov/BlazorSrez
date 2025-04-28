using BlazorSrez;
using BlazorSrez.Pages.Class;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Net.Http.Headers;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped<LocalStorageService>();
builder.Services.AddScoped<AuthenticatedHttpClientFactory>();
builder.Services.AddScoped(sp =>
{
    var client = new HttpClient { BaseAddress = new Uri("https://localhost:7125/") };
    return client;
});
builder.Services.AddAuthorizationCore();

await builder.Build().RunAsync();
