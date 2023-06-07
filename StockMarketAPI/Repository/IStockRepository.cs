using StockMarketAPI.Models;

namespace StockMarketAPI.Repository;

public interface IStockRepository
{
    public List<StockModel> GetStocks();
    public Task<StockModel?> GetStockByID(int id);
    public Task<StockModel> Create(StockModel stock);
    public void Delete(int id);
    public Task<StockModel> Update(StockModel stock);
}