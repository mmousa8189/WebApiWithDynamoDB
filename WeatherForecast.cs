using Amazon.DynamoDBv2.DataModel;
using System;

namespace WebApiWithDynamoDB
{
    [DynamoDBTable("WeatherForecast")]
    public class WeatherForecast
    {
        [DynamoDBHashKey]
        public string City { get; set; }
        [DynamoDBRangeKey]
        public DateTime Date { get; set; }
        public int TemperatureC { get; set; }

        public string Summary { get; set; }
    }
}
