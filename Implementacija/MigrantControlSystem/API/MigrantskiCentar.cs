using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

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
        [JsonIgnore]
        public int Kapacitet { get; set; }
        [JsonIgnore]
        public int? Lokacijaid { get; set; }
        [JsonIgnore]
        public int? BrojRegistrovanih { get; set; } = 0;
        [JsonIgnore]
        public int? BrojZatvorenih { get; set; } = 0;
        [JsonIgnore]
        public int? StandardniPeriodZadrzavanjaMigranta { get; set; }
        public string Discriminator { get; set; }
        public virtual Lokacija Lokacija { get; set; }
        [JsonIgnore]
        public virtual ICollection<Migrant> Migrant { get; set; }
        [JsonIgnore]
        public virtual ICollection<Zahtjev> ZahtjevDolazniMigrantskiCentar { get; set; }
        [JsonIgnore]
        public virtual ICollection<Zahtjev> ZahtjevMigrantskiCentar { get; set; }
    }
}
