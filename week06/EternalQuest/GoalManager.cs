
using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        int choice = 0;

        while (choice != 6)
        {
            Console.WriteLine();
            DisplayPlayerInfo();

            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");

            choice = ReadNumber("Select a choice from the menu: ");

            if (choice == 1)
            {
                CreateGoal();
            }
            else if (choice == 2)
            {
                ListGoalDetails();
            }
            else if (choice == 3)
            {
                SaveGoals();
            }
            else if (choice == 4)
            {
                LoadGoals();
            }
            else if (choice == 5)
            {
                RecordEvent();
            }
            else if (choice == 6)
            {
                Console.WriteLine("Thanks for playing!");
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }
        }
    }

    private int ReadNumber(string message)
    {
        int number;

        while (true)
        {
            Console.Write(message);

            if (int.TryParse(Console.ReadLine(), out number))
            {
                return number;
            }

            Console.WriteLine("Please enter a valid number.");
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {_score} points.");
        Console.WriteLine($"Current Level: {GetLevel()}");
    }

    // Extra feature: Players level up as they earn points.
    private string GetLevel()
    {
        if (_score >= 2000)
        {
            return "Goal Master";
        }
        else if (_score >= 1000)
        {
            return "Achiever";
        }
        else if (_score >= 500)
        {
            return "Apprentice";
        }
        else
        {
            return "Beginner";
        }
    }

    public void ListGoalNames()
    {
        Console.WriteLine("\nYour goals:");

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine(
                $"{i + 1}. {_goals[i].GetShortName()}");
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("\nThe goals are:");

        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals have been created.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            string checkbox = _goals[i].IsComplete() ? "[X]" : "[ ]";

            Console.WriteLine(
                $"{i + 1}. {checkbox} {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("\nTypes of Goals:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");

        int type = ReadNumber("Which type of goal? ");

        if (type < 1 || type > 3)
        {
            Console.WriteLine("Invalid goal type.");
            return;
        }

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description? ");
        string description = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(name) ||
            string.IsNullOrWhiteSpace(description) ||
            name.Contains('|') || description.Contains('|') ||
            name.Contains('\n') || description.Contains('\n'))
        {
            Console.WriteLine("Enter a name and description without | characters.");
            return;
        }

        int points = ReadNumber("How many points is this goal worth? ");

        if (points <= 0)
        {
            Console.WriteLine("Points must be greater than zero.");
            return;
        }

        if (type == 1)
        {
            SimpleGoal goal = new SimpleGoal(name, description, points);
            _goals.Add(goal);
        }
        else if (type == 2)
        {
            EternalGoal goal = new EternalGoal(name, description, points);
            _goals.Add(goal);
        }
        else if (type == 3)
        {
            int target = ReadNumber(
                "How many times does this goal need to be accomplished? ");

            int bonus = ReadNumber(
                "What is the bonus for completing the goal? ");

            if (target <= 0 || bonus < 0)
            {
                Console.WriteLine("Target must be positive and bonus cannot be negative.");
                return;
            }

            ChecklistGoal goal = new ChecklistGoal(
                name, description, points, target, bonus);

            _goals.Add(goal);
        }

        Console.WriteLine("Goal created successfully!");
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals available.");
            return;
        }

        ListGoalNames();

        int choice = ReadNumber(
            "Which goal did you accomplish? ");

        if (choice < 1 || choice > _goals.Count)
        {
            Console.WriteLine("Invalid goal selection.");
            return;
        }

        Goal goal = _goals[choice - 1];

        if (goal.IsComplete())
        {
            Console.WriteLine("This goal is already complete.");
            return;
        }

        string previousLevel = GetLevel();

        // Record the accomplishment using polymorphism.
        goal.RecordEvent();

        int earnedPoints = goal.GetPoints();

        // Award the checklist bonus when the goal is finished.
        if (goal is ChecklistGoal checklistGoal &&
            goal.IsComplete())
        {
            earnedPoints += checklistGoal.GetBonus();
        }

        _score += earnedPoints;

        Console.WriteLine(
            $"Congratulations! You earned {earnedPoints} points!");
        Console.WriteLine($"You now have {_score} points.");

        if (previousLevel != GetLevel())
        {
            Console.WriteLine(
                $"LEVEL UP! You are now a {GetLevel()}!");
        }
    }

    public void SaveGoals()
    {
        Console.Write("What filename would you like to save to? ");
        string filename = Console.ReadLine();

        try
        {
            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                outputFile.WriteLine(_score);

                foreach (Goal goal in _goals)
                {
                    outputFile.WriteLine(
                        goal.GetStringRepresentation());
                }
            }

            Console.WriteLine("Goals saved successfully!");
        }
        catch (Exception error)
        {
            Console.WriteLine($"Error saving goals: {error.Message}");
        }
    }

    public void LoadGoals()
    {
        Console.Write("What filename would you like to load? ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        try
        {
            string[] lines = File.ReadAllLines(filename);

            int loadedScore = int.Parse(lines[0]);
            List<Goal> loadedGoals = new List<Goal>();

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split('|');

                string type = parts[0];
                string name = parts[1];
                string description = parts[2];
                int points = int.Parse(parts[3]);

                if (type == "SimpleGoal")
                {
                    if (parts.Length != 5)
                    {
                        throw new FormatException("Invalid SimpleGoal data.");
                    }

                    bool isComplete = bool.Parse(parts[4]);

                    SimpleGoal goal = new SimpleGoal(
                        name, description, points, isComplete);

                    loadedGoals.Add(goal);
                }
                else if (type == "EternalGoal")
                {
                    if (parts.Length != 4)
                    {
                        throw new FormatException("Invalid EternalGoal data.");
                    }

                    EternalGoal goal = new EternalGoal(
                        name, description, points);

                    loadedGoals.Add(goal);
                }
                else if (type == "ChecklistGoal")
                {
                    if (parts.Length != 7)
                    {
                        throw new FormatException("Invalid ChecklistGoal data.");
                    }

                    int target = int.Parse(parts[4]);
                    int bonus = int.Parse(parts[5]);
                    int completed = int.Parse(parts[6]);

                    if (target <= 0 || bonus < 0 ||
                        completed < 0 || completed > target)
                    {
                        throw new FormatException("Invalid checklist progress.");
                    }

                    ChecklistGoal goal = new ChecklistGoal(
                        name, description, points,
                        target, bonus, completed);

                    loadedGoals.Add(goal);
                }
                else
                {
                    throw new FormatException("Unknown goal type.");
                }
            }

            // Replace existing goals only after loading succeeds.
            _score = loadedScore;
            _goals = loadedGoals;

            Console.WriteLine("Goals loaded successfully!");
        }
        catch (Exception error)
        {
            Console.WriteLine($"Error loading goals: {error.Message}");
        }
    }
}
