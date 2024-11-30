public class Database
{
    private static Database instance;
    private static readonly object lockObject = new object();
    private Database() { }
    // public static Database Instance
    // {
    //     get
    //     {
    //         if (instance == null)
    //         {
    //             lock (lockObject)
    //             {
    //                 if (instance == null)
    //                 {
    //                     instance = new Database();
    //                 }
    //             }
    //         }
    //         return instance;
    //     }
    // }
    public static Database GetInstance()
    {
        if (instance == null)
        {
            lock (lockObject)
            {
                if (instance == null)
                {
                    instance = new Database();
                }
            }
        }
        return instance;
    }
    public void Connect()
    {
        Console.WriteLine("Connected to database");
    }
}