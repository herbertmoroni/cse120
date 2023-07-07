public class BrazilianStock : Stock
{
    public BrazilianStock(string symbol, string companyName) : base(symbol, companyName)
    {
    }

    public override decimal CalculateValue()
    {
        return Quantity * CurrentPrice;
    }
}