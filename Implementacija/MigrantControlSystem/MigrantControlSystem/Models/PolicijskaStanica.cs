using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MigrantControlSystem.Models
{
    public class PolicijskaStanica
    {
        public int id { get; set; }
        public String naziv { get; set; }
        public virtual Lokacija lokacija { get; set; }
    }
}
