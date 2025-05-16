using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
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
                        Console.WriteLine($"Elérhető segítségeid: {segitsegek[0]}, {segitsegek[1]}, {segitsegek[2]}");
                        Console.WriteLine("Válaszod: ");
                        valasz = Console.ReadLine() ?? "";
                        if (valasz.ToUpper() == kerdes.Megoldas)
                        {
                            Console.WriteLine("Helyes válasz!");
                            Console.WriteLine("Jelenlegi nyereményed: " + Nyeremenyek[JelenlegiKerdesSzama - 1]);
                            JelenlegiKerdesSzama++;
                        }
                        else if (valasz.ToLower() == "felezés" && segitsegek.Contains(valasz.ToLower()))
                        {
                            segitsegek[0] = "";
                            int randomSzam = random.Next(0, 3);
                            switch (kerdes.Megoldas)
                            {
                                case "A":
                                    switch (randomSzam)
                                    {
                                        case 0: Console.WriteLine($"A: {kerdes.Valaszok[0]}\t B: {kerdes.Valaszok[1]}"); break;
                                        case 1: Console.WriteLine($"A: {kerdes.Valaszok[0]}\t C: {kerdes.Valaszok[2]}"); break;
                                        case 2: Console.WriteLine($"A: {kerdes.Valaszok[0]}\t D: {kerdes.Valaszok[3]}"); break;
                                        default: break;
                                    }
                                    break;
                                case "B":
                                    switch (randomSzam)
                                    {
                                        case 0: Console.WriteLine($"A: {kerdes.Valaszok[0]}\t B: {kerdes.Valaszok[1]}"); break;
                                        case 1: Console.WriteLine($"B: {kerdes.Valaszok[1]}\t C: {kerdes.Valaszok[2]}"); break;
                                        case 2: Console.WriteLine($"B: {kerdes.Valaszok[1]}\t D: {kerdes.Valaszok[3]}"); break;
                                        default: break;
                                    }
                                    break;
                                case "C":
                                    switch (randomSzam)
                                    {
                                        case 0: Console.WriteLine($"A: {kerdes.Valaszok[0]}\t C: {kerdes.Valaszok[2]}"); break;
                                        case 1: Console.WriteLine($"B: {kerdes.Valaszok[1]}\t C: {kerdes.Valaszok[2]}"); break;
                                        case 2: Console.WriteLine($"C: {kerdes.Valaszok[2]}\t D: {kerdes.Valaszok[3]}"); break;
                                        default: break;
                                    }
                                    break;
                                case "D":
                                    switch (randomSzam)
                                    {
                                        case 0: Console.WriteLine($"A: {kerdes.Valaszok[0]}\t D: {kerdes.Valaszok[3]}"); break;
                                        case 1: Console.WriteLine($"B: {kerdes.Valaszok[1]}\t D: {kerdes.Valaszok[3]}"); break;
                                        case 2: Console.WriteLine($"C: {kerdes.Valaszok[2]}\t D: {kerdes.Valaszok[3]}"); break;
                                        default: break;
                                    }
                                    break;
                            }
                            Console.WriteLine("Válaszod: ");
                            valasz = Console.ReadLine() ?? "";
                            if (valasz.ToUpper() == kerdes.Megoldas)
                            {
                                Console.WriteLine("Helyes válasz!");
                                Console.WriteLine("Jelenlegi nyereményed: " + Nyeremenyek[JelenlegiKerdesSzama - 1]);
                                JelenlegiKerdesSzama++;
                            }
                            else
                            {
                                Console.WriteLine("Helytelen válasz! A játékból kiestél!");
                                switch (JelenlegiKerdesSzama)
                                {
                                    case <= 5:
                                        Console.WriteLine("Nyereményed: 0 Ft");
                                        break;
                                    case <= 10:
                                        Console.WriteLine($"Nyerményed: {Nyeremenyek[4]}");
                                        break;
                                    case <= 15:
                                        Console.WriteLine($"Nyeréményed: {Nyeremenyek[9]}");
                                        break;
                                    default: break;
                                }
                                game = false;
                            }
                        }
                        else if (valasz.ToLower() == "közönség" && segitsegek.Contains(valasz.ToLower()))
                        {
                            segitsegek[1] = "";
                            const int max = 80;
                            int total = 80;
                            int[] szazalekok = new int[4];
                            do
                            {
                                for (int i = 0; i < szazalekok.Length; i++)
                                {
                                    szazalekok[i] = random.Next(0, total + 1);
                                    total -= szazalekok[i];
                                }
                            } while ((szazalekok[0] + szazalekok[1] + szazalekok[2] + szazalekok[3]) != max);
                            switch (kerdes.Megoldas)
                            {
                                case "A": szazalekok[0] += 20; break;
                                case "B": szazalekok[1] += 20; break;
                                case "C": szazalekok[2] += 20; break;
                                case "D": szazalekok[3] += 20; break;
                                default: break;
                            }
                            Console.WriteLine("A közönség döntött!");
                            Console.WriteLine($"A közönség válaszai: A: {szazalekok[0]}% B: {szazalekok[1]}% C: {szazalekok[2]}% D: {szazalekok[3]}%");
                            Console.WriteLine("Válaszod: ");
                            valasz = Console.ReadLine() ?? "";
                            if (valasz.ToUpper() == kerdes.Megoldas)
                            {
                                Console.WriteLine("Helyes válasz!");
                                Console.WriteLine("Jelenlegi nyereményed: " + Nyeremenyek[JelenlegiKerdesSzama - 1]);
                                JelenlegiKerdesSzama++;
                            }
                            else
                            {
                                Console.WriteLine("Helytelen válasz! A játékból kiestél!");
                                switch (JelenlegiKerdesSzama)
                                {
                                    case <= 5:
                                        Console.WriteLine("Nyereményed: 0 Ft");
                                        break;
                                    case <= 10:
                                        Console.WriteLine($"Nyerményed: {Nyeremenyek[4]}");
                                        break;
                                    case <= 15:
                                        Console.WriteLine($"Nyeréményed: {Nyeremenyek[9]}");
                                        break;
                                    default: break;
                                }
                                game = false;
                            }
                        }
                        else if (valasz.ToLower() == "hívás" && segitsegek.Contains(valasz.ToLower()))
                        {
                            segitsegek[2] = "";
                            int esely = random.Next(1, 101);
                            int randomValasztas = random.Next(0, 3);
                            switch (kerdes.Megoldas)
                            {
                                case "A":
                                    string[] egyeb = ["B", "C", "D"];
                                    if (esely > 40) Console.WriteLine("Apád azt mondja, hogy a jó válasz A lehet.");
                                    else Console.WriteLine($"Apád azt mondja, hogy a jó válasz {egyeb[randomValasztas]}");
                                    break;
                                case "B":
                                    egyeb = ["A", "C", "D"];
                                    if (esely > 40) Console.WriteLine("Apád azt mondja, hogy a jó válasz B lehet.");
                                    else Console.WriteLine($"Apád azt mondja, hogy a jó válasz {egyeb[randomValasztas]}");
                                    break;
                                case "C":
                                    egyeb = ["A", "B", "D"];
                                    if (esely > 40) Console.WriteLine("Apád azt mondja, hogy a jó válasz C lehet.");
                                    else Console.WriteLine($"Apád azt mondja, hogy a jó válasz {egyeb[randomValasztas]}");
                                    break;
                                case "D":
                                    egyeb = ["A", "B", "C"];
                                    if (esely > 40) Console.WriteLine("Apád azt mondja, hogy a jó válasz D lehet.");
                                    else Console.WriteLine($"Apád azt mondja, hogy a jó válasz {egyeb[randomValasztas]}");
                                    break;
                                default: break;
                            }
                            Console.WriteLine("Válaszod: ");
                            valasz = Console.ReadLine() ?? "";
                            if (valasz.ToUpper() == kerdes.Megoldas)
                            {
                                Console.WriteLine("Helyes válasz!");
                                Console.WriteLine("Jelenlegi nyereményed: " + Nyeremenyek[JelenlegiKerdesSzama - 1]);
                                JelenlegiKerdesSzama++;
                            }
                            else
                            {
                                Console.WriteLine("Helytelen válasz! A játékból kiestél!");
                                switch (JelenlegiKerdesSzama)
                                {
                                    case <= 5:
                                        Console.WriteLine("Nyereményed: 0 Ft");
                                        break;
                                    case <= 10:
                                        Console.WriteLine($"Nyerményed: {Nyeremenyek[4]}");
                                        break;
                                    case <= 15:
                                        Console.WriteLine($"Nyeréményed: {Nyeremenyek[9]}");
                                        break;
                                    default: break;
                                }
                                game = false;
                            }
                        }
                        else if (valasz.ToLower() == "kilép")
                        {
                            Console.WriteLine("Kiléptél a játékból, köszönöm a játékot, remélem élvezted!");
                            if (JelenlegiKerdesSzama == 1)
                            {
                                Console.WriteLine("Nyereményed: 0 Ft");
                            }
                            else
                            {
                                Console.WriteLine($"Nyereményed: {Nyeremenyek[JelenlegiKerdesSzama - 1]}");
                            }
                            game = false;
                        }
                        else
                        {
                            Console.WriteLine("Helytelen válasz! A játékból kiestél!");
                            switch (JelenlegiKerdesSzama)
                            {
                                case <= 5:
                                    Console.WriteLine("Nyereményed: 0 Ft");
                                    break;
                                case <= 10:
                                    Console.WriteLine($"Nyerményed: {Nyeremenyek[4]}");
                                    break;
                                case <= 15:
                                    Console.WriteLine($"Nyeréményed: {Nyeremenyek[9]}");
                                    break;
                                default: break;
                            }
                            game = false;
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
