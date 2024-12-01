public class Program
{
    public static async Task Main(string[] args)
    {

        Program program = new Program();
        await program.DownloadDataAsync();
        Console.WriteLine("Main method completed.");
        Console.WriteLine("-----------------------");
        Task task1 = program.DownloadDataAsync();
        Task task2 = program.DownloadDataAsync2();
        await Task.WhenAll(task1, task2);
        Console.WriteLine("All downloads completed.");
    }

    public async Task DownloadDataAsync()
    {
        try
        {
            Console.WriteLine("Download started...");
            // throw new InvalidOperationException("Simulated download error.");
            await Task.Delay(3000);
            Console.WriteLine("Download completed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
    public async Task DownloadDataAsync2()
    {
        Console.WriteLine("Download 2 started...");
        await Task.Delay(2000);
        Console.WriteLine("Download 2 completed.");
    }
}