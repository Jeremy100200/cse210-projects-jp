public class Assignment
{
    //private member variables
    private string _studentName;
    private string _topic;

    //constructor
    public Assignment(string studentName, string topic)
    {
        _studentName = studentName;
        _topic = topic;
    }       
    //public method to get summary of the assignment
    public string GetSummary()
    {
        return $"{_studentName} -- {_topic}.";
    }
}