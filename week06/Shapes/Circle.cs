using System;

namespace Shapes
{
    internal class Circle : Shape
    {
        private double _Radius;
        public Circle(string color, double radius) : base(color)
        {
            _Radius = radius;
        }
        public double GetRadius()
        {
            return _Radius;
        }
        public void SetRadius(double radius)
        {
            _Radius = radius;
        }
        public override double GetArea()
        {
            return Math.PI * _Radius * _Radius;
        }
    }
}
