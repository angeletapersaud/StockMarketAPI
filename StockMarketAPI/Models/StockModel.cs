namespace StockMarketAPI.Models;

public class StockModel
{
    public int Id { get; set; }
    public string StockName { get; set; }
    public int NumberOfSharesToPurchase { get; set; }
    public Decimal PriceBidPerShare { get; set; }
}
