using MovieStorehouse.Models;
using Microsoft.AspNetCore.Mvc;
using MovieStorehouse.Repository;
using MovieStorehouse.Storehouse;

namespace MovieStorehouse.Services
{
    public class MovieService
    {
        private readonly IMovieRepository _movieStoreHouse;
        public MovieService(IMovieRepository movieStoreHouse) 
        { 
            _movieStoreHouse= movieStoreHouse;
        }   

        public async Task<IResult> GetAllMovies()
        {
            try
            {
                var movies = await _movieStoreHouse.GetAllMoviesAsync();
                return Results.Ok(movies);
            } catch (Exception e)
            {
                //Todo log error
                return Results.StatusCode(500);
            }
        }

        public async Task<IResult> GetById(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return Results.BadRequest("id cannot be empty or null");
                }

                var movie = await _movieStoreHouse.GetMovieByIdAsync(id);
                if (movie == null)
                {
                    return Results.NotFound(id);
                }
                return Results.Ok(movie);
            } catch(Exception e)
            {
                return Results.NotFound(id);
            }
        }


        public async Task<IResult> Search(string searchTerm)
        {
            List<Movie> movies;
            try
            {
                if (string.IsNullOrEmpty(searchTerm) || searchTerm.Length < 3)
                {
                    return Results.BadRequest(nameof(Search) + " must be longer than 2 characters.");
                }

                movies = await _movieStoreHouse.SearchAsync(searchTerm);
            }
            catch (Exception e)
            {
                //Todo log error
                return Results.StatusCode(500);
            }
         
            return Results.Ok(movies);
            
        }

        public async Task<IResult> AddNew(Movie movie)
        {
            if(movie == null)
            {
                return Results.BadRequest("movie is empty");
            }
            var result = await _movieStoreHouse.AddMovieAsync(movie);
            if (result.Id <= 0 )
                return Results.StatusCode(500);

            return Results.Ok(result);
        }
    }
}
