using FluentAssertions;
using FooApiE2eTests.Proxies.FooApi;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace FooApiE2eTests.Features
{
    public class WeatherForecastFeatureTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Test1Async()
        {
            // arrange
            var configuration = new ConfigurationBuilder()
                 .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                 .AddJsonFile("appsettings.json")
                 .Build();

            var apiUrl = configuration.GetSection("AppSettings")["ApiUrl"];

            // arrange
            using var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(apiUrl);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "token");
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await httpClient.GetAsync("WeatherForecast");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var sut = JsonConvert.DeserializeObject<List<WeatherForecast>>(json);

            // assert
            sut.Should().HaveCountGreaterThan(0);
        }
    }
}