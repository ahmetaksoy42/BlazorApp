global using ProsesKontrolWeb.Client.Services.ProsesKontrolServices;
global using ProsesKontrolWeb.Shared;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ProsesKontrolWeb.Client;
using ProsesKontrolWeb.Client.Services.ImageServices;
using ProsesKontrolWeb.Client.Services.ProsesServices;
using ProsesKontrolWeb.Client.Services.UniteServices;
using Syncfusion.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IProsesKontrolService, ProsesKontrolService>();
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddScoped<IProsesService, ProsesService>();
builder.Services.AddScoped<IUniteService, UniteService>();
builder.Services.AddSyncfusionBlazor();

Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NHaF5cXmVCf1NpR2JGfV5yd0VHYFZRRXxcSk0SNHVRdkdgWXZccXVVRmJdUkV1V0s=");

await builder.Build().RunAsync();
