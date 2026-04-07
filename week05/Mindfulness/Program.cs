using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace MindfulnessProgram
{
    // Base class for all activities
    public abstract class Activity
    {
        private string _name;          
        private string _description;   
        private int _duration;         

        protected static Random _random = new Random();

        public Activity(string name, string description)
        {
            _name = name;
            _description = description;
        }

        public int Duration
        {
            get { return _duration; }
            set { _duration = value; }
        }

        public void DisplayStartingMessage()
        {
            Console.Clear();
            Console.WriteLine($"Starting {_name} Activity");
            Console.WriteLine();
            Console.WriteLine(_description);
            Console.WriteLine();
            Console.Write("How many seconds would you like this activity to last? ");
            _duration = int.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine("Prepare to begin...");
            ShowSpinner(3);
        }

        public void DisplayEndingMessage()
        {
            Console.WriteLine();
            Console.WriteLine("Grate job!");
            ShowSpinner(2);
            Console.WriteLine($"You have completed the {_name} activity for {_duration} seconds.");
            ShowSpinner(3);
        }

        protected void ShowSpinner(int seconds)
        {
            string[] spinner = { "|", "/", "-", "\\" };
            DateTime end = DateTime.Now.AddSeconds(seconds);
            int i = 0;
            while (DateTime.Now < end)
            {
                Console.Write(spinner[i % spinner.Length]);
                Thread.Sleep(200);
                Console.Write("\b");
                i++;
            }
        }

        protected void ShowCountDown(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
        }

        protected string GetUniquePrompt(List<string> prompts, ref List<string> unused)
        {
            if (unused.Count == 0)
                unused = new List<string>(prompts);
            int idx = _random.Next(unused.Count);
            string chosen = unused[idx];
            unused.RemoveAt(idx);
            return chosen;
        }

        public abstract void Run();
    }

    // Breathing Activity (no extra fields needed)
    public class BreathingActivity : Activity
    {
        public BreathingActivity() : base(
            "Breathing",
            "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
        { }

        public override void Run()
        {
            DisplayStartingMessage();

            DateTime endTime = DateTime.Now.AddSeconds(Duration);

            while (DateTime.Now < endTime)
            {
                Console.Write("Breathe in... ");
                for (int i = 1; i <= 4; i++)
                {
                    Console.Write(new string('>', i));
                    Thread.Sleep(250);
                    Console.Write("\b \b".PadLeft(i + 1, '\b'));
                }
                Console.WriteLine("Breathe in... 4");
                Thread.Sleep(1000);

                Console.Write("Breathe out... ");
                ShowCountDown(4);
                Console.WriteLine();
            }

            DisplayEndingMessage();
        }
    }

    // Reflection Activity
    public class ReflectingActivity : Activity
    {
        private List<string> _prompts;     
        private List<string> _questions;   
        private List<string> _unusedPrompts;
        private List<string> _unusedQuestions;

        public ReflectingActivity() : base(
            "Reflection",
            "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
        {
            _prompts = new List<string>
            {
                "Think of a time when you stood up for someone else.",
                "Think of a time when you did something really difficult.",
                "Think of a time when you helped someone in need.",
                "Think of a time when you did something truly selfless."
            };

            _questions = new List<string>
            {
                "Why was this experience meaningful to you?",
                "Have you ever done anything like this before?",
                "How did you get started?",
                "How did you feel when it was complete?",
                "What made this time different than other times when you were not as successful?",
                "What is your favorite thing about this experience?",
                "What could you learn from this experience that applies to other situations?",
                "What did you learn about yourself through this experience?",
                "How can you keep this experience in mind in the future?"
            };

            _unusedPrompts = new List<string>(_prompts);
            _unusedQuestions = new List<string>(_questions);
        }

        public string GetRandomPrompt()
        {
            int idx = _random.Next(_prompts.Count);
            return _prompts[idx];
        }

        public string GetRandomQuestion()
        {
            int idx = _random.Next(_questions.Count);
            return _questions[idx];
        }

        public void DisplayPrompt()
        {
            string prompt = GetUniquePrompt(_prompts, ref _unusedPrompts);
            Console.WriteLine(prompt);
            Console.WriteLine("When you have something in mind, press Enter to continue.");
            Console.ReadLine();
        }

        public void DisplayQuestions()
        {
            DateTime endTime = DateTime.Now.AddSeconds(Duration);
            while (DateTime.Now < endTime)
            {
                string question = GetUniquePrompt(_questions, ref _unusedQuestions);
                Console.Write(question + " ");
                ShowSpinner(5);
                Console.WriteLine();
            }
        }

        public override void Run()
        {
            DisplayStartingMessage();
            DisplayPrompt();
            DisplayQuestions();
            DisplayEndingMessage();
        }
    }

    // Listing Activity
    public class ListingActivity : Activity
    {
        // as specified
        private List<string> _prompts;   
        // take tracks number of items listed)
        private int _count;             

        private List<string> _unusedPrompts;

        public ListingActivity() : base(
            "Listing",
            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
        {
            _prompts = new List<string>
            {
                "Who are people that you appreciate?",
                "What are personal strengths of yours?",
                "Who are people that you have helped this week?",
                "When have you felt the Holy Ghost this month?",
                "Who are some of your personal heroes?",
                "What are some things that you are grateful for?",
                "What are some of your favorite things?"
            };

            _unusedPrompts = new List<string>(_prompts);
            _count = 0;
        }

        public string GetRandomPrompt()
        {
            int idx = _random.Next(_prompts.Count);
            return _prompts[idx];
        }

        public List<string> GetListFromUser()
        {
            List<string> items = new List<string>();
            DateTime endTime = DateTime.Now.AddSeconds(Duration);

            while (DateTime.Now < endTime)
            {
                Console.Write("> ");
                string item = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(item))
                    items.Add(item);
                if (DateTime.Now >= endTime)
                    break;
            }
            // store count in the field
            _count = items.Count;   
            return items;
        }

        public override void Run()
        {
            DisplayStartingMessage();

            string prompt = GetUniquePrompt(_prompts, ref _unusedPrompts);
            Console.WriteLine(prompt);
            Console.WriteLine("You have a few seconds to think...");
            ShowCountDown(5);
            Console.WriteLine();
            Console.WriteLine("Start listing items (press Enter after each). You have " + Duration + " seconds:");

            List<string> userItems = GetListFromUser();
            Console.WriteLine($"You listed {_count} items!");

            DisplayEndingMessage();
        }
    }

    // Activity Logger (unchanged)
    public static class ActivityLogger
    {
        private static string _logFile = "activity_log.txt";
        private static Dictionary<string, int> _counts = new Dictionary<string, int>();

        static ActivityLogger()
        {
            Load();
        }
  
        public static void Log(string activityName)
        {
            if (_counts.ContainsKey(activityName))
                _counts[activityName]++;
            else
                _counts[activityName] = 1;
            Save();
        }

        public static void DisplayLog()
        {
            Console.WriteLine("\n--- Activity Log ---");
            if (_counts.Count == 0)
                Console.WriteLine("No activities performed yet.");
            else
            {
                foreach (var kvp in _counts)
                    Console.WriteLine($"{kvp.Key}: {kvp.Value} time(s)");
            }
            Console.WriteLine("-----------");
        }

        private static void Load()
        {
            if (File.Exists(_logFile))
            {
                string[] lines = File.ReadAllLines(_logFile);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(':');
                    if (parts.Length == 2 && int.TryParse(parts[1], out int count))
                        _counts[parts[0]] = count;
                }
            }
        }

        private static void Save()
        {
            List<string> lines = new List<string>();
            foreach (var kvp in _counts)
                lines.Add($"{kvp.Key}:{kvp.Value}");
            File.WriteAllLines(_logFile, lines);
        }
    }

    // Main program
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Mindfulness Program");
                Console.WriteLine();
                Console.WriteLine(" Menu Options:");
                Console.WriteLine("2. Reflection Activity");
                Console.WriteLine("3. Listing Activity");
                Console.WriteLine("4. Show Activity Log");
                Console.WriteLine("5. Quit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();
                Activity activity = null;

                switch (choice)
                {
                    case "1":
                        activity = new BreathingActivity();
                        break;
                    case "2":
                        activity = new ReflectingActivity();
                        break;
                    case "3":
                        activity = new ListingActivity();
                        break;
                    case "4":
                        ActivityLogger.DisplayLog();
                        Console.WriteLine("\nPress Enter to continue...");
                        Console.ReadLine();
                        continue;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Press Enter.");
                        Console.ReadLine();
                        continue;
                }

                activity.Run();
                ActivityLogger.Log(activity.GetType().Name.Replace("Activity", ""));

                Console.WriteLine("\nPress Enter to return to menu...");
                Console.ReadLine();
            }
        }
    }
}