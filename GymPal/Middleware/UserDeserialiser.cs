using GymPal.Helpers;
using System.Globalization;

namespace GymPal.Middleware
{
    public class UserDeserialiser
    {
        private readonly RequestDelegate _next;
        private readonly JwtHelper _jwtHelper;

        public UserDeserialiser(RequestDelegate next, JwtHelper jwtHelper)
        {
            _next = next;
            _jwtHelper = jwtHelper;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var jwt = context.Request.Headers["Authorization"];
            if (!string.IsNullOrEmpty(jwt))
            {
                var userId = await _jwtHelper.ParseUserFromJWT(jwt);

                context.Items.Add("userId", userId);
            }

            await _next(context);
        }
    }

    public static class UserDeserialiserMiddlewareExtensions
    {
        public static IApplicationBuilder UseUserDeserialiser(
        this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<UserDeserialiser>();
        }
    }
}
