using System;

class Program
{
    static void Main()
    {
        Console.Write("Podaj imię swojego bohatera: ");
        string name = Console.ReadLine();
        Hero hero = new Hero(name);

        Console.WriteLine($"{hero.Name}, zaczynasz swoją podróż");
        Console.WriteLine($"Twoje statystyki: {hero}");

        Game game = new Game(hero);
        game.Play();

        Console.WriteLine(new string('=', 50));
        Console.WriteLine("Dziękujemy za grę!");
    }
}
