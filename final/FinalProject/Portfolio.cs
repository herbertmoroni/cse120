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

    public decimal CalculatePortfolioValue()
    {
        decimal portfolioValue = 0;
        foreach (Wallet wallet in _wallets)
        {
            portfolioValue += wallet.CalculateTotalValue();
        }
        return portfolioValue;
    }
}