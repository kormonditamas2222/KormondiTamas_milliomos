using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace milliomos
{
    
    internal class Jatek
    {
        static Random random = new Random();

        string[] nyeremenyek;
        int jelenlegiKerdesSzama;

        public Jatek()
        {
            this.nyeremenyek = ["10.000 Ft", "20.000 Ft", "50.000 Ft", "100.000 Ft", "250.000 Ft", "500.000 Ft", "750.000 Ft", "1.000.000 Ft", "1.500.000 Ft", "2.000.000 Ft", "5.000.000 Ft",
            "10.000.000 Ft", "15.000.000 Ft", "25.000.000 Ft", "50.000.000 Ft"];
            this.jelenlegiKerdesSzama = 1;
        }

        public string[] Nyeremenyek { get => nyeremenyek; }
        public int JelenlegiKerdesSzama { get => jelenlegiKerdesSzama; set => jelenlegiKerdesSzama = value; }

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

        public List<Kerdes> KerdesBeolvasas(string fileName)
        {
            List<Kerdes> kerdesek = new();
            StreamReader sr = new(fileName);
            while (!sr.EndOfStream)
            {
                string[] line = sr.ReadLine().Split(";");
                string[] valaszok = [line[2], line[3], line[4], line[5]];
                Kerdes kerdes = new(Convert.ToInt16(line[0]), line[1], valaszok, line[6], line[7]);
                kerdesek.Add(kerdes);
            }
            return kerdesek;
        }

        public void LegyenOnIsMilliomos(List<Kerdes> kerdesek, List<Sorkerdes> sorkerdesek)
        {
            bool game = true;
            string sorkerdesValasz, valasz;
            string[] segitsegek = ["felezés", "közönség", "hívás"];
            do
            {
                Console.WriteLine("Üdvözöllek a Legyen Ön is milliomos nevű játékban!");
                Sorkerdes sorkerdes = sorkerdesek[random.Next(0, sorkerdesek.Count)];
                Console.WriteLine("Válaszolj helyesen erre a kérdésre, hogy belépj az igazi játékmenetbe!");
                Console.WriteLine("A következő kérdés az alábbi kategóriában van: " + sorkerdes.Kategoria);
                Console.WriteLine(sorkerdes.Kerdes);
                Console.WriteLine($"A: {sorkerdes.Valaszok[0]}\t B: {sorkerdes.Valaszok[1]}\n C: {sorkerdes.Valaszok[2]} \t D: {sorkerdes.Valaszok[3]}");
                Console.Write("Válaszod: ");
                sorkerdesValasz = Console.ReadLine() ?? "";
                if (sorkerdesValasz.ToUpper() == sorkerdes.Sorrend)
                {
                    Console.WriteLine("Helyes a sorrend, kezdődjön a játék!");
                    Console.Write("Neved: ");
                    string nev = Console.ReadLine() ?? "";
                    Console.WriteLine($"Kedves {nev}! Válaszolj helyesen a kérdésekre, hogy végül elérd az ötven millió forintos főnyereményt. \n " +
                        $"Ha szeretnél segítséget kérni, akkor válaszként beírhatod a következő szavakat: [felezés, közönség, hívás]. " +
                        $"\n Ha nem tudsz felülkerekedni az adott kérdésen, akkor csak írd be azt hogy [kilép], és az eddig összegyűjtött pénzedet megkapod.\n" +
                        $"Sok szerencsét!");
                    do
                    {
                        List<Kerdes> validKerdesek = [];
                        Kerdes kerdes;
                        foreach (var item in kerdesek)
                        {
                            if (item.Nehezseg == JelenlegiKerdesSzama)
                            {
                                validKerdesek.Add(item);
                            }
                        }
                        kerdes = validKerdesek[random.Next(0, validKerdesek.Count)];
                        Console.WriteLine("A következő kérdés az alábbi kategóriában van: " + kerdes.Kategoria);
                        Console.WriteLine(kerdes.Kerdess);
                        Console.WriteLine($"A: {kerdes.Valaszok[0]}\t B: {kerdes.Valaszok[1]}\n C: {kerdes.Valaszok[2]} \t D: {kerdes.Valaszok[3]}");
                        Console.WriteLine("Válaszod: ");
                        valasz = Console.ReadLine() ?? "";
                        if (valasz.ToUpper() == kerdes.Megoldas)
                        {
                            Console.WriteLine("Helyes válasz!");
                            Console.WriteLine("Jelenlegi nyereményed: " + Nyeremenyek[JelenlegiKerdesSzama]);
                            JelenlegiKerdesSzama++;
                        }

                    } while (JelenlegiKerdesSzama < 16 && game == true);
                }  
                else
                {
                    Console.WriteLine("Helytelen válasz, a játékból kiestél!");
                    game = false;
                }
            } while (game);
        }
    }
}
