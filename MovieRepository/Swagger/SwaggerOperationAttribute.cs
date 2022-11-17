using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MovieRepository.Swagger
{
    public class SwaggerOperationAttribute : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            switch (operation.OperationId)
            {
                case "getAllMovies":
                    operation.Summary = "Get movies";
                    operation.Description = "Get all movies in the repository";
                    break;
                case "get":
                    operation.Summary = "Get's the weather forecast";
                    operation.Description = "A sample operation returning some json data.";
                    break;
                default:
                    break;
            }
        }
    }
}
