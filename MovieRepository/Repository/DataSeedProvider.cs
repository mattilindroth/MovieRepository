using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using MovieStorehouse.Models;
using System;

namespace MovieStorehouse.Repository
{
    public class DataSeedProvider 
    {
        private List<Person> personSeed;
        private List<Movie> movieSeed;
        private List<Genre> genreSeed;

        public DataSeedProvider()
        {
            string jsonString = File.ReadAllText(".\\movies-compact.json");
            movieSeed = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Movie>>(jsonString);

            personSeed = new List<Person>();
            genreSeed = new List<Genre>();
            Dictionary<string, Person> personDictionary = new Dictionary<string, Person>();
            Dictionary<string, Genre> genreDictionary = new Dictionary<string, Genre>();

            int counter = 1;
            string key;
            foreach (Movie movie in movieSeed)
            {
                movie.Id = counter;
                var actorList = movie.Actors.ToList();
                for (int personIndex = 0; personIndex < actorList.Count(); personIndex++)
                {
                    var person = actorList[personIndex];
                    key = person.FirstName + " " + person.LastName;
                    if (!personDictionary.ContainsKey(key))
                        personDictionary.Add(key, person);
                }
                key = movie.Director.FirstName + " " + movie.Director.LastName;
                if (!personDictionary.ContainsKey(key))
                    personDictionary.Add(key, movie.Director);

                var genreList = movie.Genres.ToList();
                for (int genreIndex = 0; genreIndex < genreList.Count(); genreIndex++)
                {
                    var genre = genreList[genreIndex];
                    key = genre.Name;
                    if (!genreDictionary.ContainsKey(key))
                        genreDictionary.Add(key, genre);
                }

                counter++;
            }
            counter = 1;
            foreach (var keyValuePair in personDictionary)
            {
                var person = keyValuePair.Value;
                person.Id = counter;
                personSeed.Add(person);
                counter++;
            }
            counter = 1;
            foreach (var keyValuePair in genreDictionary)
            {
                var genre = keyValuePair.Value;
                genre.Id = counter;
                genreSeed.Add(genre);
                counter++;
            }
        }

        public List<Movie> GetMoviesSeed { get => movieSeed; }
        public List<Person> GetPersonsSeed { get => personSeed; }
        public List<Genre> GetGenresSeed { get => genreSeed; }

    }
}
