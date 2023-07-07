public abstract class Stock
{
    private string _symbol;
    private string _companyName;
    private int _quantity;
    private decimal _purchasePrice;
    private decimal _currentPrice;
    private decimal _dividendYield;

    protected Stock(string symbol, string companyName)
    {
        Symbol = symbol;
        CompanyName = companyName;
    }

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

    public abstract decimal CalculateValue();

    public decimal CalculateYieldOnCost()
    {
        return CalculateDividendPercentage() / _dividendYield;
    }

    public decimal CalculateDividendPercentage()
    {
        return (_quantity * _dividendYield * _currentPrice) / _purchasePrice;
    }
}