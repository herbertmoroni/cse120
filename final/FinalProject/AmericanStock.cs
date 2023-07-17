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
        Console.Write($"{CompanyName}\t{Quantity}\t$ {PurchasePrice:F2}\t$ {CurrentPrice:F2}\t$ {CalculateTotalDividendsReceived():F2}\t");
        Console.WriteLine();
    }
}