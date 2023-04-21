using System;

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
            int magicNumber = random.Next(1, 101);
            int guess;
            int numGuesses = 0;
            string playAgain;

            do
            {
                Console.WriteLine("Guess the magic number between 1 and 100.");
                Console.Write("Enter your guess: ");
                guess = int.Parse(Console.ReadLine());
                numGuesses++;

                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                    Console.WriteLine("It took you " + numGuesses + " guesses.");
                    Console.WriteLine();
                    Console.Write("Do you want to play again? (yes or no): ");
                    playAgain = Console.ReadLine().ToLower();
                    if (playAgain != "yes")
                    {
                        break;
                    }
                    else
                    {
                        magicNumber = random.Next(1, 101);
                        numGuesses = 0;
                        Console.WriteLine();
                    }
                }

            } while (true);
    }
}