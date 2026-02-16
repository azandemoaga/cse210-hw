using System;

public abstract class Shape
{
    private string _color;
    public Shape(string color) => _color = color;
    public string GetColor() => _color;
    public abstract double GetArea();
}

public class Square : Shape
{
    private double _side;
    public Square(string color, double side) : base(color) => _side = side;
    public override double GetArea() => _side * _side;
}

public class Rectangle : Shape
{
    private double _length;
    private double _width;
    public Rectangle(string color, double l, double w) : base(color) { _length = l; _width = w; }
    public override double GetArea() => _length * _width;
}

public class Circle : Shape
{
    private double _radius;
    public Circle(string color, double r) : base(color) => _radius = r;
    public override double GetArea() => Math.PI * Math.Pow(_radius, 2);
}