using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2024, 6, 1), 30, 5.8),
            new Cycling(new DateTime(2024, 6, 2), 60, 20.2),
            new Swimming(new DateTime(2024, 6, 3), 45, 40)
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}