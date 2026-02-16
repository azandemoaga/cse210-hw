using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Shape> shapes = new List<Shape>();

        shapes.Add(new Square("Red", 4));
        shapes.Add(new Rectangle("Blue", 5, 10));
        shapes.Add(new Circle("Green", 3));

        foreach (Shape s in shapes)
        {
            Console.WriteLine($"Color: {s.GetColor()}, Area: {s.GetArea():0.00}");
        }
    }
}