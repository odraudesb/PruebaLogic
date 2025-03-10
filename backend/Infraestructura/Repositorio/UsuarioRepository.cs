using Core.Interfaces;
using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Repositorio
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Usuario>> GetAll() => await _context.Usuarios.ToListAsync();

        public async Task<Usuario> GetById(int id) => await _context.Usuarios.FindAsync(id);


        public async Task Add(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<Usuario?> LoginAsync(string usuarioNombre, string clave)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.UsuarioNombre == usuarioNombre && u.PassHash == clave);

            if (usuario != null)
            {
                return usuario;
            }
            return null;
        }
    }
}
