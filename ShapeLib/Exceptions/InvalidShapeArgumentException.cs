using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace ShapeLib.Exceptions;

public class InvalidShapeArgumentException : Exception
{
    public InvalidShapeArgumentException()
    {
    }

    public InvalidShapeArgumentException(string? message) : base(message)
    {
    }

    public InvalidShapeArgumentException(string? message, Exception? innerException) 
        : base(message, innerException)
    {
    }

    public static void ThrowIfNegativeOrZero<T>(T value, 
        [CallerArgumentExpression("value")] string? comparandExpression = null
        ) where T : INumber<T>
    {
        if (T.IsZero(value) || T.IsNegative(value))
            throw new InvalidShapeArgumentException($"{nameof(comparandExpression)} is negative or zero");
    }
}
