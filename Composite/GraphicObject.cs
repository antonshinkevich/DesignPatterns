using System.Text;

namespace Composite;

public class GraphicObject
{
    public virtual string Name { get; set; } = "Group";
    public string Color;

    private readonly Lazy<List<GraphicObject>> _children = new Lazy<List<GraphicObject>>(
        () => new List<GraphicObject>()
    );
    public List<GraphicObject> Children => _children.Value;

    public override string ToString()
    {
        var sb = new StringBuilder();
        Print(sb, 0);
        return sb.ToString();
    }

    private void Print(StringBuilder sb, int depth)
    {
        sb.Append(new string('*', depth))
            .Append(string.IsNullOrWhiteSpace(Color) ? string.Empty : $"{Color} ")
            .AppendLine($"{Name}");
        foreach (var child in Children)
        {
            child.Print(sb, depth + 1);
        }
    }
}

public class Circle : GraphicObject
{
    public override string Name => "Circle";
}

public class Square : GraphicObject
{
    public override string Name => "Circle";
}
