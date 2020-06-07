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
        [Required(ErrorMessage = "Polje naziv je obavezno.")]
        [StringLength(30, ErrorMessage = "Ime mora sadržavati najmanje 5, a najviše 30 slova.", MinimumLength = 5)]
        [Display(Name="Naziv policijske stanice")]
        public String naziv { get; set; }
        public virtual Lokacija lokacija { get; set; }
    }
}
