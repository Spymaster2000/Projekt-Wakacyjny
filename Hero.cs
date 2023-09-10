using System;
using System.Collections.Generic;

public class Hero
{
    public string Name { get; private set; }
    public int Level { get; private set; }
    public int Hp { get; set; }
    public int Pd { get; set; }
    public int Coins { get; set; }
    public int Exp { get; set; }
    public List<string> Items { get; set; }

    public Hero(string name)
    {
        Name = name;
        Level = 1;
        Hp = 100;
        Pd = 0;
        Coins = 0;
        Exp = 0;
        Items = new List<string>();
    }

    public override string ToString()
    {
        return $"Imię: {Name}, Poziom: {Level}, HP: {Hp}, PD: {Pd}, Coins: {Coins}, Exp: {Exp}";
    }

    public int RegularAttack()
    {
        return Level * 10;
    }

    public int PowerfulAttack()
    {
        return Level * 20;
    }

    public bool HasSword()
    {
        return Items.Contains("Miecz");
    }

    public void UsePotion()
    {
        Hp += 30;
        Pd += 15;
        Console.WriteLine($"Uleczono {Name} o 30 HP i dodano 15 PD");
    }

    public void LevelUp()
    {
        if (Exp >= 125)
        {
            Level++;
            Exp = 0;
            Console.WriteLine($"Gratulacje! {Name} awansował na poziom {Level}");
        }
    }
}