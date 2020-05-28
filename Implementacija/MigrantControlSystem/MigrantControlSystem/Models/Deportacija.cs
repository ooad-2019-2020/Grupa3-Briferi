using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MigrantControlSystem.Models
{
    public class Deportacija : Zahtjev, IRokIzvrsenja
    {
        public String drzava { get; set; }
        public int dodatniRokIzvrsenja { get; set; }
        public int getNoviRokIzvrsenja()
        {
            return 2 + dodatniRokIzvrsenja;
        }
    }
}
