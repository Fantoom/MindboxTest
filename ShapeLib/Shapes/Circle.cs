using ShapeLib.Exceptions;
using System.Numerics;

namespace ShapeLib.Shapes;

public class Circle : ICircle
{
    public double Radius { get; }

    public Circle(double radius)
    {
        InvalidShapeArgumentException.ThrowIfNegativeOrZero(radius);
        Radius = radius;
    }
    public double GetArea()
    {
        return double.Pi * Radius * Radius;
    }
}
