using Microsoft.EntityFrameworkCore;
using HeatWise_Sprint_2.Net.Persistencia.Models;

namespace HeatWise_Sprint_2.Net.Persistence
{
    public class HeatWiseDbContext : DbContext
    {
        public DbSet<Plano> Planos { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Site> Sites { get; set; }
        public DbSet<Analise> Analises { get; set; }

        public HeatWiseDbContext(DbContextOptions<HeatWiseDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Plano>()
                .Property(p => p.PlanoId)
                .HasDefaultValueSql("NEXT VALUE FOR dbo.SequenciaPlano");

            modelBuilder.Entity<Empresa>()
                .Property(e => e.Id)
                .HasDefaultValueSql("NEXT VALUE FOR dbo.SequenciaEmpresa");

            modelBuilder.Entity<Site>()
                .Property(s => s.Id)
                .HasDefaultValueSql("NEXT VALUE FOR dbo.SequenciaSite");

            modelBuilder.Entity<Analise>()
                .Property(a => a.Id)
                .HasDefaultValueSql("NEXT VALUE FOR dbo.SequenciaAnalise");
        }
    }
}
