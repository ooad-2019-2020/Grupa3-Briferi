
using Microsoft.EntityFrameworkCore;
using MigrantControlSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MigrantControlSystem.Models

{
    public class MCSDbContext:DbContext
    {
        public MCSDbContext(DbContextOptions<MCSDbContext> options) : base(options)
        {
        }
        public DbSet<Migrant> Migrant { get; set; }
        public DbSet<MigrantskiCentar> MigrantskiCentar { get; set; }
        public DbSet<PolicijskaStanica> PolicijskaStanica { get; set; }
        public DbSet<Zahtjev> Zahtjev { get; set; }

        public DbSet<Lokacija> Lokacija { get; set; }

        //Ova funkcija se koriste da bi se ukinulo automatsko dodavanje množine u nazive
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Migrant>().ToTable("Migrant");
            modelBuilder.Entity<MigrantskiCentar>().ToTable("MigrantskiCentar");
            modelBuilder.Entity<PolicijskaStanica>().ToTable("PolicijskaStanica");
            modelBuilder.Entity<Zahtjev>().ToTable("Zahtjev");
            modelBuilder.Entity<Lokacija>().ToTable("Lokacija");
            
        }
    }
}