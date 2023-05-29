using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment student1 = new Assignment("Samuel Bennett", "Multiplication");
        string StudentName = student1.GetStudentName();
        string topic = student1.GetTopic();
        Console.WriteLine(StudentName);
        Console.WriteLine(topic);
        Console.WriteLine();

        Math mathwork = new Math("Roberto Rodriguez", "Fractions", "7.3", "8-19");
        Console.WriteLine(mathwork.GetStudentTopic());
        Console.WriteLine(mathwork.GetHomeworkList());

        Console.WriteLine();

        Writing writingWork = new Writing("Mary Waters", "European History", "The Causes of World War II");
        Console.WriteLine(writingWork.GetStudentTopic());
        Console.WriteLine(writingWork.GetWritingInformation());
    }
}