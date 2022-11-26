
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MovieStorehouse.Models;
using System.Reflection.Metadata;

namespace MovieStorehouse.Repository
{
    public class MovieContext : DbContext
    {
        
        public MovieContext(DbContextOptions<MovieContext> options) 
        {
           
        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }

        #region Required

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("items");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            DataSeeding dataSeeding = new DataSeeding();

            //Person
            modelBuilder.Entity<Person>()
                .Property(p => p.Id)
                .UseIdentityColumn()
                .IsRequired();
            modelBuilder.Entity<Person>()
                .Property(p => p.FirstName)
                .IsRequired();
            modelBuilder.Entity<Person>()
                .Property(p => p.LastName)
                .IsRequired();

            //Movie
            modelBuilder.Entity<Movie>()
                .Property(m => m.Id)
                .UseIdentityColumn()
                .IsRequired();
            modelBuilder.Entity<Movie>()
                .Property(m => m.Name)
                .IsRequired();

            //Genre
            modelBuilder.Entity<Genre>().Property(m => m.Id)
                .UseIdentityColumn()
                .IsRequired();
            modelBuilder.Entity<Genre>()
                .Property(m => m.Name)
                .IsRequired();

            dataSeeding.SeedDBWithData(modelBuilder);
        }
        #endregion

    }
}
