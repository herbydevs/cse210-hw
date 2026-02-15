public class BadHabitGoal : Goal
{
    public BadHabitGoal(string name, string description, int points) : base(name, description, points) { }

    public override int RecordEvent() => -_points;

    public override bool IsComplete() => false;

    public override string GetDetailsString() => $"[!] {_shortName} ({_description}) [Penalty Goal]";

    public override string GetStringRepresentation()
    {
        return $"BadHabitGoal:{_shortName},{_description},{_points}";
    }
}
