﻿using ApiTaskApp.Service;
using Microsoft.AspNetCore.Mvc;

namespace ApiTaskApp.Service
{
    public class WeatherProcessor
    {
        /*public static async Task<WeatherModel> LoadWeather(string cityName) { 
            string apiKey = "12e9c9b3164d7a28de7274f057a0a701";
            string url = $"https://samples.openweathermap.org/data/2.5/weather?q={cityName}&appid={apiKey}";

            using (HttpResponseMessage responseMessage = await ApiHelper.ApiClient.GetAsync(url))
            {
                if(responseMessage.IsSuccessStatusCode)
                {
                    WeatherMainModel main = await responseMessage.Content.ReadAsAsync<WeatherMainModel>();

                    return main.Results;
                }
                else
                {
                    throw new Exception(responseMessage.ReasonPhrase);
                }
            }
        }*/
    }
}

