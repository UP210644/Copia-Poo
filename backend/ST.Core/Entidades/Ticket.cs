using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace ST.Core.Entidades
{
    public class Ticket
    {
        [Key]
        public Guid Id_Ticket { get; set; }
        public required EnumTicketPriority PrioTicket { get; set; }
        public required EnumTicketStatus StatusTicket { get; set; }
        public required string Ticket_Category { get; set; }
        public required string Ticket_SubCategory { get; set; }
        public required string Ticket_Nation { get; set; }
        [StringLength(200)]
        public required string Ticket_Description { get; set; }
        
    }
    public enum EnumTicketPriority
    {
        Baja,
        Media,
        Alta,
        Urgente
    }

    public enum EnumTicketStatus
    {
        Abierto,
        Pendiente,
        Cerrado
    }
}