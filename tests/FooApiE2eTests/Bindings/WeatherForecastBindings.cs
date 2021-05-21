using FluentAssertions;
using FooApiE2eTests.Proxies.FooApi;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using TechTalk.SpecFlow;

namespace FooApiE2eTests.Bindings
{
    [Binding]
    class WeatherForecastBindings
    {
        private readonly WeatherForecastContext _context;

        class WeatherForecastContext
        {
            public HttpClient HttpClient { get; set; }
            public List<WeatherForecast> Items { get; internal set; }
        }
        WeatherForecastBindings(WeatherForecastContext context)
        {
            _context = context;
        }
        [Given(@"an HttpClient")]
        public void GivenAnHttpClient()
        {
            // arrange
            var configuration = new ConfigurationBuilder()
                 .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                 .AddJsonFile("appsettings.json")
                 .Build();

            var apiUrl = configuration.GetSection("AppSettings")["ApiUrl"];

            // arrange
            _context.HttpClient = new HttpClient();
            _context.HttpClient.BaseAddress = new Uri(apiUrl);
           
            _context.HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        [Given(@"a valid Token")]
        public void GivenAValidToken()
        {
            _context.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "token");
        }
        [When(@"I Send a Find Weather Request with num ""(.*)""")]
        public async Task WhenISendAFindWeatherRequestWithNumAsync(int p0)
        {
            var query = HttpUtility.ParseQueryString(string.Empty);
            query["num"] = p0.ToString();
            var response = await _context.HttpClient.GetAsync($"WeatherForecast?{query}");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var sut = JsonConvert.DeserializeObject<List<WeatherForecast>>(json);
            _context.Items = sut;
        }
        [Then(@"I Should receive ""(.*)"" Weather items")]
        public void ThenIShouldReceiveWeatherItems(int p0)
        {
            // assert
            _context.Items.Should().HaveCountGreaterThan(0);
            _context.Items.Should().HaveCount(Convert.ToInt32(p0));
        }

    }
}
