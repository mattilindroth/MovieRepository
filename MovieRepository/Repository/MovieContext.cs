
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MovieStorehouse.Models;
//using System.Data.Entity;
using System.Reflection.Metadata;

namespace MovieStorehouse.Repository
{
    public class MovieContext : DbContext
    {
        
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {
           
        }

        public MovieContext() { }


        public DbSet<Person> Persons { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }

        #region Required

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("items");
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            DataSeedProvider dataSeeding = new DataSeedProvider();

            //Person
            modelBuilder.Entity<Person>(person => 
            {
                person.Property(p => p.Id)
                .UseIdentityColumn()
                .IsRequired();

                person.Property(p => p.FirstName)
                .IsRequired();

                person.Property(p => p.LastName)
                .IsRequired();

                //person.HasMany<Movie>(m => m.Movies).WithMany(p => p.Actors);
            });

            //Movie
            modelBuilder.Entity<Movie>(movie =>
            {
                movie.Property(m => m.Id)
                .UseIdentityColumn()
                .IsRequired();

                movie.Property(m => m.Name)
                .IsRequired();

                //movie.Property(m => m.Director)
                //.IsRequired();

                movie.HasOne<Person>(m => m.Director);

                movie.HasMany<Person>(m => m.Actors).WithMany(a => a.Movies);

                movie.HasMany<Genre>(m => m.Genres).WithMany(g => g.Movies);
            });


            //Genre
            modelBuilder.Entity<Genre>(genre =>
            {
                genre.Property(m => m.Id)
                .UseIdentityColumn()
                .IsRequired();

                genre.Property(m => m.Name)
                .IsRequired();

                //genre.HasMany<Movie>(m => m.Movies).WithMany(g => g.Genres);
            });
            
            //dataSeeding.Seed(modelBuilder);
        }
        #endregion

    }
}
