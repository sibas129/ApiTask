using ApiTaskApp.Model;
using ApiTaskApp.Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ApiTaskApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskWeatherController : ControllerBase
    {
        // GET: api/WeatherMax
        [HttpGet("{city}")]
        public async Task<IActionResult> GetWeather(string city)
        {
            ApiHelper apiHelper1 = new ApiHelper();
            ApiHelper apiHelper2 = new ApiHelper();

            string apiKey = ApiKey.GetApiKey("../apikey.json");

            //var apiKey = _configuration["OpenWeatherMapApiKey"];
            var cityGetUrl = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid=12e9c9b3164d7a28de7274f057a0a701";

            HttpResponseMessage response = await apiHelper1.ApiClient.GetAsync(cityGetUrl);
            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode, new { message = "Request failed" });
            }

            var cityData = await response.Content.ReadAsAsync<CityModel>();

            var lat = cityData.coord.lat;
            var lon = cityData.coord.lon;
            var openWeatherMapApi = $"https://api.openweathermap.org/data/3.0/onecall?lat={lat}&lon={lon}&units=metric&exclude=minutely,hourly,daily,alerts&appid=12e9c9b3164d7a28de7274f057a0a701";

            HttpResponseMessage responseFinal = await apiHelper2.ApiClient.GetAsync(openWeatherMapApi);

            if (!responseFinal.IsSuccessStatusCode)
            {
                return StatusCode((int)responseFinal.StatusCode, new { message = "Request failed" });
            }

            var weatherData = await responseFinal.Content.ReadAsAsync<WeatherModel>();

            var serverTime = DateTime.Now;
            var cityTime = serverTime.AddSeconds(weatherData.TimezoneOffset);

            var timeDifference = cityTime - serverTime;

            var responseData = new
            {
                City = weatherData.Timezone,
                CurrentCityTime = cityTime,
                CurrentServerTime = serverTime, 
                TimeDifference = timeDifference,
                Temperature = weatherData.Current.Temp,
                Pressure = weatherData.Current.Pressure,
                Humidity = weatherData.Current.Humidity,
                WindSpeed = weatherData.Current.WindSpeed,
                CloudCover = weatherData.Current.Clouds
            };


            return Ok(responseData);
        }

    }
}
