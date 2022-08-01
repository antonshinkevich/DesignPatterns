using System.Text;

namespace Builder;

public class HtmlElement
{
    public string Name, Text;
    public List<HtmlElement> Elements = new List<HtmlElement>();
    private const int indentSize = 2;

    public HtmlElement()
    {
    }

    public HtmlElement(string name, string text)
    {
        Name = name;
        Text = text;
    }

    private string ToStringImpl(int indent)
    {
        var sb = new StringBuilder();
        var i = new string(' ', indentSize * indent);
        sb.Append($"{i}<{Name}>\n");
        if (!string.IsNullOrWhiteSpace(Text))
        {
            sb.Append(new string(' ', indentSize * (indent + 1)));
            sb.Append(new string(Text));
            sb.Append("\n");
        }

        foreach (var element in Elements)
        {
            sb.Append(element.ToStringImpl(indent + 1));
        }

        sb.Append($"{i}</{Name}>\n");
        return sb.ToString();
    }

    public override string ToString()
    {
        return ToStringImpl(0);
    }

    // factory method
    public static HtmlBuilder Create(string name) => new(name);
}

public class HtmlBuilder
{
    private readonly string rootName;
    protected HtmlElement root = new HtmlElement();

    public HtmlBuilder(string rootName)
    {
        this.rootName = rootName;
        root.Name = rootName;
    }

    public HtmlBuilder AddChild(string childName, string childText)
    {
        var e = new HtmlElement(childName, childText);
        root.Elements.Add(e);
        return this;
    }

    public override string ToString() => root.ToString();

    public void Clear()
    {
        root = new HtmlElement { Name = rootName };
    }

    public HtmlElement Build() => root;

    public static implicit operator HtmlElement(HtmlBuilder builder)
    {
        return builder.root;
    }
}
