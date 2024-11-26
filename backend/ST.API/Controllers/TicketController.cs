using Microsoft.AspNetCore.Mvc;
using ST.Application.Services;
using ST.Core.Entidades;

namespace ST.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketController : ControllerBase
    {
        private readonly TicketServices _ticketServices;

        public TicketController(TicketServices ticketServices)
        {
            _ticketServices = ticketServices;
        }

        [HttpGet]
        public async Task<IEnumerable<Ticket>> GetAllTicketAsync()
        {
            return await _ticketServices.GetAllTicketAsync();
        }

        [HttpGet("{Id_Ticket}")]
        public async Task<Ticket> GetTicketByIdAsync(Guid Id_Ticket)
        {
            return await _ticketServices.GetTicketByIdAsync (Id_Ticket);
        }

        [HttpPost]
        public async Task AddTicketAsync(Ticket ticket)
        {
            await _ticketServices.AddTicketAsync(ticket);
        }

        [HttpPut]
        public async Task UpdateTicketAsync(Ticket ticket)
        {
            await _ticketServices.UpdateTicketAsync(ticket);
        }
    }
}
