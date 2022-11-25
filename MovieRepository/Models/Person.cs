using Newtonsoft.Json;

namespace MovieStorehouse.Models
{
    public class Person
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }
        
        [JsonProperty("lastName")]
        public string LastName { get; set; }
    }
}
