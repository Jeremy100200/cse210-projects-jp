using System;

namespace Shapes;

public class Square : Shapes.Shape
{
    private double _Side;
    public Square(string colored, double side) : base(colored)
    {
        _Side = side;
    }
    public double GetSide()
    {
        return _Side;
    }
    public void SetSide(double side)
    {
        _Side = side;
    }
    public override double GetArea()
    {
        return _Side * _Side;
    }
}







