using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Threading.Tasks;
using Commander.Interfaces;

namespace Commander.Middlewares
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;
        public AuthMiddleware(RequestDelegate next)
        {
            this._next = next;
        }
        public async Task Invoke(HttpContext context, IUserService userService, IJwtHelper jwtHelper)
        {
            // FIXME: Fetch token from Authorization key
            var token = context.Request.Headers["token"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
                attachUserToContext(context, userService, jwtHelper, token);

            await _next(context);
        }

        private void attachUserToContext(HttpContext context, IUserService userService, IJwtHelper jwtHelper, string token)
        {
            var userId = jwtHelper.validateToken(token);
            if (userId > -1)
            {
                // attach user to context on successful jwt validation
                context.Items["User"] = userService.GetUserById(userId);
            }
        }
    }
}