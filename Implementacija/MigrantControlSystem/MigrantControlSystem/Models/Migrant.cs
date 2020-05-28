using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MigrantControlSystem.Models
{
    public class Migrant
    {
        public int id { get; set; }
        public String ime { get; set; }
        public String prezime { get; set; }
        public String drzavaPorijekla { get; set; }
        public DateTime datumRegistracije { get; set; }
        public virtual MigrantskiCentar migrantskiCentar { get; set; }
        public virtual PolicijskaStanica policijskaStanica { get; set; }
    }
}