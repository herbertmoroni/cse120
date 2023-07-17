using System.IO;
using System.Collections.Generic;

public class CsvReader
{
    public List<Stock> ReadStockCsvFile(string path)
    {
        var stocks = new List<Stock>();
        using (var reader = new StreamReader(path))
        {
            reader.ReadLine();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');

                string symbol = values[0];
                string companyName = values[1];
                decimal quantity = decimal.Parse(values[2]);
                decimal purchasePrice = decimal.Parse(values[3]);
                decimal currentPrice = decimal.Parse(values[4]);
                decimal dividendYield = decimal.Parse(values[5]);

                string stockType = values[6];

                Stock stock;
                switch (stockType)
                {
                    case "Brazilian":
                        stock = new BrazilianStock(symbol, companyName);
                        break;
                    case "American":
                        stock = new AmericanStock(symbol, companyName);
                        break;
                    default:
                        throw new Exception($"Unknown stock type {stockType} in CSV data");
                }
                stock.Quantity = quantity;
                stock.PurchasePrice = purchasePrice;
                stock.CurrentPrice = currentPrice;
                stock.DividendYield = dividendYield;

                stocks.Add(stock);
            }
        }

        return stocks;
    }

    public List<DividendPayment> ReadDividendCsvFile(string path)
    {
        var dividendPayments = new List<DividendPayment>();
        using (var reader = new StreamReader(path))
        {
            reader.ReadLine(); 
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');

                DateTime date = DateTime.Parse(values[0]);
                string stockSymbol = values[1];
                decimal amount = decimal.Parse(values[2]);
                decimal numberStocks = decimal.Parse(values[3]);

                var dividendPayment = new DividendPayment(date, amount, numberStocks, stockSymbol);

                dividendPayments.Add(dividendPayment);
            }
        }

        return dividendPayments;
    }

}
