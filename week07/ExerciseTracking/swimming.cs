public class Swimming : Activity

{
    private int _laps;

    public Swimming(DateTime date, int minutes, int laps) : base(date, minutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        return _laps * 50 / 1000.0; // converts laps to km (50 meters per lap)
    }

    public override double GetSpeed()
    {
        return GetDistance() / (GetMinutes() / 60.0);
    }

    public override double GetPace()
    {
        double distance = GetDistance();
        if (distance == 0) return 0; // avoid division by zero
        return GetMinutes() / distance;
    }

    public override string GetSummary()
    {
        return $"{base.GetSummary()}: Distance {GetDistance():F1} km, Speed: {GetSpeed():F1} kph, Pace: {GetPace():F1} min per km";
    }
}