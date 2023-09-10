using System;

public class Shop
{
    public void SellSword(Hero hero)
    {
        hero.Coins -= 30;
        hero.Items.Add("Miecz");
        Console.WriteLine($"kupiłeś Miecz za 30 coinów");
    }

    public void SellPotion(Hero hero)
    {
        hero.Coins -= 20;
        Console.WriteLine($"kupiłeś Miksturę zdrowia za 20 coinów");
    }
}