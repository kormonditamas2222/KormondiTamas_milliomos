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
        char megoldas;
        string kategoria;

        public Kerdes(short nehezseg, string kerdess, string[] valaszok, char megoldas, string kategoria)
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
        public char Megoldas { get => megoldas; }
        public string Kategoria { get => kategoria; }

        public List<Kerdes> KerdesBeolvasas(string fileName)
        {
            List<Kerdes> kerdesek = new();
            StreamReader sr = new(fileName);
            while (!sr.EndOfStream)
            {
                string[] line = sr.ReadLine().Split(";");
                string[] valaszok = [line[2], line[3], line[4], line[5]];
                Kerdes kerdes = new(Convert.ToInt16(line[0]), line[1], valaszok, Convert.ToChar(line[6]), line[7]);
                kerdesek.Add(kerdes);
            }
            return kerdesek;
        }
    }
}
