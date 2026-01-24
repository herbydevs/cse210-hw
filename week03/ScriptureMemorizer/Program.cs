using System;

class Program
{
    static void Main(string[] args)
    {
        // 1. Create the Reference
        Reference reference = new Reference("Proverbs", 3, 5, 6);
        
        // 2. Create the Scripture object (Pass the reference and the text)
        Scripture scripture = new Scripture(reference, "Trust in the Lord with all thine heart and lean not unto thine own understanding");

        // 3. Start the main loop
        while (true)
        {
            // Clear the console to make it look like an animation
            Console.Clear();

            // Display the scripture (Reference + Text)
            Console.WriteLine(scripture.GetDisplayText());

            Console.WriteLine("");
            Console.WriteLine("Press Enter to continue or type 'quit' to finish:");
            string input = Console.ReadLine();

            // Check if the user wants to quit
            if (input == "quit")
            {
                break;
            }

            // Check if the scripture is already completely hidden
            if (scripture.IsCompletelyHidden())
            {
                break;
            }

            // Hide a few random words (e.g., 3 words at a time)
            scripture.HideRandomWords(3);
        }
    }
}