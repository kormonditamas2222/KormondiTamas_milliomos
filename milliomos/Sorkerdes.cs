using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace milliomos
{
    internal class Sorkerdes
    {
        string kerdes;
        string[] valaszok;
        string sorrend;
        string kategoria;

        public Sorkerdes(string kerdes, string[] valaszok, string sorrend, string kategoria)
        {
            this.kerdes = kerdes;
            this.valaszok = valaszok;
            this.sorrend = sorrend;
            this.kategoria = kategoria;
        }

        public string Kerdes { get => kerdes;  }
        public string[] Valaszok { get => valaszok; }
        public string Sorrend { get => sorrend; }
        public string Kategoria { get => kategoria; }

        
    }
}
