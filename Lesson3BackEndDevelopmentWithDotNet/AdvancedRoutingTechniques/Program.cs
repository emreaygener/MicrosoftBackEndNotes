var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/users/{userId}/posts/{slug}", (int userId, string slug) => $"User {userId} requested post {slug}");

app.MapGet("/products/{id:int:min(0)}", (int id) => $"Product {id}");

app.MapGet("/reports/{year?}", (int? year = 2016) => $"Report {year}");

app.MapGet("/files/{*path}", (string path) => $"File {path}");

app.MapGet("/search", (string? query, int page = 1) => $"Search {query} on page {page}");

app.MapGet("/store/{category}/{productId:int?}/{*extraPath}", (string category, int? productId, string? extraPath, bool inStock = true) => $"Category {category}, Product {productId}, Extra Path {extraPath}: In Stock: {inStock}");

app.Run();
