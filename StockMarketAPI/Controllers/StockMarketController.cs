using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockMarketAPI.Models;
using StockMarketAPI.Data;
using StockMarketAPI.Repository;
using System;

namespace StockMarketAPI.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class StockMarketController : ControllerBase
{
    private readonly IStockRepository _stockRepository;
    public StockMarketController(IStockRepository stockRepository)
    {
        _stockRepository = stockRepository;
    }

     //Create/
     [HttpPost]
     public async Task <JsonResult> Create(StockModel stock)
     {
        var result = await _stockRepository.Create(stock);

        return new JsonResult(Ok(result));
     }
    //Update
    [HttpPut]
    public async Task<JsonResult> Update(StockModel stock)
    {
        var result = await _stockRepository.Update(stock);

        return new JsonResult(Ok(result));
    }

    //Get
    [HttpGet]
    public async Task<JsonResult> Get(int id)
    {
        var result = await _stockRepository.GetStockByID(id);

        if (result == null)
            return new JsonResult(NotFound());

        return new JsonResult(Ok(result));
    }

    //Delete
    [HttpDelete]
    public JsonResult Delete(int id)
    {
        _stockRepository.Delete(id);

        return new JsonResult(NoContent());
    }

    //Get all
    [HttpGet()]
    public JsonResult GetAll()
    {
        var result = _stockRepository.GetStocks();
        return new JsonResult(Ok(result));
    }
}
