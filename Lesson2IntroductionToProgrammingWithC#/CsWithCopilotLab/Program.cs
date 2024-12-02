using System;

class Program
{
    static void Main(string[] args)
    {
        string[] books = new string[5];
        while (true)
        {
            Console.WriteLine("Library Management System");
            Console.WriteLine("1. Add a Book");
            Console.WriteLine("2. Remove a Book");
            Console.WriteLine("3. Display Books");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddBook(books);
                    break;
                case "2":
                    RemoveBook(books);
                    break;
                case "3":
                    DisplayBooks(books);
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static void AddBook(string[] books)
    {
        Console.Write("Enter the title of the book to add: ");
        string newBook = Console.ReadLine();
        for (int i = 0; i < books.Length; i++)
        {
            if (string.IsNullOrEmpty(books[i]))
            {
                books[i] = newBook;
                Console.WriteLine("Book added successfully.");
                return;
            }
        }
        Console.WriteLine("No more space to add new books.");
    }

    static void RemoveBook(string[] books)
    {
        Console.Write("Enter the title of the book to remove: ");
        string bookToRemove = Console.ReadLine();
        for (int i = 0; i < books.Length; i++)
        {
            if (books[i] == bookToRemove)
            {
                books[i] = null;
                Console.WriteLine("Book removed successfully.");
                return;
            }
        }
        Console.WriteLine("Book not found.");
    }

    static void DisplayBooks(string[] books)
    {
        Console.WriteLine("Books in the library:");
        foreach (var book in books)
        {
            if (!string.IsNullOrEmpty(book))
            {
                Console.WriteLine(book);
            }
        }
    }
}