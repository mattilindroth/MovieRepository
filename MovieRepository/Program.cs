using MovieRepository.Models;
using MovieRepository.Repository;
using MovieRepository.Services;
using MovieRepository.Storehouse;
using MovieRepository.Swagger;

var builder = WebApplication.CreateBuilder(args);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.DocumentFilter<SwaggerDocumentAttribute>();
    options.OperationFilter<SwaggerOperationAttribute>();
});

//Get parameters for cosmosDB connection
var configSection = builder.Configuration.GetSection("DbConnection");
var parameters = new MovieStorehouseConnectionParameters(configSection.GetValue<string>("EndPointUri"),
                                                           configSection.GetValue<string>("PrimaryKey"),
                                                           configSection.GetValue<string>("DatabaseId"),
                                                           configSection.GetValue<string>("ContainerId"));
// Add services to the container.
builder.Services.AddScoped<MovieService>();
builder.Services.AddScoped<IMovieStorehouse, CosmosDbStorehouse>();
builder.Services.AddSingleton(parameters);
builder.Services.AddCors();
//builder.Services.AddLogging();

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
app.MapGet("/movies/{id}", async (string id, MovieService movieService) => await movieService.GetById(id)).WithName("getMovieById");
app.MapGet("movies/search/{searchTerm}", async (string searchTerm, MovieService movieService) => await movieService.Search(searchTerm)).WithName("searchMovie");
app.MapPost("movies", async (Movie movie, MovieService movieService) => await movieService.AddNew(movie)).WithName("addNew");

app.Run();
