using Microsoft.EntityFrameworkCore;
using ST.Core.Entidades;
using ST.Core.Interfaces;
using ST.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST.Infrastructure.Repositorios
{
    public class UsuarioRepository : UsuarioInterface
    {
        private readonly AppDbContext _context;
        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuario> GetByIdAsync(int Nomina_Usuario)
        {
            return await _context.Usuarios.FindAsync(Nomina_Usuario) ?? throw new InvalidOperationException("Usuario no encontrado");
        }

        public async Task AddAsync(Usuario usuario)
        {
            var newUsuario = usuario;
            _context.Usuarios.Add(newUsuario);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Usuario usuario)
        {
            var existingUsuario = await _context.Usuarios.FindAsync(usuario.Nomina_Usuario);
            if (existingUsuario != null)
            {
                existingUsuario = usuario;

                _context.Usuarios.Update(existingUsuario);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("Usuario no encontrado");
            }
        }

        public async Task DeleteAsync(int Nomina_Usuario)
        {
            var usuario = await _context.Usuarios.FindAsync(Nomina_Usuario);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("Usuario no encontrado");
            }
        }
    }
}
