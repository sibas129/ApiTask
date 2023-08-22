using System.Net.Http.Headers;

namespace ApiTaskApp.Controllers
{
    public class ApiHelper
    {
        public HttpClient ApiClient { get; set; }

        public ApiHelper()
        {
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
