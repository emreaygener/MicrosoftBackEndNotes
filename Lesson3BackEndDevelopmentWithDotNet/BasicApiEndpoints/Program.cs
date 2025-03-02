var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Root Path");
app.MapGet("/downloads", () => "Downloads");
app.MapPut("/", () => "This is a put request");
app.MapDelete("/", () => "Delete!!!!!");
app.MapPost("/", () => "Post me");

app.Run();
