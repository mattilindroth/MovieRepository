using Microsoft.Azure.Cosmos;
using MovieRepository.Models;

namespace MovieRepository.Storehouse
{
    public interface IMovieFilter
    {
        public Task<List<Movie>> GetMoviesAsync(Container container, string? filterTerm);
    }
}
