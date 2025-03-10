using System.Net;
using BlazorWebApp;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using BlazorWebApp.Services;

namespace BlazorWebApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5153/api/") });

            builder.Services.AddBlazoredLocalStorage(config =>
            {
                config.JsonSerializerOptions.WriteIndented = true;
            });

      

            builder.Services.AddScoped<UsuarioService>();
            builder.Services.AddScoped<TareaService>();
            builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
            builder.Services.AddSingleton<SessionState>();
            builder.Services.AddAuthorizationCore();
       
            var host = builder.Build();

            var localStorage = host.Services.GetRequiredService<ILocalStorageService>();
            await localStorage.SetItemAsync("test", "OK"); 

            await host.RunAsync();
        }
    }
}
