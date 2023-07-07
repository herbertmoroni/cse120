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
        throw new NotImplementedException();
    }

    private void UpdateStockPrice()
    {
        throw new NotImplementedException();
    }

    private void UpdateDividendData()
    {
        throw new NotImplementedException();
    }

    private void ViewDividendPerformance()
    {
        throw new NotImplementedException();
    }

    private void GenerateReports()
    {
        throw new NotImplementedException();
    }
}
