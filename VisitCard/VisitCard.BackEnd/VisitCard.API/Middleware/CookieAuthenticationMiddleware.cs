using System;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using VisitCard.BLL.Services.Interfaces;

namespace VisitCard.API.Middleware
{
    public class CookieAuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;

        public CookieAuthenticationMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _configuration = configuration;
            _next = next;
        }

        public async Task Invoke(HttpContext context, ICardService cardService)
        {
            var userId = context.Request.Cookies["identity"];
            if (string.IsNullOrEmpty(userId))
            {
                var domain = new Uri(_configuration["WebUrl"]).Host;
                userId = Guid.NewGuid().ToString();
                
                context.Response.Cookies.Append("identity", userId, new CookieOptions
                {
                    HttpOnly = true,
                    Domain = domain,
                    Expires = DateTimeOffset.MaxValue,
                    SameSite = SameSiteMode.Strict
                });

                await cardService.CreateEmptyCardAsync(userId);
            }
            
            var principal = new GenericPrincipal(new GenericIdentity(userId), Array.Empty<string>());
            Thread.CurrentPrincipal = principal;
            context.User = principal;

            await _next(context);
        }
    }
}