using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MigrantControlSystem.Models
{
    public class MCZatvoreniTip : MigrantskiCentar
    {
        [Required(ErrorMessage ="Polje perioda zadržavanja je obavezno.")]
        [Range(1, 30, ErrorMessage ="Minimalan broj dana zadržavanja migranta je 1, a maximalan 30.")]
        [Display(Name ="Stand. broj dana zadrzavanja migranta")]
        public int standardniPeriodZadrzavanjaMigranta { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Minimalan broj zatvorenih migranata je 0.")]
        [Display(Name = "Broj zatvorenih migranata")]
        public int brojZatvorenih { get; set; } = 0;
    }
}
