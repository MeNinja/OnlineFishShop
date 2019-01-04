using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OnlineFishShop.Data;
using OnlineFishShop.Data.Models;
using OnlineFishShop.Services;
using Xunit;

namespace OnlineFishShop.Tests.Services
{
    public class GetAll
    {
        [Fact]
        public void GetAllProducts()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<OnlineFishShopDbContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;

            Product product1 = new Product();
            product1.Name = "First";
            Product product2 = new Product();
            product2.Name = "Second";
            Product product3 = new Product();
            product3.Name = "Third";


            // Act
            using (var context = new OnlineFishShopDbContext(options))
            {
                context.Database.EnsureDeleted();
                var service = new GenericDataService<Product>(context);
                service.Add(product1);
                service.Add(product2);
                service.Add(product3);
              
            }

            // Assert
            using (var context = new OnlineFishShopDbContext(options))
            {
                var service = new GenericDataService<Product>(context);

                var allProds =  service.GetAllAsync().Result;

                Assert.Equal(3, allProds.Count);
                Assert.NotNull(allProds.Find(p=>p.Name=="First"));
                Assert.NotNull(allProds.Find(p => p.Name == "Second"));
                Assert.NotNull(allProds.Find(p => p.Name == "Third"));

            }
        }
       
    }
}
