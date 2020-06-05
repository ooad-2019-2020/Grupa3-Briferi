using System;
using System.Collections.Generic;

namespace API
{
    public partial class Lokacija
    {
        public Lokacija()
        {
            MigrantskiCentar = new HashSet<MigrantskiCentar>();
            PolicijskaStanica = new HashSet<PolicijskaStanica>();
        }

        public int Id { get; set; }
        public double X { get; set; }
        public double Y { get; set; }

        public virtual ICollection<MigrantskiCentar> MigrantskiCentar { get; set; }
        public virtual ICollection<PolicijskaStanica> PolicijskaStanica { get; set; }
    }
}
