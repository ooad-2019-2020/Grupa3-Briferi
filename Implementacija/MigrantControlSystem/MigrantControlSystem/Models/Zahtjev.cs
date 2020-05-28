using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MigrantControlSystem.Models
{
    public abstract class Zahtjev
    {
        public int id { get; set; }
        public virtual Migrant migrant { get; set; }
        public virtual MigrantskiCentar migrantskiCentar { get; set; }
        private IRokIzvrsenja bridge;
    }
}
