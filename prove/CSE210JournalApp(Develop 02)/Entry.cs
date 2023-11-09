using System;
using System.Collections.Generic;


public class Entry
{
	public DateTime creationDate;
	public string filePath;
	public string[] entryContent;
	public string name;
	public List<string> promptList = new List<string>
	{
		"Who was the most interesting person I interacted with today?",
		"What was the best part of my day?",
		"How did I see the hand of the Lord in my life today?",
		"What was the strongest emotion I felt today?",
		"If I had one thing I could do over today, what would it be?"
	};


    public Entry()
	{
		creationDate = DateTime.Now;
		
		// Generate a random prompt
		Random random = new Random();
		int index = random.Next(promptList.Count);
		string prompt = promptList[index];


	}



}
