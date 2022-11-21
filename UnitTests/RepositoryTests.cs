using Castle.Core.Logging;
using Moq;
using MovieRepository.Services;
using MovieRepository.Storehouse;

namespace UnitTests
{
    public class RepositoryTest
    {
        readonly IMovieStorehouse _mockStorehouse;

        public RepositoryTest() 
        {
            _mockStorehouse = new MockDB();
        }

        [Fact]
        public async Task EmptyIdReturnsEmptyObject()
        {
            MovieService service = new MovieService(_mockStorehouse);
            string emptyId = "";

            var nonExistingMovie = await service.GetById(emptyId);
            Assert.NotNull(nonExistingMovie);
            Assert.True(string.IsNullOrEmpty(nonExistingMovie.Name));
            Assert.True(string.IsNullOrEmpty(nonExistingMovie.Director?.FirstName));
            Assert.True(string.IsNullOrEmpty(nonExistingMovie.Director?.LastName));
            Assert.True(string.IsNullOrEmpty(nonExistingMovie.Id));
            Assert.True(string.IsNullOrEmpty(nonExistingMovie.Synopsis));

            Assert.Null(nonExistingMovie.Actors);
            Assert.Null(nonExistingMovie.Genres);
        }

        [Fact]
        public async Task NonExistingIdReturnsNullAsync()
        {
            MovieService service = new MovieService(_mockStorehouse);
            string nonExistingId = "non-Existing-id";

            var nonExistingMovie = await service.GetById(nonExistingId);
            Assert.Null(nonExistingMovie);

        }

        [Fact]
        public async Task ExistingIdReturnsValueAsync() 
        {
            MovieService service = new MovieService(_mockStorehouse);
            var movieList = await _mockStorehouse.GetAllMoviesAsync();
                        
            string existingId = movieList.First().Id;

            var existingMovie = await service.GetById(existingId);

            Assert.NotNull(existingMovie);
            Assert.Equal(existingId, existingMovie.Id);
        }
    }
}