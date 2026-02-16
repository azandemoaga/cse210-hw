using System;
using System.IO;
using System.Collections.Generic;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void Start()
    {
        string choice = "";
        while (choice != "6")
        {
            Console.WriteLine($"\nScore: {_score} | Level: {(_score / 1000) + 1}");
            Console.WriteLine("1. Create | 2. List | 3. Save | 4. Load | 5. Record | 6. Quit");
            Console.Write("Choice: "); choice = Console.ReadLine();
            if (choice == "1") Create();
            else if (choice == "2") List();
            else if (choice == "3") Save();
            else if (choice == "4") Load();
            else if (choice == "5") Record();
        }
    }

    private void Create()
    {
        Console.Write("1.Simple 2.Eternal 3.Checklist: "); string t = Console.ReadLine();
        Console.Write("Name: "); string n = Console.ReadLine();
        Console.Write("Desc: "); string d = Console.ReadLine();
        Console.Write("Pts: "); int p = int.Parse(Console.ReadLine());
        if (t == "1") _goals.Add(new SimpleGoal(n, d, p));
        else if (t == "2") _goals.Add(new EternalGoal(n, d, p));
        else {
            Console.Write("Target: "); int trg = int.Parse(Console.ReadLine());
            Console.Write("Bonus: "); int bns = int.Parse(Console.ReadLine());
            _goals.Add(new ChecklistGoal(n, d, p, trg, bns));
        }
    }

    private void List() { for(int i=0; i<_goals.Count; i++) Console.WriteLine($"{i+1}. {_goals[i].GetDetailsString()}"); }

    private void Record()
    {
        List(); Console.Write("Goal #: "); int i = int.Parse(Console.ReadLine()) - 1;
        if (_goals[i].IsComplete()) return;
        _goals[i].RecordEvent();
        int p = _goals[i].GetPoints();
        if (_goals[i] is ChecklistGoal c && c.IsComplete()) p += c.GetBonus();
        _score += p; Console.WriteLine($"Earned {p} pts!");
    }

    private void Save()
    {
        Console.Write("File: "); string f = Console.ReadLine();
        using (StreamWriter s = new StreamWriter(f)) { s.WriteLine(_score); foreach(var g in _goals) s.WriteLine(g.GetStringRepresentation()); }
    }

    private void Load()
    {
        Console.Write("File: "); string f = Console.ReadLine(); if (!File.Exists(f)) return;
        string[] lines = File.ReadAllLines(f); _score = int.Parse(lines[0]); _goals.Clear();
        for(int i=1; i<lines.Length; i++) {
            string[] p = lines[i].Split(':'); string[] d = p[1].Split(',');
            if (p[0] == "SimpleGoal") _goals.Add(new SimpleGoal(d[0], d[1], int.Parse(d[2]), bool.Parse(d[3])));
            else if (p[0] == "EternalGoal") _goals.Add(new EternalGoal(d[0], d[1], int.Parse(d[2])));
            else _goals.Add(new ChecklistGoal(d[0], d[1], int.Parse(d[2]), int.Parse(d[4]), int.Parse(d[3]), int.Parse(d[5])));
        }
    }
}

class Program { static void Main() => new GoalManager().Start(); }