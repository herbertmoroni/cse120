public class Menu
{
    private User _user;

    public Menu(User user)
    {
        _user = user;
    }

    public void Run()
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("Dividend-Based Stock Portfolio System");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("1. Display Dividends Stocks");
            Console.WriteLine("2. Display Growth Stocks");
            Console.WriteLine("3. View Dividend Performance");
            Console.WriteLine("4. Suggest Best Dividend Stock to Buy Now");
            Console.WriteLine("5. Display Portfolio");
            Console.WriteLine("6. Exit");
            Console.WriteLine();

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    DisplayDividendsStocks();
                    break;
                case "2":
                    DisplayGrowthStocks();
                    break;
                case "3":
                    ViewDividendPerformance();
                    break;
                case "4":
                    SuggestBestDividendStockToBuyNow();
                    break;
                case "5":
                    DisplayPortfolio();
                    break;
                case "6":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }

    private void DisplayDividendsStocks()
    {
        Console.WriteLine("Dividends Stocks: ");
        DisplayStocks(_user.Portfolio.GetWallets().FirstOrDefault(w => w.Goal == "Dividends"));
    }

    private void DisplayGrowthStocks()
    {
        Console.WriteLine("Growth Stocks: ");
        DisplayStocks(_user.Portfolio.GetWallets().FirstOrDefault(w => w.Goal == "Growth"));
    }

    private void DisplayStocks(Wallet wallet)
    {
        if (wallet != null)
        {
            foreach (var stock in wallet.GetStocks())
            {
                Console.WriteLine($"{stock.Symbol} - {stock.CompanyName}");
            }
        }
        else
        {
            Console.WriteLine("No stocks found.");
        }
    }

    private void ViewDividendPerformance()
    {
        Wallet selectedWallet = SelectWallet();
        if (selectedWallet == null)
        {
            Console.WriteLine("No wallet found with the provided goal.");
            return;
        }

        Console.Write("Enter the symbol of the stock to view dividend performance: ");
        string symbol = Console.ReadLine();

        Stock stock = FindStock(selectedWallet, symbol);
        if (stock != null)
        {
            Console.WriteLine($"Dividend Performance for Stock: {stock.CompanyName}");
            Console.WriteLine($"Dividend Yield: {stock.DividendYield:F2}");
            Console.WriteLine($"Yield on Cost: {stock.CalculateYieldOnCost():F2}");
            Console.WriteLine($"Dividend Percentage: {stock.CalculateDividendPercentage():F2}");
            Console.WriteLine($"Total Dividends Received: {stock.CalculateTotalDividendsReceived():F2}");
        }
        else
        {
            Console.WriteLine("Stock not found.");
        }
    }

    private void SuggestBestDividendStockToBuyNow()
    {
        SuggestBestStock("American");
        SuggestBestStock("Brazilian");
    }

    private void SuggestBestStock(string stockType)
    {
        List<Stock> allStocks = _user.Portfolio.GetWallets()
            .SelectMany(w => w.GetStocks())
            .Where(s => s.GetType().Name == stockType + "Stock")
            .ToList();

        if (!allStocks.Any())
        {
            Console.WriteLine($"No {stockType} stocks found.");
            return;
        }

        Stock bestStock = allStocks.OrderByDescending(s => s.DividendYield).First();

        Console.WriteLine($"Suggested {stockType} stock to buy: {bestStock.Symbol} ({bestStock.CompanyName})");
    }

    private Wallet SelectWallet()
    {
        Console.Write("Enter the wallet goal: ");
        string walletGoal = Console.ReadLine();

        Wallet selectedWallet = _user.Portfolio.GetWallets().FirstOrDefault(w => w.Goal == walletGoal);

        if (selectedWallet == null)
        {
            Console.WriteLine("Wallet not found.");
        }

        return selectedWallet;
    }

    private Stock FindStock(Wallet wallet, string symbol)
    {
        return wallet.GetStocks().FirstOrDefault(s => s.Symbol == symbol);
    }


    private void DisplayPortfolio()
    {
        Console.WriteLine("Portfolio: ");
        _user.Portfolio.Display();
    }
}
