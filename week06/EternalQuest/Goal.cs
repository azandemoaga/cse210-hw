using System;

public abstract class Goal
{
    protected string _name;
    protected string _description;
    protected int _points;

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    public abstract void RecordEvent();
    public abstract bool IsComplete();
    public virtual string GetDetailsString() => $"[{(IsComplete() ? "X" : " ")}] {_name} ({_description})";
    public abstract string GetStringRepresentation();
    public int GetPoints() => _points;
}

public class SimpleGoal : Goal
{
    private bool _isComplete;
    public SimpleGoal(string name, string desc, int pts, bool complete = false) : base(name, desc, pts) => _isComplete = complete;
    public override void RecordEvent() => _isComplete = true;
    public override bool IsComplete() => _isComplete;
    public override string GetStringRepresentation() => $"SimpleGoal:{_name},{_description},{_points},{_isComplete}";
}

public class EternalGoal : Goal
{
    public EternalGoal(string name, string desc, int pts) : base(name, desc, pts) { }
    public override void RecordEvent() { } // Never ends
    public override bool IsComplete() => false;
    public override string GetStringRepresentation() => $"EternalGoal:{_name},{_description},{_points}";
}

public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string desc, int pts, int target, int bonus, int current = 0) : base(name, desc, pts)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = current;
    }
    public override void RecordEvent() { if (_amountCompleted < _target) _amountCompleted++; }
    public override bool IsComplete() => _amountCompleted >= _target;
    public override string GetDetailsString() => $"[{(IsComplete() ? "X" : " ")}] {_name} ({_description}) -- Progress: {_amountCompleted}/{_target}";
    public override string GetStringRepresentation() => $"ChecklistGoal:{_name},{_description},{_points},{_bonus},{_target},{_amountCompleted}";
    public int GetBonus() => _bonus;
}