public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonusPoints;

    public ChecklistGoal(string name, string description, int points, int target, int bonus)
        : base(name, description, points)
    {
        _target = target;
        _bonusPoints = bonus;
        _amountCompleted = 0;
    }

    public override int RecordEvent()
    {
        if (!IsComplete())
        {
            _amountCompleted++;
            int earned = _points;
            if (IsComplete())
                earned += _bonusPoints;
            return earned;
        }
        return 0;
    }

    public override bool IsComplete() => _amountCompleted >= _target;

    public override string GetDetailsString()
    {
        string checkbox = IsComplete() ? "[X]" : "[ ]";
        return $"{checkbox} {_shortName} ({_description}) -- Completed {_amountCompleted}/{_target} times";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{_shortName},{_description},{_points},{_bonusPoints},{_target},{_amountCompleted}";
    }
}