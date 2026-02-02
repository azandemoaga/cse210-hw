using System;

// This is a simple program to demonstrate the principle of Inheritance
// as discussed in the Week 05 Learning Activities.

public class BaseActivity
{
    protected string _message = "Starting Activity...";

    public void ShowCommonMessage()
    {
        Console.WriteLine(_message);
    }
}

public class SpecificActivity : BaseActivity
{
    public void Run()
    {
        // Inherits ShowCommonMessage from BaseActivity
        ShowCommonMessage(); 
        Console.WriteLine("Running specific homework logic.");
    }
}

class Program
{
    static void Main()
    {
        SpecificActivity homework = new SpecificActivity();
        homework.Run();
    }
}