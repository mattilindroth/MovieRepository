using Microsoft.EntityFrameworkCore;
using MovieStorehouse.Models;

namespace MovieStorehouse.Repository
{
    public class MovieContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }
}
