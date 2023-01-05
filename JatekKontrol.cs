public class JatekKontrol
{
    Dictionary<string, BankSzámla> szamlak = new Dictionary<string, BankSzámla>();
    int jatekosok;

    public JatekKontrol(Dictionary<string, BankSzámla> adatok)
    {
        this.szamlak = adatok;
        this.jatekosok = adatok.Count;
        listActions();
    }
    void listActions()
    {   listActionsInit:
        Console.Clear();
        int id = 1;

        foreach (string name in szamlak.Keys.ToList())
        {
            Console.WriteLine($"{Convert.ToString(id)} - {name} - {Convert.ToString(szamlak[name].Osszeg)}");
            id++;
        }
        Console.WriteLine($"Válaszd ki a játékost! (1-{Convert.ToString(jatekosok)})");
        int playernumber = 1;
        try
        {
            playernumber = Convert.ToInt32(Console.ReadLine());
        }
        catch
        {
            goto listActionsInit;
        }
        if (1 <= playernumber && playernumber <= jatekosok)
        {
            modifyAccount(szamlak.Keys.ToList()[playernumber - 1]);
        }
        else
        { goto listActionsInit; }

    }
    void modifyAccount(string name)
    {
        modifyAccountInit:
        Console.Clear();
        Console.WriteLine($"{name} - {Convert.ToString(szamlak[name].Osszeg)}");
        Console.WriteLine("\n\n\n1 - Bevétel, 2 - Kiadás, 3 - Kamat");
        Console.SetCursorPosition(0,2);
        int action = 1;
        try
        {
            action = Convert.ToInt32(Console.ReadLine());
        }
        catch
        {
            goto modifyAccountInit;
        }
        switch (action)
        {
            case 1:
                bevetel(name);
                break;
            case 2:
                kiadas(name);
                break;
            case 3:
                kamat(name);
                break;
        }
        listActions();
    }
    void bevetel(string name)
    { initFlag:
        Console.Clear();
        Console.WriteLine("Bevétel");
        Console.WriteLine($"{name} - {Convert.ToString(szamlak[name].Osszeg)}");
        Console.WriteLine("Add meg a bevétel értékét!");
        int bevetel = 0;
        try { bevetel = Convert.ToInt32(Console.ReadLine()); }
        catch { goto initFlag;}
        szamlak[name].Osszeg += bevetel;
    }
    void kiadas(string name)
    {
        initFlag:
        Console.Clear();
        Console.WriteLine("Kiadás");
        Console.WriteLine($"{name} - {Convert.ToString(szamlak[name].Osszeg)}");
        Console.WriteLine("Add meg a kiadás értékét!");
        int bevetel = 0;
        try { bevetel = Convert.ToInt32(Console.ReadLine()); }
        catch { goto initFlag;}
        szamlak[name].Osszeg -= bevetel;
    }
    void kamat(string name)
    {
        initFlag:
        Console.Clear();
        Console.WriteLine("Kamat");
        Console.WriteLine($"{name} - {Convert.ToString(szamlak[name].Osszeg)}");
        Console.WriteLine("Add meg a kamat értékét %-ban!");
        double bevetel = 0;
        try {bevetel = Convert.ToDouble(Console.ReadLine())/100 + 1;}
        catch { goto initFlag;}
        double tempmoney = Convert.ToDouble(szamlak[name].Osszeg);
        tempmoney = tempmoney * bevetel;
        szamlak[name].Osszeg = Convert.ToInt32(tempmoney);
    }
}