using Castle.Core.Logging;
using Moq;
using MovieStorehouse.Repository;
using MovieStorehouse.Services;
using MovieStorehouse.Storehouse;

namespace UnitTests
{
    public class RepositoryTest
    {
        readonly IMovieRepository _mockStorehouse;

        public RepositoryTest() 
        {
            _mockStorehouse = new MockDB();
        }

        [Fact]
        public async Task NonExistingIdReturnsNullAsync()
        {
            MovieService service = new MovieService(_mockStorehouse);
            int nonExistingId = 0;

            var nonExistingMovie = await service.GetById(nonExistingId);
            Assert.Null(nonExistingMovie);

        }

        [Fact]
        public async Task ExistingIdReturnsValueAsync() 
        {
            MovieService service = new MovieService(_mockStorehouse);
            var movieList = await _mockStorehouse.GetAllMoviesAsync();
                        
            int existingId = 1;

            var existingMovie = await service.GetById(existingId);

            Assert.NotNull(existingMovie);
            Assert.Equal(existingId, 1);
        }
    }
}