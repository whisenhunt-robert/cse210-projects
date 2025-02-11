using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var journal = new Journal();

        // Dictionary of mood-based prompts for personalized journaling.
        var moodPrompts = new Dictionary<string, List<string>>
        {
            { "Happy", new List<string>
                {
                    "What are three things that made you smile today?",
                    "Who made you feel happy today?",
                    "How did your happiness affect your actions today?"
                }
            },
            { "Sad", new List<string>
                {
                    "What made you feel down today?",
                    "What would help you feel better right now?",
                    "Is there something you can do to lift your spirits?"
                }
            },
            { "Anxious", new List<string>
                {
                    "What are you anxious about today?",
                    "What can you do right now to calm yourself?",
                    "Have you dealt with this type of anxiety before?"
                }
            },
            { "Excited", new List<string>
                {
                    "What are you most excited about right now?",
                    "How will you channel this excitement today?",
                    "What goals are you eager to achieve?"
                }
            },
            { "Other", new List<string>
                {
                    "What’s on your mind today?",
                    "How are you feeling in general today?",
                    "Describe the most significant event of your day."
                }
            }
        };

        // Main loop for menu-driven user interaction.
        while (true)
        {
            Console.WriteLine("Journal Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    // Prompt the user to choose their mood.
                    Random rand = new Random();

                    Console.WriteLine("How did you feel today?");
                    Console.WriteLine("1. Happy\n2. Sad\n3. Anxious\n4. Excited\n5. Other");
                    string moodChoice = Console.ReadLine();
                    string mood = moodChoice switch
                    {
                        "1" => "Happy",
                        "2" => "Sad",
                        "3" => "Anxious",
                        "4" => "Excited",
                        _ => "Other"
                    };

                    // Select a random prompt based on the user's mood.
                    var promptsForMood = moodPrompts[mood];
                    string prompt = promptsForMood[rand.Next(promptsForMood.Count)];

                    Console.WriteLine($"Prompt: {prompt}");
                    Console.Write("Your response: ");
                    string response = Console.ReadLine();

                    // Add the new entry to the journal with the chosen mood.
                    journal.AddEntry(prompt, response, mood);
                    Console.WriteLine($"Entry added with mood: {mood}");
                    break;

                case "2":
                    // Display all journal entries.
                    journal.DisplayEntries();
                    break;

                case "3":
                    // Prompt the user for a filename and save the journal to it.
                    Console.Write("Enter the filename to save the journal: ");
                    string saveFile = Console.ReadLine();
                    journal.SaveToFile(saveFile);
                    Console.WriteLine("Journal saved.");
                    break;

                case "4":
                    // Prompt the user for a filename and load the journal from it.
                    Console.Write("Enter the filename to load the journal from: ");
                    string loadFile = Console.ReadLine();
                    journal.LoadFromFile(loadFile);
                    Console.WriteLine("Journal loaded.");
                    break;

                case "5":
                    // Exit the program.
                    Console.WriteLine("Goodbye!");
                    return;

                default:
                    // Handle invalid menu choices.
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }

            Console.WriteLine(); // Blank line for separation.
        }
    }
}