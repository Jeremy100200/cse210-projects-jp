using System;

class Program
{
    static void Main(string[] args)
    {
    
        var Journal = new Journal();
        while (true)
        {
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");
            Console.Write("Choose an option: ");
            var option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    Journal.AddEntry();
                    break;
                case "2":
                    Journal.DisplayJournal();
                    break;
                case "3":
                    Journal.SaveJournal();
                    break;
                case "4":
                    Journal.LoadJournal();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}