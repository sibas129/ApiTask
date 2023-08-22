﻿using ApiTaskApp.Service;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApiTaskApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskWeatherController : ControllerBase
    {
        // GET: api/WeatherMax
        [HttpGet("{lat},{lon}")]
        public async Task<IActionResult> GetWeather(double lat, double lon)
        {
            //ApiHelper apiHelper1 = new ApiHelper();
            ApiHelper apiHelper2 = new ApiHelper();

            //var apiKey = _configuration["OpenWeatherMapApiKey"];
            //var cityGetUrl = $"https://api.openweathermap.org/geo/1.0/direct?q={city}&limit=1&appid=12e9c9b3164d7a28de7274f057a0a701";

            /*HttpResponseMessage response = await apiHelper1.ApiClient.GetAsync(cityGetUrl);
            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode, new { message = "Request failed" });
            }

            var cityData = await response.Content.ReadAsAsync<CityModel>();*/

            //var lat = cityData.Lat;
            //var lon = cityData.Lon;
            var openWeatherMapApi = $"https://api.openweathermap.org/data/3.0/onecall?lat={lat}&lon={lon}&units=metric&exclude=minutely,hourly,daily,alerts&appid=12e9c9b3164d7a28de7274f057a0a701";

            HttpResponseMessage responseFinal = await apiHelper2.ApiClient.GetAsync(openWeatherMapApi);
            if (!responseFinal.IsSuccessStatusCode)
            {
                return StatusCode((int)responseFinal.StatusCode, new { message = "Request failed" });
            }

            var weatherData = await responseFinal.Content.ReadAsAsync<WeatherData>();

            var serverTime = DateTime.UtcNow;
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
