using Amazon.DynamoDBv2.DataModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiWithDynamoDB.Data;

namespace WebApiWithDynamoDB.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherForecastService _weatherForecastService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastService weatherForecastService)
        {
            _logger = logger;
            _weatherForecastService = weatherForecastService;
        }
        [Route("Get")]
        [HttpGet]
        public async Task<IActionResult> Get(string city = "Brisbane")
        {
            var result = await _weatherForecastService.GetWeatherForecastByCity(city);
            return Ok(result);
        }
        [Route("GetAll")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _weatherForecastService.GetWeatherForecasts();
            return Ok(result);
        }
        [Route("AddWeatherForecas")]
        [HttpPost]
        public async Task<IActionResult> AddWeatherForecas(WeatherForecastDto weatherForecastDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _weatherForecastService.CreateWeatherForecast(weatherForecastDto);
            return Created(nameof(Get), new { id = weatherForecastDto.City });
        }
        [Route("UpdateWeatherForecas")]
        [HttpPut]
        public async Task<IActionResult> UpdateWeatherForecas(WeatherForecastDto weatherForecastDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
           var result = await _weatherForecastService.UpdateWeatherForecast(weatherForecastDto);
            return Ok(result);    
        }

    }
}
