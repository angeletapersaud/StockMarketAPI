using Microsoft.EntityFrameworkCore;
using StockMarketAPI.Models;

namespace StockMarketAPI.Data;

public class ApiContext : DbContext
{
    protected override void OnConfiguring
       (DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase(databaseName: "StockDb");
    }
    public DbSet<StockModel> Stocks { get; set; }

   
}
