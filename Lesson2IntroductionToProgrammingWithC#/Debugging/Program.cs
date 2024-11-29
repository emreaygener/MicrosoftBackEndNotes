// Method to divide two numbers with error handling
using System;
public class Program
{
    public static double DivideNumbers(double numerator, double denominator)
    {
        if (denominator == 0)
        {
            Console.WriteLine("Error: Division by zero is not allowed.");
            return double.NaN; // Return "Not a Number" to indicate an error
        }

        double result = numerator / denominator;
        return result;
    }

    public static double CalculateAverage(int[] numbers)
    {
        if (numbers.Length == 0)
        {
            Console.WriteLine("Error: Cannot calculate the average of an empty array.");
            return double.NaN; // Return "Not a Number" to indicate an error
        }

        int sum = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            sum += numbers[i];
        }
        return (double)sum / numbers.Length;
    }

    // Method to calculate the final price after a discount
    public static double ApplyDiscount(double price, double discountPercentage)
    {
        return price - (discountPercentage * price / 100);
    }

    public static int FindMax(int[] numbers)
    {
        int max = int.MinValue;
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] > max)
            {
                max = numbers[i];
            }
        }
        return max;
    }

    public static void Main()
    {
        Console.WriteLine("--------------------");
        // Attempt to divide 10 by 0
        double result = DivideNumbers(10, 0);
        Console.WriteLine("The result is: " + result);
        Console.WriteLine("--------------------");
        int[] numbers = { }; // Empty array
        double average = CalculateAverage(numbers);
        Console.WriteLine("The average is: " + average);
        Console.WriteLine("--------------------");
        double finalPrice = ApplyDiscount(1000, 15);
        Console.WriteLine("The final price is: " + finalPrice);
        Console.WriteLine("--------------------");
        int[] myNumbers = { -5, -10, -3, -8, -2 };
        int maxNumber = FindMax(myNumbers);
        Console.WriteLine("The maximum number is: " + maxNumber);
        Console.WriteLine("--------------------");
    }
}