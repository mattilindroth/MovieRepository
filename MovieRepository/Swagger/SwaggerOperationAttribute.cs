using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MovieStorehouse.Swagger
{
    public class SwaggerOperationAttribute : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            switch (operation.OperationId)
            {
                case "getAllMovies":
                    operation.Summary = "Get all movies";
                    operation.Description = "Get all movies in the repository";
                    break;
                case "getMovieById":
                    operation.Summary = "Get specific movie";
                    operation.Description = "Get details on a specific movie";
                    break;
                case "searchMovie":
                    operation.Summary = "Search movies";
                    operation.Description = "Search movies by search text";
                    break;
                case "addMovie":
                    operation.Summary = "Add movie to repository";
                    operation.Description = "Adds new movie to repository";
                    break;
                default:
                    break;
            }
        }
    }
}
