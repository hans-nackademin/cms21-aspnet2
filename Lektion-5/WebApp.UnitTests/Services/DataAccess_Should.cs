using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Models;
using WebApp.Services;
using WebApp.UnitTests.Fixtures;
using Xunit;

namespace WebApp.UnitTests.Services
{

    public class DataAccess_Should
    {
        [Fact]
        public async Task GetAllProductsAsync_Returns_TypeOf_ListOfProducts()
        {
            // Arrange - förberedelser
            var sut = new Mock<IDataAccess>();

            // Act - utförande
            var result = await sut.Object.GetAllProductsAsync();

            // Assert - kontroll
            result.Should().BeOfType<Product[]>();
        }



        //[Fact]
        //public async Task GetAllProductsAsync_Returns_ListOfProducts()
        //{
        //    // Arrange - förberedelser
        //    var sut = new Mock<IDataAccess>();
        //    sut.Setup(s => s.GetAllProductsAsync())
        //        .ReturnsAsync(await ProductsFixtures.GetAllProductsAsync());

        //    // Act - utförande
        //    var result = await sut.Object.GetAllProductsAsync();

        //    // Assert - kontroll
        //    result.Should().BeOfType<List<Product>>();
        //}

        [Fact]
        public async Task GetProductAsync_Returns_Product()
        {
            // Arrange - förberedelser
            var id = 1;
            var sut = new Mock<IDataAccess>();
            sut.Setup(s => s.GetProductAsync(id))
                .ReturnsAsync(await ProductsFixtures.GetProductAsync(id));

            // Act - utförande
            var result = await sut.Object.GetProductAsync(id);

            // Assert - kontroll
            result.Should().BeOfType<Product>();
            result.Id.Should().Be(id);
        }

        [Fact]
        public async Task CreateProductAsync_Returns_Product()
        {
            // Arrange - förberedelser
            ProductCreateRequest productRequest = new ProductCreateRequest
            {
                Name = "Test Product",
                Price = 1000
            };

            var sut = new Mock<IDataAccess>();
            sut.Setup(s => s.CreateProductAsync(productRequest))
                .ReturnsAsync(await ProductsFixtures.CreateProductAsync(productRequest));

            // Act - utförande
            var result = await sut.Object.CreateProductAsync(productRequest);

            // Assert - kontroll
            result.Should().BeOfType<Product>();
            result.Name.Should().Be(productRequest.Name);
        }

    }
}
