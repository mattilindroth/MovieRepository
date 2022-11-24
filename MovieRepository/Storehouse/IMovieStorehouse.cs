using MovieRepository.Models;

namespace MovieRepository.Storehouse
{
    public interface IMovieStorehouse
    {
        public Task<IResult> GetAllMoviesAsync();
        public Task<IResult> GetMovieByIdAsync(string id);
        public Task<IResult> SearchAsync(string searchTerm);
        public Task<IResult> AddMovieAsync(Movie movie);
    }
}
