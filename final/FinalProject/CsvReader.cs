using System.IO;
using System.Collections.Generic;

public class CsvReader
{
    public List<Stock> ReadCsvFile(string path)
    {
        var stocks = new List<Stock>();
        using (var reader = new StreamReader(path))
        {
            reader.ReadLine(); // Skip header line
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');

                string symbol = values[0];
                string companyName = values[1];
                decimal quantity = decimal.Parse(values[2]);
                decimal purchasePrice = decimal.Parse(values[3]);
                decimal currentPrice = decimal.Parse(values[4]);
                
                decimal dividendYieldPercentage = decimal.Parse(values[5]);
                decimal dividendYield = dividendYieldPercentage / 100;

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
}
