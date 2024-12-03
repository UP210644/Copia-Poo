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
    public class TicketRepository : TicketInterface
    {
        public readonly AppDbContext _context;
        public TicketRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ticket>> GetAllAsync()
        {
            return await _context.Tickets.ToListAsync();
        }

        public async Task<Ticket> GetByIdAsync(Guid Id_Ticket)
        {
            return await _context.Tickets.FindAsync(Id_Ticket) ?? throw new InvalidOperationException("Ticket no encontrado");
        }

        public async Task AddAsync(Ticket ticket)
        {
            var newTicket = ticket;
            _context.Tickets.Add(newTicket);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Ticket ticket)
        {
            var existingTicket = await _context.Tickets.FindAsync(ticket.Id_Ticket);
            if (existingTicket != null)
            {
                existingTicket = ticket;

                _context.Tickets.Update(existingTicket);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("Ticket no encontrado");
            }
        }

        public async Task DeleteAsync(Guid Id_Ticket)
        {
            var ticket = await _context.Tickets.FindAsync(Id_Ticket);
            if (ticket != null)
            {
                _context.Tickets.Remove(ticket);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("Ticket no encontrado");
            }
        }
    }
}
