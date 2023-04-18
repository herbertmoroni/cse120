using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is your grade percentage?");
        int grade = int.Parse(Console.ReadLine());

        string letter;
        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
            letter = "B";
        }
        else if (grade >= 70)
        {
            letter = "C";
        }
        else if (grade >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        if (grade >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course with a grade of " + letter + ".");
        }
        else
        {
            Console.WriteLine("You did not pass the course. Don't give up! Try again next time.");
        }

        string sign = "";
        if (letter == "A" && grade % 10 >= 7)
        {
            sign = "+";
        }
        else if ((letter == "B" || letter == "C" || letter == "D") && grade % 10 >= 3 && grade % 10 <= 6)
        {
            sign = "";
        }
        else if ((letter == "B" || letter == "C" || letter == "D") && grade % 10 < 3)
        {
            sign = "-";
        }

        if (letter == "A" && grade >= 97)
        {
            Console.WriteLine("Congratulations! You received an A+!");
        }
        else if (letter == "F" && grade % 10 != 0)
        {
            Console.WriteLine("Sorry, there is no such thing as an F+ or F-. You received an F.");
        }
        else
        {
            Console.WriteLine("Your letter grade is " + letter + sign + ".");
        }

        Console.ReadLine();
    }
}