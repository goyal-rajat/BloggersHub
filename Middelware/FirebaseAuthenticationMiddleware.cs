
using FirebaseAdmin.Auth;

namespace BloggersHub.Middelware
{
    public class FirebaseAuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        public FirebaseAuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var authenticationHeaader = context.Request.Headers["Authorization"].ToString();
            context.Response.Headers["Access-Control-Allow-Origin"] = "*";
            if (!string.IsNullOrEmpty(authenticationHeaader) && authenticationHeaader.StartsWith("Bearer"))
            {
                var token = authenticationHeaader.Substring("Bearer ".Length).Trim();
                try
                {
                    var decodedToken = await FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(token);
                    context.Items["User"] = decodedToken;
                }
                catch (FirebaseAuthException)
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await context.Response.WriteAsync("Unauthorized - Invalid User");
                    return;
                }
            }
            else
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Unauthorized - Invalid User");
                //await _next(context);
            }
            await _next(context);
        }
    }
}

