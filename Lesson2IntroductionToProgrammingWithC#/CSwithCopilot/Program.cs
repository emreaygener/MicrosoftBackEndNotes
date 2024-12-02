using System;

class Program
{
    static void Main()
    {
        int number = GetNumberFromUser();
        int sum = CalculateSum(number);
        DisplayResult(number, sum);
    }

    static int GetNumberFromUser()
    {
        Console.Write("Enter a number: ");
        return int.Parse(Console.ReadLine());
    }

    static int CalculateSum(int number)
    {
        int sum = 0;
        for (int i = 1; i <= number; i++)
        {
            sum += i;
        }
        return sum;
    }

    static void DisplayResult(int number, int sum)
    {
        Console.WriteLine($"The sum of numbers from 1 to {number} is: {sum}");
    }
}