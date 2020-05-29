using ConstructoIT.Hotel.Accor.Domain.Entities;
using ConstructoIT.Hotel.Accor.Infraestrutura.EntityConfiguration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConstructoIT.Hotel.Accor.Dominio.Context
{
    public class ConstructoItDbContext: DbContext
    {
        public ConstructoItDbContext()
        {

        }
        public ConstructoItDbContext(DbContextOptions<ConstructoItDbContext> options) : base(options) { }

        public DbSet<Condominio> Condominio { get; set; }
        public DbSet<Familia> Familia { get; set; }
        public DbSet<Morador> Morador { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ConfigurationCondominio());
            modelBuilder.ApplyConfiguration(new ConfigurationFamilia());
            modelBuilder.ApplyConfiguration(new ConfigurationMorador());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseSqlServer("server=DESKTOP-QL4VEUH;database=banco; Trusted_Connection=True;");
        }

    }
}
