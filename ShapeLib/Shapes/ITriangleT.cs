namespace ShapeLib.Shapes;

public interface ITriangle<T> : IShapeArea<T>
{
    T SideA { get; }
    T SideB { get; }
    T SideC { get; }
    bool IsRightAngled();
}