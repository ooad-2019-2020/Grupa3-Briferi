using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MigrantControlSystem.Models
{
    public abstract class MigrantskiCentar
    {
        [Display(Name = "ID")]
        public int id { get; set; }
        [Required(ErrorMessage = "Polje naziv je obavezno.")]
        [StringLength(20, ErrorMessage = "Naziv mora sadržavati najmanje 5, a najviše 20 slova.", MinimumLength = 5)]
        [Display(Name = "Naziv migrantskog centra")]
        public String naziv { get; set; }
        [Required(ErrorMessage = "Polje kapacitet je obavezno.")]
        [Range(1, int.MaxValue, ErrorMessage="Kapacitet mora biti veći od 1.")]
        [Display(Name = "Kapacitet")]
        public int kapacitet { get; set; }
        public virtual Lokacija lokacija { get; set; }
        public virtual ICollection<Migrant> migranti { get; set; }
        public virtual ICollection<Zahtjev> zahtjevi { get; set; }
    }
}

