using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace ApiTaskApp.Model
{

    public class CityModel
    {
        [JsonProperty("coord")]
        public Coord? coord { get; set; }
    }
}
