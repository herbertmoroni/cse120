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
            Console.WriteLine("1. Add Stock");
            Console.WriteLine("2. Update Stock Price");
            Console.WriteLine("3. Update Dividend Data");
            Console.WriteLine("4. View Dividend Performance");
            Console.WriteLine("5. Generate Reports");
            Console.WriteLine("6. Exit");
            Console.WriteLine();

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    AddStock();
                    break;
                case "2":
                    UpdateStockPrice();
                    break;
                case "3":
                    UpdateDividendData();
                    break;
                case "4":
                    ViewDividendPerformance();
                    break;
                case "5":
                    GenerateReports();
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

    private void AddStock()
    {
        Wallet selectedWallet = SelectWallet();

        if (selectedWallet == null)
        {
            Console.WriteLine("No wallet found with the provided goal. Stock not added.");
            return;
        }

        Console.WriteLine("Add Stock");
        Console.Write("Enter the symbol: ");
        string symbol = Console.ReadLine();

        Console.Write("Enter the company name: ");
        string companyName = Console.ReadLine();

        Console.Write("Enter the quantity: ");
        decimal quantity = decimal.Parse(Console.ReadLine());

        Console.Write("Enter the purchase price: ");
        decimal purchasePrice = decimal.Parse(Console.ReadLine());

        Console.Write("Enter the current price: ");
        decimal currentPrice = decimal.Parse(Console.ReadLine());

        Console.Write("Enter the dividend yield: ");
        decimal dividendYield = decimal.Parse(Console.ReadLine());

        Console.WriteLine("Select the type of stock:");
        Console.WriteLine("1. Brazilian Stock");
        Console.WriteLine("2. American Stock");
        Console.Write("Enter your choice: ");
        string stockTypeChoice = Console.ReadLine();

        Stock stock;

        switch (stockTypeChoice)
        {
            case "1":
                stock = new BrazilianStock(symbol, companyName);
                break;
            case "2":
                stock = new AmericanStock(symbol, companyName);
                break;
            default:
                Console.WriteLine("Invalid stock type choice. Stock not added.");
                return;
        }

        stock.Quantity = quantity;
        stock.PurchasePrice = purchasePrice;
        stock.CurrentPrice = currentPrice;
        stock.DividendYield = dividendYield;

        selectedWallet.AddStock(stock);
        Console.WriteLine("Stock added successfully.");
    }

    private void UpdateStockPrice()
    {
        Console.WriteLine("Update Stock Price");

        Wallet selectedWallet = SelectWallet();
        if (selectedWallet == null)
        {
            Console.WriteLine("No wallet found with the provided goal.");
            return;
        }

        Console.Write("Enter the symbol of the stock to update: ");
        string symbol = Console.ReadLine();

        Stock stock = FindStock(selectedWallet, symbol);
        if (stock != null)
        {
            Console.Write("Enter the new price: ");
            decimal newPrice = decimal.Parse(Console.ReadLine());
            stock.CurrentPrice = newPrice;
            Console.WriteLine("Stock price updated successfully.");
        }
        else
        {
            Console.WriteLine("Stock not found.");
        }
    }

    private void UpdateDividendData()
    {
        Console.WriteLine("Update Dividend Data");

        Wallet selectedWallet = SelectWallet();
        if (selectedWallet == null)
        {
            Console.WriteLine("No wallet found with the provided goal.");
            return;
        }

        Console.Write("Enter the symbol of the stock to update: ");
        string symbol = Console.ReadLine();

        Stock stock = FindStock(selectedWallet, symbol);
        if (stock != null)
        {
            Console.Write("Enter the dividend payment amount: ");
            decimal amount = decimal.Parse(Console.ReadLine());

            Console.Write("Enter the dividend payment date (yyyy-MM-dd): ");
            DateTime paymentDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter the number of stocks: ");
            decimal numberOfStocks = decimal.Parse(Console.ReadLine());

            DividendPayment dividendPayment = new DividendPayment
            {
                Amount = amount,
                PaymentDate = paymentDate,
                NumberOfStocks = numberOfStocks
            };

            stock.AddDividendPayment(dividendPayment);

            Console.WriteLine("Dividend data updated successfully.");
        }
        else
        {
            Console.WriteLine("Stock not found.");
        }
    }

    private void ViewDividendPerformance()
    {
        Console.WriteLine("View Dividend Performance");

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
            Console.WriteLine("Dividend Performance for Stock: " + stock.CompanyName);
            Console.WriteLine("Dividend Yield: " + stock.DividendYield);
            Console.WriteLine("Yield on Cost: " + stock.CalculateYieldOnCost());
            Console.WriteLine("Dividend Percentage: " + stock.CalculateDividendPercentage());
            Console.WriteLine("Total Dividends Received: " + stock.CalculateTotalDividendsReceived());
        }
        else
        {
            Console.WriteLine("Stock not found.");
        }
    }

    private void GenerateReports()
    {
        Console.WriteLine("Generate Reports");
        _user.Portfolio.Display();
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
}
