namespace ShapeLib.Shapes;

public interface ITriangle : IShapeArea
{
    double SideA { get; }
    double SideB { get; }
    double SideC { get; }
    bool IsRightAngled();
}