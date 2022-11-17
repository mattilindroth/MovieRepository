using MovieRepository.Models;
using MovieRepository.Services;
using MovieRepository.Swagger;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddAuthorization();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.DocumentFilter<SwaggerDocumentAttribute>();
    options.OperationFilter<SwaggerOperationAttribute>();
});

builder.Services.AddScoped<MovieService>();
builder.Services.AddLogging();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapGet("/movies", async (MovieService movieService) => await movieService.GetAllMovies());
app.MapGet("/movies/{id}", async (int id, MovieService movieService) => await movieService.GetById(id));
app.MapGet("movies/search/{searchTerm}", async (string searchTerm, MovieService movieService) => await movieService.Search(searchTerm));

app.Run();
