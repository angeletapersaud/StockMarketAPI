using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockMarketAPI.Data;
using StockMarketAPI.Models;

namespace StockMarketAPI.Repository;

public class StockRepository : IStockRepository
{

    public StockRepository()
    {

    }

    public Task<StockModel> Create(StockModel stock)
    {
        using (var context = new ApiContext())
        {
            if (stock.Id == 0)
            {
                context.Stocks.Add(stock);
            }

            context.SaveChanges();
            return Task.FromResult(stock);
        }

    }

    public Task<StockModel> Update(StockModel stock)
    {
        using (var context = new ApiContext())
        {
            var stockInDb = context.Stocks.Find(stock.Id);

            if (stockInDb != null)
            {
                stockInDb.StockName = stock.StockName;
                stockInDb.NumberOfSharesToPurchase = stock.NumberOfSharesToPurchase;
                stockInDb.PriceBidPerShare = stock.PriceBidPerShare;

                context.SaveChanges();
            }


            return Task.FromResult(stock);
        }
    }

    public Task<StockModel?> GetStockByID(int id)
    {
        using (var context = new ApiContext())
        {
            var stockInDb = context.Stocks.Find(id);
            if (stockInDb != null)
            {
                return Task.FromResult<StockModel?>(stockInDb);
            }
            return Task.FromResult<StockModel?>(null);
        }
    }

    public List<StockModel> GetStocks()
    {
        using (var context = new ApiContext())
        {
            var list = context.Stocks.ToList();
            return list;
        }
    }

    public void Delete(int id)
    {
        using (var context = new ApiContext())
        {
            var ItemToBeDeleted = context.Stocks.Find(id);

            var stockToRemove = context.Stocks.Remove(ItemToBeDeleted);

            context.SaveChanges();
        }
    }

}
