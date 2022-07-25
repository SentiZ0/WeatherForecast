using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Web.Helpers;
using WeatherForecastApiToApi.Models;

namespace WeatherForecastApiToApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpPost]
        public async Task<string> WeatherDetails(string city)
        {
            string appId = "6841189457374c62a5e105720222507";

            string url = $"http://api.weatherapi.com/v1/current.json?key={appId}&q={city}";

            using (var client = new HttpClient())
            {
                var responseTask = await client.GetStringAsync(url);

                var weatherData = JsonConvert.DeserializeObject<WeatherJson>(responseTask);
            }

            return url;
        }
    }
}