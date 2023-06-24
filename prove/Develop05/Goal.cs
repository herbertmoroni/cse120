public abstract class Goal
{
    protected string _name;
    protected string _description;
    protected int _value;
    protected bool _isCompleted = false;

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public string Description
    {
        get { return _description; }
        set { _description = value; }
    }

    public int Value
    {
        get { return _value; }
        set { _value = value; }
    }

    public Goal(string name, string description, int value)
    {
        _name = name;
        _value = value;
    }

    public virtual int Complete()
    {
        return _value;
    }

    public virtual string GoalStatus => _isCompleted ? "[X]" : "[ ]";

    public override string ToString()
    {
        return $"{GoalStatus} {Name}: {Description}";
    }
}