using System;

class Program
{
    private static readonly object randomGenerator;

    static void Main(string[] args)
    {
        string playAgain = "Yes";

        while (playAgain.ToLower() == "yes")
        {

         // in this part 1 and the user has to specified the number...
         //Console.WriteLine("Please enter a magic number: ");
                 // int magicNumber = int.Parse(Console.ReadLine());

        // in this part 3, the user has use the random number generator to generate a random number between 1 and 100
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 100);

        int guess = -1;
        int guessCount = 0;
        while (guess != magicNumber)
        {
            Console.WriteLine("What is your guess?: ");
            guess = int.Parse(Console.ReadLine());
            guessCount++;

            if ( magicNumber > guess)
            {
                Console.WriteLine("High");
            }
            else if (magicNumber < guess)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("Congratulations! You guessed the magic number.");
            }

        }
         Console.WriteLine($"It took you {guessCount} guesses.");

         Console.Write("Do you want to play again? (Yes/No): ");
         playAgain = Console.ReadLine();
     
        }
    Console.WriteLine("Thank you for playing! Goodbye!");
}

}