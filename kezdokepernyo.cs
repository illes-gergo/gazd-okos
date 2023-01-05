// See https://aka.ms/new-console-template for more information
public class KezdoKepernyo
{
    Dictionary<string, BankSzámla> szamlak = new Dictionary<string, BankSzámla>();
    public KezdoKepernyo()
    {
        Console.Clear();
        Console.WriteLine("Gazdálkodj okosan számlavezető segédlet!");
        Console.WriteLine("Nyomj meg egy gombot az első játékos felvételéhez!");
        Console.ReadKey();
        addPlayer();
        preGameMenu();
        JatekKontrol jatek = new JatekKontrol(szamlak);
    }
    void addPlayer()
    {
        Init:
        Console.Clear();
        Console.WriteLine("Add meg az új játékos nevét!");
        string name = Convert.ToString(Console.ReadLine());
        Console.WriteLine("Add meg a kezdőösszeget (alapérték 3M)!");
        string penzstring = Convert.ToString(Console.ReadLine());
        int kezdoosszeg = 0;
        if (penzstring == "")
        {
            kezdoosszeg = 3000000;
        }
        else
        {
            try
            {
                kezdoosszeg = Convert.ToInt32(penzstring);
            }
            catch
            {
                goto Init;
            }
        }
        Console.Clear();
        Console.WriteLine($"Az új játékos neve: {name}");
        Console.WriteLine($"Az új játékos kezdőösszege: {Convert.ToString(kezdoosszeg)}");
        Console.WriteLine("Amennyiben helyesek az adatok üss ENTER-t!");
        ConsoleKey keypress = Console.ReadKey().Key;
        if (!ConsoleKeyInfo.Equals(keypress, ConsoleKey.Enter))
        {
            goto Init;
        }
        szamlak.Add(name, new BankSzámla(kezdoosszeg));
    }
    void preGameMenu()
    {
        int id = 1;
        Console.Clear();
        Console.WriteLine("Eddigi játékosok:");
        foreach (string names in szamlak.Keys.ToList())
        {
            Console.WriteLine($"{Convert.ToString(id)} - {names} - {Convert.ToString(szamlak[names].Osszeg)}");
            id++;
        }
        Console.WriteLine("Játék kezdése: ENTER");
        Console.WriteLine("Új játékos felvétele: bármely más billentyű");
        if (Console.ReadKey().Key != ConsoleKey.Enter)
        {
            addPlayer();
            preGameMenu();
        }
    }
}