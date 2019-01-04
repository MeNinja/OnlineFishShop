using System.Linq;
using Microsoft.EntityFrameworkCore;
using OnlineFishShop.Data;
using OnlineFishShop.Data.Models;
using OnlineFishShop.Services;
using Xunit;

namespace OnlineFishShop.Tests.Services
{
    public class GetList
    {
        [Fact]
        public void GetAllWithName()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<OnlineFishShopDbContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;

            Product product1 = new Product();
            product1.Name = "SomeName";
            Product product2 = new Product();
            product2.Name = "SomeName";
            Product product3 = new Product();
            product3.Name = "AName";


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

                var getWithName = service.GetListAsync(p => p.Name == "SomeName").Result;

                Assert.Equal(2, getWithName.Count);
                Assert.True(getWithName.First().Name == "SomeName");
            }
        }

        [Fact]
        public void GetAllWithUnexistingName()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<OnlineFishShopDbContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;

            Product product1 = new Product();
            product1.Name = "SomeName";
            Product product2 = new Product();
            product2.Name = "SomeName";
            Product product3 = new Product();
            product3.Name = "AName";


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

                var getWithName = service.GetListAsync(p => p.Name == "AnotherName").Result;

                Assert.Empty(getWithName);
            }
        }
    }
}