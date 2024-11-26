using ST.Core.Entidades;
using ST.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST.Application.Services
{
    public class TicketServices
    {
        public readonly TicketInterface _TicketRepository;
        public TicketServices(TicketInterface TicketRepository)
        {
            _TicketRepository = TicketRepository;
        }
        public async Task<IEnumerable<Ticket>> GetAllTicketAsync()
        {
            return await _TicketRepository.GetAllAsync();
        }

        public async Task<Ticket> GetTicketByIdAsync(Guid Id_Ticket)
        {
            return await _TicketRepository.GetByIdAsync(Id_Ticket);
        }

        public async Task AddTicketAsync(Ticket ticket)
        {
            await _TicketRepository.AddAsync(ticket);
        }

        public async Task UpdateTicketAsync(Ticket ticket)
        {
            await _TicketRepository.UpdateAsync(ticket);
        }

        public async Task DeleteTicketAsync(Guid Id_Ticket)
        {
            await _TicketRepository.DeleteAsync(Id_Ticket);
        }
    }
}
