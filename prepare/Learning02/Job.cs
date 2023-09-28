public class Job
{
    public string company;
    public string jobTitle;
    public int startYear;
    public int endYear;

    public void Display()
    {
        System.Console.WriteLine($"{jobTitle} ({company}) {startYear} - {endYear}");
    }
}