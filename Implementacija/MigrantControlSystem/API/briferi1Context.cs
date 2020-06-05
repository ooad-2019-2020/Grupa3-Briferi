using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace API
{
    public partial class briferi1Context : DbContext
    {
        public briferi1Context()
        {
        }

        public briferi1Context(DbContextOptions<briferi1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Lokacija> Lokacija { get; set; }
        public virtual DbSet<Migrant> Migrant { get; set; }
        public virtual DbSet<MigrantskiCentar> MigrantskiCentar { get; set; }
        public virtual DbSet<PolicijskaStanica> PolicijskaStanica { get; set; }
        public virtual DbSet<Zahtjev> Zahtjev { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:briferi.database.windows.net,1433;Initial Catalog=briferi1;Persist Security Info=False;User ID=brifer;Password=Brife1921;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lokacija>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.X).HasColumnName("x");

                entity.Property(e => e.Y).HasColumnName("y");
            });

            modelBuilder.Entity<Migrant>(entity =>
            {
                entity.HasIndex(e => e.MigrantskiCentarid);

                entity.HasIndex(e => e.PolicijskaStanicaid);

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DatumRegistracije).HasColumnName("datumRegistracije");

                entity.Property(e => e.DrzavaPorijekla).HasColumnName("drzavaPorijekla");

                entity.Property(e => e.Ime).HasColumnName("ime");

                entity.Property(e => e.MigrantskiCentarid).HasColumnName("migrantskiCentarid");

                entity.Property(e => e.PolicijskaStanicaid).HasColumnName("policijskaStanicaid");

                entity.Property(e => e.Prezime).HasColumnName("prezime");

                entity.HasOne(d => d.MigrantskiCentar)
                    .WithMany(p => p.Migrant)
                    .HasForeignKey(d => d.MigrantskiCentarid);

                entity.HasOne(d => d.PolicijskaStanica)
                    .WithMany(p => p.Migrant)
                    .HasForeignKey(d => d.PolicijskaStanicaid);
            });

            modelBuilder.Entity<MigrantskiCentar>(entity =>
            {
                entity.HasIndex(e => e.Lokacijaid);

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BrojRegistrovanih).HasColumnName("brojRegistrovanih");

                entity.Property(e => e.BrojZatvorenih).HasColumnName("brojZatvorenih");

                entity.Property(e => e.Discriminator)
                    .IsRequired()
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.Kapacitet).HasColumnName("kapacitet");

                entity.Property(e => e.Lokacijaid).HasColumnName("lokacijaid");

                entity.Property(e => e.Naziv).HasColumnName("naziv");

                entity.Property(e => e.StandardniPeriodZadrzavanjaMigranta).HasColumnName("standardniPeriodZadrzavanjaMigranta");

                entity.HasOne(d => d.Lokacija)
                    .WithMany(p => p.MigrantskiCentar)
                    .HasForeignKey(d => d.Lokacijaid);
            });

            modelBuilder.Entity<PolicijskaStanica>(entity =>
            {
                entity.HasIndex(e => e.Lokacijaid);

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Lokacijaid).HasColumnName("lokacijaid");

                entity.Property(e => e.Naziv).HasColumnName("naziv");

                entity.HasOne(d => d.Lokacija)
                    .WithMany(p => p.PolicijskaStanica)
                    .HasForeignKey(d => d.Lokacijaid);
            });

            modelBuilder.Entity<Zahtjev>(entity =>
            {
                entity.HasIndex(e => e.DolazniMigrantskiCentarid);

                entity.HasIndex(e => e.Migrantid);

                entity.HasIndex(e => e.MigrantskiCentarid);

                entity.HasIndex(e => e.PolicijskaStanicaid);

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Discriminator)
                    .IsRequired()
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.DodatniRokIzvrsenja).HasColumnName("dodatniRokIzvrsenja");

                entity.Property(e => e.DolazniMigrantskiCentarid).HasColumnName("dolazniMigrantskiCentarid");

                entity.Property(e => e.Drzava).HasColumnName("drzava");

                entity.Property(e => e.HapsenjeDodatniRokIzvrsenja).HasColumnName("Hapsenje_dodatniRokIzvrsenja");

                entity.Property(e => e.Migrantid).HasColumnName("migrantid");

                entity.Property(e => e.MigrantskiCentarid).HasColumnName("migrantskiCentarid");

                entity.Property(e => e.PolicijskaStanicaid).HasColumnName("policijskaStanicaid");

                entity.Property(e => e.PremjestanjeDodatniRokIzvrsenja).HasColumnName("Premjestanje_dodatniRokIzvrsenja");

                entity.HasOne(d => d.DolazniMigrantskiCentar)
                    .WithMany(p => p.ZahtjevDolazniMigrantskiCentar)
                    .HasForeignKey(d => d.DolazniMigrantskiCentarid);

                entity.HasOne(d => d.Migrant)
                    .WithMany(p => p.Zahtjev)
                    .HasForeignKey(d => d.Migrantid);

                entity.HasOne(d => d.MigrantskiCentar)
                    .WithMany(p => p.ZahtjevMigrantskiCentar)
                    .HasForeignKey(d => d.MigrantskiCentarid);

                entity.HasOne(d => d.PolicijskaStanica)
                    .WithMany(p => p.Zahtjev)
                    .HasForeignKey(d => d.PolicijskaStanicaid);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
