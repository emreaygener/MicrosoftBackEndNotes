using System.Diagnostics;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpLogging((o) => { });

var app = builder.Build();

// app.UseHttpLogging();

// app.Use(async (context, next) =>
// {
//     // before here logic that comes before the next middleware
//     await next();
//     // after logic here that comes after the next middleware
// });

app.UseGlobalExceptionMiddleware();
// app.UseHttpsRedirection();
// dotnet run --launch-profile https

app.MapGet("/", () => "Hello World!");
app.MapGet("/hello", () => "This is the hello route!");
app.MapGet("/json", () => new { Name = "John Doe", Age = 30 });
app.MapGet("/throw", (int i = 0) => { return (2 / i); });
app.MapGet("/status", () => Results.StatusCode((int)HttpStatusCode.InternalServerError));
app.MapGet("/status/{code}", (int code) => Results.StatusCode(code));
app.MapGet("/search", (string? query, int page = 1) => $"Search {query} on page {page}");
app.MapGet("/files/{*path}", (string path) => $"File {path}");

app.Run();

public class GlobalExceptionMiddleware
{
    private readonly ILogger<GlobalExceptionMiddleware> logger;
    private readonly IWebHostEnvironment env;

    private readonly RequestDelegate next;

    public GlobalExceptionMiddleware(ILogger<GlobalExceptionMiddleware> logger, IWebHostEnvironment env, RequestDelegate next)
    {
        this.logger = logger;
        this.env = env;
        this.next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        long start = Stopwatch.GetTimestamp();
        try
        {
            await next(context);
            var ms = Stopwatch.GetElapsedTime(start).TotalMilliseconds;
            var message = $"[{context.Request.Scheme.ToUpper()}] {context.Request.Method} {context.Request.Path}{context.Request.QueryString} => {context.Response.StatusCode} in {ms} ms.";

            if (context.Response.StatusCode >= 300 || context.Response.StatusCode < 200)
                logger.LogWarning(message);
            else
                logger.LogInformation(message);
        }
        catch (Exception ex)
        {
            var ms = Stopwatch.GetElapsedTime(start).TotalMilliseconds;
            var message = $"[{context.Request.Scheme.ToUpper()}] {context.Request.Method} {context.Request.Path}{context.Request.QueryString} => {context.Response.StatusCode} in {ms} ms.";

            if (env.IsDevelopment())
                logger.LogCritical(ex, $"[{message} | Error Message: {ex.Message}");
            else
                logger.LogCritical(message + $" | Something went wrong!");
        }
    }
}
public static class GlobalExceptionMiddlewareExtension
{
    public static IApplicationBuilder UseGlobalExceptionMiddleware(this IApplicationBuilder app)
    {
        return app.UseMiddleware<GlobalExceptionMiddleware>();
    }
}