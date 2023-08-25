using Newtonsoft.Json;
using System.Security.Authentication.ExtendedProtection;

namespace ApiTaskApp.Service
{
    public class ApiKey
    {
        public static string GetApiKey(string filePath)
        {
            string apiKey = null;

            try
            {
                string json = File.ReadAllText(filePath);

                dynamic obj = JsonConvert.DeserializeObject(json);

                apiKey = obj.name;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return apiKey;
        }
    }
}
