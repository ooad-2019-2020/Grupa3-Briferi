using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace API
{
    public partial class PolicijskaStanica
    {
        public PolicijskaStanica()
        {
            Migrant = new HashSet<Migrant>();
            Zahtjev = new HashSet<Zahtjev>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }
        [JsonIgnore]
        public int? Lokacijaid { get; set; }
        public virtual Lokacija Lokacija { get; set; }
        [JsonIgnore]
        public virtual ICollection<Migrant> Migrant { get; set; }
        [JsonIgnore]
        public virtual ICollection<Zahtjev> Zahtjev { get; set; }
    }
}
