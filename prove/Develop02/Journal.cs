using System;
using System.Collections.Generic;
using System.IO;

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
