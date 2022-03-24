using BlazorDownloadFile;
using Fluxor;
using HungryPig.Services;
using HungryPig.UI;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddBlazorDownloadFile();
builder.Services.AddScoped<IGameService, GameService>();
builder.Services.AddScoped<IExportService, ExportService>();
builder.Services.AddMudServices();
builder.Services.AddFluxor(opt => opt.ScanAssemblies(typeof(Program).Assembly));

await builder.Build().RunAsync();
