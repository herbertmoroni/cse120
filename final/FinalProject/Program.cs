using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

public class Program
{
    public static void Main()
    {
        // Example usage
        User user = new User("John Doe");
        Portfolio portfolio = new Portfolio();

        Wallet wallet1 = new Wallet("Dividend Growth");
        BrazilianStock brazilianStock1 = new BrazilianStock("ITSA4", "Brazilian Stock 1");
        wallet1.AddStock(brazilianStock1);

        Wallet wallet2 = new Wallet("Growth");
        AmericanStock americanStock1 = new AmericanStock("LUMN", "American Stock 1");
        wallet2.AddStock(americanStock1);

        portfolio.AddWallet(wallet1);
        portfolio.AddWallet(wallet2);
        user.AddPortfolio(portfolio);

        Menu menu = new Menu(user);
        menu.Run();
    }
}
