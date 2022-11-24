using MovieRepository.Models;
using Microsoft.AspNetCore.Mvc;
using MovieRepository.Repository;
using MovieRepository.Storehouse;

namespace MovieRepository.Services
{
    public class MovieService
    {
        private readonly IMovieStorehouse _movieStoreHouse;
        public MovieService(IMovieStorehouse movieStoreHouse) 
        { 
            _movieStoreHouse= movieStoreHouse;
        }   

        public async Task<IResult> GetAllMovies()
        {
            return await _movieStoreHouse.GetAllMoviesAsync();
        }

        public async Task<IResult> GetById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return Results.BadRequest("id cannot be empty or null");
            }

            return await _movieStoreHouse.GetMovieByIdAsync(id);
        }


        public async Task<IResult> Search(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm) || searchTerm.Length < 3)
            {
                return Results.BadRequest(nameof(Search) + " must be longer than 2 characters.");
            }

            return await _movieStoreHouse.SearchAsync(searchTerm);
        }

        public async Task<IResult> AddNew(Movie movie)
        {
            if(movie == null)
            {
                return Results.BadRequest("movie is empty");
            }
            return await _movieStoreHouse.AddMovieAsync(movie);
        }
    }
}
