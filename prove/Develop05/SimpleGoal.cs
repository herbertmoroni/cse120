public class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description, int value) : base(name, description, value)
    {
    }

    public override int Complete()
    {
        _isCompleted = true;
        return _value;
    }
}