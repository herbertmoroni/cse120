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
        User user = new User("Moroni");
        Portfolio portfolio = new Portfolio();

       
        portfolio.AddWallet(LoadStockFromCsv("StockDataDividends.csv"));
        //portfolio.AddWallet(wallet2);
        user.Portfolio = portfolio;

        Menu menu = new Menu(user);
        menu.Run();
    }

    private static Wallet LoadStockFromCsv(string fileName)
    {
        CsvReader csvReader = new CsvReader();
        List<Stock> stocks = csvReader.ReadCsvFile(fileName);

        Wallet dividendsWallet = new Wallet("Dividends");
        foreach (Stock stock in stocks)
        {
            dividendsWallet.AddStock(stock);
        }

        return dividendsWallet;
    }
}
