using FluentAssertions;
using FooApi;
using FooApiFunctionalTests.Helpers;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace FooApiFunctionalTests.Tests.Controllers
{
    [ExcludeFromCodeCoverage]
    public class WeatherForecastControllerTests
    {
        private IHost host;
        private HttpClient testClient;

        [SetUp]
        public async Task SetupAsync()
        {
            host = await TestHelper.GetTestHostAsync();
            testClient = host.GetTestClient();
        }

        [TearDown]
        public void TearDown()
        {
            host.Dispose();
        }

        [Test]
        public async Task GetTest_ShouldReturnArrayOfWeather()
        {
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