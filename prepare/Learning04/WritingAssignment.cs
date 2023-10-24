class WritingAssignment : Assignment
{
    private string _title;

    public WritingAssignment(string studentName, string topic, string title)
        :base(studentName, topic)
    {
        _topic = topic;
    }

    public string GetWritingInformation()
    {
        return $"{}{}";
    }
}
