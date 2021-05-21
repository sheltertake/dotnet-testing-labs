using FluentAssertions;
using FooApi;
using FooApi.Controllers;
using FooApi.Services;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FooApiUnitTests.Tests.Controller
{
    public class WeatherForecastControllerTests
    {
        [SetUp]
        public void Setup()
        {
            Console.WriteLine(nameof(Setup));
        }

        [TearDown]
        public void TearDown()
        {
            Console.WriteLine(nameof(TearDown));
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Console.WriteLine(nameof(OneTimeTearDown));
        }
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Console.WriteLine(nameof(OneTimeSetUp));
        }

        [Category("read")]
        [TestCase(1)]
        [TestCase(5)]
        public async Task GetTest_ShouldReturnArrayOfWeatherAsync(int expected)
        {
            var sut = await GetTestAsync(expected);


            // assert
            sut.Should().HaveCount(expected);
        }

        [Test]
        public async Task GetTest_ShouldReturnRandom([Random(1, 6, 3)] int expected)
        {
            var sut = await GetTestAsync(expected);


            // assert            
            sut.Should().HaveCountLessOrEqualTo(5);
        }

        [Test]
        public async Task GetTest_ShouldReturnRange([Range(1, 5)] int expected)
        {
            var sut = await GetTestAsync(expected);


            // assert            
            sut.Should().HaveCountLessOrEqualTo(5);
        }


        private async Task<IEnumerable<WeatherForecast>> GetTestAsync(int expected)
        {
            var mockService = new Mock<IWeatherService>();

            mockService.Setup(x => x.GetAsync(expected))
                       .ReturnsAsync(Enumerable.Range(1, expected).Select(y => new WeatherForecast()).ToArray());

            // arrange
            var controller = new WeatherForecastController(
                //Mock.Of<IWeatherService>(),
                mockService.Object,
                Mock.Of<ILogger<WeatherForecastController>>()
                );
            // act
            var sut = await controller.GetAsync(expected);

            // assert
            sut.Should().NotBeNull();
            sut.Should().BeOfType<WeatherForecast[]>();
            sut.Should().HaveCountGreaterThan(0);
            return sut;
        }
    }
}