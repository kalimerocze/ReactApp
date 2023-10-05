using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

public class CorsOptionsMiddleware
{
    private readonly RequestDelegate _next;

    public CorsOptionsMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        if (context.Request.Method == "OPTIONS")
        {
            context.Response.StatusCode = 200;
            context.Response.Headers["Access-Control-Allow-Origin"] = "*"; // Povolte přístup z jakéhokoli zdroje
            context.Response.Headers["Access-Control-Allow-Methods"] = "GET, POST, PUT, DELETE, OPTIONS"; // Definujte povolené metody
            context.Response.Headers["Access-Control-Allow-Headers"] = "Content-Type, Authorization"; // Definujte povolené hlavičky
            await context.Response.CompleteAsync();
        }
        else
        {
            await _next(context);
        }
    }
}