class UserInput
{
    static string GreetUser()
    {
        Console.WriteLine("Welcome to the calculator!");
        Console.WriteLine("Please enter your name!");
        string name = Console.ReadLine();
        Console.WriteLine($"Hello, {name}!");
        return name;
    }
    static void Main()
    {
        GreetUser();
    }
}