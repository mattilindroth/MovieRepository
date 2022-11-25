using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MovieStorehouse.Models
{
    public class Genre
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
