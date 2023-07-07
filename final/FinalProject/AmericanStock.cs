public class AmericanStock : Stock
{
    public AmericanStock(string symbol, string companyName) : base(symbol, companyName)
    {
    }

    public override decimal CalculateValue()
    {
        return Quantity * CurrentPrice;
    }
}