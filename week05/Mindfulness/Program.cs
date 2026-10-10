
using System;

class Program
{
    static void Main(string[] args)
    {
        // Exceeding Requirements:
        // 1. Added a counter to track how many activities the user
        //    completes during the current session.
        // 2. The reflecting activity avoids repeating questions
        //    until all available questions have been used.
        // 3. Added input validation so users must enter a positive
        //    number for the activity duration.

        int completedActivities = 0;
        bool running = true;

        while (running)
        {
            Console.Clear();

            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.WriteLine();
            Console.WriteLine($"Activities completed this session: {completedActivities}");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    BreathingActivity breathing = new BreathingActivity();
                    breathing.Run();
                    completedActivities++;
                    break;

                case "2":
                    ReflectingActivity reflecting = new ReflectingActivity();
                    reflecting.Run();
                    completedActivities++;
                    break;

                case "3":
                    ListingActivity listing = new ListingActivity();
                    listing.Run();
                    completedActivities++;
                    break;

                case "4":
                    running = false;
                    Console.WriteLine("Thank you for using the Mindfulness Program!");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please select 1-4.");
                    break;
            }

            if (running)
            {
                Console.WriteLine();
                Console.WriteLine("Press Enter to return to the menu...");
                Console.ReadLine();
            }
        }
    }
}
