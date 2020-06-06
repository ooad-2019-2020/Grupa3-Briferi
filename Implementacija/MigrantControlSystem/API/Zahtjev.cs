using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace API
{
    public partial class Zahtjev
    {
        public int Id { get; set; }
        public int? Migrantid { get; set; }
        public int? MigrantskiCentarid { get; set; }
        public int? DodatniRokIzvrsenja { get; set; }
        public string Drzava { get; set; }
        public int? HapsenjeDodatniRokIzvrsenja { get; set; }
        public int? PolicijskaStanicaid { get; set; }
        public int? PremjestanjeDodatniRokIzvrsenja { get; set; }
        public int? DolazniMigrantskiCentarid { get; set; }
        public string Discriminator { get; set; }
        [JsonIgnore]
        public virtual MigrantskiCentar DolazniMigrantskiCentar { get; set; }
        [JsonIgnore]
        public virtual Migrant Migrant { get; set; }
        [JsonIgnore]
        public virtual MigrantskiCentar MigrantskiCentar { get; set; }
        [JsonIgnore]
        public virtual PolicijskaStanica PolicijskaStanica { get; set; }
    }
}
