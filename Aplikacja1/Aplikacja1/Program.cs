using System;
using System.Collections.Generic;
using Aplikacja1;

class Program
{
    static void Main(string[] args)
    {
        // Tworzenie dwóch obiektów klasy KontenerChodniczy
        KontenerChlodniczy chilledContainer1 = new KontenerChlodniczy(100, 50, 200, 5000, "Food", -10);
        KontenerChlodniczy chilledContainer2 = new KontenerChlodniczy(120, 60, 250, 6000, "Medicine", -20);

        // Demonstracja metod klasy KontenerChodniczy
        chilledContainer1.Zaladuj("Food", "Ice Cream", -20, 500);
        chilledContainer2.Zaladuj("Medicine", "Vaccine", -15, 700);
        Console.WriteLine("\n"+chilledContainer1.ToString());
        Console.WriteLine("\n"+chilledContainer2.ToString());
        chilledContainer1.Oproznij();
        chilledContainer2.Oproznij();
        Console.WriteLine();
        // Tworzenie dwóch obiektów klasy KontenerNaPlyny
        KontenerNaPlyny liquidContainer1 = new KontenerNaPlyny( 2.5, 500, 2, 2000, true);
        KontenerNaPlyny liquidContainer2 = new KontenerNaPlyny( 2.5, 400, 2, 1500, false);

        // Demonstracja metod klasy KontenerNaPlyny
        liquidContainer1.Zaladuj(10000);
        liquidContainer1.Zaladuj(10000);
        liquidContainer2.Zaladuj(200);
        Console.WriteLine(liquidContainer1.ToString()+"\n");
        Console.WriteLine(liquidContainer2.ToString());
        liquidContainer1.Oproznij();
        liquidContainer2.Oproznij();
        Console.WriteLine();
        // Tworzenie dwóch obiektów klasy KontenerNaGaz
        KontenerNaGaz gasContainer1 = new KontenerNaGaz(2.5,1000,  500, 2000, 5);
        KontenerNaGaz gasContainer2 = new KontenerNaGaz(2.5,800,  400, 15000, 3);

        // Demonstracja metod klasy KontenerNaGaz
        gasContainer1.Zaladuj(1000);
        gasContainer2.Zaladuj(2000);
        Console.WriteLine("\n"+gasContainer1.ToString());
        Console.WriteLine(gasContainer2.ToString());
        gasContainer1.Oproznij();
        gasContainer2.Oproznij();
        
        // Tworzenie dwóch obiektów klasy Kontenerowiec
        Kontenerowiec ship1 = new Kontenerowiec("Ship1", 30, 10, 100);
        Kontenerowiec ship2 = new Kontenerowiec("Ship2", 25, 8, 80);

        Console.WriteLine();
        ship1.Zaladuj(chilledContainer1);
        ship1.Zaladuj(liquidContainer1);
        Console.WriteLine();

        // Załadowanie listy kontenerów na drugi statek
        List<Contener> containers = new List<Contener> { chilledContainer2, liquidContainer2, gasContainer1, gasContainer2 };
        ship2.Zaladuj(containers);

        // Usunięcie kontenera z pierwszego statku
        Console.WriteLine();
        foreach (var contener in ship1.GetListe())
        {
            Console.WriteLine(contener.GetNazwe());
        }
        
        ship1.Delete(chilledContainer1);
        
        foreach (var contener in ship1.GetListe())
        {
            Console.WriteLine(contener.GetNazwe());
        }

        Console.WriteLine();

        // Rozładowanie kontenera z drugiego statku

        ship2.Rozladuj();
        
        // Zastąpienie kontenera na pierwszym statku innym kontenerem
        KontenerNaGaz newGasContainer = new KontenerNaGaz(2.5, 900, 450, 1800, 4);
        ship1.Change(liquidContainer1, newGasContainer);

        foreach (var contener in ship1.GetListe())
        {
            Console.WriteLine(contener.GetNazwe());
        }
        
        // Przeniesienie kontenera między dwoma statkami
        ship1.Przeniesienie(ship2, newGasContainer);
        ship1.Przeniesienie(ship2, chilledContainer1);

        // Wypisanie informacji o danym kontenerze
        
        Console.WriteLine("\n"+chilledContainer1.ToString());

        // Wypisanie informacji o danym statku i jego ładunku
        ship1.DaneStatku();
        ship2.DaneStatku();
        
    }
}