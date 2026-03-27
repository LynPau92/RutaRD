using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Frontend;
using Frontend.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<HotelService>();
builder.Services.AddScoped<RestauranteService>();
builder.Services.AddScoped<TurismoEcologicoService>();
builder.Services.AddScoped<EventosActividadesService>();
builder.Services.AddScoped<TurismoCulturalService>();
builder.Services.AddScoped<AuthService>();

await builder.Build().RunAsync();
