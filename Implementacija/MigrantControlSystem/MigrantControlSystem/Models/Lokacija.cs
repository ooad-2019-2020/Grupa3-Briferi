using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace MigrantControlSystem.Models
{
    public class Lokacija
    {
        public int id { get; set; }
        [Required(ErrorMessage ="Polje x koordinate je obavezno.")]
        [Display(Name ="X koordinata")]
        public double x { get; set; }
        [Required(ErrorMessage = "Polje y koordinate je obavezno.")]
        [Display(Name = "Y koordinata")]
        public double y { get; set; }
    }
}
