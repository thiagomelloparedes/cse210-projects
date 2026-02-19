using System;

public class Cycling : Activity
{
    private double _speedMph;

    public Cycling(DateTime date, int minutes, double speedMph)
        : base(date, minutes)
    {
        _speedMph = speedMph;
    }

    public override string GetActivityName()
    {
        return "Cycling";
    }

    public override double GetDistance()
    {
        // distance = (speed * minutes) / 60
        return (_speedMph * GetMinutes()) / 60.0;
    }

    public override double GetSpeed()
    {
        return _speedMph;
    }

    public override double GetPace()
    {
        // pace = 60 / speed  (min per mile)
        return 60.0 / GetSpeed();
    }
}
