using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int input;

        do
        {
            Console.Write("Enter a list of numbers, type 0 when finished: ");
            input = int.Parse(Console.ReadLine());
            
            if (input != 0)
            {
                numbers.Add(input);
            }

        } while (input != 0);

        int sum = numbers.Sum();
        double average = numbers.Average();
        int max = numbers.Max();

        Console.WriteLine("The sum is: " + sum);
        Console.WriteLine("The average is: " + average);
        Console.WriteLine("The largest number is: " + max);

        List<int> positives = numbers.Where(n => n > 0).ToList();
        int minPositive = positives.Min();

        Console.WriteLine("The smallest positive number is: " + minPositive);

        List<int> sorted = numbers.OrderBy(n => n).ToList();

        Console.WriteLine("The sorted list is:");
        
        foreach (int num in sorted)
        {
            Console.WriteLine(num);
        }
    }
}