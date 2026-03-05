using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise2 Project.");

        Console.WriteLine("Please enter your grade: ");
        string answer = Console.ReadLine();
        int percentage = int.Parse(answer);

        string letter = "";
        if (percentage >= 90)
        {
            letter = "A";
        }
        else if (percentage >= 80)
        {
            letter = "B";
        }
        else if (percentage >= 70)
        {
            letter = "C";
        }
        else if (percentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }
        string sign = "";
        int lastDigit = percentage % 10;
        if (letter !="F")
        {
            if (lastDigit >= 7)
            {
                sign = "+";
            }
            else if (lastDigit <= 3)
            {
                sign = "-";
            }
            
            Console.WriteLine($"Your letter grade is {letter}{sign}.");
        }
        else
        {
            Console.WriteLine($"Your letter grade is {letter}.");
        }
        if (percentage >= 70)
        {
            Console.WriteLine("Congratulations! You passed the class.");
        }
        else
        {
            Console.WriteLine("Sorry, you did not pass the class. Better luck next time!");
        }

    }
}