
public class Running : Activity
{
    public double distance { get; set; }

    public Running(DateTime date, int minutes, double distance) : base(date, minutes)
    {
        this.distance = distance;
    }

    public override double GetDistance()
    {
        return distance;
    }

    public override double GetSpeed()
    {
        return (distance / GetMinutes()) * 60;
    }

    public override double GetPace()
    {
        return GetMinutes() / distance;
    }
    public override string GetSummary()
    {
        return $"{base.GetSummary()}: Distance {GetDistance():F1} km, " + $"  Speed: {GetSpeed():F1} mph, Pace: {GetPace():F1} min per km";
    }
}