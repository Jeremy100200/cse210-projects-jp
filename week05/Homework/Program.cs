using System;

class Program
{
    static void Main(string[] args)
    {
        // create an instance of the Assignment class
        Assignment assignment1 = new Assignment("Alice", "Multiplication");
        Console.WriteLine(assignment1.GetSummary());
        Assignment assignment2 = new Assignment("Bob", "Division");
        Console.WriteLine(assignment2.GetSummary());

        // create an instance of the MathAssignment class
        MathAssignment mathAssignment1 = new MathAssignment("Charlie", "Algebra", "Section 2.1", "Problems 1-10");
        Console.WriteLine(mathAssignment1.GetHomeworkList());
        MathAssignment mathAssignment2 = new MathAssignment("Diana", "Geometry", "Section 3.2", "Problems 11-20");
        Console.WriteLine(mathAssignment2.GetHomeworkList());
    }
} 