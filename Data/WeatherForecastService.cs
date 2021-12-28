using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApiWithDynamoDB.Data
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly IWeatherForecastRepository _weatherForecastRepository;
        private readonly IMapper _mapper;

        public WeatherForecastService(IWeatherForecastRepository weatherForecastRepository, IMapper mapper)
        {
            _weatherForecastRepository = weatherForecastRepository;
            _mapper = mapper;
        }
        public async Task<Response<WeatherForecastDto>> CreateWeatherForecast(WeatherForecastDto dto)
        {
            var weatherForecastModel = _mapper.Map<WeatherForecast>(dto);
            await _weatherForecastRepository.SaveWeatherForecast(weatherForecastModel);
            return new Response<WeatherForecastDto>()
            {
                StatusCode = "200",
                StatusMessage = "",
                Data = dto
            };

        }

        public async Task<Response<IEnumerable<WeatherForecastDto>>> GetWeatherForecastByCity(string city)
        {

            var weatherForecastItem = await _weatherForecastRepository.GetWeatherForecastByCity(city);
            return new Response<IEnumerable<WeatherForecastDto>>()
            {
                StatusCode = "200",
                StatusMessage = "",
                Data = _mapper.Map<IEnumerable<WeatherForecastDto>>(weatherForecastItem)
            };

        }

        public async Task<Response<List<WeatherForecastDto>>> GetWeatherForecasts()
        {
            var weatherForecastItems = await _weatherForecastRepository.GetWeatherForecasts();
            List<WeatherForecastDto> weatherForecastDtoList = new List<WeatherForecastDto>();
            foreach (var item in weatherForecastItems)
            {
                var result = _mapper.Map<WeatherForecastDto>(item);
                weatherForecastDtoList.Add(result);
            }

            return new Response<List<WeatherForecastDto>>()
            {
                StatusCode = "200",
                StatusMessage = "",
                Data = weatherForecastDtoList
            };
        }

        public async Task<Response<WeatherForecastDto>> UpdateWeatherForecast(WeatherForecastDto dto)
        {
            var validItem = await _weatherForecastRepository.GetWeatherForecastByCity(dto.City);
            if (validItem == null)
            {
                throw new Exception();
            }

            var weatherForecastModel = _mapper.Map<WeatherForecast>(dto);
            await _weatherForecastRepository.SaveWeatherForecast(weatherForecastModel);

            return new Response<WeatherForecastDto>()
            {
                StatusCode = "200",
                StatusMessage = "",
                Data = dto
            };
        }
    }
}
