namespace Aplikacja1;

public class Kontenerowiec
{
    protected string nazwa;
    protected List<Contener> listaKontenerow ;
    protected double predkosc; // węzły
    protected int maxIloscKontenerow;
    protected double maxWaga; // tona 
    protected double aktualnaWaga = 0;
    protected double aktualnaIloscKontenerow = 0;

    public double GetNowWaga()
    {
        return aktualnaWaga;
    }

    public List<Contener> GetListe()
    {
        return listaKontenerow;
    }
    public Kontenerowiec(string nazwa,double predkosc, int maxIloscKontenerow, double maxWaga)
    {
        this.nazwa = nazwa;
        listaKontenerow = new List<Contener>();
        this.predkosc = predkosc;
        this.maxIloscKontenerow = maxIloscKontenerow;
        this.maxWaga = maxWaga;
    }

    public void Zaladuj(Contener contener)
    {
        
        if (aktualnaWaga+contener.GetWaga() > maxWaga * 1000 )
        {
            Console.WriteLine("Zbyt duża waga kontenera. Nie można załadowac kontenera : " + contener.GetNazwe());
        }
        else if (aktualnaIloscKontenerow + 1 > maxIloscKontenerow)
        {
            Console.WriteLine("Zbyt duża ilość kontenerów. Nie można załadowac kontenera : " + contener.GetNazwe());
        }
        else 
        {
            aktualnaIloscKontenerow++;
            aktualnaWaga += contener.GetWaga();
            listaKontenerow.Add(contener);    
            Console.WriteLine("Dodano kontener "+ contener.GetNazwe());
            
        }
        
    }

    public void Zaladuj(List<Contener> list)
    {
        foreach (var contener in list)
        {
            if (aktualnaWaga+contener.GetWaga() > maxWaga * 1000 )
            {
                Console.WriteLine("Zbyt duża waga koontenera. Nie można załadowac kontenera : " + contener.GetNazwe());
                break;
            }
            else if (aktualnaIloscKontenerow + 1 > maxIloscKontenerow)
            {
                Console.WriteLine("Zbyt duża ilość kontenerów. Nie można załadowac kontenera : " + contener.GetNazwe());
                break;
            }
            else 
            {
                aktualnaIloscKontenerow++;
                aktualnaWaga += contener.GetWaga();
                listaKontenerow.Add(contener);    
                Console.WriteLine("Dodano kontener "+ contener.GetNazwe());
            
            }
        }
    }

    public void Delete(Contener contener)
    {
        if (listaKontenerow.Contains(contener))
        {
            Console.WriteLine("Został usuniety kontener " + contener.GetNazwe());
            listaKontenerow.Remove(contener);
        }
        else
        {
            Console.WriteLine("Nie ma podanego kontenera na kontenerowcu");
        }
    }

    public void Rozladuj()
    {
        Console.WriteLine("Rozładowano kontenerowiec "+ nazwa);
        listaKontenerow.Clear();
    }

    public void Change(Contener doUsuniecia , Contener doDodania)
    {
        if (listaKontenerow.Contains(doUsuniecia))
        {
            listaKontenerow.Remove(doUsuniecia);
            listaKontenerow.Add(doDodania);
        }else
        {
            Console.WriteLine("Nie ma podanego kontenera do zmiany na kontenerowcu");
        }
    }

    public void Przeniesienie(Kontenerowiec kontenerowiec, Contener doZmiany)
    {
        if (listaKontenerow.Contains(doZmiany))
        {
            listaKontenerow.Remove(doZmiany);
            kontenerowiec.listaKontenerow.Add(doZmiany);
            Console.WriteLine($"Przeniesiono kontener {doZmiany.GetNazwe()} z kontenerowca {nazwa} na {kontenerowiec.nazwa}");
        }
        else
        {
            Console.WriteLine("Nie ma podanego kontenera do przeniesienia na kontenerowcu "+nazwa);
        }
    }

    public void DaneStatku()
    {
        Console.WriteLine(
            "\nNazwa : "+ nazwa +"\nPredkosc max : "+ predkosc +"\nMax ilosc kontenerow : "+ maxIloscKontenerow
            +"\nAktualna ilosc kontenerow : "+aktualnaIloscKontenerow+"\nMax waga załadunku : "+ maxWaga 
            +"\nAktualna waga załadunku : "+ aktualnaWaga
            );
        
        foreach (var contener in this.listaKontenerow)
        {
            Console.WriteLine("\t"+contener.ToString());
        }
            
    }


    
}