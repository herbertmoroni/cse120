public class Wallet
{
    private List<Stock> _stocks;
    private string _goal;

    public Wallet(string goal)
    {
        _stocks = new List<Stock>();
        _goal = goal;
    }

    public void AddStock(Stock stock)
    {
        _stocks.Add(stock);
    }

    public void RemoveStock(Stock stock)
    {
        _stocks.Remove(stock);
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
}