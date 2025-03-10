using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
  public   class Tarea
    {
        public int TareaId { get; set; }
        public string? Titulo { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
        public DateTime FechaVencimiento { get; set; }
        public bool Completada { get; set; }
        public int UsuarioId { get; set; }
    }
}
