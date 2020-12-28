using Microsoft.AspNetCore.Builder;
using VisitCard.API.Middleware;

namespace VisitCard.API.Extensions
{
    public static class ConfigureExtensions
    {
        public static void UseCookieAuthentication(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<CookieAuthenticationMiddleware>();
        }
    }
}