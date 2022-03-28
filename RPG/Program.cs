Dictionary<string, int> Staty = new Dictionary<string, int>()
{
    {"STR", 10},
    {"DEX", 10},
    {"INT", 10}
};
Console.WriteLine("Zadej jméno postavy");
string jmenoPostavy = Console.ReadLine();
int unava = 0;
Random random = new Random();
int cas = 10;
int lvl = 1;
while (true)
{
    Console.Clear();
    Console.WriteLine($"Jsi unavený na {unava}%");
    Console.WriteLine("Chcete jít na quest nebo se jít vyspat? Q/V");
    string questSpat = Console.ReadLine();
    Console.Clear();
    if (questSpat == "q" | questSpat == "Q")
    {
        int quest = random.Next(0,3);
        Console.WriteLine($"Vydáváš se plnit úkol na {Staty.ElementAt(quest).Key}, vrať se za {cas} sekund");
        Console.WriteLine("...");
        Thread.Sleep(cas * 1000);
        int SanceNaPreziti = random.Next(0, 101);
        if (unava < SanceNaPreziti)
        {
            lvl = lvl + 1;
            cas = cas + 10;
            unava = unava + 10;
            Staty[Staty.ElementAt(quest).Key] = Staty.ElementAt(quest).Value + 10;
            Console.WriteLine($"{jmenoPostavy} se z výpravy vrátil celý");
            Console.WriteLine("------------");
            Console.WriteLine($"{jmenoPostavy} má lvl. {lvl} a vlastnosti:");
            foreach (var radekStatu in Staty)
            {
                Console.WriteLine($"{radekStatu.Key}: {radekStatu.Value}");
            }
            Console.WriteLine("Pro pokračování stiskni tlačítko na klávesnici");
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine("Unsul jsi v boji a zemřel");
            break;
        }
    }
    else if (questSpat == "V" | questSpat == "v")
    {
        Console.WriteLine($"{jmenoPostavy} bude spát ještě {unava} sekund, vrať se pak");
        Thread.Sleep(unava * 1000);
        unava = 0;
        Console.WriteLine($"{jmenoPostavy} už je vzhůru");
        Console.WriteLine("Pro pokračování stiskni tlačítko na klávesnci");
        Console.ReadKey();
    }
}