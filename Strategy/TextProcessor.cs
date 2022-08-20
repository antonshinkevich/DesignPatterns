using System.Text;

namespace Strategy;

public enum OutputFormat
{
    Markdown,
    Html
}

class MarkdownListStrategy : IListStrategy
{
    public void Start(StringBuilder sb)
    {
    }

    public void End(StringBuilder sb)
    {
    }

    public void AddListItem(StringBuilder sb, string item)
    {
        sb.AppendLine($" * {item}");
    }
}

class HtmlListStrategy : IListStrategy
{
    public void Start(StringBuilder sb)
    {
        sb.AppendLine("<ul>");
    }

    public void End(StringBuilder sb)
    {
        sb.AppendLine("</ul>");
    }

    public void AddListItem(StringBuilder sb, string item)
    {
        sb.AppendLine($"  <li>{item}</li>");
    }
}

public interface IListStrategy
{
    void Start(StringBuilder sb);
    void End(StringBuilder sb);
    void AddListItem(StringBuilder sb, string item);
}

public class TextProcessor
{
    private StringBuilder sb = new StringBuilder();
    private IListStrategy listStrategy;

    public void SetOutFormat(OutputFormat format)
    {
        switch (format)
        {
            case OutputFormat.Markdown:
                listStrategy = new MarkdownListStrategy();
                break;
            case OutputFormat.Html:
                listStrategy = new HtmlListStrategy();
                break;
        }
    }

    public StringBuilder Clear()
    {
        return sb.Clear();
    }

    public override string ToString() => sb.ToString();

    public void AppendList(IEnumerable<string> items)
    {
        listStrategy.Start(sb);
        foreach (string item in items)
        {
            listStrategy.AddListItem(sb, item);
        }

        listStrategy.End(sb);
    }
}

