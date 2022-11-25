using Microsoft.Azure.Cosmos;
using MovieStorehouse.Models;

namespace MovieStorehouse.Storehouse.Filters
{
    public class MovieActorFiltercs : IMovieFilter
    {
        public async Task<List<Movie>> GetMoviesAsync(Container container, string? filterTerm)
        {
            if (string.IsNullOrEmpty(filterTerm))
                throw new ArgumentNullException(nameof(filterTerm));

            filterTerm = filterTerm.Trim().ToLower();

            string sql = "SELECT * FROM movies m WHERE (LOWER(m.actors[0].firstName) like '%" + filterTerm + "%') OR (LOWER(m.actors[0].lastName) like '%" + filterTerm + "%')";
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
