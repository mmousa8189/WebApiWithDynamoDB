using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApiWithDynamoDB.Data
{
 

    public interface IWeatherForecastRepository
    {
        public Task SaveWeatherForecast(WeatherForecast model);
        public Task DeleteWeatherForecast(WeatherForecast model);
        public Task<IEnumerable<WeatherForecast>> GetWeatherForecastByCity(string city);
        public Task<List<WeatherForecast>> GetWeatherForecasts();

      

    }
}
