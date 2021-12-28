
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
namespace WebApiWithDynamoDB.Data
{
    public class WeatherForecastRepository: IWeatherForecastRepository
    {
        private readonly DynamoDBContext _dynamoDBContext;

        public WeatherForecastRepository(IAmazonDynamoDB dynamoDBContext)
        {
            _dynamoDBContext = new DynamoDBContext(dynamoDBContext);
        }

        public async Task DeleteWeatherForecast(WeatherForecast model) => await _dynamoDBContext.DeleteAsync(model);

        public async Task<IEnumerable<WeatherForecast>> GetWeatherForecastByCity(string city) => await _dynamoDBContext.QueryAsync<WeatherForecast>(city).GetRemainingAsync();

        public async Task<List<WeatherForecast>> GetWeatherForecasts() => await _dynamoDBContext.ScanAsync<WeatherForecast>(new List<ScanCondition>()).GetRemainingAsync();

        public async Task SaveWeatherForecast(WeatherForecast model) => await _dynamoDBContext.SaveAsync(model);

        /*
       return await _dynamoDbContext
  .QueryAsync<WeatherForecast>(
      city, 
      QueryOperator.Between, 
      new object[] { DateTime.Now.Date.AddDays(1), DateTime.Now.Date.AddDays(5)})
  .GetRemainingAsync();
       */
    }
}
