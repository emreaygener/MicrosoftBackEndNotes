using System;
using System.Collections.Generic;

class LibraryManager
{
    static void Main()
    {
        List<string> books = new List<string>();
        Dictionary<string, bool> borrowedBooks = new Dictionary<string, bool>();
        int borrowedCount = 0;
        const int maxBorrowedBooks = 3;

        while (true)
        {
            Console.WriteLine("Would you like to add, remove, search, borrow, return a book, or exit? (add/remove/search/borrow/return/exit)");
            string action = Console.ReadLine().ToLower();
            if (action == "add")
            {
                AddBook(books, borrowedBooks);
            }
            else if (action == "remove")
            {
                RemoveBook(books, borrowedBooks);
            }
            else if (action == "search")
            {
                SearchBook(books);
            }
            else if (action == "borrow")
            {
                BorrowBook(books, borrowedBooks, ref borrowedCount, maxBorrowedBooks);
            }
            else if (action == "return")
            {
                ReturnBook(borrowedBooks, ref borrowedCount);
            }
            else if (action == "exit")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid action. Please type 'add', 'remove', 'search', 'borrow', 'return', or 'exit'.");
            }
            DisplayBooks(books, borrowedBooks);
        }
    }

    static void AddBook(List<string> books, Dictionary<string, bool> borrowedBooks)
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
            borrowedBooks[newBook] = false;
        }
    }

    static void RemoveBook(List<string> books, Dictionary<string, bool> borrowedBooks)
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
                borrowedBooks.Remove(removeBook);
                Console.WriteLine("Book removed.");
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }
    }

    static void SearchBook(List<string> books)
    {
        Console.WriteLine("Enter the title of the book to search:");
        string searchBook = Console.ReadLine();
        if (books.Contains(searchBook))
        {
            Console.WriteLine("The book is available.");
        }
        else
        {
            Console.WriteLine("The book is not in the collection.");
        }
    }

    static void BorrowBook(List<string> books, Dictionary<string, bool> borrowedBooks, ref int borrowedCount, int maxBorrowedBooks)
    {
        if (borrowedCount >= maxBorrowedBooks)
        {
            Console.WriteLine("You have reached the limit of borrowed books.");
        }
        else
        {
            Console.WriteLine("Enter the title of the book to borrow:");
            string borrowBook = Console.ReadLine();
            if (books.Contains(borrowBook) && !borrowedBooks[borrowBook])
            {
                borrowedBooks[borrowBook] = true;
                borrowedCount++;
                Console.WriteLine("Book borrowed.");
            }
            else if (!books.Contains(borrowBook))
            {
                Console.WriteLine("The book is not in the collection.");
            }
            else
            {
                Console.WriteLine("The book is already borrowed.");
            }
        }
    }

    static void ReturnBook(Dictionary<string, bool> borrowedBooks, ref int borrowedCount)
    {
        Console.WriteLine("Enter the title of the book to return:");
        string returnBook = Console.ReadLine();
        if (borrowedBooks.ContainsKey(returnBook) && borrowedBooks[returnBook])
        {
            borrowedBooks[returnBook] = false;
            borrowedCount--;
            Console.WriteLine("Book returned.");
        }
        else if (!borrowedBooks.ContainsKey(returnBook))
        {
            Console.WriteLine("The book is not in the collection.");
        }
        else
        {
            Console.WriteLine("The book was not borrowed.");
        }
    }

    static void DisplayBooks(List<string> books, Dictionary<string, bool> borrowedBooks)
    {
        Console.WriteLine("Available books:");
        foreach (string book in books)
        {
            string status = borrowedBooks[book] ? " (borrowed)" : "";
            Console.WriteLine(book + status);
        }
    }
}
