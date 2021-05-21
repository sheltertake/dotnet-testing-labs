using FluentAssertions;
using FooApi;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace FooApiFunctionalTests.Tests.Controllers
{
    public class WeatherForecastControllerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task GetTest_ShouldReturnArrayOfWeather()
        {
            // arrange
            var configuration = new ConfigurationBuilder()
                 .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                 .AddJsonFile("appsettings.json")
                 .Build();


            var hostBuilder = new HostBuilder()
                .ConfigureWebHost(webHost =>
                {
                    webHost.UseStartup<Startup>();
                    webHost.UseConfiguration(configuration);
                    webHost.UseTestServer();
                    webHost.ConfigureTestServices(services =>
                    {
                        services.AddLogging(x => x.AddConsole());
                        //services.AddAuthentication(FakeJwtBearerDefaults.AuthenticationScheme).AddFakeJwtBearer();

                    });
                });
            var host = await hostBuilder.StartAsync();
            var testClient = host.GetTestClient();

            // act
            var response = await testClient.GetAsync("WeatherForecast");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var sut = JsonSerializer.Deserialize<List<WeatherForecast>>(json);

            // assert
            sut.Should().HaveCountGreaterThan(0);
        }
    }
}