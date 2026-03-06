using System;

class Program
{
    static void Main(string[] args)
    {
       {
        // Display a welcome message to the user
        DisplayWelcomeMessage();

        // Get the user's name
        string userName = PromptUserName();

        // Get the user's favorite number
        int userNumber = PromptUserNumber();

        // Compute the square of the number
        int squaredNumber = SquareNumber(userNumber);

        // Display the result
        DisplayResult(userName, squaredNumber);
    }

    /// <summary>
    static void DisplayWelcomeMessage()
    {
        Console.WriteLine("Welcome to the program!");
    }

    /// <summary>
    /// Prompts the user to enter their name and returns it.
    /// <returns>The name entered by the user.</returns>
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();

        return name;
    }

    /// <summary>
    /// Prompts the user for their favorite number, validates the input,
    /// and returns the number as an integer.
    /// </summary>
    /// <returns>A valid integer entered by the user.</returns>
    static int PromptUserNumber()
    {
        int number;
        bool isValid;

        // Loop until the user enters a valid integer
        do
        {
            Console.Write("Please enter your favorite number: ");
            string input = Console.ReadLine();

            // TryParse returns true if conversion succeeded
            isValid = int.TryParse(input, out number);

            if (!isValid)
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }

        } while (!isValid);

        return number;
    }

    /// <summary>
    /// Computes the square of a given integer.
    /// </summary>
    /// <param name="number">The number to square.</param>
    /// <returns>The square of the input number.</returns>
    static int SquareNumber(int number)
    {
        int square = number * number;
        return square;
    }

    /// <summary>
    /// Displays the result message with the user's name and the squared number.
    /// </summary>
    /// <param name="name">The user's name.</param>
    /// <param name="square">The squared number.</param>
    static void DisplayResult(string name, int square)
    {
        Console.WriteLine($"{name}, the square of your number is {square}");
    }
}
}