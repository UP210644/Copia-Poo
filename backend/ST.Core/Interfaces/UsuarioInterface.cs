using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ST.Core.Entidades;

namespace ST.Core.Interfaces
{
    public interface UsuarioInterface
    {
        Task<IEnumerable<Usuario>> GetAllAsync();
        Task<Usuario> GetByIdAsync(int Nomina_Usuario);
        Task AddAsync(Usuario Usuario);
        Task UpdateAsync(Usuario Usuario);
        Task DeleteAsync(int Nomina_Usuario);
    }

}
