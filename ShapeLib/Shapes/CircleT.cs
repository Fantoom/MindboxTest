using ShapeLib.Exceptions;
using System.Numerics;

namespace ShapeLib.Shapes;

public class Circle<T> : ICircle<T> where T : INumber<T>
{
    public T Radius { get; }

    public Circle(T radius)
    {
        InvalidShapeArgumentException.ThrowIfNegativeOrZero(radius);
        Radius = radius;
    }
    public T GetArea()
    {
        return T.CreateSaturating(double.Pi) * Radius * Radius;
    }
}
