using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieStorehouse.Models;

using Newtonsoft.Json;

namespace UnitTests
{
    internal class MockDB : MovieStorehouse.Storehouse.IMovieRepository
    {

        private readonly List<Movie> _movies;

        public MockDB() 
        { 
            _movies = new List<Movie>();

            string json = File.ReadAllText("movies-compact.json");

            _movies = JsonConvert.DeserializeObject<List<Movie>>(json);
            int counter = 1;
            foreach(var m in _movies)
            {
                m.Id = counter;
                counter++;
            }
        }

        public Task<Movie> AddMovieAsync(Movie movie)
        {

            movie.Id = _movies.Count() +1;
            _movies.Add(movie);
            return Task.FromResult(movie);
        }

        public Task<List<Movie>> GetAllMoviesAsync()
        {
            return Task.FromResult( _movies );
        }

        public Task<Movie?> GetMovieByIdAsync(int id)
        {
            var movie = _movies.Where(m => m.Id == id).FirstOrDefault();
            return Task.FromResult(movie);
        }

        public Task<List<Movie>> SearchAsync(string searchTerm)
        {
            searchTerm= searchTerm.ToLower();
            List<Movie> byName = _movies.Where(m => m.Name.ToLower().Contains(searchTerm)).ToList();
            List<Movie> byDirector = _movies.Where(m => m.Director == null ? false : m.Director.FirstName.ToLower().Contains(searchTerm) || m.Director.LastName.ToLower().Contains(searchTerm)).ToList();
            List<Movie> byActors = _movies.Where(m => m.Actors == null ? false : m.Actors.Where(a => a.FirstName.ToLower().Contains(searchTerm) || a.LastName.ToLower().Contains(searchTerm)).Any()).ToList();

            return Task.FromResult((List<Movie>)byName.Union(byDirector).Union(byActors));

        }
    }
}
