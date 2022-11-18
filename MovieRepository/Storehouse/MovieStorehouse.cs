using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using MovieRepository.Models;
using MovieRepository.Storehouse;

namespace MovieRepository.Repository
{
    internal class MovieStorehouse : IMovieStorehouse
    {

        private readonly Container _cosmosContainer;

        public MovieStorehouse(MovieStorehouseConnectionParameters parameters) 
        {
            CosmosClient cosmosClient = new(parameters.EndPointUri, parameters.PrimaryKey, new CosmosClientOptions() { ApplicationName = "MovieRepository" });
            Database cosmosDatabase = cosmosClient.GetDatabase(parameters.DatabaseId);
            _cosmosContainer = cosmosDatabase.GetContainer(parameters.ContainerId);
        }

        private async Task<IEnumerable<Movie>> RetrieveMovieByProperty(string propertyName, string propertyValue)
        {
            string sql = "SELECT * FROM movies m WHERE m." + propertyName + " = @filter";
            var query = new QueryDefinition(query: sql).WithParameter("@filter", propertyValue);

            using FeedIterator<Movie> feed = _cosmosContainer.GetItemQueryIterator<Movie>(queryDefinition: query);

            List<Movie> results = new();

            while (feed.HasMoreResults)
            {
                FeedResponse<Movie> response = await feed.ReadNextAsync();
                foreach (Movie item in response)
                {
                    results.Add(item);
                }
            }

            return (IEnumerable<Movie>)results.FirstOrDefault<Movie>();
        }

        public async Task<Movie> AddMovieAsync(Movie movie)
        {
            if (movie == null)
                throw new NullReferenceException(nameof(movie));

            var possiblyExistingMovie = await RetrieveMovieByProperty("name", movie.Name);

            if (possiblyExistingMovie == null)
            {
                movie.Id = Guid.NewGuid().ToString();
                var itemResponse = await _cosmosContainer.CreateItemAsync<Movie>(movie);
                if (itemResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return itemResponse.Resource;
                }
            }
            return movie;
        }

        public async Task<List<Movie>> GetAllMoviesAsync()
        {
            var queryable = _cosmosContainer.GetItemLinqQueryable<Movie>();

            using FeedIterator<Movie> feed = queryable.ToFeedIterator();

            List<Movie> results = new();

            while (feed.HasMoreResults)
            {
                var response = await feed.ReadNextAsync();
                foreach (Movie movie in response)
                {
                    results.Add(movie);
                }
            }
            return results;
        }

        public async Task<Movie> GetMovieByIdAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return new Movie();
            }

            var possiblyExistingMovie = await RetrieveMovieByProperty("id", id);

            return possiblyExistingMovie.FirstOrDefault();
        }

        public async Task<List<Movie>> SearchAsync(string searchTerm)
        {
            string sql = "SELECT * FROM movies m WHERE LOWER(m.name) like '%@searchTerm%'";
            var query = new QueryDefinition(query: sql).WithParameter("@searchTerm", searchTerm);

            using FeedIterator<Movie> feed = _cosmosContainer.GetItemQueryIterator<Movie>(queryDefinition: query);

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
