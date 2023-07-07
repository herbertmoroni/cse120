public class User
{
    private List<Portfolio> _portfolios;
    private string _name;

    public User(string name)
    {
        _portfolios = new List<Portfolio>();
        _name = name;
    }

    public void AddPortfolio(Portfolio portfolio)
    {
        _portfolios.Add(portfolio);
    }

    public void RemovePortfolio(Portfolio portfolio)
    {
        _portfolios.Remove(portfolio);
    }

    public decimal CalculateTotalPortfolioValue()
    {
        decimal totalValue = 0;
        foreach (Portfolio portfolio in _portfolios)
        {
            totalValue += portfolio.CalculatePortfolioValue();
        }
        return totalValue;
    }
}