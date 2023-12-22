using System.Numerics;

namespace ShapeLib.Shapes;

public interface ICircle<T> : IShapeArea<T>
{
    T Radius { get; }
}