using ShapeLib.Exceptions;
using ShapeLib.Shapes;

namespace ShapeLib.Tests;

public class CircleTests
{
    [Fact]
    public void CircleAreaCalculation()
    {
        var circle = new Circle(5);
        Assert.Equal(78.54, circle.GetArea(), 2);
    }

    [Fact]
    public void CircleWithZeroRadius()
    {
        Assert.Throws<InvalidShapeArgumentException>(() => new Circle(0));
    }
    [Fact]
    public void CircleWithNegativeRadius()
    {
        Assert.Throws<InvalidShapeArgumentException>(() => new Circle(-5));
    }
}
