using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace MovieStorehouse.Models
{
    public class Movie
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("year")]
        public int Year { get; set; }

        [JsonProperty("genres")]
        public virtual List<Genre> Genres { get; set; }

        [JsonProperty("ageLimit")]
        public int AgeLimit { get; set; }

        [JsonProperty("rating")]
        public int Rating { get; set; }

        [JsonProperty("actors")]
        public virtual List<Person>? Actors { get; set; }

        [JsonProperty("director")]
        public virtual Person? Director { get; set; }

        [JsonProperty("synopsis")]
        public string Synopsis { get; set; }

    }
}
