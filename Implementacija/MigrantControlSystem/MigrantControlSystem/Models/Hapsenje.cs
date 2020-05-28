using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MigrantControlSystem.Models
{
    public class Hapsenje : Zahtjev, IRokIzvrsenja
    {
        public virtual PolicijskaStanica policijskaStanica { get; set; }
        public int dodatniRokIzvrsenja { get; set; }
        public int getNoviRokIzvrsenja()
        {
            return 2 + dodatniRokIzvrsenja;
        }
    }
}
