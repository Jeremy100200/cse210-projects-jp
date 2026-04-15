
using System;

class Program
{
    static void Main()
    {
        GoalManager manager = new GoalManager();
        string filename = "goals.txt";

        Console.WriteLine("Welcome to the Enhanced Goal Tracker! ");

        bool running = true;
        while (running)
        {
            Console.WriteLine("\n--- Menu ---");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event (Complete a Goal)");
            Console.WriteLine("4. Show Score & Level");
            Console.WriteLine("5. Save Goals");
            Console.WriteLine("6. Load Goals");
            Console.WriteLine("7. Quit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal(manager);
                    break;
                case "2":
                    manager.DisplayGoals();
                    break;
                case "3":
                    manager.DisplayGoals();
                    Console.Write("Enter goal number to record: ");
                    if (int.TryParse(Console.ReadLine(), out int idx))
                        manager.RecordEvent(idx - 1);
                    else
                        Console.WriteLine("Invalid number.");
                    break;
                case "4":
                    manager.DisplayScore();
                    break;
                case "5":
                    manager.SaveGoals(filename);
                    break;
                case "6":
                    manager.LoadGoals(filename);
                    break;
                case "7":
                    running = false;
                    Console.WriteLine("\nGoodbye! Keep achieving your goals! ");
                    break;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }

    static void CreateGoal(GoalManager manager)
    {
        Console.WriteLine("\nGoal Types:");
        Console.WriteLine("1. Simple Goal (complete once)");
        Console.WriteLine("2. Eternal Goal (repeatable, never completes)");
        Console.WriteLine("3. Checklist Goal (requires multiple completions + bonus)");
        Console.WriteLine("4. Negative Goal (lose points each time – for bad habits)");
        Console.Write("Which type? ");
        string typeChoice = Console.ReadLine();

        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter description: ");
        string desc = Console.ReadLine();

        Goal goal = null;

        switch (typeChoice)
        {
            case "1":
                Console.Write("Points when completed: ");
                int points = int.Parse(Console.ReadLine());
                goal = new SimpleGoal(name, desc, points);
                break;
            case "2":
                Console.Write("Points each time: ");
                points = int.Parse(Console.ReadLine());
                goal = new EternalGoal(name, desc, points);
                break;
            case "3":
                Console.Write("Points per completion: ");
                int perPoints = int.Parse(Console.ReadLine());
                Console.Write("Target number of times: ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Bonus points on completion: ");
                int bonus = int.Parse(Console.ReadLine());
                goal = new ChecklistGoal(name, desc, perPoints, target, bonus);
                break;
            case "4":
                // Negative Goal: This goal allow user to lose points each time the even is recorded.
                // This is useful for tacking bad habit (eg. "smoking", Procrastination").
                //The point enter by the user are stored as positive number but when the event is recorded, the user will lose that amount of points.
                // For example, if the user create a Negative Goal called "Smoking" and enter 5 points, each time the user record an event for that goal, they will lose 5 points from their total score.
               
                Console.Write("Points to LOSE each time (enter positive): ");
                int losePoints = int.Parse(Console.ReadLine());
                goal = new NegativeGoal(name, desc, losePoints);
                break;
            default:
                Console.WriteLine("Invalid type.");
                return;
        }

        manager.AddGoal(goal);
        Console.WriteLine($"\n Goal \"{name}\" created successfully!\n");
    }
}