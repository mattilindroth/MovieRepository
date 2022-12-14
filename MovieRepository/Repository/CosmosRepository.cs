using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using MovieStorehouse.Models;
using MovieStorehouse.Storehouse;
using System.Reflection.Metadata.Ecma335;

namespace MovieStorehouse.Repository
{
    internal class CosmosRepository : IMovieRepository
    {

        private readonly Container _cosmosContainer;

        public CosmosRepository(CosmosDBConnectionParameters parameters) 
        {
            CosmosClient cosmosClient = new(parameters.EndPointUri, parameters.PrimaryKey, new CosmosClientOptions() { ApplicationName = "MovieRepository" });
            Database cosmosDatabase = cosmosClient.GetDatabase(parameters.DatabaseId);
            _cosmosContainer = cosmosDatabase.GetContainer(parameters.ContainerId);
        }

        private async Task<List<Movie>> RetrieveMovieByProperty(string propertyName, string propertyValue)
        {
            //Todo: Use Linq instead
            string sql = "SELECT * FROM movies m WHERE m.@propertyName = @filter";
            var query = new QueryDefinition(query: sql)
                .WithParameter("@filter", propertyValue)
                .WithParameter("@propertyName", propertyName);


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

        public async Task<Movie> AddMovieAsync(Movie movie)
        {

            var possiblyExistingMovie = await RetrieveMovieByProperty("name", movie.Name);

            if (possiblyExistingMovie == null || possiblyExistingMovie.Any())
            {
                var itemResponse = await _cosmosContainer.CreateItemAsync<Movie>(movie);
                if (itemResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return movie;
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

        public async Task<Movie?> GetMovieByIdAsync(int id)
        {
            var possiblyExistingMovie = await RetrieveMovieByProperty("id", id.ToString());

            return possiblyExistingMovie.FirstOrDefault();
        }

        public async Task<List<Movie>> SearchAsync(string searchTerm)
        {
            IEnumerable<Movie> allResults= new List<Movie>();
            var interfaceType = typeof(IMovieFilter);

            var all = AppDomain.CurrentDomain.GetAssemblies()
              .SelectMany(x => x.GetTypes())
              .Where(x => interfaceType.IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
              .Select(x => Activator.CreateInstance(x));

            foreach (IMovieFilter filter in all)
            {
                var currentFilterResults = await filter.GetMoviesAsync(_cosmosContainer, searchTerm);
                allResults = allResults.Union(currentFilterResults);
            }

            return allResults.ToList();
        }
    }
}
