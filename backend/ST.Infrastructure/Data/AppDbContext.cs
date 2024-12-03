using Microsoft.EntityFrameworkCore;
using ST.Core.Entidades;
using System.Diagnostics;

namespace ST.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Tecnico> Tecnicos { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Guid autoincrement
            modelBuilder.Entity<Ticket>()
                .Property(a => a.Id_Ticket)
                .ValueGeneratedOnAdd();
        }
    }
}
