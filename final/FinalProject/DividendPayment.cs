public class DividendPayment
{
    private DateTime _paymentDate;
    private decimal _amount;
    private decimal _numberOfStocks;
    private string _symbol;

    public DividendPayment(DateTime paymentDate, decimal amount, decimal numberOfStocks, string symbol)
    {
        _paymentDate = paymentDate;
        _amount = amount;
        _numberOfStocks = numberOfStocks;
        _symbol = symbol;
    }

    public DateTime PaymentDate
    {
        get { return _paymentDate; }
        set { _paymentDate = value; }
    }

    public decimal Amount
    {
        get { return _amount; }
        set { _amount = value; }
    }

    public decimal NumberOfStocks
    {
        get { return _numberOfStocks; }
        set { _numberOfStocks = value; }
    }

    public string Symbol
    {
        get { return _symbol; }
        set { _symbol = value; }
    }
}