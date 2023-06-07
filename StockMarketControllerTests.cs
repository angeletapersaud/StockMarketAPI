namespace StockMarketAPI.UnitTest;

using Microsoft.AspNetCore.Mvc;
using Moq;
using StockMarketAPI.Controllers;
using StockMarketAPI.Data;
using StockMarketAPI.Models;
using StockMarketAPI.Repository;
using Xunit;

public class StockMarketControllerTests
{
    [Fact]
    public void Create_WhenCreateEndpointIsCalled_ShouldReturnEqualValue()
    {
        //Arrange
        int testID = 1;
        string testStockName = "AAPL";
        int testNumberOfShares = 20;
        Decimal testPriceBidPerShare = 135.50M;
        var testModel = new StockModel
        {
            Id = testID,
            StockName = testStockName,
            NumberOfSharesToPurchase = testNumberOfShares,
            PriceBidPerShare = testPriceBidPerShare,
        };

        //var mockStockRepository = new Mock<IStockRepository>();
        //mockStockRepository.Setup(repo => repo.Create(It.IsAny<StockModel>())
        //.ReturnsAsync(Task.FromResult<JsonResult>(OkResult(testModel))));

        //var stockMarketController = new StockMarketController(mockStockRepository.Object);


       


        //Act
        //var result=stockMarketController.Create(testModel);

        //Assert

       // Assert.Equals(result. );

    }
}