using AggregatorService.Clients;
using AggregatorService.Model;
using Microsoft.AspNetCore.Mvc;

namespace AggregatorService.Controllers
{
    [ApiController]
    [Route("api/data")]
    public class DataController : ControllerBase
    {
        private readonly IWeatherServiceClient _weatherClient;

        public DataController(IWeatherServiceClient weatherClient)
        {
            _weatherClient = weatherClient;
        }

        [HttpGet(Name = "GetData")]
        public async Task<AggregatedData> Get()
        {
            var forecast = await _weatherClient.GetWeatherForecastAsync();
            return new AggregatedData
            {
                AverageTemperature = forecast.Average(d => d.TemperatureC)
            };
        }
    }
}