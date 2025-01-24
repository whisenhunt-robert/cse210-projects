using System;

public class Job
{
    // Member variables (fields)
    private string _jobTitle;
    private string _companyName;
    private string _jobDescription;
    private decimal _salary;
    private int _startYear;
    private int _endYear;

    // Constructor to initialize the Job object
    public Job(string jobTitle, string companyName, string jobDescription, decimal salary, int startYear, int endYear)
    {
        _jobTitle = jobTitle;
        _companyName = companyName;
        _jobDescription = jobDescription;
        _salary = salary;
        _startYear = startYear;
        _endYear = endYear;
    }

    // Properties to access private fields (optional)
    public string JobTitle
    {
        get { return _jobTitle; }
        set { _jobTitle = value; }
    }

    public string CompanyName
    {
        get { return _companyName; }
        set { _companyName = value; }
    }

    public string JobDescription
    {
        get { return _jobDescription; }
        set { _jobDescription = value; }
    }

    public decimal Salary
    {
        get { return _salary; }
        set { _salary = value; }
    }

    public int StartYear
    {
        get { return _startYear; }
        set { _startYear = value; }
    }

    public int EndYear
    {
        get { return _endYear; }
        set { _endYear = value; }
    }

    // Method to display job details in the desired format
    public void DisplayJobDetails()
    {
        Console.WriteLine($"{_jobTitle} ({_companyName}) {_startYear}-{_endYear}");
    }
}