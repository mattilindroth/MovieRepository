using Microsoft.EntityFrameworkCore;
using MovieStorehouse.Models;

namespace MovieStorehouse.Repository
{
    public class DataSeeding
    {
        public DataSeeding()
        {

        }

        public void SeedDBWithData(ModelBuilder modelBuilder)
        {
            string jsonString = File.ReadAllText( ".\\movies-compact.json");
            List<Movie> movies = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Movie>>(jsonString);
            int counter = 1;
            foreach (Movie movie in movies) { 
                movie.Id = counter;
                counter++; 
            }

            modelBuilder.Entity<Movie>().HasData(movies);
        }

    }
}
