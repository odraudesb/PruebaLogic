namespace BlazorFrontend.Models
{
    public class Tarea
    {
        public int TareaId { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
        public DateTime FechaVencimiento { get; set; }
        public bool Completada { get; set; }
        public int UsuarioId { get; set; } 
    }

}
