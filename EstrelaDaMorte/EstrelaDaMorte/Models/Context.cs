using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EstrelaDaMorte.Models
{
    public class Context : DbContext
    {
        public DbSet<Piloto> Pilotos { get; set; }
        public DbSet<Planeta> Planetas { get; set; }
        public DbSet<Nave> Naves { get; set; }
        public DbSet<PilotoNave> PilotosNaves { get; set; }
        public DbSet<HistoricoViagem> HistoricoViagens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PilotoNave>().HasKey(pn => new { pn.IdPiloto, pn.IdNave });
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: @"Server=(localdb)\mssqllocaldb;Database=EstrelaDaMorte;Integrated Security=True");
        }
    }
}
