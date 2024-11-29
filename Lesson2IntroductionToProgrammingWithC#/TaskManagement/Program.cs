bool running = true;
while (running)
{
    Console.WriteLine("                    ");
    Console.WriteLine("     ----------------     ");
    Console.WriteLine("                    ");
    Console.WriteLine("What would you like to do?");
    Console.WriteLine("1. Add a task");
    Console.WriteLine("2. View tasks");
    Console.WriteLine("3. Complete a task");
    Console.WriteLine("4. Exit");
    string choice = Console.ReadLine();
    switch (choice)
    {
        case "1":
            ToDoList.AddTask();
            break;
        case "2":
            ToDoList.ViewTasks();
            break;
        case "3":
            ToDoList.CompleteTask();
            break;
        case "4":
            running = false;
            break;
        default:
            Console.WriteLine("Invalid choice. Please try again.");
            break;
    }
}