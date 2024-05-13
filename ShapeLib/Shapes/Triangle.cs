using ShapeLib.Exceptions;

namespace ShapeLib.Shapes;

public class Triangle : ITriangle
{
    public double SideA { get; }
    public double SideB { get; }
    public double SideC { get; }

    public Triangle(double sideA, double sideB, double sideC)
    {
        InvalidShapeArgumentException.ThrowIfNegativeOrZero(sideA);
        InvalidShapeArgumentException.ThrowIfNegativeOrZero(sideB);
        InvalidShapeArgumentException.ThrowIfNegativeOrZero(sideC);

        // Checks that arguments do not violate triangle inequality 
        if (!CheckInequality(sideA, sideB, sideC))
            throw new TriangleInequalityViolation($"Invalid parameters. ({sideA}, {sideB}, {sideC})");

        SideA = sideA;
        SideB = sideB;
        SideC = sideC;
    }

    public double GetArea()
    {
        var semiPerimeter = (SideA + SideB + SideC) / 2.0;
        // Heron's formula to calculate triangle area
        return double.Sqrt(semiPerimeter * (semiPerimeter - SideA) * (semiPerimeter - SideB) * (semiPerimeter - SideC));
    }

    public bool IsRightAngled()
    {
        // Check Pythagorean theorem for all triplets
        return IsPythagoreanTriple(SideA, SideB, SideC)
            || IsPythagoreanTriple(SideC, SideA, SideB)
            || IsPythagoreanTriple(SideB, SideC, SideA);
    }

    private static bool IsPythagoreanTriple(double sideA, double sideB, double hypotenuse, double epsilon = 1e-6)
    {
        // Pythagorean theorem
        return Math.Abs(sideA * sideA + sideB * sideB - hypotenuse * hypotenuse) < epsilon;
    }

    public static bool CheckInequality(double sideA, double sideB, double sideC)
    {
        // Triangle inequality condition
        return sideA + sideB > sideC
               && sideA + sideC > sideB
               && sideC + sideB > sideA;
    }
}

