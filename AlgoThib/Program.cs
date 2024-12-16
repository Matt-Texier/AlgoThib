using AlgoThib;

internal class Program
{
    public static void Main(string[] args)
    {
        string[] motsdutibz = { "coucou", "salut", "hey" };
        Joueur thibz = new Joueur("Le Thibz", 0, motsdutibz);
        De Ledé1 = new De(1);
        string a = Ledé1.toString();
        Console.WriteLine(a);
        Ledé1.Lance();
        Dictionnaire Français = new Dictionnaire("Française");
        string b = Français.toString();
        Console.WriteLine(b);
        Français.TriList();
        bool e = Français.RechDicoRecursif("TU");
        Console.WriteLine(e);
        Lettres l1 = new Lettres();
        string f = l1.toString();
        Console.WriteLine(f);
        Plateau plat = new Plateau(1, 5);
        string h = plat.ToString();
        Console.WriteLine(h);
        Console.WriteLine("Donnez le mot à chercher ");
        string j = Console.ReadLine();
        bool p = plat.FormeMot(j);
        Console.WriteLine(p);
        if (p == true)
        {
            bool z = Français.RechDicoRecursif(j);
            Console.WriteLine(z);
        }
    }
}