using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace API
{
    public partial class Migrant
    {
        public Migrant()
        {
            Zahtjev = new HashSet<Zahtjev>();
        }

        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string DrzavaPorijekla { get; set; }
        public DateTime DatumRegistracije { get; set; }
        public int? MigrantskiCentarid { get; set; }
        public int? PolicijskaStanicaid { get; set; }
        [JsonIgnore]
        public virtual MigrantskiCentar MigrantskiCentar { get; set; }
        [JsonIgnore]
        public virtual PolicijskaStanica PolicijskaStanica { get; set; }
        [JsonIgnore]
        public virtual ICollection<Zahtjev> Zahtjev { get; set; }
    }
}
