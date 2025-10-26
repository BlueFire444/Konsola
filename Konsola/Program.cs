public class Program
{

    private static readonly Random random = new Random();
    static void Main(string[] args)
    {
        int liczbaKostek = PobierzLiczbeKostek();
        bool graTrwa;

        do
        {
            Console.WriteLine("GRA");

            int[] wynikiRzutow = RzutKostkami(liczbaKostek);

            WyswietlWyniki(wynikiRzutow);

            int punkty = LiczPunkty(wynikiRzutow);
            Console.WriteLine($"Liczba punktów: {punkty}");

            graTrwa = Powtorz();
        }
        while (graTrwa);
        Console.WriteLine("Koniec gry");
    }

    static int PobierzLiczbeKostek()
    {
        int liczba;
        bool poprawnaLiczba = false;

        do
        {
            Console.WriteLine("Podaj liczbę kostek do rzucenia od 3 do 10");
            string input = Console.ReadLine();

            if (int.TryParse(input, out liczba) && liczba >= 3 && liczba <= 10)
            {
                poprawnaLiczba = true;
            }
            else
            {
                Console.WriteLine("Zła liczba kostek");
            }
        }
        while (!poprawnaLiczba);
        return liczba;
    }

    static int[] RzutKostkami(int liczbaKostek)
    {
        int[] wyniki = new int[liczbaKostek];

        for (int i = 0; i < liczbaKostek; i++)
        {
            wyniki[i] = random.Next(1, 7);
        }
        return wyniki;
    }

    static void WyswietlWyniki(int[] wyniki)
    {
        Console.WriteLine("Rzucone oczka:");
        for (int i = 0; i < wyniki.Length; i++)
        {
            Console.WriteLine($"Kostka {i + 1}: {wyniki[i]}");
        }
    }

    static int LiczPunkty(int[] wynikiRzutów)
    {
        Dictionary<int, int> wystapienia = new Dictionary<int, int>();
        int sumaPunktow = 0;

        foreach (int oczko in wynikiRzutów)
        {
            if (wystapienia.ContainsKey(oczko))
            {
                wystapienia[oczko]++;
            }
            else
            {
                wystapienia.Add(oczko, 1);
            }
        }
        foreach (var para in wystapienia)
        {
            int oczko = para.Key;
            int ilosc = para.Value;

            if (ilosc >= 2)
            {
                sumaPunktow += oczko * ilosc;
            }
        }
        return sumaPunktow;
    }

    static bool Powtorz()
    {
        string odpowiedz;
        bool poprawnaOdpowiedz = false;

        do
        {
            Console.Write("Chcesz powtórzyć grę? (t/n): ");
            odpowiedz = Console.ReadLine()?.ToLower();

            if (odpowiedz == "t")
            {
                return true;
            }
            else if (odpowiedz == "n")
            {
                return false;
            }
            else
            {
                Console.WriteLine("Nieprawidłowa odpowiedź. Wpisz 't' lub 'n'.");
            }
        } while (true);
    }
}