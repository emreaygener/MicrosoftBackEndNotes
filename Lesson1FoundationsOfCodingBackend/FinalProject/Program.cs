using System;
using System.Collections.Generic;


class Program
{
    static List<Product> products = new List<Product>();

    static void Main()
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nInventory Management System\n");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Update Stock");
            Console.WriteLine("3. View Products");
            Console.WriteLine("4. Remove Product");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine() ?? string.Empty;

            switch (choice)
            {
                case "1":
                    AddProduct();
                    break;
                case "2":
                    UpdateStock();
                    break;
                case "3":
                    ViewProducts();
                    break;
                case "4":
                    RemoveProduct();
                    break;
                case "5":
                    running = false;
                    Console.WriteLine("Exiting the application.");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void AddProduct()
    {
        Console.Write("Enter product name: ");
        string name = Console.ReadLine() ?? string.Empty;
        Console.Write("Enter product price: ");
        decimal price = Convert.ToDecimal(Console.ReadLine());
        Console.Write("Enter stock quantity: ");
        int stock = Convert.ToInt32(Console.ReadLine());

        products.Add(new Product { Name = name, Price = price, Stock = stock });
        Console.WriteLine("Product added successfully!");
    }

    static void UpdateStock()
    {
        Console.Write("Enter product name: ");
        string name = Console.ReadLine() ?? string.Empty;

        Product? product = products.Find(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (product != null)
        {
            Console.Write("Enter stock change (positive for restock, negative for sale): ");
            if (int.TryParse(Console.ReadLine(), out int change) && product.Stock + change >= 0)
            {
                product.Stock += change;
                Console.WriteLine("\nStock updated successfully!");
            }
            else if (product.Stock + change < 0)
            {
                Console.WriteLine("\nInsufficient stock.");
            }
            else
            {
                Console.WriteLine("\nInvalid input. Please enter a valid integer.");
            }
        }
        else
        {
            Console.WriteLine("\nProduct not found!");
        }
    }

    static void ViewProducts()
    {
        Console.WriteLine("\nProduct List:");
        foreach (var product in products)
        {
            Console.WriteLine($"Name: {product.Name}, Price: {product.Price:C}, Stock: {product.Stock}" + (product.Stock > 0 ? "" : " (Out of Stock)"));
        }
    }

    static void RemoveProduct()
    {
        Console.Write("Enter product name to remove: ");
        string name = Console.ReadLine() ?? string.Empty;

        Product? product = products.Find(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (product != null)
        {
            products.Remove(product);
            Console.WriteLine("Product removed successfully!");
        }
        else
        {
            Console.WriteLine("Product not found!");
        }
    }
}

class Product
{
    public required string Name { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
}