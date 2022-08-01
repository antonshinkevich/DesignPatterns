using System.Text;

namespace Builder;

public class CodeBuilder
{
    private const int IndentSize = 2;
    private readonly List<Field> _fields;
    private readonly CodeClass _codeClass;

    public CodeBuilder(string className)
    {
        _codeClass = new CodeClass(className);
        _fields = new List<Field>();
    }

    public CodeBuilder AddField(string fieldName, string type)
    {
        var field = new Field(fieldName, type);
        _fields.Add(field);
        return this;
    }

    public override string ToString()
    {
        var sb = new StringBuilder(_codeClass.ToString());
        sb.AppendLine("\n{");
        foreach (var field in _fields)
        {
            sb.Append(' ', IndentSize);
            sb.AppendLine(field.ToString());
        }

        sb.Append('}');
        return sb.ToString();
    }

    class CodeClass
    {
        private readonly string _className;

        public CodeClass(string className)
        {
            _className = className;
        }

        public override string ToString()
        {
            return "public class " + _className;
        }
    }

    class Field
    {
        private readonly string _type, _fieldName;

        public Field(string name, string type)
        {
            _fieldName = name;
            _type = type;
        }

        public override string ToString()
        {
            return "public " + _type + ' ' + _fieldName + ';';
        }
    }
}
