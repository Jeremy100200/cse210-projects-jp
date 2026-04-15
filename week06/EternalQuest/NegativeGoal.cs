// Negative goal: each time you record it, you LOSE points (eternal style, never complete)
public class NegativeGoal : Goal
{
    public NegativeGoal(string name, string description, int pointsLost)
        : base(name, description, -Math.Abs(pointsLost)) // points stored as negative
    { }

    public override int RecordEvent()
    {
        //  lose points (negative points)
        return _points;
    }

    public override bool IsComplete() => false;

    public override string GetDetailsString()
    {
        return $"{_shortName} ({_description}) -- Lose {Math.Abs(_points)} points each time";
    }

    public override string GetStringRepresentation()
    {
        return $"NegativeGoal:{_shortName},{_description},{Math.Abs(_points)}";
    }
}