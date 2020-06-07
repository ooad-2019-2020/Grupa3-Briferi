using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MigrantControlSystem.Models
{
    public class Migrant
    {
        [Display(Name = "ID")]
        public int id { get; set; }
        [Required(ErrorMessage = "Polje ime je obavezno.")]
        [StringLength(20, ErrorMessage = "Ime mora sadržavati najmanje 2, a najviše 20 slova.", MinimumLength = 2)]
        [Display(Name = "Ime")]
        public String ime { get; set; }
        [Required(ErrorMessage = "Polje prezime je obavezno.")]
        [StringLength(30, ErrorMessage = "Prezime mora sadržavati najmanje 2, a najviše 30 slova.", MinimumLength = 2)]
        [Display(Name = "Prezime")]
        public String prezime { get; set; }
        [Display(Name = "Država porijekla")]
        public String drzavaPorijekla { get; set; }
        [Required(ErrorMessage = "Unos datuma je obavezan.")]
        [Display(Name = "Datum registracije")]
        public DateTime datumRegistracije { get; set; }
        public virtual MigrantskiCentar migrantskiCentar { get; set; }
        public virtual PolicijskaStanica policijskaStanica { get; set; }
    }
}