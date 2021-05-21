using FluentAssertions;
using FooApi;
using FooApi.Controllers;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace FooApiUnitTests.Tests.Controller
{
    public class WeatherForecastControllerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetTest_ShouldReturnArrayOfWeather()
        {
            // arrange
            var controller = new WeatherForecastController(Mock.Of<ILogger<WeatherForecastController>>());
            // act
            var sut = controller.Get();

            // assert
            sut.Should().NotBeNull();
            sut.Should().BeOfType<WeatherForecast[]>();
            sut.Should().HaveCountGreaterThan(0);
        }
    }
}