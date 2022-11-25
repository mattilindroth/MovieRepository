using Microsoft.Azure.Cosmos;
using MovieStorehouse.Models;

namespace MovieStorehouse.Storehouse
{
    public interface IMovieFilter
    {
        public Task<List<Movie>> GetMoviesAsync(Container container, string? filterTerm);
    }
}
