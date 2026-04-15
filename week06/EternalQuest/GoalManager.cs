using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private int _level;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
        _level = 1;
    }

    private void UpdateLevel()
    {
        int newLevel = (_score / 1000) + 1;
        if (newLevel > _level)
        {
            _level = newLevel;
            Console.WriteLine($"\n🎉 LEVEL UP! You are now level {_level}! 🎉\n");
        }
    }

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void RecordEvent(int goalIndex)
    {
        if (goalIndex < 0 || goalIndex >= _goals.Count)
        {
            Console.WriteLine("Invalid goal index.");
            return;
        }
        Goal goal = _goals[goalIndex];
        int pointsEarned = goal.RecordEvent();
        if (pointsEarned != 0)
        {
            _score += pointsEarned;
            Console.WriteLine($"\n✅ You earned {pointsEarned} points! (Total: {_score})");
            if (pointsEarned < 0)
                Console.WriteLine($"⚠️ Oops! You lost {Math.Abs(pointsEarned)} points for a negative goal.");
            UpdateLevel();
        }
        else
        {
            Console.WriteLine("\n⚠️ This goal is already complete. No points awarded.");
        }
    }

    public void DisplayGoals()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("\nNo goals yet. Create some!\n");
            return;
        }
        Console.WriteLine("\nYour Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
        Console.WriteLine();
    }

    public void DisplayScore()
    {
        Console.WriteLine($"\n🏆 Current Score: {_score} points   |   Level: {_level}\n");
    }

    public void SaveGoals(string filename)
    {
        using StreamWriter writer = new StreamWriter(filename);
        writer.WriteLine(_score);
        writer.WriteLine(_level);
        foreach (Goal goal in _goals)
        {
            writer.WriteLine(goal.GetStringRepresentation());
        }
        Console.WriteLine($"\n💾 Goals saved to {filename}\n");
    }

    public void LoadGoals(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine($"\n❌ File {filename} not found. Starting fresh.\n");
            return;
        }
        try
        {
            string[] lines = File.ReadAllLines(filename);
            _score = int.Parse(lines[0]);
            _level = int.Parse(lines[1]);
            _goals.Clear();

            for (int i = 2; i < lines.Length; i++)
            {
                string line = lines[i];
                string[] parts = line.Split(':');
                string type = parts[0];
                string[] data = parts[1].Split(',');

                switch (type)
                {
                    case "SimpleGoal":
                        var simple = new SimpleGoal(data[0], data[1], int.Parse(data[2]));
                        if (bool.Parse(data[3])) // force complete state
                            simple.RecordEvent(); // mark complete
                        _goals.Add(simple);
                        break;
                    case "EternalGoal":
                        _goals.Add(new EternalGoal(data[0], data[1], int.Parse(data[2])));
                        break;
                    case "ChecklistGoal":
                        var check = new ChecklistGoal(data[0], data[1], int.Parse(data[2]), int.Parse(data[4]), int.Parse(data[3]));
                        // replay completions
                        int completed = int.Parse(data[5]);
                        for (int j = 0; j < completed; j++)
                            check.RecordEvent();
                        _goals.Add(check);
                        break;
                    case "NegativeGoal":
                        _goals.Add(new NegativeGoal(data[0], data[1], int.Parse(data[2])));
                        break;
                }
            }
            Console.WriteLine($"\n📂 Goals loaded from {filename}\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\n❌ Error loading file: {ex.Message}\n");
        }
    }
}