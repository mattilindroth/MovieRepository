using Microsoft.Azure.Cosmos;
using MovieRepository.Models;

namespace MovieRepository.Storehouse.Filters
{
    public class MovieDirectorFilter : IMovieFilter
    {
        public async Task<List<Movie>> GetMoviesAsync(Container container, string? filterTerm)
        {
            if (string.IsNullOrEmpty(filterTerm))
                throw new ArgumentNullException(nameof(filterTerm));

            filterTerm = filterTerm.Trim().ToLower();

            string sql = "SELECT * FROM movies m WHERE (LOWER(m.director.firstName) like '%" + filterTerm + "%') OR (LOWER(m.director.lastName) like '%" + filterTerm + "%')";
            var query = new QueryDefinition(query: sql);

            using FeedIterator<Movie> feed = container.GetItemQueryIterator<Movie>(queryDefinition: query);

            List<Movie> results = new();

            while (feed.HasMoreResults)
            {
                FeedResponse<Movie> response = await feed.ReadNextAsync();
                foreach (Movie item in response)
                {
                    results.Add(item);
                }
            }

            return results;
        }
    }
}
