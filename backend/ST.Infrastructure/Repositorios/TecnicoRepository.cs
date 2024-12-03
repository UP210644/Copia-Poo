using ST.Core.Entidades;
using ST.Core.Interfaces;
using ST.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ST.Infrastructure.Repositorios
{
    public class TecnicoRepository : TecnicoInterface
    {
        private readonly AppDbContext _context;
        public TecnicoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tecnico>> GetAllAsync()
        {
            return await _context.Tecnicos.ToListAsync();
        }

        public async Task<Tecnico> GetByIdAsync(int Id_Tecnico)
        {
            return await _context.Tecnicos.FindAsync(Id_Tecnico) ?? throw new InvalidOperationException("Tecnico no encontrado");
        }

        public async Task AddAsync(Tecnico tecnico)
        {
            var newTecnico = tecnico;
            _context.Tecnicos.Add(newTecnico);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Tecnico tecnico)
        {
            var existingTecnico = await _context.Tecnicos.FindAsync(tecnico.Id_Tecnico);
            if (existingTecnico != null)
            {
                existingTecnico = tecnico;

                _context.Tecnicos.Update(existingTecnico);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("Tecnico no encontrado");
            }
        }

        public async Task DeleteAsync(int Id_Tecnico)
        {
            var tecnico = await _context.Tecnicos.FindAsync(Id_Tecnico);
            if (tecnico != null)
            {
                _context.Tecnicos.Remove(tecnico);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("Tecnico no encontrado");
            }
        }

    }
}
