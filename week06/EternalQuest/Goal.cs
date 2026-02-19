using System;

public abstract class Goal
{
    protected string _shortName;
    protected string _description;
    protected int _points;
    protected bool _isComplete;

    protected Goal(string shortName, string description, int points)
    {
        _shortName = shortName;
        _description = description;
        _points = points;
        _isComplete = false; // default
    }

    public string GetName() => _shortName;
    public string GetDescription() => _description;
    public int GetPoints() => _points;

    public virtual bool IsComplete() => _isComplete;

    public virtual string GetDetailsString()
    {
        string box = IsComplete() ? "[X]" : "[ ]";
        return $"{box} {_shortName} ({_description})";
    }

    // Returns points earned for recording this event.
    public abstract int RecordEvent();

    // For saving/loading
    public abstract string GetStringRepresentation();

    protected static string Sanitize(string text)
    {
        return text.Replace("|", "/");
    }
}
