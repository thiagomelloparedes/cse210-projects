public class SimpleGoal : Goal
{
    public SimpleGoal(string shortName, string description, int points, bool isComplete = false)
        : base(shortName, description, points)
    {
        _isComplete = isComplete;
    }

    public override int RecordEvent()
    {
        if (_isComplete)
        {
            return 0;
        }

        _isComplete = true;
        return _points;
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal|{Sanitize(_shortName)}|{Sanitize(_description)}|{_points}|{_isComplete}";
    }
}
