﻿using Newtonsoft.Json;

namespace MovieStorehouse.Models
{
    public class Person
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }
        
        [JsonProperty("lastName")]
        public string LastName { get; set; }
    }
}
