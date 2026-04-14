
using System.Diagnostics;

public class Cycling : Activity
{
    private double speed; 
    public Cycling(DateTime date, int minutes, double speed) : base(date, minutes)
    {
        this.speed = speed;
    }
    public override double GetDistance()
    {
        return (speed * GetMinutes()) / 60;
    }
    public override double GetSpeed()
    {
        return speed;
    }
    public override double GetPace()
    {
        return 60 / speed;
    }
    public override string GetSummary()
    {
        return $"{base.GetSummary()}: Distance {GetDistance():F1} km, " + $"  Speed: {GetSpeed():F1} kph, Pace: {GetPace():F1} min per km";
    }

}
