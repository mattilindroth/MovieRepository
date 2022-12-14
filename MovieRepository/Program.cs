using Microsoft.EntityFrameworkCore;
using MovieStorehouse.Models;
using MovieStorehouse.Repository;
using MovieStorehouse.Services;
using MovieStorehouse.Storehouse;
using MovieStorehouse.Swagger;
using System.Reflection.Metadata;

var builder = WebApplication.CreateBuilder(args);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.DocumentFilter<SwaggerDocumentAttribute>();
    options.OperationFilter<SwaggerOperationAttribute>();
});

//**************Get parameters for cosmosDB connection**************

//var configSection = builder.Configuration.GetSection("CosmosDbConnection");
//var parameters = new CosmosDBConnectionParameters(configSection.GetValue<string>("EndPointUri"),
//                                                           configSection.GetValue<string>("PrimaryKey"),
//                                                           configSection.GetValue<string>("DatabaseId"),
//                                                           configSection.GetValue<string>("ContainerId"));
//builder.Services.AddScoped<IMovieRepository, CosmosRepository>();
//builder.Services.AddSingleton(parameters);


//******************* Parameters for SQL db *********************

//builder.Services.AddDbContext<MovieContext>(
//       options => options.UseSqlServer("name=ConnectionStrings:MovieContext"));

//********************* In memory db ***************************
builder.Services.AddDbContext<MovieContext>(options => 
    options.UseInMemoryDatabase("items"));
builder.Services.AddScoped<IMovieRepository, SqlRepository>();


// Add services to the container.
builder.Services.AddScoped<MovieService>();

builder.Services.AddCors();

var app = builder.Build();
app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
   );

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/movies", async (MovieService movieService) => await movieService.GetAllMovies()).WithName("getAllMovies");
app.MapGet("/movies/{id}", async (int id, MovieService movieService) => await movieService.GetById(id)).WithName("getMovieById");
app.MapGet("movies/search/{searchTerm}", async (string searchTerm, MovieService movieService) => await movieService.Search(searchTerm)).WithName("searchMovie");
app.MapPost("movies", async (Movie movie, MovieService movieService) => await movieService.AddNew(movie)).WithName("addNew");

//Ensure data seeding not in test or production environments
#if DEBUG
using (var context = new MovieContext())
{
    context.Database.EnsureCreated();
    var seedProvider = new DataSeedProvider();
    var movies = seedProvider.GetMoviesSeed;

    var genres = seedProvider.GetGenresSeed;
    var persons = seedProvider.GetPersonsSeed;

    context.Genres.AddRange(genres);
    context.SaveChanges();

    context.Persons.AddRange(persons);
    context.SaveChanges();
    
    context.Movies.AddRange(movies);
    context.SaveChanges();
   
}

#endif

app.Run();
