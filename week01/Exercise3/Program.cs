using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int magic = randomGenerator.Next(1, 101); // random number between 1 and 100

        Console.WriteLine("I'm thinking of a number between 1 and 100. Can you guess it?");
        Console.Write("What is your guess? ");
        int guess = int.Parse(Console.ReadLine());

        while (guess != magic)
        {
            if (guess < magic)
                Console.WriteLine("Higher");
            else
                Console.WriteLine("Lower");

            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());
        }

        Console.WriteLine("You guessed it!");
    }
}
