using BlazorApp;
using BlazorApp.Services;
using BlazorApp.ViewModels;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using SharedModels.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddMudServices();

builder.Services.AddScoped(_ => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<ParticipationWinnerSelector>();
builder.Services.AddScoped<BackendCaller>();
builder.Services.AddScoped<IndexViewModel>();

await builder.Build().RunAsync();