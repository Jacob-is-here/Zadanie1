namespace Aplikacja1;

public class Contener
{
    protected double masaLadunku =0; // kg
    protected double wysokosc; // cm
    protected double wagaWlasna; // kg
    protected double glebokosc; // cm
    protected string numerSeryjny;
    protected static int count = 0;
    protected double maxLadownosc; // kg
    
    
    public Contener(double wysokosc , double wagaWlasna , double glebokosc , double maxLadownosc)
    {
        count++;
        this.masaLadunku = masaLadunku;
        this.wysokosc = wysokosc;
        this.wagaWlasna = wagaWlasna;
        this.glebokosc = glebokosc;
        this.maxLadownosc = maxLadownosc;
        if (masaLadunku > this.maxLadownosc)
        {
            throw new OverfillException("Zbyt duza masa ładunku !!!");
        }
        
    }

    public virtual void Oproznij()
    {
        this.masaLadunku = 0;
    }

    public virtual void Zaladuj(double ladunek)
    {
        if (masaLadunku+ladunek > maxLadownosc)
        {
            throw new OverfillException($"\n\t$Przeciążono kontener {numerSeryjny}!!!");
        }
        else
        {
            masaLadunku += ladunek;
            Console.WriteLine("Załadowano gaz pomyślnie.");
        }
    }

    public double GetWaga()
    {
        return wagaWlasna + masaLadunku;
    }

    public double GetMasa()
    {
        return masaLadunku;
    }

    public string GetNazwe()
    {
        return this.numerSeryjny;
    }
    public virtual string ToString()
    {
        return $"Contener: {numerSeryjny}\nMasa Ladunku: {masaLadunku}\nWysokosc: {wysokosc}\nWaga Wlasna: {wagaWlasna}\nGlebokosc: {glebokosc}\nMax Ladownosc: {maxLadownosc}";
    }
    
}

public class OverfillException : Exception
{
    public OverfillException(string message):base(message){}
}