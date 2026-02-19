using System;

public abstract class Activity
{
    private DateTime _date;
    private int _minutes;

    protected Activity(DateTime date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    // Protected accessors (variables remain private: encapsulation)
    protected int GetMinutes()
    {
        return _minutes;
    }

    protected DateTime GetDate()
    {
        return _date;
    }

    public abstract string GetActivityName();

    // Declared but not implemented here (polymorphism via overriding)
    public abstract double GetDistance(); // miles
    public abstract double GetSpeed();    // mph
    public abstract double GetPace();     // min per mile

    // Base summary uses the other methods (rubric requirement)
    public virtual string GetSummary()
    {
        string dateString = GetDate().ToString("dd MMM yyyy");
        return $"{dateString} {GetActivityName()} ({_minutes} min)- " +
               $"Distance {GetDistance():0.0} miles, " +
               $"Speed {GetSpeed():0.0} mph, " +
               $"Pace: {GetPace():0.0} min per mile";
    }
}
