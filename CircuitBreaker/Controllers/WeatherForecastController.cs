using Microsoft.AspNetCore.Mvc;

namespace CircuitBreaker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
   
       private readonly IHttpClientFactory _httpClientFactory;

        public WeatherForecastController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<string> Get()
        {
            var client = _httpClientFactory.CreateClient("errorApiClient");
            return await client.GetStringAsync("api/values");
        }
    }
}