using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace milliomos
{
    internal class Kerdes
    {
        short nehezseg;
        string kerdess;
        string[] valaszok;
        string megoldas;
        string kategoria;

        public Kerdes(short nehezseg, string kerdess, string[] valaszok, string megoldas, string kategoria)
        {
            this.nehezseg = nehezseg;
            this.kerdess = kerdess;
            this.valaszok = valaszok;
            this.megoldas = megoldas;
            this.kategoria = kategoria;
        }

        public short Nehezseg { get => nehezseg; }
        public string Kerdess { get => kerdess; }
        public string[] Valaszok { get => valaszok; }
        public string Megoldas { get => megoldas; }
        public string Kategoria { get => kategoria; }

    }
}
