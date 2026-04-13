public class MathAssignment : Assignment
{
    //private member variables
     private string _studentName;
    private string _topic;
    private string _textbookSection;
    private string _problems;
    //constructor
    public MathAssignment(string studentName, string topic, string textbookSection, string problems) : base(studentName, topic)
    {
        _studentName = studentName;
        _topic = topic;
        _textbookSection = textbookSection;
        _problems = problems;
    }
    //public method to get summary of the math assignment
    public string GetHomeworkList()
    {
        return $"{GetSummary()} Section {_textbookSection} Problems {_problems }.";
    }
}