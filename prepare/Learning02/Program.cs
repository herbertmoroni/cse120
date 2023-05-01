using System;

class Program
{
    static void Main(string[] args)
    {
        var job1 = new Job
        {
            Company = "Microsoft",
            Title = "Software Engineer",
            StartYear = 2019,
            EndYear = 2022
        };
        var job2 = new Job
        {
            Company = "Google",
            Title = "Product Manager",
            StartYear = 2015,
            EndYear = 2019
        };

        var resume = new Resume
        {
            Name = "John Doe",
            Jobs = new List<Job> { job1, job2 }
        };

        Console.WriteLine(resume.Display());
    }
}