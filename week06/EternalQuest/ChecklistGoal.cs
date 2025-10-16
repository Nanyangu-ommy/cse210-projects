using System;

public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonusPoints;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints, int currentCount = 0)
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _bonusPoints = bonusPoints;
        _currentCount = currentCount;
    }

    public override int RecordEvent()
    {
        _currentCount++;
        if (_currentCount == _targetCount)
        {
            Console.WriteLine($"🎉 You completed {GetName()} and earned a bonus of {_bonusPoints} points!");
            return GetPoints() + _bonusPoints;
        }
        return GetPoints();
    }

    public override bool IsComplete() => _currentCount >= _targetCount;

    public override void DisplayProgress()
    {
        Console.WriteLine($"[{(IsComplete() ? "X" : " ")}] {GetName()} ({GetDescription()}) - Completed {_currentCount}/{_targetCount}");
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal|{GetName()}|{GetDescription()}|{GetPoints()}|{_targetCount}|{_bonusPoints}|{_currentCount}";
    }
}

