using ST.Core.Entidades;
using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST.Core.Interfaces
{
	public interface TecnicoInterface
	{
		Task<IEnumerable<Tecnico>> GetAllAsync();
		Task<Tecnico> GetByIdAsync(int Id_Tecnico);
        Task AddAsync(Tecnico Tecnico);
		Task UpdateAsync(Tecnico Tecnico);
		Task DeleteAsync(int Id_Tecnico);
    }
}