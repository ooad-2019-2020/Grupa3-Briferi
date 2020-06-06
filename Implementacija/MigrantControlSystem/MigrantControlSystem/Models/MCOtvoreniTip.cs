using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MigrantControlSystem.Models
{

    public class MCOtvoreniTip : MigrantskiCentar
    {
        private int brojRegistrovanih1 = 0;

        public int brojRegistrovanih { get => brojRegistrovanih1; set => brojRegistrovanih1 = value; }
    }
}
