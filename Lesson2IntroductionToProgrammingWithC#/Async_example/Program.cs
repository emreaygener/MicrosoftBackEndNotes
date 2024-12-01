public class Program
{



    // Asynchronous method to fetch product data
    public async Task<List<Product>> FetchProductsAsync1()
    {
        await Task.Delay(new Random().Next(1000, 3000)); // Simulating a 2-second delay for data fetching
        return new List<Product>
        {
            new Product("Eco Bag"),
            new Product("Reusable Straw")
        };
    }

    // Asynchronous method to display product data
    public async Task DisplayProductsAsync()
    {
        List<Product> products = await FetchProductsAsync1();
        foreach (Product product in products)
        {
            Console.WriteLine(product.Name);
        }
    }

    // Asynchronous method to fetch product data
    public async Task<List<Product>> FetchProductsAsync()
    {
        await Task.Delay(new Random().Next(1000, 3000)); // Simulating a 2-second delay for fetching products
        return new List<Product> { new Product("Eco Bag"), new Product("Reusable Straw") };
    }

    // Asynchronous method to fetch review data
    public async Task<List<Review>> FetchReviewsAsync()
    {
        await Task.Delay(new Random().Next(1000, 3000)); // Simulating a 3-second delay for fetching reviews
        return new List<Review>
        {
            new Review("Great product!"),
            new Review("Good value for the money."),
        };
    }

    // Asynchronous method to display both products and reviews
    public async Task FetchDataAsync()
    {
        // Start fetching products and reviews concurrently
        Task<List<Product>> productsTask = FetchProductsAsync();
        Task<List<Review>> reviewsTask = FetchReviewsAsync();

        // Wait for both tasks to complete
        await Task.WhenAll(productsTask, reviewsTask);

        // Get the results
        List<Product> products = await productsTask;
        List<Review> reviews = await reviewsTask;

        // Display the results
        Console.WriteLine("Products:");
        foreach (Product product in products)
        {
            Console.WriteLine(product.Name);
        }

        // Display fetched reviews
        Console.WriteLine("\nReviews:");
        foreach (Review review in reviews)
        {
            Console.WriteLine(review.Content);
        }
    }

    public async Task<string> DownloadFileAsync(string fileName)
    {
        Console.WriteLine($"Starting download of {fileName}...");
        await Task.Delay(new Random().Next(1000, 3000)); // Simulate a 3-second download time
        Console.WriteLine($"Completed download of {fileName}.");
        return $"{fileName} content";
    }

    public async Task DownloadFilesAsync()
    {
        // Start downloading "File1.txt" and "File2.txt" concurrently
        var downloadTask1 = DownloadFileAsync("File1.txt");
        var downloadTask2 = DownloadFileAsync("File2.txt");


        // Wait for both downloads to complete
        await Task.WhenAll(downloadTask1, downloadTask2);
        Console.WriteLine("All downloads completed.");
    }

    public async Task ProcessDataChunkAsync(int chunkNumber)
    {
        Console.WriteLine($"Processing chunk {chunkNumber}...");
        await Task.Delay(new Random().Next(1000, 3000)); // Simulate processing time
        Console.WriteLine($"Completed processing of chunk {chunkNumber}.");
    }


    public async Task ProcessLargeDatasetAsync(int numberOfChunks)
    {
        var tasks = new List<Task>();

        // Start processing each chunk concurrently
        for (int i = 1; i <= numberOfChunks; i++)
        {
            tasks.Add(ProcessDataChunkAsync(i));
        }

        // Wait for all tasks to complete
        await Task.WhenAll(tasks);

        Console.WriteLine("All data chunks processed.");
    }

    public static async Task Main(string[] args)
    {
        Program program = new Program();
        await program.DisplayProductsAsync();
        await program.FetchDataAsync();
        await program.DownloadFilesAsync();
        await program.ProcessLargeDatasetAsync(5); // Process 5 chunks
    }
}


public class Product
{
    public string Name { get; set; }

    public Product(string name)
    {
        Name = name;
    }
}

public class Review
{
    public string Content { get; set; }

    public Review(string content)
    {
        Content = content;
    }
}