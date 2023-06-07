using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockMarketAPI.Data;
using StockMarketAPI.Models;
using StockMarketAPI.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace StockMarketAPI.UnitTest;
public class StockRepositoryTests
{
    [Fact]
    public void Create_CreateEndpointIsCalled_ShouldReturnEqualValues()
    {
        //Arrange
        var options = new DbContextOptionsBuilder<ApiContext>()
            .UseInMemoryDatabase("StockDb")
            .Options;

        var stockRepository = new StockRepository();
        var stockmodel = new Models.StockModel();
        stockmodel.Id = 8;
        stockmodel.StockName = "NVIDIA";
        stockmodel.NumberOfSharesToPurchase = 20;
        stockmodel.PriceBidPerShare = 200.54M;

        // Act
        var output = stockRepository.Create(stockmodel);

        // Assert
        Assert.Equal(8, output.Result.Id);
        Assert.Equal("NVIDIA", output.Result.StockName);
        Assert.Equal(20, output.Result.NumberOfSharesToPurchase);
        Assert.Equal(200.54M, output.Result.PriceBidPerShare);
    }

    [Fact]
    public void Update_UpdateMethodIsCalled_ShouldUpdateValues()
    {
        //Arrange
        var options = new DbContextOptionsBuilder<ApiContext>()
            .UseInMemoryDatabase("StockDb")
            .Options;

        var stockRepository = new StockRepository();
        var stockmodel = new Models.StockModel();
        stockmodel.Id = 9;
        stockmodel.StockName = "NVIDIA";
        stockmodel.NumberOfSharesToPurchase = 20;
        stockmodel.PriceBidPerShare = 200.54M;
        var IndividualStock = stockRepository.Create(stockmodel);

        // Act
        stockmodel.StockName = "AAPL";
        var output = stockRepository.Update(stockmodel);

        // Assert
        Assert.Equal(9, output.Result.Id);
        Assert.Equal("AAPL", output.Result.StockName);
        Assert.Equal(20, output.Result.NumberOfSharesToPurchase);
        Assert.Equal(200.54M, output.Result.PriceBidPerShare);
    }

    [Fact]
    public void GetStockById_GetStockByIDMethodIsCalled_ShouldReturnStockByID()
    {
        //Arrange
        var options = new DbContextOptionsBuilder<ApiContext>()
            .UseInMemoryDatabase("StockDb")
            .Options;
        using (var context = new ApiContext())
        {
            context.Stocks.Add(new StockModel() { Id = 7, StockName = "AAPL", NumberOfSharesToPurchase = 20, PriceBidPerShare = 120.30M });
            context.SaveChanges();
        }

        // Act
        using (var context = new ApiContext())
        {
            var stockRepository = new StockRepository();
            var output = stockRepository.GetStockByID(7);

            // Assert
            Assert.Equal(7, output.Result.Id);
            Assert.Equal("AAPL", output.Result.StockName);
            Assert.Equal(20, output.Result.NumberOfSharesToPurchase);
            Assert.Equal(120.30M, output.Result.PriceBidPerShare);
        }
    }
    [Fact]
    public void GetStocks_GetStocksMethodIsCalled_ShouldReturnAllStocks()
    {
        //Arrange
        var options = new DbContextOptionsBuilder<ApiContext>()
            .UseInMemoryDatabase("StockDb")
            .Options;
        using (var context = new ApiContext())
        {
            context.Stocks.Add(new StockModel() { Id = 10, StockName = "AAPL", NumberOfSharesToPurchase = 20, PriceBidPerShare = 120.30M });
            context.Stocks.Add(new StockModel() { Id = 11, StockName = "NVIDIA", NumberOfSharesToPurchase = 8, PriceBidPerShare = 55.70M });
            context.Stocks.Add(new StockModel() { Id = 12, StockName = "SONY", NumberOfSharesToPurchase = 350, PriceBidPerShare = 27.80M });
            context.SaveChanges();
        }
        // Act & Assert
        using (var context = new ApiContext())
        {
            var stockRepository = new StockRepository();
            var output = stockRepository.GetStocks();

            Assert.Equal(3, output.Count);
            Assert.Equal("SONY", output[2].StockName);
        }
    }
    [Fact]
    public void Delete_DeleteMethodIsCalled_ShouldDeleteStockByID()
    {

        //Arrange
        var options = new DbContextOptionsBuilder<ApiContext>()
            .UseInMemoryDatabase("StockDb")
            .Options;
        using (var context = new ApiContext())
        {
            context.Stocks.Add(new StockModel() { Id = 15, StockName = "SONY", NumberOfSharesToPurchase = 350, PriceBidPerShare = 27.80M });
            context.SaveChanges();
        }

        // Act & Assert
        using (var context = new ApiContext())
        {
            var stockRepository = new StockRepository();
            stockRepository.Delete(15);

             Assert.Equal(null, stockRepository.GetStockByID(15).Result);
        }

    }
}
