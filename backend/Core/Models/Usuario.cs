using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string? UsuarioNombre { get; set; }
        public string? Email { get; set; }
        public string? PassHash { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
