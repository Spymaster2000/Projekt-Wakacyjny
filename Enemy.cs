using System;
using System.Linq;

public class Enemy
{
    private static readonly string[] Names = { "Wilk", "Pająk", "Troll", "Smok" };
    private static readonly Random random = new Random();

    public string Name { get; private set; }
    public int Hp { get; set; }
    public int Attack { get; private set; }
    public int Coins { get; private set; }
    public int Exp { get; private set; }

    public Enemy(int level)
    {
        Name = Names[random.Next(Names.Length)];
        Hp = level * 50;
        Attack = level * 10;
        Coins = level * 10;
        Exp = level * 25;
    }
}