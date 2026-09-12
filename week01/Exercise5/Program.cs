using System;

class Program
{
    static void Main(string[] args)
    {
        // Display the welcome message.
        DisplayWelcome();

        // Ask the user for their name and save the returned value.
        string name = PromptUserName();

        // Ask the user for their favorite number and save the returned value.
        int number = PromptUserNumber();

        // Square the user's number and save the returned value.
        int squaredNumber = SquareNumber(number);

        // Display the user's name and squared number.
        DisplayResult(name, squaredNumber);
    }

    // Displays the welcome message.
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    // Asks the user for their name and returns it as a string.
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();

        return name;
    }

    // Asks the user for their favorite number and returns it as an integer.
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int number = int.Parse(Console.ReadLine());

        return number;
    }

    // Accepts a number as a parameter and returns the number squared.
    static int SquareNumber(int number)
    {
        int squared = number * number;

        return squared;
    }

    // Accepts the user's name and squared number and displays the result.
    static void DisplayResult(string name, int squaredNumber)
    {
        Console.WriteLine($"{name}, the square of your number is {squaredNumber}");
    }
}