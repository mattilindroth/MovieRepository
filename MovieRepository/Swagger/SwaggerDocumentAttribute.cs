using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MovieStorehouse.Swagger
{
    public class SwaggerDocumentAttribute : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            swaggerDoc.Info = new OpenApiInfo
            {
                Title = "Movie repository",
                Description = "An API to query movies",
                Version = "1.0.0",
            };
        }
    }
}
