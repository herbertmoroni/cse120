public class DividendPayment
{
    private DateTime _paymentDate;
    private decimal _amount;
    private decimal _numberOfStocks;

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
}