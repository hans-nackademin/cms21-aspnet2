using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Models;
using Xunit;

namespace WebApi.Tests
{
    public class IntegrationTests
    {
        [Fact]
        public async Task Should_Return_ListOfTypeProduct_From_Production()
        {
            // Arrange
            var webFactory = new WebApplicationFactory<Program>();
            var client = webFactory.CreateDefaultClient();

            // Act
            var response = await client.GetFromJsonAsync<Product[]>("/api/products");

            // Assert
            response.Should().BeOfType<Product[]>();
        }

        [Fact]
        public async Task Should_Return_ListOfTypeProduct_From_Testing()
        {
            // Arrange
            var webFactory = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        var descriptor = services.SingleOrDefault(x => x.ServiceType == typeof(DbContextOptions<DataContext>));
                        if(descriptor != null)
                            services.Remove(descriptor);

                        //services.AddDbContext<DataContext>(x => x.UseSqlServer("Server=tcp:cms21sqlserver.database.windows.net,1433;Initial Catalog=sql_testing;Persist Security Info=False;User ID=SqlAdmin;Password=BytMig123!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));
                        services.AddDbContext<DataContext>(x => x.UseInMemoryDatabase("inmemorydb"));
                    });
                });

            var client = webFactory.CreateDefaultClient();

            // Act
            var response = await client.GetFromJsonAsync<Product[]>("/api/products");

            // Assert
            response.Should().BeOfType<Product[]>();
        }

        [Fact]
        public async Task Should_Add_ProductRequest_Return_Product_Production()
        {
            // Arrange
            var webFactory = new WebApplicationFactory<Program>();
            var client = webFactory.CreateDefaultClient();


            // Act
            var productRequest = new ProductRequest { Name = "Product 1", Price = 100 };
            var response = await client.PostAsJsonAsync("/api/products", productRequest);
            var data = JsonConvert.DeserializeObject<Product>(await response.Content.ReadAsStringAsync());

            // Assert
            data.Should().BeOfType<Product>();
            data.Id.Should().NotBe(null);
            data.Name.Should().Be(productRequest.Name);
        }

        [Fact]
        public async Task Should_Add_ProductRequest_Return_Product()
        {
            // Arrange
            var webFactory = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        var descriptor = services.SingleOrDefault(x => x.ServiceType == typeof(DbContextOptions<DataContext>));
                        if (descriptor != null)
                            services.Remove(descriptor);

                        //services.AddDbContext<DataContext>(x => x.UseSqlServer("Server=tcp:cms21sqlserver.database.windows.net,1433;Initial Catalog=sql_testing;Persist Security Info=False;User ID=SqlAdmin;Password=BytMig123!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));
                        services.AddDbContext<DataContext>(x => x.UseInMemoryDatabase("inmemorydb"));
                    });
                });

            var client = webFactory.CreateDefaultClient();


            // Act
            var productRequest = new ProductRequest { Name = "Product 1", Price = 100 };
            var response = await client.PostAsJsonAsync("/api/products", productRequest);
            var data = JsonConvert.DeserializeObject<Product>(await response.Content.ReadAsStringAsync());
            
            // Assert
            data.Should().BeOfType<Product>();
            data.Id.Should().NotBe(null);
            data.Name.Should().Be(productRequest.Name);
        }
    }
}