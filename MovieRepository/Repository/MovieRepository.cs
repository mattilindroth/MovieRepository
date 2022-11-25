﻿using Microsoft.EntityFrameworkCore;
using MovieStorehouse.Models;
using MovieStorehouse.Storehouse;

namespace MovieStorehouse.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieContext movieContext;

        public MovieRepository(MovieContext context) 
        {
            movieContext= context;
        }
        
        public async Task<Movie> AddMovieAsync(Movie movie)
        {
            movieContext.Movies.Add(movie);
            await movieContext.SaveChangesAsync();
            return movie;
        }

        public async Task<List<Movie>> GetAllMoviesAsync()
        {
            return await movieContext.Movies.ToListAsync<Movie>();
        }

        public async Task<Movie?> GetMovieByIdAsync(string id)
        {
            return await movieContext.Movies.FirstAsync(m => m.Id == id);
        }

        public async Task<List<Movie>> SearchAsync(string searchTerm)
        {
            searchTerm = searchTerm.ToLower();
            var byName =  await movieContext.Movies.Where(m => m.Name.Contains(searchTerm)).ToListAsync();
            var byDirector = await movieContext.Movies.Where(m => m.Director.FirstName.ToLower().Contains(searchTerm) || m.Director.LastName.ToLower().Contains(searchTerm)).ToListAsync();
            var byActor = await movieContext.Movies.Where(m => m.Actors.Any(a => a.FirstName.ToLower().Contains(searchTerm) || a.LastName.ToLower().Contains(searchTerm))).ToListAsync();
            
            return byName.Union(byDirector).Union(byActor).ToList();    
        }
    }
}
