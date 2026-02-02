public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string> {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can.") {}

    public void Run()
    {
        DisplayStartingMessage();
        Random rnd = new Random();

        Console.WriteLine("\nList as many items as you can regarding the following prompt:");
        Console.WriteLine($" --- {_prompts[rnd.Next(_prompts.Count)]} ---");
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.WriteLine();

        int count = 0;
        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            Console.ReadLine();
            count++;
        }

        Console.WriteLine($"List complete! You listed {count} items.");
        DisplayEndingMessage();
    }
}