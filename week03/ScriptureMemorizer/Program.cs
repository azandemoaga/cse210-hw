using System;
using System.Collections.Generic;

// EXCEEDING REQUIREMENTS:
// 1. Implementation of a Scripture Library: Instead of a single hardcoded scripture, 
//    the program stores a list of scriptures in a List and selects one at random 
//    each time the program starts.
// 2. Enhanced Word Hiding Logic: The program ensures it only picks from words that 
//    are not already hidden (the stretch challenge). This prevents the program 
//    from selecting a word that is already underscores, ensuring progress is made 
//    every time the user presses enter.

class Program
{
    static void Main(string[] args)
    {
        // 1. Create a library of scriptures (Exceeding Requirements)
        List<Scripture> library = new()
        {
            new Scripture(new Reference("John", 3, 16), "For God so loved the world that he gave his only begotten Son"),
            new Scripture(new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all thine heart and lean not unto thine own understanding"),
            new Scripture(new Reference("Philippians", 4, 13), "I can do all things through Christ which strengtheneth me"),
            new Scripture(new Reference("Alma", 37, 35), "O remember my son and learn wisdom in thy youth"),
            new Scripture(new Reference("D&C", 18, 10), "Remember the worth of souls is great in the sight of God")
        };

        // 2. Randomly select one scripture from the library
        Random random = new();
        Scripture selectedScripture = library[random.Next(library.Count)];

        // 3. Main program loop
        while (true)
        {
            // Clear the console and display the scripture
            Console.Clear();
            Console.WriteLine(selectedScripture.GetDisplayText());
            Console.WriteLine();

            // Check if all words are hidden
            if (selectedScripture.IsCompletelyHidden())
            {
                Console.WriteLine("All words are now hidden. Well done!");
                break;
            }

            // Prompt user
            Console.WriteLine("Press enter to hide words or type 'quit' to finish:");
            string input = Console.ReadLine();

            // Handle user choice
            if (input.ToLower() == "quit")
            {
                break;
            }
            else
            {
                // Hide 3 words at a time
                selectedScripture.HideRandomWords(3);
            }
        }
    }
}

internal class Scripture
{
    private Reference reference;
    private string v;

    public Scripture(Reference reference, string v)
    {
        this.reference = reference;
        this.v = v;
    }

    internal bool GetDisplayText()
    {
        throw new NotImplementedException();
    }

    internal void HideRandomWords(int v)
    {
        throw new NotImplementedException();
    }

    internal bool IsCompletelyHidden()
    {
        throw new NotImplementedException();
    }
}