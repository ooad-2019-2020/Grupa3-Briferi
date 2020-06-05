using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MigrantControlSystem.Models
{
    public class ZatvoreniLokacijaViewModel
    {
        public MCZatvoreniTip zatvoreniTip { get; set; }
        public Lokacija lokacija { get; set; }
    }
}
