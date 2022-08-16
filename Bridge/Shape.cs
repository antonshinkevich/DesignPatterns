public interface IRenderer
{
    void RenderCircle(float radius);
}

public class VectorRenderer : IRenderer
{
    public void RenderCircle(float radius)
    {
        Console.WriteLine($"Drawing circle of radius {radius} by {nameof(VectorRenderer)}");
    }
}

public class RasterRenderer : IRenderer
{
    public void RenderCircle(float radius)
    {
        Console.WriteLine($"Drawing pixels for circle of radius {radius} by {nameof(RasterRenderer)}");
    }
}

public abstract class Shape
{
    protected IRenderer renderer;

    protected Shape(IRenderer renderer)
    {
        this.renderer = renderer;
    }

    public abstract void Draw();
    public abstract void Resize(float factor);
}

public class Circle : Shape
{

    private float radius;

    public Circle(IRenderer renderer, float radius) : base(renderer)
    {
        this.radius = radius;
    }

    public override void Draw()
    {
        renderer.RenderCircle(radius);
    }

    public override void Resize(float factor)
    {
        radius *= factor;
    }
}
