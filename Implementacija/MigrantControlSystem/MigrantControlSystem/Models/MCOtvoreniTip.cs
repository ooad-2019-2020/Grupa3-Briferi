using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MigrantControlSystem.Models
{

    public class MCOtvoreniTip : MigrantskiCentar
    {
        private int brojRegistrovanih1 = 0;
        [Range(0, int.MaxValue, ErrorMessage ="Minimalan broj registrovanih migranata je 0.")]
        [Display(Name ="Broj registrovanih migranata")]
        public int brojRegistrovanih { get => brojRegistrovanih1; set => brojRegistrovanih1 = value; }
    }
}
