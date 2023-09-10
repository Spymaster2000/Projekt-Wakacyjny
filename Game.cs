
using System;

public class Game
{
    private Hero hero;

    public Game(Hero hero)
    {
        this.hero = hero;
    }

    public void Play()
    {
        while (hero.Hp > 0)
        {
            Console.WriteLine(new string('-', 50));
            Console.WriteLine($"Twoje przedmioty: {string.Join(", ", hero.Items)}");
            Console.WriteLine($"Twoje statystyki: {hero}");
            int pdNeeded = 125 - hero.Pd;
            Console.WriteLine($"Potrzebujesz {pdNeeded} PD do kolejnego poziomu!");
            Console.WriteLine("1 - walka");
            Console.WriteLine("2 - sklep");

            string input = Console.ReadLine();
            if (input == "stop")
                break;

            if (input == "1")
            {
                if (hero.Level % 5 == 0)
                {
                    Console.WriteLine(new string('!', 50));
                    Console.WriteLine("Nadszedł czas na walkę z Bossem!");
                    Boss boss = new Boss(hero.Level);
                    while (boss.Hp > 0 && hero.Hp > 0)
                    {
                        Console.WriteLine($"{hero.Name}, walczysz teraz z {boss.Name}");
                        Console.WriteLine($"Przeciwnik ma {boss.Hp} HP i zadaje ci {boss.Attack} obrażeń");

                        hero.Hp -= boss.Attack;
                        if (hero.Hp <= 0)
                            break;

                        Console.WriteLine($"Zostało ci {hero.Hp} HP");
                        Console.WriteLine($"Twoje przedmioty: {string.Join(", ", hero.Items)}");
                        Console.WriteLine("1 - atak");
                        Console.WriteLine("2 - uleczyć");

                        string input1 = Console.ReadLine();
                        if (input1 == "stop")
                            break;

                        if (input1 == "1")
                        {
                            Console.WriteLine("1 - wykonaj Zwykły atak");
                            Console.WriteLine("2 - wykonaj Mocny atak");

                            string attackChoice = Console.ReadLine();
                            if (attackChoice == "1")
                            {
                                int attack = hero.RegularAttack();
                                boss.Hp -= attack;
                                Console.WriteLine($"Zadałeś {attack} obrażeń");
                                Console.WriteLine(new string('-', 50));
                            }
                            else if (attackChoice == "2")
                            {
                                if (!hero.HasSword())
                                {
                                    Console.WriteLine(new string('!', 50));
                                    Console.WriteLine("Zadełeś 0 obrażeń. Nie możesz tego zrobić! Potrzebujesz 'Miecz' aby użyć!");
                                }
                                else
                                {
                                    int attack = hero.PowerfulAttack();
                                    boss.Hp -= attack;
                                    Console.WriteLine($"Zadałeś {attack} obrażeń");
                                    Console.WriteLine(new string('-', 50));
                                }
                            }
                        }
                        else if (input1 == "2")
                        {
                            hero.UsePotion();
                        }
                    }

                    if (boss.Hp <= 0 && hero.Hp > 0)
                    {
                        Console.WriteLine("Brawo! Pokonałeś Bossa!");
                        Console.WriteLine($"Dostałeś {boss.Coins} coinów i {boss.Exp} doświadczenia");
                        hero.Coins += boss.Coins;
                        hero.Exp += boss.Exp;
                        hero.LevelUp();
                    }
                    else
                    {
                        Console.WriteLine(new string('!', 50));
                        Console.WriteLine($"Niestety, {hero.Name} zginął! Koniec gry!");
                        break;
                    }
                }
                else
                {
                    Enemy enemy = new Enemy(hero.Level);
                    while (enemy.Hp > 0 && hero.Hp > 0)
                    {
                        Console.WriteLine($"{hero.Name}, walczysz teraz z {enemy.Name}");
                        Console.WriteLine($"Przeciwnik ma {enemy.Hp} HP i zadaje ci {enemy.Attack} obrażeń");

                        hero.Hp -= enemy.Attack;
                        if (hero.Hp <= 0)
                            break;

                        Console.WriteLine($"Zostało ci {hero.Hp} HP");
                        Console.WriteLine($"Twoje przedmioty: {string.Join(", ", hero.Items)}");
                        Console.WriteLine("1 - atak");
                        Console.WriteLine("2 - uleczyć");

                        string input2 = Console.ReadLine();
                        if (input2 == "stop")
                            break;

                        if (input2 == "1")
                        {
                            Console.WriteLine("1 - wykonaj Zwykły atak");
                            Console.WriteLine("2 - wykonaj Mocny atak");

                            string attackChoice = Console.ReadLine();
                            if (attackChoice == "1")
                            {
                                int attack = hero.RegularAttack();
                                enemy.Hp -= attack;
                                Console.WriteLine($"Zadałeś {attack} obrażeń");
                                Console.WriteLine(new string('-', 50));
                            }
                            else if (attackChoice == "2")
                            {
                                if (!hero.HasSword())
                                {
                                    Console.WriteLine(new string('!', 50));
                                    Console.WriteLine("Zadełeś 0 obrażeń. Nie możesz tego zrobić! Potrzebujesz 'Miecz' aby użyć!");
                                }
                                else
                                {
                                    int attack = hero.PowerfulAttack();
                                    enemy.Hp -= attack;
                                    Console.WriteLine($"Zadałeś {attack} obrażeń");
                                    Console.WriteLine(new string('-', 50));
                                }
                            }
                        }
                        else if (input2 == "2")
                        {
                            hero.UsePotion();
                        }
                    }

                    if (enemy.Hp <= 0 && hero.Hp > 0)
                    {
                        Console.WriteLine($"Brawo! Pokonałeś przeciwnika {enemy.Name}");
                        Console.WriteLine($"Dostałeś {enemy.Coins} coinów i {enemy.Exp} doświadczenia");
                        hero.Coins += enemy.Coins;
                        hero.Exp += enemy.Exp;
                        hero.LevelUp();
                    }
                    else
                    {
                        Console.WriteLine(new string('!', 50));
                        Console.WriteLine($"Niestety, {hero.Name} zginął! Koniec gry!");
                        break;
                    }
                }
            }
            else if (input == "2")
            {
                Shop shop = new Shop();
                Console.WriteLine("Witaj w sklepie! Co chcesz kupić?");
                Console.WriteLine("1 - Miecz (30 coinów)");
                Console.WriteLine("2 - Mikstura zdrowia (20 coinów)");

                string shopInput = Console.ReadLine();
                if (shopInput == "1")
                {
                    if (hero.Coins < 30)
                    {
                        Console.WriteLine(new string('!', 50));
                        Console.WriteLine("Nie masz wystarczającej ilości coinów!");
                    }
                    else
                    {
                        shop.SellSword(hero);
                    }
                }
                else if (shopInput == "2")
                {
                    if (hero.Coins < 20)
                    {
                        Console.WriteLine(new string('!', 50));
                        Console.WriteLine("Nie masz wystarczającej ilości coinów!");
                    }
                    else
                    {
                        shop.SellPotion(hero);
                    }
                }
            }
        }
    }
}