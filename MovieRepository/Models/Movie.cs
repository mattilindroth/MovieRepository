namespace MovieRepository.Models
{
    public class Movie
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public List<string> Genres { get; set; }
        public int AgeLimit { get; set; } 
        public int Rating { get; set; }
        public List<Person> Actors { get; set; }
        public Person Director { get; set; }    
        public string Synopsis { get; set; }

    }
}
