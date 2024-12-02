// using System;

// namespace CSwithCopilot
// {
//     class Program
//     {
//         static void Main(string[] args)
//         {
//             int age = 0;
//             bool isValid = false;

//             while (!isValid)
//             {
//                 Console.Write("Please enter your age: ");
//                 string input = Console.ReadLine();

//                 if (int.TryParse(input, out age) && age >= 1 && age <= 120)
//                 {
//                     isValid = true;
//                 }
//                 else
//                 {
//                     Console.WriteLine("Invalid input. Please enter a number between 1 and 120.");
//                 }
//             }

//             Console.WriteLine($"Your age is: {age}");
//         }
//     }
// }