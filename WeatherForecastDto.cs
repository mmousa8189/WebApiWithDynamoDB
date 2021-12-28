using System;

namespace WebApiWithDynamoDB
{
    public class WeatherForecastDto
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }
        public string City { get; set; }
        public string Summary { get; set; }
    }
}
