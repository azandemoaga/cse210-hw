using System;
using System.Collections.Generic;
using System.IO;

// ...existing code...

public class Entry
{
    public string _date;
    public string _promptText;
    public string _entryText;
    public string _mood; // Creative addition to exceed requirements

    public void Display()
    {
        Console.WriteLine("-----------------------------------------------------------");
        Console.WriteLine($"Date: {_date} - Prompt: {_promptText}");
        Console.WriteLine($"Mood: {_mood}");
        Console.WriteLine($"Entry: {_entryText}");
    }
}

public class PromptGenerator
{
    public List<string> _prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What is a goal I worked toward today?",
        "Describe something beautiful you saw in Johannesburg today."
    };

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
}

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("\n[The journal is currently empty.]");
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string file)
    {
        using (StreamWriter outputFile = new StreamWriter(file))
        {
            foreach (Entry entry in _entries)
            {
                // Using | as a separator as suggested in the simplifications
                outputFile.WriteLine($"{entry._date}|{entry._promptText}|{entry._entryText}|{entry._mood}");
            }
        }
        Console.WriteLine("\n[Journal saved successfully.]");
    }

    public void LoadFromFile(string file)
    {
        if (!File.Exists(file))
        {
            Console.WriteLine("\n[Error: File not found.]");
            return;
        }

        _entries.Clear();
        string[] lines = System.IO.File.ReadAllLines(file);

        foreach (string line in lines)
        {
            string[] parts = line.Split("|");
            if (parts.Length == 4)
            {
                Entry newEntry = new Entry();
                newEntry._date = parts[0];
                newEntry._promptText = parts[1];
                newEntry._entryText = parts[2];
                newEntry._mood = parts[3];
                _entries.Add(newEntry);
            }
        }
        Console.WriteLine("\n[Journal loaded successfully.]");
    }
}

/* 
  NAME: Azande Moaga
  PROJECT: Journal Program (W02)
  
  SHOWING CREATIVITY AND EXCEEDING REQUIREMENTS:
  1. Added an extra data field ("Mood") to the Entry class and updated the save/load 
     logic to track how the user was feeling.
  2. Included a localized prompt for Johannesburg in the PromptGenerator to make 
     the journaling experience more personally relevant.
  3. Added file-existence validation in the Journal.LoadFromFile method to prevent 
     the program from crashing if a user enters a wrong filename.
  4. Added UI formatting (separators and success messages) to make the console 
     experience cleaner and more user-friendly.
*/

class Program
{
    static void Main(string[] args)
    {
        Journal theJournal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        bool running = true;

        Console.WriteLine("Welcome to the Journal Program, Azande!");

        while (running)
        {
            Console.WriteLine("\nPlease select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine($"\nPrompt: {prompt}");
                    Console.Write("> ");
                    string response = Console.ReadLine();
                    
                    Console.Write("What is your current mood? ");
                    string mood = Console.ReadLine();

                    Entry newEntry = new Entry();
                    newEntry._date = DateTime.Now.ToShortDateString();
                    newEntry._promptText = prompt;
                    newEntry._entryText = response;
                    newEntry._mood = mood;

                    theJournal.AddEntry(newEntry);
                    break;

                case "2":
                    theJournal.DisplayAll();
                    break;

                case "3":
                    Console.Write("What is the filename? ");
                    string loadFile = Console.ReadLine();
                    theJournal.LoadFromFile(loadFile);
                    break;

                case "4":
                    Console.Write("What is the filename? ");
                    string saveFile = Console.ReadLine();
                    theJournal.SaveToFile(saveFile);
                    break;

                case "5":
                    running = false;
                    break;

                default:
                    Console.WriteLine("\n[Invalid choice. Please enter 1-5.]");
                    break;
            }
        }
        Console.WriteLine("Goodbye!");
    }
}