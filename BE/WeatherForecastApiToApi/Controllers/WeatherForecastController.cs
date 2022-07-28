using Microsoft.AspNetCore.Mvc;
using System.Web.Helpers;
using WeatherForecastApiToApi.Models;
using static WeatherForecastApiToApi.WeatherJson;
using System.Text.Json;

namespace WeatherForecastApiToApi.Controllers
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


        [HttpPost]
        public async Task<ActionResult<Weather>> WeatherDetails(string city)
        {
            string appId = "6841189457374c62a5e105720222507";

            var httpClient = _httpClientFactory.CreateClient("WeatherAPI");

            var httpResponseMessage = await httpClient.GetAsync($"current.json?key={appId}&q={city}&aqi=no");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();

                var weatherData = await JsonSerializer.DeserializeAsync<Root>(contentStream);

                var weather = new Weather
                {
                    City = weatherData.location.name,
                    Region = weatherData.location.region,
                    Country = weatherData.location.country,
                    TimeZone = weatherData.location.tz_id,
                    LocalTime = weatherData.location.localtime,
                    Temp_c = weatherData.current.temp_c,
                    WindDirection = weatherData.current.wind_dir,
                    Condition = weatherData.current.condition.text,
                    ConditionIcon = weatherData.current.condition.icon,
                    Wind_kph = weatherData.current.wind_kph,
                    Feelslike_c = weatherData.current.feelslike_c,
                    Last_updated = weatherData.current.last_updated,
                };

                return Ok(weather);
            }

            return BadRequest();
        }
    }
}