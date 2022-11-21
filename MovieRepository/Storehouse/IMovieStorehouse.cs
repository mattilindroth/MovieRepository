using MovieRepository.Models;

namespace MovieRepository.Storehouse
{
    public interface IMovieStorehouse
    {
        public Task<List<Movie>> GetAllMoviesAsync();
        public Task<Movie?> GetMovieByIdAsync(string id);
        public Task<List<Movie>> SearchAsync(string searchTerm);
        public Task<Movie> AddMovieAsync(Movie movie);
    }
}
