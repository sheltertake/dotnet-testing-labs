using FluentAssertions;
using FooApi;
using FooApi.Controllers;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

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
        public void GetTest_ShouldReturnArrayOfWeather(int expected)
        {
            var sut = GetTest(expected);


            // assert
            sut.Should().HaveCount(expected);
        }

        [Test]
        public void GetTest_ShouldReturnRandom([Random(1, 6, 3)] int expected)
        {
            var sut = GetTest(expected);


            // assert            
            sut.Should().HaveCountLessOrEqualTo(5);
        }

        [Test]
        public void GetTest_ShouldReturnRange([Range(1, 5)] int expected)
        {
            var sut = GetTest(expected);


            // assert            
            sut.Should().HaveCountLessOrEqualTo(5);
        }


        private IEnumerable<WeatherForecast> GetTest(int expected)
        {

            // arrange
            var controller = new WeatherForecastController(Mock.Of<ILogger<WeatherForecastController>>());
            // act
            var sut = controller.Get(expected);

            // assert
            sut.Should().NotBeNull();
            sut.Should().BeOfType<WeatherForecast[]>();
            sut.Should().HaveCountGreaterThan(0);
            return sut;
        }
    }
}