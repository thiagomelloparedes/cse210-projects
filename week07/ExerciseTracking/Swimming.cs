using System;

public class Swimming : Activity
{
    private int _laps;

    public Swimming(DateTime date, int minutes, int laps)
        : base(date, minutes)
    {
        _laps = laps;
    }

    public override string GetActivityName()
    {
        return "Swimming";
    }

    public override double GetDistance()
    {
        // Distance (miles) = laps * 50 / 1000 * 0.62
        return _laps * 50.0 / 1000.0 * 0.62;
    }

    public override double GetSpeed()
    {
        return (GetDistance() / GetMinutes()) * 60.0;
    }

    public override double GetPace()
    {
        return GetMinutes() / GetDistance();
    }
}
