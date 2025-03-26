namespace Aplikacja1;

public class KontenerNaPlyny : Contener , IHazardNotifier

{
    private bool niebezpieczny;
    public KontenerNaPlyny(double wysokosc , double wagaWlasna , double glebokosc , double maxLadownosc, bool niebezpieczny) : 
        base(wysokosc, wagaWlasna, glebokosc,  maxLadownosc)
    {
        this.niebezpieczny = niebezpieczny;
        this.numerSeryjny = "KON-L-"+count;

    }

    public override void Zaladuj(double ladunek)
    {
        if ((niebezpieczny && masaLadunku >= maxLadownosc / 2) ||(!niebezpieczny && masaLadunku >= maxLadownosc *0.9))
        {
            NiebezpiecznaCiecz();
        }
        else
        {
            if (niebezpieczny)
            {
                if (ladunek > maxLadownosc / 2)
                {
                    Console.WriteLine("Moglem zaladowac tylko "+maxLadownosc / 2+" litrow");
                    base.Zaladuj(maxLadownosc / 2);
                }
                else
                {
                    base.Zaladuj(ladunek);
                }

            }
            else
            {
                if (ladunek > maxLadownosc * 0.9)
                {
                    Console.WriteLine("Mogłem jedynie zatankowac "+maxLadownosc * 0.9+" litrow");
                    base.Zaladuj(maxLadownosc * 0.9);
                }
                else
                {
                    base.Zaladuj(ladunek);
                }
            }

            
            
            Console.WriteLine("Załadowano towar.");
            
        }

    }

    public override string ToString()
    {
        return base.ToString() +"\nNiebezpieczny : "+niebezpieczny;
    }


    public void NiebezpiecznaCiecz()
    {
        Console.WriteLine("\n\tNiebezpieczna sytuacja w kontenerze " + this.numerSeryjny+"\n");
    }
}