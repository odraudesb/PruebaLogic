using System.Net.Http.Json;
using BlazorFrontend.Models;

public class TareaService
{
    private readonly HttpClient _http;

    public TareaService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<Tarea>> ObtenerTareas()
    {
        return await _http.GetFromJsonAsync<List<Tarea>>("Tareas") ?? new List<Tarea>();
    }

    public async Task<Tarea> ObtenerTareaPorId(int id)
    {
        return await _http.GetFromJsonAsync<Tarea>($"Tareas/{id}") ?? new Tarea();
    }

    public async Task<bool> CrearTarea(Tarea tarea)
    {
        var response = await _http.PostAsJsonAsync("Tareas", tarea);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> EditarTarea(Tarea tarea)
    {
        var response = await _http.PutAsJsonAsync($"Tareas/{tarea.TareaId}", tarea);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> EliminarTarea(int id)
    {
        var response = await _http.DeleteAsync($"Tareas/{id}");
        return response.IsSuccessStatusCode;
    }
}
