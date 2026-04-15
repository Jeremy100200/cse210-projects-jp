using System;

public abstract class Goal
{
    protected string _shortName;
    protected string _description;
    protected int _points;

    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points; 
    }

    public string GetName() => _shortName;
    public string GetDescription() => _description;
    public int GetPoints() => _points;

    // Record an event and return points earned (may be overridden)
    public abstract int RecordEvent();

    // Check if goal is complete (virtual so Simple/Checklist can override)
    public virtual bool IsComplete() => false;

    // String for displaying in the goal list
    public virtual string GetDetailsString()
    {
        string checkbox = IsComplete() ? "[X]" : "[ ]";
        return $"{checkbox} {_shortName} ({_description})";
    }

    // String for saving to file (format: type|name|desc|points|...)
    public abstract string GetStringRepresentation();
}