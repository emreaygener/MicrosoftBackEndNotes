using System.Reflection;

namespace CSharpBasics
{
    // Interface for discountable products
    public interface IDiscountable
    {
        decimal ApplyDiscount(decimal percentage);
    }

    // Base Product class with fields, properties, and static methods
    class Product
    {
        // Private field
        private decimal _price;

        // Public property
        public string Name { get; set; }

        // Public property with additional logic in setter
        public decimal Price
        {
            get { return _price; }
            set
            {
                if (value >= 0) _price = value;
            }
        }

        // Constructor
        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        // Virtual method
        public virtual void DisplayProductDetails()
        {
            Console.WriteLine($"\nProduct: {Name}, Price: {Price:C}");
        }

        // Static method to calculate discount
        public static decimal CalculateDiscount(decimal price, decimal discountPercentage)
        {
            return price - (price * discountPercentage / 100);
        }
    }

    // Subclass: Clothing (Discountable)
    class Clothing : Product, IDiscountable
    {
        // Property to store the size as an integer
        public int Size { get; set; }

        // Constructor
        public Clothing(string name, decimal price, int size) : base(name, price)
        {
            Size = size;
        }

        // Method to convert size from int to a size name
        public string GetSizeName()
        {
            return Size switch
            {
                1 => "SM",
                2 => "MD",
                3 => "LG",
                _ => "Unknown Size"
            };
        }

        // Override method to include size details
        public override void DisplayProductDetails()
        {
            base.DisplayProductDetails();
            Console.WriteLine($"Size: {GetSizeName()}\n");
        }

        // Implementations of IDiscountable interface
        public decimal ApplyDiscount(decimal percentage)
        {
            return CalculateDiscount(Price, percentage);
        }
    }

    class Program
    {
        static void Main()
        {
            List<Clothing> catalog = new List<Clothing>();
            // Creating a Clothing object and demonstrating, properties, methods, and polymorphism
            catalog.Add(new Clothing("Super Cool T-Shirt", 49.99m, 2));
            catalog.Add(new Clothing("Short Pants", 79.99m, 1));
            catalog.Add(new Clothing("Short Pants", 82.99m, 2));

            // Displaying product details
            // for (int i = 0; i < catalog.Count; i++)
            // {
            //     catalog[i].DisplayProductDetails();
            // }

            foreach (Clothing item in catalog)
            {
                item.DisplayProductDetails();
            }

            // Applying discount to the Clothing product
            decimal discountedPrice = catalog[0].ApplyDiscount(10);
            Console.WriteLine($"\nT-shirt price after discount: {discountedPrice:C}");
            Console.WriteLine(Product.CalculateDiscount(29.50m, 0.1m));
        }
    }
}