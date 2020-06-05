using System;
using System.Collections.Generic;

namespace API
{
    public partial class PolicijskaStanica
    {
        public PolicijskaStanica()
        {
            Migrant = new HashSet<Migrant>();
            Zahtjev = new HashSet<Zahtjev>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }
        public int? Lokacijaid { get; set; }

        public virtual Lokacija Lokacija { get; set; }
        public virtual ICollection<Migrant> Migrant { get; set; }
        public virtual ICollection<Zahtjev> Zahtjev { get; set; }
    }
}
