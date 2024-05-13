using ShapeLib.Shapes;
using ShapeLib.Exceptions;
namespace ShapeLib.Tests;

public class TriangleTests
{
    [Fact]
    public void TriangleAreaCalculation()
    {
        Triangle triangle = new Triangle(3, 4, 5);
        Assert.Equal(6, triangle.GetArea(), 2);
    }

    [Fact]
    public void RightAngledTriangleCheck()
    {
        Triangle rightTriangle = new Triangle(3, 4, 5);
        Assert.True(rightTriangle.IsRightAngled());
    }

    [Fact]
    public void NonRightAngledTriangleCheck()
    {
        Triangle nonRightTriangle = new Triangle(2, 3, 4);
        Assert.False(nonRightTriangle.IsRightAngled());
    }

    [Fact]
    public void CheckInvalidInequality() 
    {
        Assert.False(Triangle.CheckInequality(1, 5, 8));
    }

    [Fact]
    public void CheckValidInequality()
    {
        Assert.True(Triangle.CheckInequality(4, 5, 6));
    }

    [Fact]
    public void TriangleWithNegativeSide()
    {
        Assert.Throws<InvalidShapeArgumentException>(() => new Triangle(2, -3, 4));
    }

    [Fact]
    public void TriangleWithInvalidSides()
    {
        Assert.Throws<TriangleInequalityViolation>(() => new Triangle(1, 1, 10));
    }

    [Theory]
    [InlineData(3.7, 4.6, 5.1)]
    public void TwoTrianglesAreaEquality(double a, double b, double c)
    {
        Triangle triangle1 = new Triangle(a, b, c);
        Triangle triangle2 = new Triangle(b, c, a);

        Assert.Equal(triangle1.GetArea(), triangle2.GetArea(), 2);
    }
}