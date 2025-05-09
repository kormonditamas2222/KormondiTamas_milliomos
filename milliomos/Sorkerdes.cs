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

        public List<Sorkerdes> SorkerdesBeolvasas(string fileName)
        {
            List<Sorkerdes> sorkerdesek = new();
            StreamReader sr = new(fileName);
            while (!sr.EndOfStream)
            {
                string[] line = sr.ReadLine().Split(";");
                string[] valaszok = [line[1], line[2], line[3], line[4]];
                Sorkerdes kerdes = new(line[0], valaszok, line[5], line[6]);
                sorkerdesek.Add(kerdes);
            }
            return sorkerdesek;
        }
    }
}
