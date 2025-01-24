using System;

class Program
{
    static void Main()
    {
        // Create a Resume instance for a person
        Resume resume = new Resume("Allison Rose");

        // Create job instances
        Job job1 = new Job("Software Engineer", "Microsoft", "Design and develop software applications.", 95000, 2019, 2022);
        Job job2 = new Job("Manager", "Apple", "Lead software engineering team.", 120000, 2022, 2023);

        // Add jobs to the resume
        resume.AddJob(job1);
        resume.AddJob(job2);

        // Display the resume with name and job details
        resume.Display();  // Call the new Display method from the Resume class
    }
}