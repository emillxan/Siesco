namespace Task2Api;

public class CustomAuthorizationMiddleware
{
    private readonly RequestDelegate _next;

    public CustomAuthorizationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        await _next(context);

        if (context.Response.StatusCode == StatusCodes.Status401Unauthorized)
        {
            context.Response.ContentType = "application/json";
            var response = new { message = "İcazəsiz giriş: İstifadəçiyə icazə verilməyib." };
            await context.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(response));
        }
        else if (context.Response.StatusCode == StatusCodes.Status403Forbidden)
        {
            context.Response.ContentType = "application/json";
            var response = new { message = "Giriş qadağandır: Bu əməliyyat üçün kifayət qədər hüquqlarınız yoxdur." };
            await context.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(response));
        }
    }
}
