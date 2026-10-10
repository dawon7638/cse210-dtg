
using System;
using System.Collections.Generic;

public class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    private Random _random = new Random();

    public ReflectingActivity() : base(
        "Reflecting Activity",
        "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
    }

    public string GetRandomPrompt()
    {
        int index = _random.Next(_prompts.Count);
        return _prompts[index];
    }

    public string GetRandomQuestion()
    {
        int index = _random.Next(_questions.Count);
        return _questions[index];
    }

    public void DisplayPrompt()
    {
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();
        Console.WriteLine($" --- {GetRandomPrompt()} --- ");
        Console.WriteLine();
        Console.Write("When you have something in mind, press enter to continue.");
        Console.ReadLine();
    }

    public void DisplayQuestions()
    {
        // Extra feature: Questions do not repeat until all have been used.
        List<string> availableQuestions = new List<string>(_questions);

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            if (availableQuestions.Count == 0)
            {
                availableQuestions = new List<string>(_questions);
            }

            int index = _random.Next(availableQuestions.Count);
            string question = availableQuestions[index];

            availableQuestions.RemoveAt(index);

            Console.WriteLine($"> {question}");

            int remaining = (int)Math.Ceiling((endTime - DateTime.Now).TotalSeconds);

            ShowSpinner(Math.Min(5, remaining));
            Console.WriteLine();
        }
    }

    public void Run()
    {
        DisplayStartingMessage();
        DisplayPrompt();

        Console.WriteLine();
        Console.WriteLine("Now ponder on each of the following questions.");
        Console.Write("You may begin in: ");
        ShowCountDown(5);

        Console.Clear();

        DisplayQuestions();

        DisplayEndingMessage();
    }
}
