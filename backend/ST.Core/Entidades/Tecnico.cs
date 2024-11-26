using ST.Core.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ST.Core.Entidades
{
    public class Tecnico
    {
        public required int Nomina_Tecnico { get; set; }

        [Key]
        public int Id_Tecnico { get; set; }
        public required string Especialidad { get; set; }
        public required int AnosExperiencia { get; set; }
        public List<string> Certificaciones { get; set; } = new List<string>();
        public required string TelefonoContacto { get; set; }
        public required DateTime FechaContratacion { get; set; }
        public required bool Activo { get; set; }
        public required RolTecnico Rol { get; set; }
    }
    public enum RolTecnico
    {
        TecnicoSoporte,
        TecnicoSenior,
        Administrador,
        SupervisorSoporte
    }
}
