using FluentAssertions;
using FooApiFunctionalTests.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Threading.Tasks;

namespace FooApiFunctionalTests.Tests.Controllers
{
    [ExcludeFromCodeCoverage]
    public class HealthControllerTests
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
        public async Task GetTest_ShouldReturnOk()
        {
            // act
            var response = await testClient.GetAsync("health");
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(StatusCodes.Status200OK);
        }
    }
}