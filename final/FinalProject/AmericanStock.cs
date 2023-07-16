public class AmericanStock : Stock
{
    public AmericanStock(string symbol, string companyName) : base(symbol, companyName)
    {
    }

    public override decimal CalculateValue()
    {
        return Quantity * CurrentPrice;
    }

    public override void Display()
    {
        Console.Write($"{CompanyName}\t{Quantity}\t$ {PurchasePrice:C2}\t$ {CurrentPrice:C2}\t$ {CalculateTotalDividendsReceived():C2}\t");
        Console.WriteLine();
    }
}