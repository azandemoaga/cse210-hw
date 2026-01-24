using System;
using System.Collections.Generic;
using System.Linq;

// EXCEEDING REQUIREMENTS:
// 1. Added a Scripture Library: The program contains a list of scriptures and 
//    randomly selects one for the user to practice.
// 2. Enhanced Word Hiding: The program specifically tracks which words are visible 
//    and only hides those (Stretch Challenge).

class Program
{
    static void Main(string[] args)
    {
        List<Scripture> library = new List<Scripture>
        {
            new Scripture(new Reference("John", 3, 16), "For God so loved the world that he gave his only begotten Son"),
            new Scripture(new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all thine heart and lean not unto thine own understanding"),
            new Scripture(new Reference("Philippians", 4, 13), "I can do all things through Christ which strengtheneth me")
        };

        Random random = new Random();
        Scripture scripture = library[random.Next(library.Count)];

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();

            if (scripture.IsCompletelyHidden()) break;

            Console.WriteLine("Press enter to hide words or type 'quit' to finish:");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit") break;

            scripture.HideRandomWords(3);
        }
    }
}

public class Word
{
    private string _text;
    private bool _isHidden;
    public Word(string text) { _text = text; _isHidden = false; }
    public void Hide() { _isHidden = true; }
    public bool IsHidden() => _isHidden;
    public string GetDisplayText() => _isHidden ? new string('_', _text.Length) : _text;
}

public class Reference
{
    private string _book;
    private int _chapter, _verse, _endVerse;
    public Reference(string book, int chapter, int verse) { _book = book; _chapter = chapter; _verse = verse; _endVerse = verse; }
    public Reference(string book, int chapter, int start, int end) { _book = book; _chapter = chapter; _verse = start; _endVerse = end; }
    public string GetDisplayText() => _verse == _endVerse ? $"{_book} {_chapter}:{_verse}" : $"{_book} {_chapter}:{_verse}-{_endVerse}";
}

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(w => new Word(w)).ToList();
    }
    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();
        var visibleWords = _words.Where(w => !w.IsHidden()).ToList();
        int actualToHide = Math.Min(numberToHide, visibleWords.Count);
        for (int i = 0; i < actualToHide; i++)
        {
            int index = random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }
    public string GetDisplayText() => $"{_reference.GetDisplayText()} {string.Join(" ", _words.Select(w => w.GetDisplayText()))}";
    public bool IsCompletelyHidden() => _words.All(w => w.IsHidden());
}
