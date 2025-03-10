using System.Net.Http.Headers;
using System.Net.Http.Json;
using Blazored.LocalStorage;
using BlazorWebApp.Models;
using BlazorWebApp.Services;
using Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Http;

public class UsuarioService
{
    private readonly HttpClient _http;
    private readonly ILocalStorageService _localStorage;
    private readonly SessionState _session;
    public UsuarioService(HttpClient http, SessionState session)
    {
        _http = http;
        _session = session;
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

    public async Task<int> Login(string usuarioNombre, string password)
    {
        var response = await EnviarSolicitudAsync(HttpMethod.Post, "Usuario/login", new { UsuarioNombre = usuarioNombre, PassHash = password });

        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadFromJsonAsync<LoginResponse>();

            if (!string.IsNullOrEmpty(result?.token))
            {

                _session.Login( result.usuarioId, result.token);
                return result.usuarioId;
            }
           
            return 0;
        }
        return 0;
    }

    public async Task<bool> RegistrarUsuario(Usuario usuario)
    {
        var response = await EnviarSolicitudAsync(HttpMethod.Post, "Usuario/create", usuario);
        return response.IsSuccessStatusCode;
    }

    public async Task<List<Usuario>> ObtenerUsuarios()
    {
        var response = await EnviarSolicitudAsync(HttpMethod.Get, "Usuario");

        return response.IsSuccessStatusCode
            ? await response.Content.ReadFromJsonAsync<List<Usuario>>() ?? new List<Usuario>()
            : new List<Usuario>();
    }
    public async Task<int?> ObtenerUsuarioId()
    {
        return await _localStorage.GetItemAsync<int?>("UsuarioId");
    }
}
