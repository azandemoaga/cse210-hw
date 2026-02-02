using System;
using System.Collections.Generic;

// EXCEEDING REQUIREMENTS:
// 1. Added a Scripture Library: The program contains a list of scriptures and 
//    randomly selects one for the user to practice, rather than always showing the same one.
// 2. Enhanced Word Hiding: The program specifically tracks which words are visible 
//    and only hides those, ensuring that it doesn't "pick" a word that is already hidden.

class Program
{
    static void Main(string[] args)
    {
        // Library of scriptures for the "Exceeding Requirements" part
        List<Scripture> library = new List<Scripture>
        {
            new Scripture(new Reference("John", 3, 16), "For God so loved the world that he gave his only begotten Son"),
            new Scripture(new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all thine heart and lean not unto thine own understanding"),
            new Scripture(new Reference("Alma", 37, 35), "O remember my son and learn wisdom in thy youth"),
            new Scripture(new Reference("D&C", 18, 10), "Remember the worth of souls is great in the sight of God")
        };

        // Pick a random scripture
        Random random = new Random();
        Scripture scripture = library[random.Next(library.Count)];

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();

            if (scripture.IsCompletelyHidden())
            {
                break;
            }

            Console.WriteLine("Press enter to hide words or type 'quit' to finish:");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords(3);
        }

        Console.WriteLine("\nGood job! You have hidden the entire scripture.");
    }
}
