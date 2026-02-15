using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score;
    private int _level;

    public GoalManager()
    {
        _score = 0;
        _level = 1;
    }

    public void Start()
    {
        bool quit = false;
        while (!quit)
        {
            UpdateLevel();
            DisplayPlayerInfo();

            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1": CreateGoal(); break;
                case "2": ListGoalDetails(); break;
                case "3": SaveGoals(); break;
                case "4": LoadGoals(); break;
                case "5": RecordEvent(); break;
                case "6": quit = true; break;
                default: Console.WriteLine("Invalid selection."); break;
            }
        }
    }

    private void UpdateLevel() => _level = (_score / 1000) + 1;

    public void DisplayPlayerInfo()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"--- LEVEL {_level} QUESTING ---");
        Console.ResetColor();
        Console.WriteLine($"Points: {_score}");

        int progress = _score % 1000;
        int barWidth = 20;
        int filled = (progress * barWidth) / 1000;
        Console.Write("XP: [");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(new string('=', filled) + new string(' ', barWidth - filled));
        Console.ResetColor();
        Console.WriteLine($"] {progress}/1000 to next level");
    }

    public void CreateGoal()
    {
        Console.WriteLine("\nThe types of Goals are:");
        Console.WriteLine("  1. Simple Goal\n  2. Eternal Goal\n  3. Checklist Goal\n  4. Bad Habit Goal");
        Console.Write("Which type of goal would you like to create? ");
        string type = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string desc = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        switch (type)
        {
            case "1": _goals.Add(new SimpleGoal(name, desc, points)); break;
            case "2": _goals.Add(new EternalGoal(name, desc, points)); break;
            case "3":
                Console.Write("How many times for a bonus? ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("What is the bonus? ");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
                break;
            case "4": _goals.Add(new BadHabitGoal(name, desc, points)); break;
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("\nThe goals are:");
        for (int i = 0; i < _goals.Count; i++)
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        Console.WriteLine("\nPress Enter to continue...");
        Console.ReadLine();
    }

    public void RecordEvent()
    {
        for (int i = 0; i < _goals.Count; i++)
            Console.WriteLine($"{i + 1}. {_goals[i].GetName()}");
        Console.Write("Which goal did you accomplish? ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < _goals.Count)
        {
            int earned = _goals[index].RecordEvent();
            _score += earned;
            Console.WriteLine($"Earned {earned} points! Total: {_score}");
        }
        System.Threading.Thread.Sleep(1500);
    }

    public void SaveGoals()
    {
        Console.Write("Filename: ");
        string filename = Console.ReadLine();
        using (StreamWriter sw = new StreamWriter(filename))
        {
            sw.WriteLine(_score);
            foreach (Goal g in _goals) sw.WriteLine(g.GetStringRepresentation());
        }
    }

    public void LoadGoals()
    {
        Console.Write("Filename: ");
        string filename = Console.ReadLine();
        if (!File.Exists(filename)) return;

        string[] lines = File.ReadAllLines(filename);
        _score = int.Parse(lines[0]);
        _goals.Clear();

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(":");
            string type = parts[0];
            string[] d = parts[1].Split(",");

            switch (type)
            {
                case "SimpleGoal":
                    SimpleGoal sg = new SimpleGoal(d[0], d[1], int.Parse(d[2]));
                    if (bool.Parse(d[3])) sg.ForceComplete();
                    _goals.Add(sg);
                    break;
                case "EternalGoal": _goals.Add(new EternalGoal(d[0], d[1], int.Parse(d[2]))); break;
                case "ChecklistGoal":
                    ChecklistGoal cg = new ChecklistGoal(d[0], d[1], int.Parse(d[2]), int.Parse(d[4]), int.Parse(d[5]));
                    for (int j = 0; j < int.Parse(d[3]); j++) cg.RestoreProgress();
                    _goals.Add(cg);
                    break;
                case "BadHabitGoal": _goals.Add(new BadHabitGoal(d[0], d[1], int.Parse(d[2]))); break;
            }
        }
    }
}
