using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        int number;

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        // Get numbers from the user
        do
        {
            Console.Write("Enter number: ");
            number = int.Parse(Console.ReadLine());

            if (number != 0)
            {
                numbers.Add(number);
            }

        } while (number != 0);

        // Calculate the sum
        int sum = 0;

        foreach (int numberInList in numbers)
        {
            sum += numberInList;
        }

        // Calculate the average
        double average = (double)sum / numbers.Count;

        // Find the largest number
        int largest = numbers[0];

        foreach (int numberInList in numbers)
        {
            if (numberInList > largest)
            {
                largest = numberInList;
            }
        }

        // Find the smallest positive number
        int smallestPositive = int.MaxValue;

        foreach (int numberInList in numbers)
        {
            if (numberInList > 0 && numberInList < smallestPositive)
            {
                smallestPositive = numberInList;
            }
        }

        // Sort the list
        numbers.Sort();

        // Display results
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {largest}");
        Console.WriteLine($"The smallest positive number is: {smallestPositive}");

        Console.WriteLine("The sorted list is:");

        foreach (int numberInList in numbers)
        {
            Console.WriteLine(numberInList);
        }
    }
}