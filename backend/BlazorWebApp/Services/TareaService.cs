using System.Net.Http.Headers;
using System.Net.Http.Json;
using Blazored.LocalStorage;
using BlazorWebApp.Models;
using Microsoft.AspNetCore.Components.WebAssembly.Http;

public class TareaService
{
    private readonly HttpClient _http;
    private readonly ILocalStorageService _localStorage;
    private int? _usuarioId; 

    public TareaService(HttpClient http, ILocalStorageService localStorage)
    {
        _http = http;
        _localStorage = localStorage;
    }

  

    private async Task<HttpResponseMessage> EnviarSolicitudAsync(HttpMethod metodo, string url, object? contenido = null)
    {
        var requestMessage = new HttpRequestMessage(metodo, $"{_http.BaseAddress}{url}");

        if (contenido != null)
        {
            requestMessage.Content = JsonContent.Create(contenido, new MediaTypeHeaderValue("application/json"));
        }

        requestMessage.SetBrowserRequestCache(BrowserRequestCache.NoCache);
        requestMessage.SetBrowserRequestMode(BrowserRequestMode.Cors);
        requestMessage.SetBrowserRequestCredentials(BrowserRequestCredentials.Omit);

        return await _http.SendAsync(requestMessage);
    }

    public async Task<List<Tarea>> ObtenerTareas()
    {
        var response = await EnviarSolicitudAsync(HttpMethod.Get, "Tareas");

        return response.IsSuccessStatusCode
            ? await response.Content.ReadFromJsonAsync<List<Tarea>>() ?? new List<Tarea>()
            : new List<Tarea>();
    }

    public async Task<Tarea> ObtenerTareaPorId(int id)
    {
        var response = await EnviarSolicitudAsync(HttpMethod.Get, $"Tareas/{id}");

        return response.IsSuccessStatusCode
            ? await response.Content.ReadFromJsonAsync<Tarea>() ?? new Tarea()
            : new Tarea();
    }
    public async Task<bool> CrearTarea(Tarea tarea, int usuarioId)
    {
        if (usuarioId == 0) return false; 

        tarea.UsuarioId = usuarioId;

        var response = await EnviarSolicitudAsync(HttpMethod.Post, "Tareas/Create", tarea);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> EditarTarea(Tarea tarea, int usuarioId)
    {
        if (usuarioId == null) return false;

        tarea.UsuarioId = usuarioId;
        var response = await EnviarSolicitudAsync(HttpMethod.Put, $"Tareas/{tarea.TareaId}", tarea);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> EliminarTarea(int id)
    {
        var response = await EnviarSolicitudAsync(HttpMethod.Delete, $"Tareas/{id}");
        return response.IsSuccessStatusCode;
    }
}
