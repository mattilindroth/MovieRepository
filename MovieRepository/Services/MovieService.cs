using MovieRepository.Models;
using Microsoft.AspNetCore.Mvc;

namespace MovieRepository.Services
{
    public class MovieService
    {
        private readonly ILogger<MovieService> _logger;
        public MovieService(ILogger<MovieService> logger) 
        { 
            _logger=  logger;
        }   

        public async Task<List<Movie>> GetAllMovies()
        {
            return new List<Movie>();
        }

        public async Task<Movie> GetById(int id)
        {
            return new Movie();
        }

        public async Task<List<Movie>> Search(string searchTerm)
        {
            return new List<Movie>();
        }

        public async Task<Movie> AddNew(Movie movie)
        {
            return movie;
        }
    }
}
