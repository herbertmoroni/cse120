public class Program
{
    public static void Main(string[] args)
    {
        User user;
        const string filename = "userdata.json";
        if (File.Exists(filename))
        {
            user = User.Load(filename);
            Console.WriteLine($"Welcome back, {user.Name}! Here's a quick summary:");
            Console.WriteLine($"Current Score: {user.TotalScore}");
            Console.WriteLine($"Number of Goals: {user.Goals.Count}");
            Console.WriteLine("User data loaded from file.");
        }
        else
        {
            Console.WriteLine("Welcome to Eternal Quest!");
            Console.WriteLine("Please enter your name:");
            string name = Console.ReadLine();
            user = new User(name);
            Console.WriteLine($"Hello, {user.Name}! Let's start setting some goals.");
        }

        bool runProgram = true;
        while (runProgram)
        {
            Console.WriteLine("1. Add Goal");
            Console.WriteLine("2. Complete Goal");
            Console.WriteLine("3. View Goals");
            Console.WriteLine("4. View Score");
            Console.WriteLine("5. Save and Exit");

            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    Console.WriteLine("Select Goal Type: 1. Simple Goal, 2. Eternal Goal, 3. Checklist Goal");
                    int goalType = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter Goal Name:");
                    string goalName = Console.ReadLine();
                    Console.WriteLine("Enter Goal Description:");
                    string goalDescription = Console.ReadLine();
                    Console.WriteLine("Enter Goal Value:");
                    int goalValue = Convert.ToInt32(Console.ReadLine());
                    if (goalType == 3)
                    {
                        Console.WriteLine("Enter Goal Count:");
                        int goalCount = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Goal Bonus:");
                        int goalBonus = Convert.ToInt32(Console.ReadLine());
                        user.AddGoal(new ChecklistGoal(goalName, goalDescription, goalValue, goalCount, goalBonus));
                    }
                    else if (goalType == 2)
                    {
                        user.AddGoal(new EternalGoal(goalName, goalDescription, goalValue));
                    }
                    else
                    {
                        user.AddGoal(new SimpleGoal(goalName, goalDescription, goalValue));
                    }
                    Console.WriteLine("\nGoal Added Successfully.\n");
                    break;
                case 2:
                    Console.WriteLine("Select a goal to complete from the list below by typing its number:\n");
                    for (int i = 0; i < user.Goals.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {user.Goals[i]}");
                    }
                    Console.WriteLine();

                    int goalIndexToComplete = Convert.ToInt32(Console.ReadLine()) - 1; // subtract 1 because list is zero-indexed
                    if (goalIndexToComplete >= 0 && goalIndexToComplete < user.Goals.Count)
                    {
                        int pointsEarned = user.CompleteGoal(goalIndexToComplete);
                        Console.WriteLine($"You've completed the goal '{user.Goals[goalIndexToComplete].Name}' and earned {pointsEarned} points! Congratulations!\n");
                    }
                    else
                    {
                        Console.WriteLine("Invalid selection. Please make sure to enter a valid number from the list.\n");
                    }
                    break;
                case 3:
                    for (int i = 0; i < user.Goals.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {user.Goals[i]}");
                    }
                    break;
                case 4:
                    Console.WriteLine($"\nTotal Score: {user.TotalScore}\n");
                    break;
                case 5:
                    user.Save(filename);
                    Console.WriteLine("\nUser data saved to file.\n");
                    runProgram = false;
                    break;
            }
        }
    }
}
