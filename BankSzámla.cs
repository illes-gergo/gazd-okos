// See https://aka.ms/new-console-template for more information
public class BankSzámla
{
    int osszeg = 0;
    public int Osszeg
    {
        get { return osszeg; }
        set { osszeg = value; }
    }
    public BankSzámla()
    {

    }
    public BankSzámla(int kezdoosszeg)
    {
        if (kezdoosszeg != 0)
        {
            osszeg = kezdoosszeg;
        }
    }
}