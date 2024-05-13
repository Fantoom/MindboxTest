namespace ShapeLib.Exceptions;

public class TriangleInequalityViolation : InvalidShapeArgumentException
{
    public TriangleInequalityViolation()
    {
    }

    public TriangleInequalityViolation(string? message) : base(message)
    {
    }

    public TriangleInequalityViolation(string? message, Exception? innerException) 
        : base(message, innerException)
    {
    }
}
