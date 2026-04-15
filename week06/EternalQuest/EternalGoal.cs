public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points) { }

    public override int RecordEvent()
    {
        // Never complete, always award points
        return _points;
    }

    public override bool IsComplete() => false; // Never complete

    public override string GetDetailsString()
    {
        // No checkbox; show as [∞] or similar
        return $"[∞] {_shortName} ({_description})";
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{_shortName},{_description},{_points}";
    }
}