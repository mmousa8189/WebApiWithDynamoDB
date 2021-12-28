using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApiWithDynamoDB.Data
{
    public interface IWeatherForecastService
    {
        Task<Response<WeatherForecastDto>> CreateWeatherForecast(WeatherForecastDto dto);
        Task<Response<WeatherForecastDto>> UpdateWeatherForecast(WeatherForecastDto dto);
        Task<Response<IEnumerable<WeatherForecastDto>>> GetWeatherForecastByCity(string city);
        Task<Response<List<WeatherForecastDto>>> GetWeatherForecasts();
    }
}
