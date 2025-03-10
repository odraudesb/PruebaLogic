using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;

namespace Core.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> GetAll();
        Task<Usuario> GetById(int id);
        Task Add(Usuario persona);
        Task Update(Usuario persona);
        Task Delete(int id);
        Task<Usuario> LoginAsync(string usuarioNombre, string pass);
    }
}
