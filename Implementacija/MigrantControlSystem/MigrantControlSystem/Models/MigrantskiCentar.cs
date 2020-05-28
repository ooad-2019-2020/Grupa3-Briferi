using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MigrantControlSystem.Models
{
    public class MigrantskiCentar
    {
        public int id { get; set; }
        public String naziv { get; set; }
        public int kapacitet { get; set; }
        public virtual Lokacija lokacija { get; set; }
        public virtual ICollection<Migrant> migranti { get; set; }
        public virtual ICollection<Zahtjev> zahtjevi { get; set; }
    }
}

