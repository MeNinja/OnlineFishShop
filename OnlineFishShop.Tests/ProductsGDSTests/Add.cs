using Microsoft.EntityFrameworkCore;
using OnlineFishShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using OnlineFishShop.Data.Models;
using OnlineFishShop.Services;
using Xunit;

namespace OnlineFishShop.Tests.ProductsGDSTests
{
    public class Add
    {
        [Theory]
        [InlineData("one")]
        [InlineData("two")]
        [InlineData("three")]
        public void Add_AddSingleProduct(string productName)
        {
            //Arrange
            var options = new DbContextOptionsBuilder<OnlineFishShopDbContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;

            Product product = new Product();
            product.Name = productName;

            // Act
            using (var context = new OnlineFishShopDbContext(options))
            {
                context.Database.EnsureDeleted();
                var service = new GenericDataService<Product>(context);
                service.Add(product);
            }

            // Assert
            using (var context = new OnlineFishShopDbContext(options))
            {
                Assert.Equal(1, context.Products.Count());
                Assert.Equal(productName, context.Products.Single().Name);
            }
        }

        [Fact]
        public void Add_AddMultipleProductsOneByOne()
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
                Product first = context.Products.Where(p => p.Name == "First").FirstOrDefault();
                Product second = context.Products.Where(p => p.Name == "Second").FirstOrDefault();
                Product third = context.Products.Where(p => p.Name == "Third").FirstOrDefault();


                Assert.Equal(3, context.Products.Count());
                Assert.NotNull(first);
                Assert.NotNull(second);
                Assert.NotNull(third);
            }
        }

        [Fact]
        public void Add_AddMultipleProductsAtOnce()
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
            List<Product> all = new List<Product>();
            all.Add(product1);
            all.Add(product2);
            all.Add(product3);

            // Act
            using (var context = new OnlineFishShopDbContext(options))
            {
                context.Database.EnsureDeleted();
                var service = new GenericDataService<Product>(context);
                service.Add(all.ToArray());
            }

            // Assert
            using (var context = new OnlineFishShopDbContext(options))
            {
                Product first = context.Products.Where(p => p.Name == "First").FirstOrDefault();
                Product second = context.Products.Where(p => p.Name == "Second").FirstOrDefault();
                Product third = context.Products.Where(p => p.Name == "Third").FirstOrDefault();


                Assert.Equal(3, context.Products.Count());
                Assert.NotNull(first);
                Assert.NotNull(second);
                Assert.NotNull(third);
            }
        }
    }
}