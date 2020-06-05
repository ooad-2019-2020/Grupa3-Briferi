using System;
using System.Collections.Generic;

namespace API
{
    public partial class MigrantskiCentar
    {
        public MigrantskiCentar()
        {
            Migrant = new HashSet<Migrant>();
            ZahtjevDolazniMigrantskiCentar = new HashSet<Zahtjev>();
            ZahtjevMigrantskiCentar = new HashSet<Zahtjev>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }
        public int Kapacitet { get; set; }
        public int? Lokacijaid { get; set; }
        public int? BrojRegistrovanih { get; set; }
        public int? BrojZatvorenih { get; set; }
        public int? StandardniPeriodZadrzavanjaMigranta { get; set; }
        public string Discriminator { get; set; }

        public virtual Lokacija Lokacija { get; set; }
        public virtual ICollection<Migrant> Migrant { get; set; }
        public virtual ICollection<Zahtjev> ZahtjevDolazniMigrantskiCentar { get; set; }
        public virtual ICollection<Zahtjev> ZahtjevMigrantskiCentar { get; set; }
    }
}
