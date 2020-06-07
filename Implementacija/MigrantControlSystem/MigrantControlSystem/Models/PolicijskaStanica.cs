using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MigrantControlSystem.Models
{
    public class PolicijskaStanica
    {
        [Display(Name = "ID")]
        public int id { get; set; }
        [Display(Name="Naziv policijske stanice")]
        public String naziv { get; set; }
        public virtual Lokacija lokacija { get; set; }
    }
}
