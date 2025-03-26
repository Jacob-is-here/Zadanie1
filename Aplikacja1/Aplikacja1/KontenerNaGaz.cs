namespace Aplikacja1;

public class KontenerNaGaz : Contener
{
    private double cisnienie; // Bar
    public KontenerNaGaz( double wysokosc, double wagaWlasna, double glebokosc, double maxLadownosc , double cisnienie) : 
        base(wysokosc, wagaWlasna, glebokosc,  maxLadownosc)
    {
        this.numerSeryjny = "KON-G-"+count;
        this.cisnienie = cisnienie;
    }

    public override void Oproznij()
    {
        if (masaLadunku>0)
        {
            this.masaLadunku *= 0.05;      
            Console.WriteLine("Pozostało "+masaLadunku+" l gazu.");
        }
        else
        {
            Console.WriteLine("/tNie ma co opróżnić , kontener jest pusty .");
        }
     
    }

    public override string ToString()
    {
        return base.ToString()+ $"\nCisnienie : {cisnienie}";
    }
}