using System.Net.Http.Headers;

namespace ApiTaskApp.Service
{
    public class ApiHelper
    {
        public static HttpClient ApiClient { get; set; } = new HttpClient(); 

        public static void InitializeClient()
        {
            ApiClient = new HttpClient();
            //ApiClient.BaseAddress = new Uri("https://api.openweathermap.org/data/3.0/");
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); 
        }
    }
}
