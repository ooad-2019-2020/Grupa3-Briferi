using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MigrantControlSystem.Models
{
    public class MCZatvoreniTip : MigrantskiCentar
    {
        public int standardniPeriodZadrzavanjaMigranta { get; set; }
        public int brojZatvorenih { get; set; }
    }
}
