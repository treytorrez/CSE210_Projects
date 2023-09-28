using System;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1.jobTitle = "Software Engineer";
        job1.company = "Microsoft";
        job1.startYear = 2019;
        job1.endYear = 2022;

        Job job2 = new Job();
        job2.jobTitle = "iOS Developer";
        job2.company = "Apple";
        job1.startYear = 2022;
        job1.endYear = 2023;

        job1.Display();
        job2.Display();

        Resume resume1 = new Resume();
        resume1.name = "Allison Rose";

        resume1.jobs.Add(job1);
        resume1.jobs.Add(job2);    

        resume1.Display();
            
    }
}