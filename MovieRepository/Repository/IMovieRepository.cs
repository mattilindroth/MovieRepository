using MovieStorehouse.Models;

namespace MovieStorehouse.Storehouse
{
    public interface IMovieRepository
    {
        public Task<List<Movie>> GetAllMoviesAsync();
        public Task<Movie?> GetMovieByIdAsync(string id);
        public Task<List<Movie>> SearchAsync(string searchTerm);
        public Task<Movie> AddMovieAsync(Movie movie);
    }
}
