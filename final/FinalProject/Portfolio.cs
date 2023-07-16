public class Portfolio
{
    private List<Wallet> _wallets;

    public Portfolio()
    {
        _wallets = new List<Wallet>();
    }

    public void AddWallet(Wallet wallet)
    {
        _wallets.Add(wallet);
    }

    public void RemoveWallet(Wallet wallet)
    {
        _wallets.Remove(wallet);
    }

    public List<Wallet> GetWallets()
    {
        return _wallets;
    }

    public decimal CalculatePortfolioValue()
    {
        decimal portfolioValue = 0;
        foreach (Wallet wallet in _wallets)
        {
            portfolioValue += wallet.CalculateTotalValue();
        }
        return portfolioValue;
    }

    public void Display()
    {
        Console.WriteLine($"Portfolio Summary:");
        foreach (var wallet in _wallets)
        {
            wallet.Display();
            Console.WriteLine();
        }
        Console.WriteLine($"Total Portfolio Value: {CalculatePortfolioValue():C2}");
    }
}