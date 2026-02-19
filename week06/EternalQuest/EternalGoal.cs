public class EternalGoal : Goal
{
    public EternalGoal(string shortName, string description, int points)
        : base(shortName, description, points)
    {
        _isComplete = false;
    }

    public override bool IsComplete() => false;

    public override int RecordEvent()
    {
        return _points;
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal|{Sanitize(_shortName)}|{Sanitize(_description)}|{_points}";
    }
}
