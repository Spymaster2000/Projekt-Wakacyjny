using System;
using System.Linq;

public class Boss
{
    private static readonly string[] Names = { "Potwór", "Demon", "Czarnoksiężnik" };
    private static readonly Random random = new Random();

    public string Name { get; private set; }
    public int Hp { get; set; }
    public int Attack { get; private set; }
    public int Coins { get; private set; }
    public int Exp { get; private set; }

    public Boss(int level)
    {
        Name = Names[random.Next(Names.Length)];
        Hp = level * 100;
        Attack = level * 20;
        Coins = level * 50;
        Exp = level * 75;
    }
}