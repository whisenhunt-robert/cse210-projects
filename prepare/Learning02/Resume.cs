using System;
using System.Collections.Generic;  // This is needed for the List<T> type

public class Resume
{
    // Member variables
    private string _name;              // To store the person's name
    private List<Job> _jobs;           // List of Job objects

    // Constructor to initialize the Resume object
    public Resume(string name)
    {
        _name = name;
        _jobs = new List<Job>();  // Initialize the jobs list when the Resume is created
    }

    // Properties to access private fields
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public List<Job> Jobs
    {
        get { return _jobs; }
        set { _jobs = value; }
    }

    // Method to add a job to the resume
    public void AddJob(Job job)
    {
        _jobs.Add(job);
    }

    // Method to display the resume details
    public void Display()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");
        foreach (var job in _jobs)
        {
            job.DisplayJobDetails();  // Call the DisplayJobDetails method from the Job class
        }
    }
}