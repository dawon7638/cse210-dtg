using System;

class Program
{
    static void Main(string[] args)
    {
        // C# Programming Exercise 2: If Statements

        // Ask the user for their grade percentage
        Console.Write("What is your grade percentage? ");

        // Read the input as a string and convert it to an integer
        string gradeInput = Console.ReadLine();
        int gradeNumber = int.Parse(gradeInput);

        // Determine the letter grade and sign based on the grade percentage
        string letter;
        string sign;

        // Determine the letter grade
        if (gradeNumber >= 90)
        {
            letter = "A";
        }
        else if (gradeNumber >= 80)
        {
            letter = "B";
        }
        else if (gradeNumber >= 70)
        {
            letter = "C";
        }
        else if (gradeNumber >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Determine the sign based on the last digit of the grade percentage
        if (letter == "A" || letter == "F")
        {
            sign = "";
        }
        else if (gradeNumber % 10 >= 7)
        {
            sign = "+";
        }
        else if (gradeNumber % 10 < 3)
        {
            sign = "-";
        }
        else
        {
            sign = "";
        }
        Console.WriteLine($"Your grade is {letter}{sign}.");

        // Determine if the user passed or failed the class
        if (gradeNumber >= 70)
        {
            Console.Write("Congratulations! You passed the class.");
        }
        else
        {
            Console.Write("Sorry, you did not pass the class. Better luck next time!");
        }

    }
}