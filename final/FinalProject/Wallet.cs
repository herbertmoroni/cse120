public class Wallet
{
    private List<Stock> _stocks;
    private string _goal;

    public Wallet(string goal)
    {
        _stocks = new List<Stock>();
        _goal = goal;
    }

    public string Goal
    {
        get { return _goal; }
        set { _goal = value; }
    }

    public void AddStock(Stock stock)
    {
        _stocks.Add(stock);
    }

    public void RemoveStock(Stock stock)
    {
        _stocks.Remove(stock);
    }

    public List<Stock> GetStocks()
    {
        return _stocks;
    }


    public decimal CalculateTotalValue()
    {
        decimal totalValue = 0;
        foreach (Stock stock in _stocks)
        {
            totalValue += stock.CalculateValue();
        }
        return totalValue;
    }

    public void Display()
    {
        Console.WriteLine($"Goal: {_goal}");
        Console.WriteLine($"{"Stock",-25} {"Quantity",-12} {"Purchase Price",-15} {"Current Price",-15} {"Total Dividends",-15}");
        foreach (var stock in _stocks)
        {
            stock.Display();
        }
        Console.WriteLine($"Total Wallet Value: {CalculateTotalValue():C2}");
    }

}