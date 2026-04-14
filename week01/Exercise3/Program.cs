using System;

static class Program
{

    static void Main(string[] args)
    {
        string playAgain = "Yes";

        while (playAgain.Equals("yes", StringComparison.OrdinalIgnoreCase))
        {

         // in this part 1 and 2 the user has to specified the number...
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

            // give hints to the user if the guess is too high or too low
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
        // count the number of guesses and display it to the user
         Console.WriteLine($"It took you {guessCount} guesses.");

        // Ask the user if they want to play again
         Console.Write("Do you want to play again? (Yes/No): ");
         playAgain = Console.ReadLine();
     
        }
    Console.WriteLine("Thank you for playing! Goodbye!");
}

}