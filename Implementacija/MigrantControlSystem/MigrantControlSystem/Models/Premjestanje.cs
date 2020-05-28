using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MigrantControlSystem.Models
{
    public class Premjestanje : Zahtjev, IRokIzvrsenja
    {
        public virtual MigrantskiCentar dolazniMigrantskiCentar { get; set; }
        public int dodatniRokIzvrsenja { get; set; }

        public int getNoviRokIzvrsenja()
        {
            return 2 + dodatniRokIzvrsenja;
        }
    }
}
