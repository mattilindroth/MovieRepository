using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace MovieRepository.Models
{
    public class Movie
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("year")]
        public int Year { get; set; }

        [JsonProperty("genres")]
        public List<string>? Genres { get; set; }

        [JsonProperty("ageLimit")]
        public int AgeLimit { get; set; }

        [JsonProperty("rating")]
        public int Rating { get; set; }

        [JsonProperty("actors")]
        public List<Person>? Actors { get; set; }

        [JsonProperty("director")]
        public Person? Director { get; set; }

        [JsonProperty("synopsis")]
        public string Synopsis { get; set; }

    }
}
