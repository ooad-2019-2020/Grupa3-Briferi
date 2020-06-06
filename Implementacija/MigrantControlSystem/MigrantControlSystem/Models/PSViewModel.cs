using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MigrantControlSystem.Models
{
    public class PSViewModel
    {
        public IEnumerable<PolicijskaStanica> stanice { get; set; }
        public IEnumerable<MCOtvoreniTip> otvoreni { get; set; }

        public IEnumerable<MCZatvoreniTip> zatvoreni { get; set; }
    }
}
