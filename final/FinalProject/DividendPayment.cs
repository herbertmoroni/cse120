public class DividendPayment
{
    private Stock _stock;
    private DateTime _paymentDate;
    private decimal _amount;
    private int _numberOfStocks;

    public Stock Stock
    {
        get { return _stock; }
        set { _stock = value; }
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

    public int NumberOfStocks
    {
        get { return _numberOfStocks; }
        set { _numberOfStocks = value; }
    }
}