using BlazorFrontend.Components;

using Microsoft.AspNetCore.Components.Web;
using System;
using Microsoft.AspNetCore.Components.Authorization;
using BlazorFrontend.Auth;
namespace BlazorFrontend
{



    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();
            
            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:5001/api/") });

            builder.Services.AddScoped<UsuarioService>();
            builder.Services.AddScoped<TareaService>();

            var app = builder.Build();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAntiforgery();


            app.Run();
        }
    }
}
