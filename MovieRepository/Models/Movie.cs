using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MovieStorehouse.Models
{
    [PrimaryKey("Id")]
    public class Movie
    {
        public Movie()
        {
            Genres = new HashSet<Genre>();
            Actors = new HashSet<Person>();

        }

        [JsonProperty("id")]
        
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("year")]
        public int Year { get; set; }

        [JsonProperty("genres")]
        public virtual ICollection<Genre> Genres { get; set; }

        [JsonProperty("ageLimit")]
        public int AgeLimit { get; set; }

        [JsonProperty("rating")]
        public int Rating { get; set; }

        [JsonProperty("actors")]
        public virtual ICollection<Person> Actors { get; set; }

        [JsonProperty("director")]
        public virtual Person? Director { get; set; }


        [JsonProperty("synopsis")]
        public string Synopsis { get; set; }

    }
}
