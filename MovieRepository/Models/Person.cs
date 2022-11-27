using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MovieStorehouse.Models
{
    [PrimaryKey("Id")]
    public class Person
    {
        public Person() 
        {
            //Movies = new HashSet<Movie>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }
        
        [JsonProperty("lastName")]
        public string LastName { get; set; }

        //public virtual ICollection<Movie> Movies { get;}
    }
}
