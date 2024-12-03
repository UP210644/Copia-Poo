using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ST.Core.Entidades;

namespace ST.Core.Interfaces
{
    public interface TicketInterface
    {
        Task<IEnumerable<Ticket>> GetAllAsync();
        Task<Ticket> GetByIdAsync(Guid Id_Ticket);
        Task AddAsync(Ticket Ticket);
        Task UpdateAsync(Ticket Ticket);
        Task DeleteAsync(Guid Id_Ticket);
    }
}
