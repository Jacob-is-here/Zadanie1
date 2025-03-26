namespace Aplikacja1;

public class KontenerChlodniczy : Contener
{
    protected string rodzajProduktu;
    protected double tempKontenera;
    protected Dictionary<string, double> slownik;
    protected string mapa="";
    public KontenerChlodniczy( double wysokosc, double wagaWlasna, double glebokosc, double maxLadownosc, string rodzajProduktu,double tempKontenera) : 
        base( wysokosc, wagaWlasna, glebokosc, maxLadownosc)
    {
        this.numerSeryjny = "KON-C-"+count;
        this.slownik =  new Dictionary<string, double>();
        this.rodzajProduktu = rodzajProduktu;
        this.tempKontenera = tempKontenera;
    }

    public Dictionary<string, double> GetSlownik()
    {
        return slownik;
    }

    public void Zaladuj(string typProduktu ,string nazwa , double temp , double waga)
    {
        if (masaLadunku+waga > maxLadownosc)
        {
            throw new OverfillException($"\n\t$Przeciążono kontener {numerSeryjny}!!!");
        }
        else
        {
            if (rodzajProduktu.Equals(typProduktu))
            {
                if (this.tempKontenera > temp)
                {
                    slownik.Add(nazwa, temp);
                    masaLadunku += waga;

                }
                else
                {
                    Console.WriteLine("Kontener "+numerSeryjny+" ma zbyt niską temperature");
                }
            }
            else
            {
                Console.WriteLine("Nie moge dodac innego typu produktu");
            }
        }
    }
    
    public void WypiszKluczeITemp()
    {
        foreach (var item in slownik)
        {
            mapa+=$"Produkt: {item.Key}, Temperatura: {item.Value}\n";
        }
    }

    public override string ToString()
    {
        return base.ToString() + $"\nrodzaj produktu: {rodzajProduktu}\nTemperatura kontenera: {tempKontenera}";
    }
}