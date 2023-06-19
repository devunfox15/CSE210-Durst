using System;
namespace prepare05
{
class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();
        // this will input into the shape list the color and length of a side of the square
        Square shape1 = new Square("Red", 3);
        shapes.Add(shape1);
        // this will input into the shape list the color and length and width of a rectangle
        Rectangle shape2 = new Rectangle("Blue", 4, 5);
        shapes.Add(shape2);

        Circle shape3 = new Circle("Green", 6);
        shapes.Add(shape3);
        // this loop will loop through all the shapes in the list and print them out with the distingusih area
        foreach (Shape s in shapes)
        {
            string color = s.GetColor();
            double area = s.GetArea();
            Console.WriteLine($"The {color} shape has an area of {area}.");
        }
    }
}
}