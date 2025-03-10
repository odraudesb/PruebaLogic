using System.Net.Http.Json;
using BlazorFrontend.Models;

public class UsuarioService
{
    private readonly HttpClient _http;

    public UsuarioService(HttpClient http)
    {
        _http = http;
    }

    public async Task<bool> Login(string usuarioNombre, string password)
    {
        var loginModel = new { UsuarioNombre = usuarioNombre, PassHash = password };
        var response = await _http.PostAsJsonAsync("Usuario/login", loginModel);
        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadFromJsonAsync<dynamic>();
            var token = result?.token;
            if (!string.IsNullOrEmpty(token))
            {
                return true;
            }
        }
        return false;
    }

    public async Task<bool> RegistrarUsuario(Usuario usuario)
    {
        var response = await _http.PostAsJsonAsync("Usuario", usuario);
        return response.IsSuccessStatusCode;
    }
}
