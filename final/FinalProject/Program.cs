public abstract class Asset
{
    private string _symbol;
    private string _companyName;

    public string Symbol
    {
        get { return _symbol; }
        set { _symbol = value; }
    }

    public string CompanyName
    {
        get { return _companyName; }
        set { _companyName = value; }
    }

    public abstract decimal CalculateValue();
}

public class Stock : Asset
{
    private int _quantity;
    private decimal _purchasePrice;
    private decimal _currentPrice;
    private decimal _dividendYield;
    private List<DividendPayment> _dividendPayments;

    public int Quantity
    {
        get { return _quantity; }
        set { _quantity = value; }
    }

    public decimal PurchasePrice
    {
        get { return _purchasePrice; }
        set { _purchasePrice = value; }
    }

    public decimal CurrentPrice
    {
        get { return _currentPrice; }
        set { _currentPrice = value; }
    }

    public decimal DividendYield
    {
        get { return _dividendYield; }
        set { _dividendYield = value; }
    }

    public IReadOnlyList<DividendPayment> DividendPayments
    {
        get { return _dividendPayments; }
    }

    public Stock(string symbol, string companyName)
    {
        Symbol = symbol;
        CompanyName = companyName;
        _dividendPayments = new List<DividendPayment>();
    }

    public void AddDividendPayment(DividendPayment dividendPayment)
    {
        _dividendPayments.Add(dividendPayment);
    }

    public void RemoveDividendPayment(DividendPayment dividendPayment)
    {
        _dividendPayments.Remove(dividendPayment);
    }

    public override decimal CalculateValue()
    {
        return Quantity * CurrentPrice;
    }

    public decimal CalculateYieldOnCost()
    {
        decimal totalDividendAmount = _dividendPayments.Sum(dp => dp.Amount);
        return totalDividendAmount / PurchasePrice;
    }

    public decimal CalculateDividendPercentage()
    {
        decimal totalDividendAmount = _dividendPayments.Sum(dp => dp.Amount);
        return (totalDividendAmount / PurchasePrice) * 100;
    }
}

public class Dividend
{
    private string _company;
    private decimal _amount;
    private decimal _perShare;
    private int _quantity;
    private DateTime _date;

    public string Company
    {
        get { return _company; }
        set { _company = value; }
    }

    public decimal Amount
    {
        get { return _amount; }
        set { _amount = value; }
    }

    public decimal PerShare
    {
        get { return _perShare; }
        set { _perShare = value; }
    }

    public int Quantity
    {
        get { return _quantity; }
        set { _quantity = value; }
    }

    public DateTime Date
    {
        get { return _date; }
        set { _date = value; }
    }
}

public class DividendPayment
{
    private decimal _amount;
    private DateTime _paymentDate;

    public decimal Amount
    {
        get { return _amount; }
        set { _amount = value; }
    }

    public DateTime PaymentDate
    {
        get { return _paymentDate; }
        set { _paymentDate = value; }
    }
}

public class Wallet
{
    private List<Asset> _assets;
    private string _goal;

    public Wallet(string goal)
    {
        _assets = new List<Asset>();
        _goal = goal;
    }

    public void AddAsset(Asset asset)
    {
        _assets.Add(asset);
    }

    public void RemoveAsset(Asset asset)
    {
        _assets.Remove(asset);
    }

    public decimal CalculateTotalValue()
    {
        decimal totalValue = 0;
        foreach (Asset asset in _assets)
        {
            totalValue += asset.CalculateValue();
        }
        return totalValue;
    }
}

public class Country
{
    private List<Stock> _stocks;
    private string _name;

    public Country(string name)
    {
        _stocks = new List<Stock>();
        _name = name;
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

public class User
{
    private List<Wallet> _wallets;
    private List<Country> _countries;
    private string _name;

    public User(string name)
    {
        _wallets = new List<Wallet>();
        _countries = new List<Country>();
        _name = name;
    }

    public void AddWallet(Wallet wallet)
    {
        _wallets.Add(wallet);
    }

    public void RemoveWallet(Wallet wallet)
    {
        _wallets.Remove(wallet);
    }

    public void AddCountry(Country country)
    {
        _countries.Add(country);
    }

    public void RemoveCountry(Country country)
    {
        _countries.Remove(country);
    }
}

public class Portfolio
{
    private List<Wallet> _wallets;
    private List<Country> _countries;

    public Portfolio()
    {
        _wallets = new List<Wallet>();
        _countries = new List<Country>();
    }

    public void AddWallet(Wallet wallet)
    {
        _wallets.Add(wallet);
    }

    public void RemoveWallet(Wallet wallet)
    {
        _wallets.Remove(wallet);
    }

    public void AddCountry(Country country)
    {
        _countries.Add(country);
    }

    public void RemoveCountry(Country country)
    {
        _countries.Remove(country);
    }

    public decimal CalculatePortfolioValue()
    {
        decimal portfolioValue = 0;
        foreach (Wallet wallet in _wallets)
        {
            portfolioValue += wallet.CalculateTotalValue();
        }
        foreach (Country country in _countries)
        {
            portfolioValue += country.CalculateTotalValue();
        }
        return portfolioValue;
    }
}

public class Menu
{
    public void ShowMenu()
    {
        // Display the menu options to the user
    }

    public void AddStockOption()
    {
        // Perform the action to add a stock
    }

    public void RemoveStockOption()
    {
        // Perform the action to remove a stock
    }

    public void AddWalletOption()
    {
        // Perform the action to add a wallet
    }

    public void RemoveWalletOption()
    {
        // Perform the action to remove a wallet
    }

    public void AddCountryOption()
    {
        // Perform the action to add a country
    }

    public void RemoveCountryOption()
    {
        // Perform the action to remove a country
    }

    public void AnalyzePortfolioOption()
    {
        // Perform the action to analyze the entire portfolio
    }

    public void AnalyzeWalletOption()
    {
        // Perform the action to analyze a specific wallet
    }
}

public class Program
{
    public static void Main()
    {
        // Main entry point of the program
        // Initialize objects, handle user interactions, etc.
    }
}
