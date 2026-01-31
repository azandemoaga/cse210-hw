using System;
using System.Collections.Generic;

// --- MAIN PROGRAM ---
class Program
{
    static void Main(string[] args)
    {
        // 1. Create 3-4 Video objects
        Video video1 = new Video("How to Bake Bread", "The Baker", 600);
        Video video2 = new Video("C# Tutorial for Beginners", "Code Academy", 1200);
        Video video3 = new Video("Top 10 Travel Destinations", "World Explorer", 900);

        // 2. Add 3 comments to each video
        video1.AddComment(new Comment("Alice", "Great recipe, thanks!"));
        video1.AddComment(new Comment("Bob", "Mine didn't rise, help!"));
        video1.AddComment(new Comment("Charlie", "Best bread I've ever made."));

        video2.AddComment(new Comment("Dave", "Finally, a tutorial that makes sense."));
        video2.AddComment(new Comment("Eve", "Can you explain inheritance next?"));
        video2.AddComment(new Comment("Frank", "Great production quality."));

        video3.AddComment(new Comment("Grace", "Adding Switzerland to my list!"));
        video3.AddComment(new Comment("Heidi", "I've been to number 4, it's amazing."));
        video3.AddComment(new Comment("Ivan", "What camera did you use to film this?"));

        // 3. Put videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // 4. Iterate through the list and display details
        foreach (Video video in videos)
        {
            video.DisplayVideoInfo();
        }
    }
}

// --- COMMENT CLASS ---
public class Comment
{
    private string _name;
    private string _text;

    public Comment(string name, string text)
    {
        _name = name;
        _text = text;
    }

    public string GetCommentDisplay()
    {
        return $"{_name}: {_text}";
    }
}

// --- VIDEO CLASS ---
public class Video
{
    private string _title;
    private string _author;
    private int _length; // in seconds
    private List<Comment> _comments = new List<Comment>();

    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return _comments.Count;
    }

    public void DisplayVideoInfo()
    {
        Console.WriteLine("-------------------------------------------");
        Console.WriteLine($"Title: {_title}");
        Console.WriteLine($"Author: {_author}");
        Console.WriteLine($"Length: {_length} seconds");
        Console.WriteLine($"Number of Comments: {GetNumberOfComments()}");
        Console.WriteLine("\nComments:");
        
        foreach (Comment comment in _comments)
        {
            Console.WriteLine($"  - {comment.GetCommentDisplay()}");
        }
        Console.WriteLine();
    }
}
