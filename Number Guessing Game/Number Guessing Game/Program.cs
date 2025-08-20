using System;
using System.Collections.Generic;

namespace Number_Guessing_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random randomizer = new Random();
            int random_number = randomizer.Next(0, 5000);

            Console.WriteLine("Hello! Welcome to the number guessing game. Your task is to find a number between 0 and 5000.\nHave Fun :)\n");
            List<int> attempts = new List<int>();

            for (; ; )
            {
                Console.WriteLine("Enter a number:");
                int input_number;
                if (!int.TryParse(Console.ReadLine(), out input_number))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nYou entered a text value. Please try with an integer.");
                    Console.ResetColor();
                    continue;
                }
                attempts.Add(input_number);

                if (input_number > random_number)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nThe target number is smaller. Try another value.");
                }

                else if (input_number < random_number)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nThe target number is larger. Try another value.");
                }

                if (input_number == random_number)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\nCongratulations!!!\n{random_number} is the correct value.\nYou guessed it after {attempts.Count} tries, that’s an amazing result!\n");
                    Console.ResetColor();
                    Console.WriteLine($"Here are all your attempts:");
                    attempts.ForEach(attempt => Console.WriteLine(attempt));
                    break;
                }

                Console.ResetColor();

            }
        }
    }
}
