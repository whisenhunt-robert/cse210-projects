using System;

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
