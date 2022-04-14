using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Controllers;
using WebApi.Models;
using WebApi.Services;
using WebApi.Tests.Fixtures;
using Xunit;

namespace WebApi.Tests.Systems.Controllers
{
    
    public class ProductsController_Should
    {
        [Fact]
        public async Task GetAllProducts_OnSuccess_Return_StatusCode_200()
        {
            // Arrange
            var mockProductService = new Mock<IProductService>();
            var sut = new ProductsController(mockProductService.Object);

            // Act
            var result = (OkObjectResult)await sut.GetAllProducts();

            // Assert
            result.StatusCode.Should().Be(200);
        }


        [Fact]
        public async Task GetAllProducts_OnSuccess_Return_ListOfProducts()
        {
            // Arrange
            var mockProductService = new Mock<IProductService>();
            mockProductService.Setup(service => service.GetAllProductsAsync())
                .ReturnsAsync(ProductsFixtures.GetTestProducts());

            var sut = new ProductsController(mockProductService.Object);

            // Act
            var result = await sut.GetAllProducts();

            // Assert
            result.Should().BeOfType<OkObjectResult>();
            var objectResult = (OkObjectResult)result;
            objectResult.Value.Should().BeOfType<List<Product>>();
        }
    }
}
