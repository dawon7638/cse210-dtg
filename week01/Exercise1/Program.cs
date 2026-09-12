using System;

class Program
{
    static void Main(string[] args)
    {
        // C# Programming Exercise 1: Input and Output
        // Ask the user for their first name
        Console.Write("What is your first name? ");
        string firstName = Console.ReadLine();

        // Ask the user for their last name
        Console.Write("What is your last name? ");
        string lastName = Console.ReadLine();

        // Display the user's full name in the format "Your name is [last name], [first name]."
        Console.WriteLine($"Your name is  {lastName}, {firstName}.");
    }
}