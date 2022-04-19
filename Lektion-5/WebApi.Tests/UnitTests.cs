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
using Xunit;

namespace WebApi.Tests
{
    public class UnitTests
    {
        [Fact]
        public async Task GetAllProductsAsync_Should_Return_ListOfTypeProduct()
        {
            // Arrange - förberedelser
            var sut = new Mock<IDataAccess>();

            // Act - utförande
            var result = await sut.Object.GetAllProductsAsync();

            // Assert - kontroll
            result.Should().BeOfType<Product[]>();
        }

        [Fact]
        public async Task Should_Return_Ok()
        {
            // Arrange
            var mock = new Mock<IDataAccess>();
            var sut = new ProductsController(mock.Object);

            // Act
            var result = await sut.GetAllProducts();

            // Assert
            result.Should().BeOfType<OkObjectResult>();

        }
    }
}
