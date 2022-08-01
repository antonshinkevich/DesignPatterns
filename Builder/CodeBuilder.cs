using System.Text;

namespace Builder;

public class CodeBuilder
{
    private const int IndentSize = 2;
    private readonly string _className;
    private readonly List<string> _fields;

    public CodeBuilder(string className)
    {
        _className = className;
        _fields = new List<string>();
    }

    public CodeBuilder AddField(string fieldName, string type)
    {
        var output = new string(' ', IndentSize) +
                     "public " + type + " " + fieldName + ";\n";
        _fields.Add(output);
        return this;
    }

    public override string ToString()
    {
        var sb = new StringBuilder(new string($"public class {_className}\n" + "{\n"));
        foreach (var field in _fields)
        {
            sb.Append(field);
        }

        sb.Append('}');
        return sb.ToString();
    }
}
