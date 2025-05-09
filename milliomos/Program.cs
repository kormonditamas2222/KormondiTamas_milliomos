namespace milliomos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Jatek jatek = new Jatek();
            List<Sorkerdes> sorkerdesek = jatek.SorkerdesBeolvasas("sorkerdes.txt");
            List<Kerdes> kerdesek = jatek.KerdesBeolvasas("kerdes.txt");
            jatek.LegyenOnIsMilliomos(kerdesek, sorkerdesek);
        }
    }
}
