using MovieRepository.Models;
using Microsoft.AspNetCore.Mvc;
using MovieRepository.Repository;
using MovieRepository.Storehouse;

namespace MovieRepository.Services
{
    public class MovieService
    {
        private readonly ILogger _logger;
        private readonly IMovieStorehouse _movieStoreHouse;
        public MovieService(ILogger logger, IMovieStorehouse movieStoreHouse) 
        { 
            _logger=  logger;
            _movieStoreHouse= movieStoreHouse;
        }   

        public async Task<List<Movie>> GetAllMovies()
        {
            return await _movieStoreHouse.GetAllMoviesAsync();
        }

        public async Task<Movie?> GetById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return new Movie() ;
            }

            return await _movieStoreHouse.GetMovieByIdAsync(id);
        }


        public async Task<List<Movie>> Search(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm) || searchTerm.Length < 3)
            {
                return new List<Movie>();
            }

            return await _movieStoreHouse.SearchAsync(searchTerm);
        }

        public async Task<Movie> AddNew(Movie movie)
        {
            return await _movieStoreHouse.AddMovieAsync(movie);
        }
    }
}
