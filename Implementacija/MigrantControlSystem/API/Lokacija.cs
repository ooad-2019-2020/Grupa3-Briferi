using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace API
{
    public partial class Lokacija
    {
        public Lokacija()
        {
            MigrantskiCentar = new HashSet<MigrantskiCentar>();
            PolicijskaStanica = new HashSet<PolicijskaStanica>();
        }
        [JsonIgnore]
        public int Id { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        [JsonIgnore]
        public virtual ICollection<MigrantskiCentar> MigrantskiCentar { get; set; }
        [JsonIgnore]
        public virtual ICollection<PolicijskaStanica> PolicijskaStanica { get; set; }
    }
}
