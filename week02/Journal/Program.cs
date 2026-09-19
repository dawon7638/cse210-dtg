using System;

class Program
{
    static void Main(string[] args)
    {
        // Creativity: I added a mood to each journal entry.
        // This allows the user to record how they were feeling
        // when they wrote their entry.

        Journal theJournal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        int choice = 0;

        while (choice != 5)
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            string choiceInput = Console.ReadLine();
            choice = int.Parse(choiceInput);

            Console.WriteLine();

            if (choice == 1)
            {
                string prompt = promptGenerator.GetRandomPrompt();

                Console.WriteLine($"Prompt: {prompt}");
                Console.Write("Response: ");
                string response = Console.ReadLine();

                Console.Write("How are you feeling today? ");
                string mood = Console.ReadLine();

                string date = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
                Entry newEntry = new Entry(date, prompt, response, mood);

                theJournal.AddEntry(newEntry);

                Console.WriteLine("Entry added.");
                Console.WriteLine();
            }
            else if (choice == 2)
            {
                theJournal.DisplayAll();
            }
            else if (choice == 3)
            {
                Console.Write("Enter the filename: ");
                string fileName = Console.ReadLine();

                theJournal.SaveToFile(fileName);
            }
            else if (choice == 4)
            {
                Console.Write("Enter the filename: ");
                string fileName = Console.ReadLine();

                theJournal.LoadFromFile(fileName);
            }
            else if (choice == 5)
            {
                Console.WriteLine("Goodbye!");
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
                Console.WriteLine();
            }
        }
    }
}