using System;
namespace prepare05
{
public class Shape
{
    private string _color;
    
    public Shape(string color)
    {
        _color = color;
    }
    public string GetColor()
    {
        return _color;
    }

    public void SetColor(string UserInput)
    {
        string userInput1 = UserInput;
        Console.WriteLine($"The chosen color is: {userInput1}");
    }

    public virtual double GetArea()
    {
        return -1;
    }
   
}
}