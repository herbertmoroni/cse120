public class BrazilianStock : Stock
{
    public BrazilianStock(string symbol, string companyName) : base(symbol, companyName)
    {
    }

    public override decimal CalculateValue()
    {
        return Quantity * CurrentPrice;
    }

    public new int Quantity
    {
        get { return (int)base.Quantity; }
        set { base.Quantity = value; }
    }

    public override void Display()
    {
        Console.Write($"{CompanyName}\t{Quantity}\tR$ {PurchasePrice:F2}\tR$ {CurrentPrice:F2}\tR$ {CalculateTotalDividendsReceived():F2}\t");
        Console.WriteLine();
    }
}