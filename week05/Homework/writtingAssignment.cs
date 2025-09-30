using System;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

public class WrittingAssignment : Assignment
{
    private string _title;
    public WrittingAssignment(string studentName, string topic, string string_title)
    : base(studentName, topic)
    {
        _title = string_title;
    }
    public string GetwritingInformation()
    {
        string studentName = GetStudentName();

        return $"{_title} by {studentName}";  
    }
}