using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST.Core.Entidades
{
    public class Usuario
    {
        [Key]
        public int Nomina_Usuario { get; set; }
        public required string Nombre_Usuario { get; set; }
        public required string Apellidos_Usuario { get; set; }
        public required string Email_Usuario { get; set; }
        public required string Telefono_Usuario { get; set; }
        public required string Puesto_Usuario { get; set; }
        public required UsuarioActivoInactivo User_Status { get; set; }
        public required DateTime FechaRegistro_Usuario { get; set; }
    }
    public enum UsuarioActivoInactivo
    {
        Activo,
        Inactivo
       
    }
}
