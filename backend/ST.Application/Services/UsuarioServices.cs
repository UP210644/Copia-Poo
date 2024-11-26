using ST.Core.Entidades;
using ST.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST.Application.Services
{
    public class UsuarioServices
    {
        private readonly UsuarioInterface _UsuarioRepository;

        public UsuarioServices(UsuarioInterface UsuarioRepository)
        {
            _UsuarioRepository = UsuarioRepository;
        }

        public async Task<IEnumerable<Usuario>> GetAllUsuarioAsync()
        {
            return await _UsuarioRepository.GetAllAsync();
        }

        public async Task<Usuario?> GetUsuarioByIdAsync(int Nomina_Usuario)
        {
            return await _UsuarioRepository.GetByIdAsync(Nomina_Usuario);
        }

        public async Task AddUsuarioAsync(Usuario usuario)
        {
            await _UsuarioRepository.AddAsync(usuario);
        }

        public async Task UpdateUsuarioAsync(Usuario usuario)
        {
            await _UsuarioRepository.UpdateAsync(usuario);
        }

        public async Task DeleteUsuarioAsync(int Nomina_Usuario)
        {
            await _UsuarioRepository.DeleteAsync(Nomina_Usuario);
        }
    }
}
