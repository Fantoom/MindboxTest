using ShapeLib.Exceptions;
using System.Collections.Immutable;
using System.Numerics;

namespace ShapeLib.Shapes;

public class Triangle<T> : ITriangle<T> where T : INumber<T>, IRootFunctions<T>
{
    public T SideA { get; }
    public T SideB { get; }
    public T SideC { get; }

    public Triangle(T sideA, T sideB, T sideC)
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

    public T GetArea()
    {
        var semiPerimeter = (SideA + SideB + SideC) / T.CreateChecked(2);
        // Heron's formula to calculate triangle area
        return T.Sqrt(semiPerimeter * (semiPerimeter - SideA) * (semiPerimeter - SideB) * (semiPerimeter - SideC));
    }

    public bool IsRightAngled()
    {
        // Check Pythagorean theorem for all triplets
        return IsPythagoreanTriple(SideA, SideB, SideC)
            || IsPythagoreanTriple(SideC, SideA, SideB)
            || IsPythagoreanTriple(SideB, SideC, SideA);
    }

    private static bool IsPythagoreanTriple(T sideA, T sideB, T hypotenuse)
    {
        // Pythagorean theorem
        return sideA * sideA + sideB * sideB == hypotenuse * hypotenuse;
    }

    public static bool CheckInequality(T sideA, T sideB, T sideC)
    {
        // Triangle inequality condition
        return sideA + sideB > sideC
               && sideA + sideC > sideB
               && sideC + sideB > sideA;
    }
}

