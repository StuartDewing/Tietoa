using DotNetApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json;
using static DotNetApi.Models.WeatherForecastCityResponse;
using static DotNetApi.Models.WeatherForecastDto;

namespace DotNetApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private static HttpClient _httpClient = new HttpClient();

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<WeatherForecastDto> Get()
        {
            var ApiKey = "b3e753f0bbd44ec99db165836221407";
            var URL = $"http://api.weatherapi.com/v1/current.json?key={ApiKey}&q=Portsmouth";
            var response = await _httpClient.GetAsync(URL);

            var responseString = await response.Content.ReadAsStringAsync();

            WeatherForecastCity weatherForecastCityResponse = JsonConvert.DeserializeObject<WeatherForecastCity>(responseString);
            WeatherForecastDto weatherForecastDto = new WeatherForecastDto
            {
                Name = weatherForecastCityResponse.location.name,
                CurrentTemp = weatherForecastCityResponse.current.temp_c,
                Condition = weatherForecastCityResponse.current.condition.text
            };

            return weatherForecastDto;
        }
    }
}