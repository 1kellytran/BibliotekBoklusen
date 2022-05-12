global using BibliotekBoklusen.Shared;
global using Microsoft.AspNetCore.Components.Authorization;
global using Blazored.LocalStorage;
global using System.Net.Http.Json;
global using BibliotekBoklusen.Client.Services.ProductService;
using BibliotekBoklusen.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BibliotekBoklusen.Client.Services;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddBlazoredLocalStorage();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddScoped<IUserManager, UserManager>();
builder.Services.AddScoped<IDataManager, DataManager>();
builder.Services.AddScoped<IProductService, ProductService>();


await builder.Build().RunAsync();
