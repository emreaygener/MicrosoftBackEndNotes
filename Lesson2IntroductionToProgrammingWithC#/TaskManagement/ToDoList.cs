public class ToDoList
{
    public static string[] tasks = new string[10];
    public static int taskCount = 0;
    public static void AddTask()
    {
        Console.WriteLine("Enter a new task:");
        string? task = Console.ReadLine();
        if (taskCount == tasks.Length)
        {
            Console.WriteLine("No more space in the list.");
            return;
        }
        if (task == "" || task == null)
        {
            Console.WriteLine("Task cannot be empty.");
            AddTask();
            return;
        }
        tasks[taskCount] = task;
        taskCount++;
    }
    public static void ViewTasks()
    {
        if (taskCount == 0)
        {
            Console.WriteLine("No tasks to display.");
            return;
        }
        Console.WriteLine("Your tasks: ");
        for (int i = 0; i < taskCount; i++)
        {
            Console.WriteLine($"{i + 1}. {tasks[i]}");
        }
    }
    public static void CompleteTask()
    {
        Console.WriteLine("Enter the number of the task you want to complete:");
        int taskNumber = Convert.ToInt32(Console.ReadLine());
        if (taskNumber < 1 || taskNumber > taskCount)
        {
            Console.WriteLine("Invalid task number.");
            CompleteTask();
            return;
        }
        for (int i = taskNumber - 1; i < taskCount - 1; i++)
        {
            tasks[i] = tasks[i + 1];
        }
        taskCount--;
    }
}