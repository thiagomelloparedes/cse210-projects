using System;

public class Running : Activity
{
    private double _distanceMiles;

    public Running(DateTime date, int minutes, double distanceMiles)
        : base(date, minutes)
    {
        _distanceMiles = distanceMiles;
    }

    public override string GetActivityName()
    {
        return "Running";
    }

    public override double GetDistance()
    {
        return _distanceMiles;
    }

    public override double GetSpeed()
    {
        // mph = (distance / minutes) * 60
        return (GetDistance() / GetMinutes()) * 60.0;
    }

    public override double GetPace()
    {
        // min per mile = minutes / distance
        return GetMinutes() / GetDistance();
    }
}

