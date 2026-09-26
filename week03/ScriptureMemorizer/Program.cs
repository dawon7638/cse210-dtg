using System;

class Program
{
    static void Main(string[] args)
    {
        // Creativity and exceeding requirements:
        // I created a ScriptureLibrary class that contains multiple scriptures.
        // The program randomly selects a scripture when the program starts,
        // allowing the user to practice memorizing different passages.

        ScriptureLibrary library = new ScriptureLibrary();

        Scripture scripture = library.GetRandomScripture();

        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());

        while (!scripture.IsCompletelyHidden())
        {
            Console.WriteLine();
            Console.Write("Press Enter to hide words or type 'quit' to exit: ");

            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords(3);

            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
        }
    }
}