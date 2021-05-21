using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FooApi.Services
{
    public interface IWeatherService
    {
        public Task<IEnumerable<WeatherForecast>> GetAsync(int num);
    }
    public class WeatherService : IWeatherService
    {

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public Task<IEnumerable<WeatherForecast>> GetAsync(int num)
        {
            var rng = new Random();
            var ret = Enumerable.Range(1, num).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });

            return Task.FromResult(ret);
        }
    }
}
