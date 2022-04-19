using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Data;
using Xunit;

namespace WebApp.IntegrationTests
{
    public class Test
    {
        [Fact]
        public void TestingToSee()
        {
            var appFactory = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<MsSqlContext>));
                        if (descriptor != null)
                            services.Remove(descriptor);

                        services.AddDbContext<MsSqlContext>(x => x.UseSqlServer(""));
                    });
                });

            var testClient = appFactory.CreateClient
        }


    }
}
