using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Welcome to the Stock Portfolio Tracker!");
        Console.Write("Enter your name: ");
        string userName = Console.ReadLine();
        User user = new User(userName);

        Console.WriteLine($"Welcome, {userName}!");

        Console.WriteLine("\nNOTE: The CSV files 'StockDataDividends.csv', 'DividendsData.csv', and 'StockDataGrow.csv' must be in the project folder.");

        Console.WriteLine("\nLoading Dividends Wallet from 'StockDataDividends.csv'...");
        Wallet walletDividends = new Wallet("Dividends");
        LoadStockFromCsv("StockDataDividends.csv", walletDividends);
        Console.WriteLine("Stocks for Dividends Wallet successfully loaded.");

        Console.WriteLine("Loading Dividends Payments from 'DividendsData.csv'...");
        LoadDividendsFromCsv("DividendsData.csv", walletDividends);
        Console.WriteLine("Dividends Payments for Dividends Wallet successfully loaded.");

        Console.WriteLine("\nLoading Growth Wallet from 'StockDataGrow.csv'...");
        Wallet walletGrowth = new Wallet("Growth");
        LoadStockFromCsv("StockDataGrow.csv", walletGrowth);
        Console.WriteLine("Stocks for Growth Wallet successfully loaded.");

        Console.WriteLine("Loading Dividends Payments from 'DividendsData.csv'...");
        LoadDividendsFromCsv("DividendsData.csv", walletGrowth);
        Console.WriteLine("Dividends Payments for Growth Wallet successfully loaded.");

        Portfolio portfolio = new Portfolio();
        portfolio.AddWallet(walletDividends);
        portfolio.AddWallet(walletGrowth);

        user.Portfolio = portfolio;

        Console.WriteLine("\nYour portfolio has been successfully set up. Launching the menu...\n");

        Menu menu = new Menu(user);
        menu.Run();
    }


    private static void LoadStockFromCsv(string fileName, Wallet wallet)
    {
        CsvReader csvReader = new CsvReader();
        List<Stock> stocks = csvReader.ReadStockCsvFile(fileName);

        foreach (Stock stock in stocks)
        {
            wallet.AddStock(stock);
        }
    }


    private static void LoadDividendsFromCsv(string fileName, Wallet wallet)
    {
        CsvReader csvReader = new CsvReader();
        List<DividendPayment> dividendPayments = csvReader.ReadDividendCsvFile(fileName);

        foreach (var dividendPayment in dividendPayments)
        {
            var stock = wallet.GetStocks().FirstOrDefault(s => s.Symbol == dividendPayment.Symbol);

            if (stock != null)
            {
                stock.AddDividendPayment(dividendPayment);
            }
        }
    }
}
