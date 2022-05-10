using Microsoft.AspNetCore.Builder;

namespace BEChallenge.API.Shared.Middleware
{
    public static class MiddlewareCollectionExtensions
    {
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
