using System;
using System.Collections.Generic;

class LibraryManager
{
    static void Main()
    {
        List<string> books = new List<string>();
        while (true)
        {
            Console.WriteLine("Would you like to add or remove a book? (add/remove/exit)");
            string action = Console.ReadLine().ToLower();
            if (action == "add")
            {
                AddBook(books);
            }
            else if (action == "remove")
            {
                RemoveBook(books);
            }
            else if (action == "exit")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid action. Please type 'add', 'remove', or 'exit'.");
            }
            DisplayBooks(books);
        }
    }

    static void AddBook(List<string> books)
    {
        if (books.Count >= 5)
        {
            Console.WriteLine("The library is full. No more books can be added.");
        }
        else
        {
            Console.WriteLine("Enter the title of the book to add:");
            string newBook = Console.ReadLine();
            books.Add(newBook);
        }
    }

    static void RemoveBook(List<string> books)
    {
        if (books.Count == 0)
        {
            Console.WriteLine("The library is empty. No books to remove.");
        }
        else
        {
            Console.WriteLine("Enter the title of the book to remove:");
            string removeBook = Console.ReadLine();
            if (books.Remove(removeBook))
            {
                Console.WriteLine("Book removed.");
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }
    }

    static void DisplayBooks(List<string> books)
    {
        Console.WriteLine("Available books:");
        foreach (string book in books)
        {
            Console.WriteLine(book);
        }
    }
}
