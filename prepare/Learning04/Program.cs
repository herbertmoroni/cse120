using System;

namespace Learning04
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Tessting base
            Assignment assignment = new Assignment("Samuel Bennett", "Multiplication");
            Console.WriteLine(assignment);

            // Testing MathAssignment
            MathAssignment mathAssignment = new MathAssignment("Samuel Bennett", "Multiplication", "7.3", "3-10, 20-21");
            Console.WriteLine(mathAssignment.GetSummary());
            mathAssignment.GetHomeworkList();
            Console.WriteLine();

            // Testing WritingAssignment
            WritingAssignment writingAssignment = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II");
            Console.WriteLine(writingAssignment.GetSummary());
            writingAssignment.GetWritingInformation();
        }
    }

}
