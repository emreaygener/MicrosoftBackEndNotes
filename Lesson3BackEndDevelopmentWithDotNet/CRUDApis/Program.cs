using Microsoft.AspNetCore.Http.HttpResults;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
var blogs = new List<Blog>
{
    new Blog { Id = 1, Title = "First Blog", Body = "This is the first blog" },
    new Blog { Id = 2, Title = "Second Blog", Body = "This is the second blog" }
};

app.MapGet("/blogs", (Func<IEnumerable<Blog>>)(() => blogs));

app.MapGet("/blogs/{id:int}", (Func<int, IResult>)((id) =>
{
    var blog = blogs.FirstOrDefault(x => x.Id == id);
    if (blog is null) return Results.NotFound();
    return Results.Ok(blog);
}));

app.MapPost("/blogs", (Func<Blog, IResult>)((blog) =>
{
    blog.Id = blogs.Max(x => x.Id) + 1;
    blogs.Add(blog);
    return Results.Created("/blogs", blog);
}));

app.MapPut("/blogs/{id:int}", (Func<int, Blog, IResult>)((id, blog) =>
{
    var existingBlog = blogs.FirstOrDefault(x => x.Id == id);
    if (existingBlog != null)
    {
        existingBlog.Title = blog.Title;
        existingBlog.Body = blog.Body;
        return Results.Ok(existingBlog);
    }
    return Results.NotFound();
}));

app.MapDelete("/blogs/{id:int}", (Func<int, IResult>)((id) =>
{
    var existingBlog = blogs.FirstOrDefault(x => x.Id == id);
    if (existingBlog != null)
    {
        blogs.Remove(existingBlog);
        return Results.NoContent();
    }
    return Results.NotFound();
}));

app.Run();
public class Blog
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Body { get; set; }
}
