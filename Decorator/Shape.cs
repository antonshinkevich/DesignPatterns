public abstract class Shape
{
    public virtual string AsString => string.Empty;
}

public sealed class Circle : Shape
{
    private float radius;

    public Circle()
    {
        
    }
    public Circle(float radius)
    {
        this.radius = radius;
    }

    public void Resize(float factor)
    {
        radius *= factor;
    }

    public override string AsString => $"A circle of radius {radius}";
}

public class ColorShape : Shape
{
    private Shape shape;
    private string color;

    public ColorShape(Shape shape, string color)
    {
        this.shape = shape;
        this.color = color;
    }

    public override string AsString => $"{shape.AsString} has the color {color}";
}

public class TransparentShape : Shape
{
    private Shape shape;
    private float transparency;

    public TransparentShape(Shape shape, float transparency)
    {
        this.shape = shape;
        this.transparency = transparency;
    }

    public override string AsString => $"{shape.AsString} has " +
                                       $"{transparency * 100.0f}% transparency";
}
