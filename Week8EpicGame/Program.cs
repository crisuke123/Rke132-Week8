string folderPath = @"C:\Data\";
string heroFile = "heroes.txt";
string VillainsFile = "villains.txt";

string[]heroes = File.ReadAllLines(Path.Combine(folderPath, heroFile));
string[] villains = File.ReadAllLines(Path.Combine(folderPath, VillainsFile));

////string[] heroes = { "Thor ", " Odin", "Tyr", "Ullr" };
//string[] villains = { "Loki", "Dragon", "Fenrir", "Joker", "Sauron" };



string[] Weapon = { "Sword", "Spear", "Bow", "Staf", "Hammer", "axe", "knife", "dager" };


string hero = GetrandomValueformArray(heroes);
int heroHP = GetCharacterHP(hero);
int heroStrikeStrength = heroHP;
string heroWeapon = GetrandomValueformArray(Weapon);
Console.WriteLine($"Today {hero} ({heroHP}) with {heroWeapon} save the day!");



string villain = GetrandomValueformArray(villains);
string villainWeapon = GetrandomValueformArray(Weapon);
int villainHP = GetCharacterHP(villain);
int villainStrikeStrength = villainHP;
Console.WriteLine($"today {villain}({villainHP}) with {villainWeapon} tries to take over the world ");


while (heroHP > 0 && villainHP > 0)
{
    heroHP = heroHP - Hit(villain, villainStrikeStrength);
    villainHP = villainHP - Hit(hero, heroStrikeStrength);
}
Console.WriteLine($"hero {hero} HP: {heroHP}");
Console.WriteLine($"villain {villain} HP : {villainHP}");
if (heroHP > 0)
{
    Console.WriteLine($"{hero} save the day!");
}
else if (villainHP > 0)
{
    Console.WriteLine($"Dark side wins!");
}
else
{
    Console.WriteLine("draw!");
}
static string GetrandomValueformArray(string[] someArray)
{
    Random rnd = new Random();
    int randomIndex = rnd.Next(0, someArray.Length);
    string randomStringFromArray = someArray[randomIndex];
    return randomStringFromArray;
}

static int GetCharacterHP(string characterName)
{
    if(characterName.Length < 10)
    {
        return 10;
    }
    else
    {
        return characterName.Length;
    }
}

static int Hit(string characterName,int characterHP)
{
    Random rnd = new Random();
    int strike = rnd.Next(0, characterHP);

    if (strike == 0)
    {
        Console.WriteLine($"{characterName} missed the target!");
    }
    else if (strike == characterHP - 1)
    {
        Console.WriteLine($"{characterName} made a critical hit!");
    }
    else
    {
        Console.WriteLine($"{characterName} hit {strike}!");
        
    }
    return strike;
}