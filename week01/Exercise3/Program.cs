using System;
using System.Numerics;

class Program
{
    static void Main(string[] args)
    {
        // C# Programming Exercise 3: Loops

        // Create a random number generator
        Random randomGenerator = new Random();
        // Variable to store the user's response to play again
        string playAgain;
        // Loop to allow the user to play multiple times
        do
        {

            // Generate a random number between 1 and 100, intialize guess and guessCount
            int magicNumber = randomGenerator.Next(1, 101);
            int guess;
            int guessCount = 0;
            // Loop to allow the user to guess until they get it right
            do
            {
                // Ask the user for their guess and increment the guess count
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                guessCount++;
                // Check if the guess is too high, too low, or correct and give feedback
                if (magicNumber < guess)
                {
                    Console.WriteLine("Lower");

                }
                else if (magicNumber > guess)
                {
                    Console.WriteLine("Higher");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                    Console.WriteLine($"It took you {guessCount} guesses.");
                }
                // End of inner loop
            } while (guess != magicNumber);
            // Ask the user if they want to play again
            Console.Write("Would you like to play again? (yes/no):");
            playAgain = Console.ReadLine().ToLower();
            // End of outer loop
        } while (playAgain == "yes");


    }
}