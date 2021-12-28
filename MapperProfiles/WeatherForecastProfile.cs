using AutoMapper;

namespace WebApiWithDynamoDB.MapperProfiles
{
    public class WeatherForecastProfile: Profile
    {
        public WeatherForecastProfile()
        {
            CreateMap<WeatherForecastDto, WeatherForecast>();

            CreateMap<WeatherForecast, WeatherForecastDto>();

        }
    }
}
