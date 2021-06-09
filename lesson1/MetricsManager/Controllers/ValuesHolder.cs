using System;
using System.Collections.Generic;
using System.Linq;

namespace MetricsManager.Controllers
{
    public class ValuesHolder
    {
        public List<WeatherForecast> WeatherForecasts { get; set; }

        public ValuesHolder() {
            WeatherForecasts = new List<WeatherForecast>();
        }

        public WeatherForecast Find(DateTime date)
        {
            return WeatherForecasts.FirstOrDefault(p => p.Date == date);
        }

        public List<WeatherForecast> Get(DateTime fromDate, DateTime toDate) {
            return WeatherForecasts.Where(p => p.Date >= fromDate && p.Date <= toDate).ToList();
        }

        public void Add(DateTime date, int temperature) {
            WeatherForecasts.Add(new WeatherForecast { 
                Date = date,
                TemperatureC = temperature
            });
        }

        public void Update(DateTime date, int temperature)
        {
            var weatherForecast = Find(date);
            weatherForecast.TemperatureC = temperature;
        }

        public void Delete(DateTime date)
        {
            var weatherForecast = Find(date);
            WeatherForecasts.Remove(weatherForecast);
        }
    }
}