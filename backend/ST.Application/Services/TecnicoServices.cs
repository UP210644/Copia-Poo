using ST.Core.Entidades;
using ST.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST.Application.Services
{
    public class TecnicoServices
    {
        private readonly TecnicoInterface _TecnicoRepository;
        public TecnicoServices(TecnicoInterface TecnicoRepository)
        {
            _TecnicoRepository = TecnicoRepository;
        }
        public async Task<IEnumerable<Tecnico>> GetAllTecnicoAsync()
        {
            return await _TecnicoRepository.GetAllAsync();
        }

        public async Task<Tecnico?> GetTecnicoByIdAsync(int Id_Tecnico)
        {
            return await _TecnicoRepository.GetByIdAsync(Id_Tecnico);
        }

        public async Task AddTecnicoAsync(Tecnico tecnico)
        {
            await _TecnicoRepository.AddAsync(tecnico);
        }

        public async Task UpdateTecnicoAsync(Tecnico tecnico)
        {
            await _TecnicoRepository.UpdateAsync(tecnico);
        }

        public async Task DeleteTecnicoAsync(int Id_Tecnico)
        {
            await _TecnicoRepository.DeleteAsync(Id_Tecnico);
        }
    }
}
