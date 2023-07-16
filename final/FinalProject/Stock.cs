public abstract class Stock
{
    private string _symbol;
    private string _companyName;
    private decimal _quantity;
    private decimal _purchasePrice;
    private decimal _currentPrice;
    private decimal _dividendYield;
    private List<DividendPayment> _dividendPayments;

    protected Stock(string symbol, string companyName)
    {
        Symbol = symbol;
        CompanyName = companyName;

        _dividendPayments = new List<DividendPayment>();
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

    public decimal Quantity
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

    public void AddDividendPayment(DividendPayment payment)
    {
        _dividendPayments.Add(payment);
    }

    public void RemoveDividendPayment(DividendPayment payment)
    {
        _dividendPayments.Remove(payment);
    }

    public List<DividendPayment> GetDividendPayments()
    {
        return _dividendPayments;
    }

    public decimal CalculateTotalDividendsReceived()
    {
        decimal totalDividends = 0;
        foreach (var payment in _dividendPayments)
        {
            totalDividends += payment.Amount;
        }
        return totalDividends;
    }


    public virtual void Display()
    {
        decimal totalDividendsReceived = CalculateTotalDividendsReceived();
        Console.Write($"{CompanyName}\t{Quantity}\t{PurchasePrice:C2}\t{CurrentPrice:C2}\t{totalDividendsReceived:C2}\t");
    }


}