using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ST.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tecnicos",
                columns: table => new
                {
                    Id_Tecnico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nomina_Tecnico = table.Column<int>(type: "int", nullable: false),
                    Especialidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnosExperiencia = table.Column<int>(type: "int", nullable: false),
                    Certificaciones = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelefonoContacto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaContratacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    Rol = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tecnicos", x => x.Id_Tecnico);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id_Ticket = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrioTicket = table.Column<int>(type: "int", nullable: false),
                    StatusTicket = table.Column<int>(type: "int", nullable: false),
                    Ticket_Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ticket_SubCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ticket_Nation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ticket_Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id_Ticket);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Nomina_Usuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_Usuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellidos_Usuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email_Usuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono_Usuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Puesto_Usuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User_Status = table.Column<int>(type: "int", nullable: false),
                    FechaRegistro_Usuario = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Nomina_Usuario);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tecnicos");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
