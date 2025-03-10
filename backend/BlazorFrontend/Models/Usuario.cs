namespace BlazorFrontend.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string UsuarioNombre { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PassHash { get; set; } = string.Empty;
    }

}
