using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Journal
{
    public List<Entry> Entries { get; set; }
    public List<string> Prompts { get; set; }

    public Journal()
    {
        Entries = new List<Entry>();
        Prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What is something I learned today?",
            "What is something I'm looking forward to tomorrow?"
        };
    }

    public void AddEntry()
    {
        var random = new Random();
        var prompt = Prompts[random.Next(0, Prompts.Count)];
        Console.WriteLine(prompt);
        var response = Console.ReadLine();
        var date = DateTime.Now.ToString("yyyy-MM-dd");
        var entry = new Entry(prompt, response, date);
        Entries.Add(entry);
    }

    public void DisplayJournal()
    {
        foreach (var entry in Entries)
        {
            Console.WriteLine(entry.ToString());
        }
    }

    public void SaveJournal()
    {
        Console.Write("Enter a filename: ");
        var filename = Console.ReadLine();
        using (var writer = new StreamWriter(filename))
        {
            foreach (var entry in Entries)
            {
                writer.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");
            }
        }
    }

    public void LoadJournal()
    {
        Console.Write("Enter a filename: ");
        var filename = Console.ReadLine();
        Entries.Clear();
        using (var reader = new StreamReader(filename))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                var parts = line.Split('|');
                var entry = new Entry(parts[1], parts[2], parts[0]);
                Entries.Add(entry);
            }
        }
    }
}