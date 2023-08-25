namespace ApiTaskApp.Model
{
    public class WeatherModel
    {
        public string? Timezone { get; set; }
        public int TimezoneOffset { get; set; }
        public CurrentWeather? Current { get; set; }
    }
}
