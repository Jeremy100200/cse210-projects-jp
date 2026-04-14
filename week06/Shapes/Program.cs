using System;
using System.Collections.Generic;  
namespace Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Shape> shapes = new List<Shape>();

            shapes.Add(new Square("Red", 9));
            shapes.Add(new Rectangle("Blue", 4, 8));
            shapes.Add(new Circle("Green", 7));

            foreach (Shape shape in shapes)
            {
                Console.WriteLine($"Color: {shape.GetColored()}, Area: {shape.GetArea():F2}");
            }
        }
    }
}