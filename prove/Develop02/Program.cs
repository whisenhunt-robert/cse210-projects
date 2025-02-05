using System;
using System.Collections.Generic;
using System.IO;

// Entry Class: Represents a single journal entry.
public class Entry
{
    // Properties representing the entry's prompt, response, date, and mood.
    public string Prompt { get; private set; }
    public string Response { get; private set; }
    public DateTime Date { get; set; }
    public string Mood { get; set; }

    // Constructor initializes the entry with a prompt, response, and mood.
    public Entry(string prompt, string response, string mood)
    {
        Prompt = prompt;
        Response = response;
        Date = DateTime.Now;  // Automatically sets the current date and time.
        Mood = mood;
    }

    // Provides a string representation of the entry, formatted for display.
    public override string ToString()
    {
        return $"{Date.ToShortDateString()} - {Prompt}\n{Response}\nMood: {Mood}\n";
    }
}

// Journal Class: Manages the collection of journal entries.
public class Journal
{
    // List to hold all the journal entries.
    private List<Entry> Entries { get; set; }

    // Constructor initializes an empty list for journal entries.
    public Journal()
    {
        Entries = new List<Entry>();
    }

    // Adds a new entry to the journal with a given prompt, response, and mood.
    public void AddEntry(string prompt, string response, string mood)
    {
        Entries.Add(new Entry(prompt, response, mood));
    }

    // Displays all entries in the journal, or a message if there are none.
    public void DisplayEntries()
    {
        if (Entries.Count == 0)
        {
            Console.WriteLine("No entries to display.");
            return;
        }

        // Loop through each entry and print it to the console.
        foreach (var entry in Entries)
        {
            Console.WriteLine(entry);
        }
    }

    // Saves all journal entries to a file with the given filename.
    public void SaveToFile(string filename)
    {
        using (var writer = new StreamWriter(filename))
        {
            // Write each entry to the file, separated by '|' characters.
            foreach (var entry in Entries)
            {
                writer.WriteLine($"{entry.Date.ToShortDateString()}|{entry.Prompt}|{entry.Response}|{entry.Mood}");
            }
        }
    }

    // Loads journal entries from a file and replaces the current entries.
    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename)) 
        {
            Console.WriteLine("File not found.");
            return;
        }

        // Clear existing entries before loading new ones.
        Entries.Clear();

        // Read each line from the file and create entries.
        foreach (var line in File.ReadLines(filename))
        {
            var parts = line.Split('|');
            if (parts.Length == 4)
            {
                var date = DateTime.Parse(parts[0]);
                var prompt = parts[1];
                var response = parts[2];
                var mood = parts[3];

                // Add the new entry with the loaded data.
                Entries.Add(new Entry(prompt, response, mood) { Date = date });
            }
        }
    }
}

// Program Class: Handles the user interaction, menu, and journal operations.
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

// Comment that explains how I exceeded the expectations.

// I wanted to be creative by having it prompt based off the current mood the user is in.
// This way it gives off kind of a theriputic feel when pondering the answer to the prompt.
// I plan to add more questions to each to expand, but felt three each was good enough for now.
// I feel this was a fun and creative addition adding to the journal entry. I'm proud of myself for getting it to work.

// Previous assignment commented out, cause I didn't know rather to keep it or delete it.
// class Program
//{
    //static void Main(string[] args)
    //{
        //Console.WriteLine("What is version control and why is it important?");
        //Console.WriteLine("Version control allows you to track and manage changes made to your codebase over time.");
        //Console.WriteLine("It keeps a record of every change you make so that you can go back to check previous versions of your code.");
        //Console.WriteLine("It is great for collaboration, working together with others to work on the same code.");
        //Console.WriteLine("The changes you and others make are merged and tracked, making it easy to know who made what changes and when.");
        //Console.WriteLine("For example, say you are in a team working on a web application, working on different features and such.");
        //Console.WriteLine("Version control ensures that the changes can be merged together safely without any issues or errors.");
        //Console.WriteLine("Like when you use Git, you can use the command 'git commit' to save the changes to a local repository.");
        //Console.WriteLine("You can also add a comment when you commit that tells what changes you made so that others know.");
        //Console.WriteLine("To do that, you can type 'git commit -m <comment here>' to add a comment.");
        //Console.WriteLine("To sum it up, version control is great for managing code changes as you work on it.");
        //Console.WriteLine("It helps prevent you from losing your hard work and makes collaborating with others easier.");
        //Console.WriteLine("The most common version control system is Git, which provides both local and remote repositories.");
        //Console.WriteLine("These repositories, you can push and pull changes that are made any time you wish using commands like 'git push' or 'git pull'.");
        //Console.WriteLine("It's a great way to save and share updates with those who you're working together with on the code.");
//    }
//}